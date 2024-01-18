using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics
{
    public class ImageData
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public Colour[] Colours { get; protected set; }

        public ImageData(int width, int height)
        {
            Colours = new Colour[0];
        }
    }
}
