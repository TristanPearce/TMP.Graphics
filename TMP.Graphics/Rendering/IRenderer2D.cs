using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering
{
    public interface IRenderer2D
    {
        Fill Fill { get; set; }
        Outline Outline { get; set; }

        void Draw(Line line);
        void Draw(Ellipse ellipse);
        void Draw(Rectangle rectangle);
        void Draw(Polygon polygon);
        void Draw(Path path);
        void Draw(Image image);

        void Clear(Colour colour);
    }
}
