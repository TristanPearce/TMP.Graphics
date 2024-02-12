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
using TMP.Graphics.Win32.Renderer2D;
using TMP.Graphics.Win32.Renderer2D.GDIPlus;

namespace TMP.Graphics.Win32
{
    public class Win32RenderContext : IRenderContext, IDisposable
    {
        public event Action<RenderingArguments>? Rendering;

        private Win32Window _window;
        private IWin32NativeWindowMessageHandler _windowMessageHandler;

        public Win32RenderingBackend PreferredBackend { get; set; } = Win32RenderingBackend.GdiPlus;

        public Win32RenderContext(Win32Window window)
        {
            _window = window;
            _windowMessageHandler = new Win32MessageHandler(this);
            _window.MessageHandlers.Add(_windowMessageHandler);
        }

        private IRenderer2D CreateRenderer2D(HDC hdc)
        {
            switch (PreferredBackend)
            {
                case Win32RenderingBackend.Gdi:
                    return new GDIRenderer2D(hdc, _window);
                case Win32RenderingBackend.GdiPlus:
                    return new GDIPlusRenderer2D(hdc);
                default:
                    throw new NotImplementedException();
            }
        }

        private IGraphicsFactory CreateGraphicsFactory()
        {
            switch (PreferredBackend)
            {
                case Win32RenderingBackend.GdiPlus:
                    return new GdiPlusGraphicsFactory();
                default:
                    throw new NotImplementedException();
            }
        }

        public void Refresh()
        {
            RedrawWindow((SafeHWND)_window, null, HRGN.NULL, 
                RedrawWindowFlags.RDW_INTERNALPAINT | RedrawWindowFlags.RDW_INVALIDATE);
        }

        public void Dispose()
        {
            
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
                IGraphicsFactory graphicsFactory = _renderContext.CreateGraphicsFactory();

                RenderingArguments args = new RenderingArguments()
                {
                    Renderer = renderer,
                    GraphicsFactory = graphicsFactory
                };
                _renderContext.Rendering?.Invoke(args);

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
