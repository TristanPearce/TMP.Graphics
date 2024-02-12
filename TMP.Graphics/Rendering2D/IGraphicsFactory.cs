using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public interface IGraphicsFactory
    {
        public IEllipse CreateEllipse();
        public IImage CreateImage();
        public ILine CreateLine();
        public IPath CreatePath();
        public IPolygon CreatePolygon();
        public IRectangle CreateRectangle();
    }
}
