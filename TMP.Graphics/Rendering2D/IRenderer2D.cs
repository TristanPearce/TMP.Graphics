using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public interface IRenderer2D
    {
        Fill Fill { get; set; }
        Outline Outline { get; set; }

        void Draw(ILine line);
        void Draw(IEllipse ellipse);
        void Draw(IRectangle rectangle);
        void Draw(IPolygon polygon);
        void Draw(IPath path);
        void Draw(IImage image);

        void Clear(Colour colour);
    }
}
