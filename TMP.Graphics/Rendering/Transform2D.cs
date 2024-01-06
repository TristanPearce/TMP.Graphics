using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics
{
    public sealed class Transform2D
    {
        public Vector2 Translation = new Vector2(0, 0);
        public Vector2 Scale = new Vector2(1, 1);
        public float Rotation = 0f;

        public Transform2D() 
        {

        }

        public static explicit operator Matrix3x2(Transform2D transform)
        {
            return
                Matrix3x2.CreateScale(transform.Scale) *
                Matrix3x2.CreateRotation(transform.Rotation) *
                Matrix3x2.CreateTranslation(transform.Translation);
        }
    }
}
