using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Tests.Unit
{
    public class Transform2DTests
    {

        [Theory]
        [InlineData(0f, 0f)]
        [InlineData(10f, 20f)]
        [InlineData(10f, -20f)]
        [InlineData(-10f, 20f)]
        [InlineData(-10f, -20f)]
        public void SetTranslation(float x, float y)
        {
            Transform2D transform = new Transform2D();
            transform.SetTranslation(x, y);

            Assert.Equal(x, transform.Translation.X);
            Assert.Equal(y, transform.Translation.Y);
        }

        [Theory]
        [InlineData(0f, 0f)]
        [InlineData(10f, 20f)]
        [InlineData(10f, -20f)]
        [InlineData(-10f, 20f)]
        [InlineData(-10f, -20f)]
        public void TranslateBy(float dX, float dY)
        {
            Transform2D transform = new Transform2D();
            transform.TranslateBy(dX, dY);

            Assert.Equal(dX, transform.Translation.X);
            Assert.Equal(dY, transform.Translation.Y);
        }

        [Theory]
        [InlineData(0f, 0f)]
        [InlineData(10f, 20f)]
        [InlineData(10f, -20f)]
        [InlineData(-10f, 20f)]
        [InlineData(-10f, -20f)]
        public void SetScale (float x, float y)
        {
            Transform2D transform = new Transform2D();
            transform.SetScale(x, y);

            Assert.Equal(x, transform.Scale.X);
            Assert.Equal(y, transform.Scale.Y);
        }

        [Theory]
        [InlineData(0f, 0f)]
        [InlineData(10f, 20f)]
        [InlineData(10f, -20f)]
        [InlineData(-10f, 20f)]
        [InlineData(-10f, -20f)]
        public void ScaleBy_Addition(float dX, float dY)
        {
            Transform2D transform = new Transform2D();
            transform.ScaleBy(dX, dY, Transform2D.ScaleByMethod.Addition);
            Assert.Equal(1 + dX, transform.Scale.X);
            Assert.Equal(1 + dY, transform.Scale.Y);
        }

        [Theory]
        [InlineData(0f, 0f)]
        [InlineData(10f, 20f)]
        [InlineData(10f, -20f)]
        [InlineData(-10f, 20f)]
        [InlineData(-10f, -20f)]
        public void ScaleBy_Multiplication(float dX, float dY)
        {
            Transform2D transform = new Transform2D();
            transform.ScaleBy(dX, dY, Transform2D.ScaleByMethod.Multiplication);
            Assert.Equal(dX, transform.Scale.X);
            Assert.Equal(dY, transform.Scale.Y);
        }

        [Theory]
        [InlineData(0f, 0f)]
        [InlineData(10f, 20f)]
        [InlineData(10f, -20f)]
        [InlineData(-10f, 20f)]
        [InlineData(-10f, -20f)]
        public void ScaleBy_Exponential(float dX, float dY)
        {
            Transform2D transform = new Transform2D();
            transform.ScaleBy(dX, dY, Transform2D.ScaleByMethod.Exponential);
            Assert.Equal(1, transform.Scale.X);
            Assert.Equal(1, transform.Scale.Y);
        }
    }
}
