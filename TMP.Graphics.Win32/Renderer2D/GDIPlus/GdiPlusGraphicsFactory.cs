using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMP.Graphics.Rendering2D;
using TMP.Graphics.Win32.Renderer2D.GDIPlus.Shapes;

namespace TMP.Graphics.Win32.Renderer2D.GDIPlus
{
    public class GdiPlusGraphicsFactory : GraphicsFactory
    {

        public override IEllipse CreateEllipse()
        {
            return new GdiPlusEllipse();
        }

    }
}
