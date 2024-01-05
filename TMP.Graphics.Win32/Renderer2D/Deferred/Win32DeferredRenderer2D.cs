using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMP.Graphics.Rendering;
using TMP.Graphics.Win32.Window;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace TMP.Graphics.Win32.Renderer2D.Deferred
{
    public class Win32DeferredRenderer2D : IRenderer2D
    {
        private Win32Renderer2dDeferredCommandExecutor _commandExecutor;

        private DeferredCommandCollection _deferredCommands;

        private Win32Window _window;
        private IWin32NativeWindowMessageHandler _handler;

        public Win32DeferredRenderer2D(Win32Window window) 
        {
            _deferredCommands = new DeferredCommandCollection();
            _commandExecutor = new Win32Renderer2dDeferredCommandExecutor();
            _window = window;
            _handler = new Win32DeferredRenderer2D.Win32WindowMessageHandler(this);
            _window.MessageHandlers.Add(_handler);
        }

        private Fill _fillColour;
        public Fill FillColor 
        {
            get => _fillColour;
            set
            {
                _fillColour = value;
                _deferredCommands.Add(new SetFillDeferredCommand(value));
            }
        }

        private Outline _outline;
        public Outline Outline 
        {
            get => _outline;
            set
            {
                _outline = value;
                _deferredCommands.Add(new SetOutlineDeferredCommand(value));
            }
        }

        public void Draw(Line line) => _deferredCommands.Add(new DrawLineDeferredCommand(line));

        public void Draw(Ellipse ellipse) => _deferredCommands.Add(new DrawEllipseDeferredCommand(ellipse));

        public void Draw(Rectangle rectangle) => _deferredCommands.Add(new DrawRectangleDeferredCommand(rectangle));

        public void Draw(Polygon polygon) => _deferredCommands.Add(new DrawPolygonDeferredCommand(polygon));

        public void Draw(Image image) => _deferredCommands.Add(new DrawImageDeferredCommand(image));

        private class Win32WindowMessageHandler : Win32NativeWindowMessageHandler
        {
            private Win32DeferredRenderer2D _renderer;

            public Win32WindowMessageHandler(Win32DeferredRenderer2D renderer)
            {
                this._renderer = renderer;
            }

            public override void WM_PAINT(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                var deferredCommands = _renderer._deferredCommands;

                PAINTSTRUCT ps;
                HDC hdc = BeginPaint(hWnd, out ps);
                _renderer._commandExecutor.HDC = hdc;
                _renderer._commandExecutor.Execute(deferredCommands);
                EndPaint(hWnd, in ps);
                deferredCommands.Clear();

                Console.WriteLine("Draw");
            }
        }
    }
}
