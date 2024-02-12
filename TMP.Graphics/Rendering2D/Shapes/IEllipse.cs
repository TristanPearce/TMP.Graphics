using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public interface IEllipse : IShape
    {
        float X { get; set; }
        float Y { get; set; }
        float RadiusX { get; set; }
        float RadiusY { get; set; }
    }
}
