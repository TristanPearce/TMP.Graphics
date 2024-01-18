using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public class Image
    {
        private Colour[] _imageData;

        public Transform2D Transform { get; set; }

        public Image()
        {
            Transform = new Transform2D();
        }

        public Colour[] GetImageData()
        {
            return new Colour[] { };
        }

        public void SetImageData(Colour[] colours)
        {
            _imageData = colours;
        }
    }
}
