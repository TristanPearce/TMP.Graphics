using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMP.Graphics.Rendering2D;

namespace TMP.Graphics.Win32.Renderer2D.GDIPlus.Shapes
{
    public class GdiPlusEllipse : IEllipse
    {
        private System.Drawing.RectangleF _bounds;

        public float X 
        {
            get => _bounds.X;
            set => _bounds.X = value; 
        }

        public float Y 
        {
            get => _bounds.Y;
            set => _bounds.Y = value;
        }

        public float RadiusX 
        { 
            get => _bounds.Width / 2;
            set => _bounds.Width = value * 2;
        }
        
        public float RadiusY 
        {
            get => _bounds.Height / 2;
            set => _bounds.Height = value * 2;
        }

        public System.Drawing.Rectangle CalculateBounds() 
        {
            return new System.Drawing.Rectangle() { Location = new Point((int)X, (int)Y), Size = new Size((int)RadiusX, (int)RadiusY) };
        }
    }
}
