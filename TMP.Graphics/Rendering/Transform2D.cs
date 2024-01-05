using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering
{
    public sealed class Transform2D
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; } 

        public Transform2D() 
        {

        }

        public static explicit operator Matrix3x2(Transform2D transform)
        {
            return 
                Matrix3x2.CreateTranslation(transform.Position) *
                Matrix3x2.CreateScale(transform.Position) *
                Matrix3x2.CreateRotation(transform.Rotation);
        }
    }
}
