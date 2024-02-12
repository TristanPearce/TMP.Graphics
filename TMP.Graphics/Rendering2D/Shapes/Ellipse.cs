using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public class Ellipse : IEllipse
    {
        public virtual float Left
        {
            get => X - RadiusX / 2;
            set
            {
                RadiusX = Right - value;
                X = (value + RadiusX / 2);
            }
        }

        public virtual float Right
        {
            get => X + RadiusX / 2;
            set
            {
                RadiusX = value - Left;
                X = (value - RadiusX / 2);
            }
        }

        public virtual float Top
        {
            get => Y + RadiusY / 2;
            set
            {
                RadiusY = value - Bottom;
                Y = (value - RadiusY / 2);
            }
        }

        public virtual float Bottom
        {
            get => Y - RadiusY / 2;
            set
            {
                RadiusY = Top - value;
                Y = (value + RadiusY / 2);
            }
        }

        public float RadiusX { get; set; }
        public float RadiusY { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}
