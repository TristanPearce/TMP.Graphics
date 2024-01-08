using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering.Shapes
{
    public class Line
    {
        public Vector2 Start;
        public Vector2 End;

        public Line()
        {
            Start = new Vector2 (0.0f, 0.0f);
            End = new Vector2 (0.0f, 0.0f);
        }

        public Line(Vector2 start, Vector2 end)
        {
            Start = start;
            End = end;
        }
    }
}
