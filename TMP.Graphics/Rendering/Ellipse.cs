using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics
{
    public struct Ellipse
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;

        public float Left
        {
            readonly get => X - Width / 2;
            set => X = value + Width / 2;
        }

        public float Right
        {
            readonly get => X + Width / 2;
            set => X = value - Width / 2;
        }

        public float Top 
        {
            readonly get => Y - Height / 2;
            set => Y = value - Height / 2;
        }


        public float Bottom
        {
            readonly get => Y + Height / 2;
            set => Height = value + Height / 2;
        }

    }
}
