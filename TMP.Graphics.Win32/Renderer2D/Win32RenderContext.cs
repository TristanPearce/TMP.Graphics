using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMP.Graphics.Rendering2D;
using TMP.Graphics.Win32.Window;
using static Vanara.PInvoke.User32;
using Vanara.PInvoke;
using System.Runtime.CompilerServices;

namespace TMP.Graphics.Win32
{
    public class Win32RenderContext : IRenderContext
    {
        public event Action<IRenderer2D>? Rendering;

        private Win32Window _window;
        private IWin32NativeWindowMessageHandler _windowMessageHandler;

        private HDC _bufferContext;
        private Gdi32.SafeHBITMAP _bufferBitmap;

        public Win32RenderContext(Win32Window window)
        {
            _window = window;
            _windowMessageHandler = new Win32MessageHandler(this);
            _window.MessageHandlers.Add(_windowMessageHandler);
        }

        private IRenderer2D CreateRenderer2D(HDC hdc)
        {
            return new GDIRenderer2D(hdc, _window);
        }

        public void Refresh()
        {
            GetClientRect((SafeHWND)_window, out RECT clientRect);
            InvalidateRect((SafeHWND)_window, clientRect, true);
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
                GetClientRect((SafeHWND)_renderContext._window, out RECT clientRect);

                PAINTSTRUCT ps;
                HDC hdc = BeginPaint(hWnd, out ps);

                // Create an off-screen buffer
                HDC bufferContext = Gdi32.CreateCompatibleDC(hdc);
                HBITMAP bufferBitmap = Gdi32.CreateCompatibleBitmap(hdc, clientRect.Width, clientRect.Height);
                var oldBufferBitmap = Gdi32.SelectObject(bufferContext, bufferBitmap);

                // Create a renderer for the off-screen buffer
                IRenderer2D renderer = _renderContext.CreateRenderer2D(bufferContext);
                _renderContext.Rendering?.Invoke(renderer);

                // Copy the off-screen buffer to the screen
                Gdi32.BitBlt(hdc, 0, 0, clientRect.Width, clientRect.Height, bufferContext, 0, 0, Gdi32.RasterOperationMode.SRCCOPY);

                // Clean up
                Gdi32.SelectObject(bufferContext, oldBufferBitmap);
                Gdi32.DeleteObject(bufferBitmap);
                Gdi32.DeleteDC(bufferContext);

                EndPaint(hWnd, in ps);
            }
        }
    }
}
