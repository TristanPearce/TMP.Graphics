using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Win32.Renderer2D
{
    public enum Win32RenderingBackend : byte
    {
        Gdi = 1,
        GdiPlus = 2,
        Unknown = byte.MaxValue
    }
}
