using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering
{
    public interface IRenderer2D
    {
        Color FillColor { get; set; }
        Color OutlineColor { get; set; }

        float OutlineThickness { get; set; }

        void Draw(Line line);
        void Draw(Ellipse ellipse);
        void Draw(Rectangle rectangle);
        void Draw(Polygon polygon);
        void Draw(Image image);
    }
}
