using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering
{
    public struct Line
    {
        public Vector2 Start;
        public Vector2 End;

        public Line(Vector2 start, Vector2 end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
