using TMP.Graphics.Rendering;
using TMP.Graphics.Win32.Window;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace TMP.Graphics.Win32.Renderer2D.Immediate
{
    public class Win32ImmediateModeRenderer2D : IRenderer2D
    {

        private Win32Window _window;

        private bool _isPainting = false;

        private HDC _hdc;

        private IWin32NativeWindowMessageHandler _handler;

        public Fill FillColor { get; set; }
        public Outline Outline { get; set; }

        public event Action OnPaint;

        public Win32ImmediateModeRenderer2D(Win32Window window)
        {
            _window = window;
            _handler = new Win32MessageHandler(this);
            _window.MessageHandlers.Add(_handler);
        }

        public void Draw(Line line)
        {
            if (_hdc == HDC.NULL)
                throw new InvalidOperationException("Can only call draw functions inside OnPaint event.");

            HPEN hPen = CreatePen((uint)PenStyle.PS_SOLID, 2, new COLORREF(255, 0, 0));  // Red pen
            HGDIOBJ hOldPen = SelectObject(_hdc, hPen);

            MoveToEx(_hdc, (int)line.Start.X, (int)line.Start.Y, out POINT p);  // Move to starting point
            LineTo(_hdc, (int)line.End.X, (int)line.End.Y);           // Draw a line to ending point

            SelectObject(_hdc, hOldPen);
            DeleteObject(hPen);
        }

        public void Draw(Ellipse ellipse)
        {
            throw new NotImplementedException();
        }

        public void Draw(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void Draw(Polygon polygon)
        {
            throw new NotImplementedException();
        }

        public void Draw(Image image)
        {
            throw new NotImplementedException();
        }

        private class Win32MessageHandler : Win32NativeWindowMessageHandler
        {
            Win32ImmediateModeRenderer2D _renderer;
            public Win32MessageHandler(Win32ImmediateModeRenderer2D renderer)
            {
                _renderer = renderer;
            }

            public override void WM_PAINT(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                PAINTSTRUCT ps;
                _renderer._hdc = BeginPaint(hWnd, out ps);
                _renderer._isPainting = true;
                _renderer.OnPaint?.Invoke();
                EndPaint(hWnd, in ps);
                _renderer._hdc = HDC.NULL;
                _renderer._isPainting = false;
            }
        }
    }
}
