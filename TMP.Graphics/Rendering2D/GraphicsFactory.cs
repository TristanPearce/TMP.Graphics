using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public class GraphicsFactory : IGraphicsFactory
    {
        public virtual IEllipse CreateEllipse()
        {
            return new Ellipse();
        }

        public virtual IImage CreateImage()
        {
            return new Image(); 
        }

        public virtual ILine CreateLine()
        {
            return new Line();
        }

        public virtual IPath CreatePath()
        {
            return new Path();
        }

        public virtual IPolygon CreatePolygon()
        {
            return new Polygon();
        }

        public virtual IRectangle CreateRectangle()
        {
            return new Rectangle();
        }
    }
}
