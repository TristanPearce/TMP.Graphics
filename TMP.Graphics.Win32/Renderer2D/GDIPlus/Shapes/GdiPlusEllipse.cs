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
            get; 
            set; 
        }

        public float RadiusX 
        { 
            get; 
            set; 
        }
        
        public float RadiusY 
        { 
            get; 
            set; 
        }

        public System.Drawing.Rectangle CalculateBounds() 
        {
            return new System.Drawing.Rectangle() { Location = new Point((int)X, (int)Y), Size = new Size((int)RadiusX, (int)RadiusY) };
        }
    }
}
