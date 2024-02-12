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
        private bool _shouldRecalculateMatrix;
        private Matrix3x2 _backingMatrix;

        private Vector2 _translation;
        public Vector2 Translation 
        {
            get => _translation; 
            set => SetTranslation(value.X, value.Y);
        }

        private Vector2 _scale;
        public Vector2 Scale 
        { 
            get => _scale;
            set => SetScale(value.X, value.Y);
        }

        private float _rotation;
        public float Rotation 
        {
            get => _rotation;
            set => SetRotation(value);
        }

        public Transform2D() 
        {
            Translation = new Vector2(0, 0);
            Scale = new Vector2(1, 1);
            Rotation = 0f;
        }

        private void InvalidateMatrix()
        {
            _shouldRecalculateMatrix = true;
        }

        private void RecalculateMatrix()
        {
            _backingMatrix = Matrix3x2.CreateScale(_scale) *
                Matrix3x2.CreateRotation(_rotation) *
                Matrix3x2.CreateTranslation(_translation);
            _shouldRecalculateMatrix = true;
        }

        #region Translation

        public void SetTranslation(float x, float y)
        {
            _translation.X = x;
            _translation.Y = y;

            InvalidateMatrix();
        }

        public void SetTranslationX(float x)
        {
            _translation.X = x;
            InvalidateMatrix();
        }

        public void SetTranslationY(float y)
        {
            _translation.Y = y;
            InvalidateMatrix();
        }

        public void TranslateBy(float dX, float dY)
        {
            _translation.X += dX;
            _translation.Y += dY;
            InvalidateMatrix();
        }

        #endregion

        #region Scale

        public void SetScale(float x, float y)
        {
            _scale.X = x;
            _scale.Y = y;
            InvalidateMatrix();
        }

        public void SetScaleX(float x)
        {
            _scale.X = x;
            InvalidateMatrix();
        }

        public void SetScaleY(float y)
        {
            _scale.Y = y;
            InvalidateMatrix();
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
            InvalidateMatrix();
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

        public void SetRotation(float angle)
        {
            _rotation = angle;
            InvalidateMatrix();
        }

        public void RotateBy(float dAngle)
        {
            _rotation += dAngle;
            InvalidateMatrix();
        }

        #endregion

        public static Transform2D Identity => new Transform2D() { _backingMatrix = Matrix3x2.Identity };

        public static explicit operator Matrix3x2(Transform2D transform)
        {
            if (transform._shouldRecalculateMatrix)
                transform.RecalculateMatrix();

            return transform._backingMatrix;
        }
    }
}
