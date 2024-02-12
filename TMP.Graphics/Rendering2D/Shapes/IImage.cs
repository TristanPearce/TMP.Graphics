using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public interface IImage : IShape
    {

        int ResolutionX { get; }
        int ResolutionY { get; }

    }
}
