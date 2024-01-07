using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics
{
    public struct Ellipse
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public float Left
        {
            get => X - Width / 2;
            set
            {
                Width = Right - value;
                X = value + Width / 2;
            }
        }

        public float Right
        {
            get => X + Width / 2;
            set
            {
                Width = value - Left;
                X = value - Width / 2;
            }
        }

        public float Top
        {
            get => Y + Height / 2;
            set
            {
                Height = value - Bottom;
                Y = value - Height / 2;
            }
        }

        public float Bottom
        {
            get => Y - Height / 2;
            set
            {
                Height = Top - value;
                Y = value + Height / 2;
            }
        }
    }
}
