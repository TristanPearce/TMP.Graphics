using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMP.Graphics.Rendering2D;
using TMP.Graphics.Win32.Window;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

using Drawing = System.Drawing;

namespace TMP.Graphics.Win32
{
    internal sealed class GDIPlusRenderer2D : IRenderer2D
    {

        private Brush _brush;
        private Fill _fill;
        public Fill Fill 
        { 
            get {  return _fill; }
            set
            {
                _brush?.Dispose();
                Color brushColor = CastColour(value.Colour);
                _brush = new SolidBrush(brushColor);
                _fill = value;
            }
        }

        private Pen _pen;
        private Outline _outline;
        public Outline Outline
        {
            get { return _outline; }
            set
            {
                _pen?.Dispose();
                Color penColor = CastColour(value.Colour);
                _pen = new Pen(penColor, value.Thickness);
                _outline = value;
            }
        } 


        private System.Drawing.Graphics _graphics;

        public GDIPlusRenderer2D(HDC hdc) 
        {
            _graphics = System.Drawing.Graphics.FromHdc((IntPtr)hdc);

            Fill = new Fill() { Colour = new Colour() { Red = 255, Alpha = 255} };
            Outline = new Outline() { Colour = new Colour() { Alpha = 255 }, Thickness = 1 };
        }

        private static System.Drawing.Color CastColour(Colour colour)
        {
            return System.Drawing.Color.FromArgb(colour.Alpha, colour.Red, colour.Green, colour.Blue);
        }

        public void Clear(Colour colour)
        {
            _graphics.Clear(CastColour(colour));
        }

        public void Draw(Line line)
        {
            Point point1 = new Point((int)line.Start.X, (int)line.Start.Y);
            Point point2 = new Point((int)line.End.X, (int)line.End.Y);
            _graphics.DrawLine(_pen, point1, point2);
        }

        public void Draw(Ellipse ellipse)
        {
            Drawing.Rectangle ellipseBounds = new Drawing.Rectangle((int)ellipse.X, (int)ellipse.Y, (int)ellipse.Width, (int)ellipse.Height);
            _graphics.FillEllipse(_brush, ellipseBounds);
            _graphics.DrawEllipse(_pen, ellipseBounds);
        }

        public void Draw(TMP.Graphics.Rendering2D.Rectangle rectangle)
        {
            Drawing.Rectangle rectBounds = new Drawing.Rectangle((int)rectangle.X, (int)rectangle.Y, (int)rectangle.Width, (int)rectangle.Height);
            _graphics.FillRectangle(_brush, rectBounds);
            _graphics.DrawRectangle(_pen, rectBounds);
        }

        public void Draw(Polygon polygon)
        {
            var points = polygon.Select(p => new PointF(p.X, p.Y)).ToArray();
            _graphics.FillPolygon(_brush, points);
            _graphics.DrawPolygon(_pen, points);
        }

        public void Draw(Path path)
        {
            throw new NotImplementedException();
        }

        public void Draw(Rendering2D.Image image)
        {
            throw new NotImplementedException();
        }
    }
}
