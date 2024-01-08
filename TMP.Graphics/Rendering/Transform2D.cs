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
        private Vector2 _translation;
        public Vector2 Translation 
        {
            get => _translation; 
            set => _translation = value;
        }

        private Vector2 _scale;
        public Vector2 Scale 
        { 
            get => _scale;
            set => _scale = value; 
        }

        private float _rotation;
        public float Rotation 
        {
            get => _rotation;
            set => _rotation = value;
        }

        public Transform2D() 
        {
            Translation = new Vector2(0, 0);
            Scale = new Vector2(1, 1);
            Rotation = 0f;
        }

        #region Translation

        public void SetTranslation(float x, float y)
        {
            _translation.X = x;
            _translation.Y = y;
        }

        public void SetTranslationX(float x)
        {
            _translation.X = x;
        }

        public void SetTranslationY(float y)
        {
            _translation.Y = y;
        }

        public void TranslateBy(float dX, float dY)
        {
            _translation.X += dX;
            _translation.Y += dY;
        }

        #endregion

        #region Scale

        public void SetScale(float x, float y)
        {
            _scale.X = x;
            _scale.Y = y;
        }

        public void SetScaleX(float x)
        {
            _scale.X = x;
        }

        public void SetScaleY(float y)
        {
            _scale.Y = y;
        }

        public void ScaleBy(float dX, float dY, ScaleByMethod method)
        {
            switch (method) 
            {
                case ScaleByMethod.Addition:
                    _scale.X += dX;
                    _scale.Y += dY;
                    break;
                case ScaleByMethod.Multiplication:
                    _scale.X *= dX;
                    _scale.Y *= dY;
                    break;
                case ScaleByMethod.Exponential:
                    _scale.X = MathF.Pow(_scale.X, dX);
                    _scale.Y = MathF.Pow(_scale.Y, dY);
                    break;
                default:
                    throw new NotSupportedException($"ScaleByMethod ({method}) is not supported.");
            }
        }

        public enum ScaleByMethod
        {
            /// <summary>
            /// (x', y') = (x + dx, y + dy)
            /// </summary>
            Addition,
            /// <summary>
            /// (x', y') = (x * dx, y * dy)
            /// </summary>
            Multiplication,
            /// <summary>
            /// (x', y') = (x^dx, y^dy)
            /// </summary>
            Exponential
        }

        #endregion

        #region Rotation

        public void RotateBy(float dAngle)
        {
            _rotation += dAngle;
        }

        #endregion

        public static explicit operator Matrix3x2(Transform2D transform)
        {
            return
                Matrix3x2.CreateScale(transform.Scale) *
                Matrix3x2.CreateRotation(transform.Rotation) *
                Matrix3x2.CreateTranslation(transform.Translation);
        }
    }
}
