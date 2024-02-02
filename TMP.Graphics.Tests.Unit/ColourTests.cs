using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Tests.Unit
{
    public class ColourTests
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        public void Hsl(byte h, byte s, byte l, byte expectedRed, byte expectedGreen, byte expectedBlue)
        {
            var colour = Colour.HSL(h, s, l);

            Assert.Equal(expectedRed, colour.Red);
            Assert.Equal(expectedGreen, colour.Green);
            Assert.Equal(expectedBlue, colour.Blue);
        }

    }
}
