using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMP.Graphics.Rendering;
using TMP.Graphics.Win32.Window;
using static Vanara.PInvoke.User32;
using Vanara.PInvoke;

namespace TMP.Graphics.Win32
{
    public class Win32RenderContext : IRenderContext
    {
        public event Action<IRenderer2D>? Rendering;

        private Win32Window _window;
        private IWin32NativeWindowMessageHandler _windowMessageHandler;

        public Win32RenderContext(Win32Window window) 
        {
            _window = window;
            _windowMessageHandler = new Win32RenderContext.Win32MessageHandler(this);
            _window.MessageHandlers.Add(_windowMessageHandler);
        }

        private IRenderer2D CreateRenderer2D(HDC hdc, PAINTSTRUCT ps)
        {
            return new Win32GDIRenderer2D(hdc, ps);
        }

        private class Win32MessageHandler : Win32NativeWindowMessageHandler
        {
            Win32RenderContext _renderContext;

            public Win32MessageHandler(Win32RenderContext renderContext)
            {
                _renderContext = renderContext;
            }

            public override void WM_PAINT(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                PAINTSTRUCT ps;
                HDC hdc = BeginPaint(hWnd, out ps);
                IRenderer2D renderer = _renderContext.CreateRenderer2D(hdc, ps);
                _renderContext.Rendering?.Invoke(renderer);
                EndPaint(hWnd, in ps);
            }
        }
    }
}
