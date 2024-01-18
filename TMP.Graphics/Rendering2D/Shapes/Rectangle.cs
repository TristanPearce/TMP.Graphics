using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public class Rectangle
    {
        private Transform2D _transform = new Transform2D();

        public float Rotation
        {
            get => _transform.Rotation;
            set => _transform.Rotation = value;
        }

        public float X
        {
            get => _transform.Translation.X;
            set => _transform.SetTranslationX(value);
        }

        public float Y
        {
            get => _transform.Translation.Y;
            set => _transform.SetTranslationY(value);
        }

        public float Width
        {
            get => _transform.Scale.X;
            set => _transform.SetScaleX(value);
        }

        public float Height
        {
            get => _transform.Scale.Y;
            set => _transform.SetScaleY(value);
        }

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

        public static explicit operator Transform2D(Rectangle rectangle)
        {
            return rectangle._transform;
        }
    }
}
