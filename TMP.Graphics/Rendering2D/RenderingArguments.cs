using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public class RenderingArguments
    {
        public IRenderer2D Renderer { get; init; }
        public IGraphicsFactory GraphicsFactory { get; init; }
    }
}
