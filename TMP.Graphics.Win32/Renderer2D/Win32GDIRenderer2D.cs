using System.Numerics;
using System.Runtime.CompilerServices;
using TMP.Graphics.Rendering;
using TMP.Graphics.Win32.Window;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace TMP.Graphics.Win32.Renderer2D
{
    internal class Win32GDIRenderer2D : IRenderer2D
    {

        private Win32Window _window;
        private HDC _hdc;
        private PAINTSTRUCT _ps;

        private HBRUSH _hbrush;
        private Fill _fill;
        public Fill Fill
        {
            get => _fill;
            set
            {
                DeleteObject(_hbrush);
                var colorRef = new COLORREF(value.Colour.Red, value.Colour.Green, value.Colour.Blue);
                _hbrush = CreateSolidBrush(colorRef);
                _ = SelectObject(_hdc, _hbrush);

                _fill = value;
            }
        }

        private HPEN _hpen;
        private Outline _outline;
        public Outline Outline
        {
            get => _outline;
            set
            {
                DeleteObject(_hpen);
                var colorRef = new COLORREF(value.Colour.Red, value.Colour.Green, value.Colour.Blue);
                _hpen = CreatePen((uint)PenStyle.PS_SOLID, (int)value.Thickness, colorRef);  // Red pen
                _ = SelectObject(_hdc, _hpen);

                _outline = value;
            }
        }

        public Win32GDIRenderer2D(HDC hardwareDeviceContext, PAINTSTRUCT ps)
        {
            _hdc = hardwareDeviceContext;
            _ps = ps;
        }

        public void Draw(Line line)
        {
            if (_hdc == HDC.NULL)
                throw new InvalidOperationException("Can only call draw functions inside OnPaint event.");

            HPEN hPen = CreatePen((uint)PenStyle.PS_SOLID, 2, new COLORREF(255, 0, 0));  // Red pen
            HGDIOBJ hOldPen = SelectObject(_hdc, hPen);

            MoveToEx(_hdc, (int)line.Start.X, (int)line.Start.Y, out POINT p);  // Move to starting point
            LineTo(_hdc, (int)line.End.X, (int)line.End.Y);           // Draw a line to ending point

            SelectObject(_hdc, hOldPen);
            DeleteObject(hPen);
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
            throw new NotImplementedException();
        }

        public void Draw(Image image)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
