using System;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using TMP.Graphics.Rendering2D;
using TMP.Graphics.Win32.Window;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace TMP.Graphics.Win32
{
    internal class Win32GDIRenderer2D : IRenderer2D
    {
        private Win32Window _window;

        private HDC _hdc;
        private PAINTSTRUCT _ps;

        private HBRUSH _hbrush = HBRUSH.NULL;
        private Fill _fill;
        public Fill Fill
        {
            get => _fill;
            set
            {
                SetBrush(value);
                _fill = value;
            }
        }

        private HPEN _hpen = HPEN.NULL;
        private Outline _outline;
        public Outline Outline
        {
            get => _outline;
            set
            {
                SetPen(value);
                _outline = value;
            }
        }

        public Win32GDIRenderer2D(HDC hDC, Win32Window window)
        {
            _hdc = hDC;

            _window = window;
        }

        private void SetBrush(Fill fill)
        {
            if(_hbrush != HBRUSH.NULL)
                DeleteObject(_hbrush);
            var colorRef = new COLORREF(fill.Colour.Red, fill.Colour.Green, fill.Colour.Blue);
            _hbrush = CreateSolidBrush(colorRef);
            _ = SelectObject(_hdc, _hbrush);
        }

        private void SetPen(Outline outline)
        {
            if (_hpen != HPEN.NULL)
                DeleteObject(_hpen);
            var colorRef = new COLORREF(outline.Colour.Red, outline.Colour.Green, outline.Colour.Blue);
            _hpen = CreatePen((uint)PenStyle.PS_SOLID, (int)outline.Thickness, colorRef);
            _ = SelectObject(_hdc, _hpen);
        }

        public void Draw(Line line)
        {
            MoveToEx(_hdc, (int)line.Start.X, (int)line.Start.Y, out POINT p);  // Move to starting point
            LineTo(_hdc, (int)line.End.X, (int)line.End.Y);           // Draw a line to ending point
        }

        public void Draw(Ellipse ellipse)
        {
            Ellipse(_hdc, (int)ellipse.Left, (int)ellipse.Top, (int)ellipse.Right, (int)ellipse.Bottom);
        }

        public void Draw(Rectangle rectangle)
        {
            Gdi32.Rectangle(_hdc, (int)rectangle.Left, (int)rectangle.Top, (int)rectangle.Right, (int)rectangle.Bottom);
        }

        public void Draw(Polygon polygon)
        {
            var points = polygon.Select(x => new POINT((int)x.X, (int)x.Y)).ToArray();

            Gdi32.Polygon(_hdc, points, points.Length);
        }

        public void Draw(Image image)
        {
            throw new NotImplementedException();
        }

        public void Draw(Path path)
        {
            throw new NotImplementedException();
        }

        public void Clear(Colour colour)
        {
            Fill oldFill = Fill;
            Outline oldOutline = Outline;

            Fill = new Fill() { Colour = colour };
            Outline= new Outline() { Colour = colour, Thickness = 0 };

            User32.GetClientRect((SafeHWND)_window, out RECT clientRect);
            Gdi32.Rectangle(_ps.hdc, clientRect.left, clientRect.top, clientRect.right, clientRect.bottom);

            Fill = oldFill; 
            Outline = oldOutline;
        }
    }
}
