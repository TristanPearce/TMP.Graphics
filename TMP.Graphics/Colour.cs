using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics
{
    public struct Colour
    {
        public byte Red;
        public byte Green;
        public byte Blue;
        public byte Alpha;

        public Colour()
        {
            Red = Green = Blue = 0;
            Alpha = 255;
        }
    }
}
