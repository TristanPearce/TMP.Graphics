using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMP.Graphics.Rendering2D;

namespace TMP.Graphics.Win32
{
    internal class GDIPlusRenderer2D : IRenderer2D
    {
        public Fill Fill { get; set; }
        public Outline Outline { get; set; }

        public void Clear(Colour colour)
        {
            throw new NotImplementedException();
        }

        public void Draw(Line line)
        {
            throw new NotImplementedException();
        }

        public void Draw(Ellipse ellipse)
        {
            throw new NotImplementedException();
        }

        public void Draw(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void Draw(Polygon polygon)
        {
            throw new NotImplementedException();
        }

        public void Draw(Path path)
        {
            throw new NotImplementedException();
        }

        public void Draw(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
