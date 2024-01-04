using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TMP.Graphics.Window;

namespace TMP.Graphics
{
    public interface IWindow
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public WindowMode WindowMode { get; set; }

        public void Show();
        public void Hide();
    }
}
