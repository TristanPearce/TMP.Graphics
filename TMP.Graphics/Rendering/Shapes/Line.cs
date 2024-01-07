using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics
{
    public struct Line
    {
        public Vector2 Start;
        public Vector2 End;

        public Line(Vector2 start, Vector2 end)
        {
            Start = start;
            End = end;
        }
    }
}
