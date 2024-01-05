using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Tests.Unit.Shapes
{
    public class EllipseTests
    {

        [Theory]
        [InlineData(/* Input */0, 0, 0, 0,         /* Expected */ 0, 0, 0, 0)]
        [InlineData(/* Input */50, 50, 100, 100,   /* Expected */ 0, 100, 100, 0)]
        [InlineData(/* Input */-50, -50, 100, 100, /* Expected */ -100, 0, 0, -100)]
        public void SetXYWH_ConfirmBounds(float x, float y, float width, float height, 
            float expectedLeft, float expectedRight, float expectedTop, float expectedBottom)
        {
            Ellipse ellipse = new Ellipse()
            {
                X = x,
                Y = y,
                Width = width,
                Height = height
            };

            Assert.Equal(expectedLeft, ellipse.Left);
            Assert.Equal(expectedRight, ellipse.Right);
            Assert.Equal(expectedTop, ellipse.Top);
            Assert.Equal(expectedBottom, ellipse.Bottom);
        }

        /// <summary>
        /// Set left right top and bottom values and confirm that X, Y, Width and Height are appropriately set.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="expectedLeft"></param>
        /// <param name="expectedRight"></param>
        /// <param name="expectedTop"></param>
        /// <param name="expectedBottom"></param>
        [Theory]
        [InlineData(/* Input */0, 0, 0, 0,         
            /* Expected */ 0, 0, 0, 0)]
        [InlineData(/* Input */50, 100, 100, 50,   
            /* Expected */ 75, 75, 50, 50)]
        [InlineData(/* Input */-50, 50, 100, -100, 
            /* Expected */ 0, 0, 150, 150)]
        public void SetLRTB_ConfirmXYWH(float left, float right, float top, float bottom,
            float expectedX, float expectedY, float expectedWidth, float expectedHeight)
        {
            Ellipse ellipse = new Ellipse()
            {
                Left = left,
                Right = right,
                Top = top,
                Bottom = bottom
            };

            Assert.Equal(expectedX, ellipse.X);
            Assert.Equal(expectedY, ellipse.Y);
            Assert.Equal(expectedWidth, ellipse.Width);
            Assert.Equal(expectedHeight, ellipse.Height);
        }
    }
}
