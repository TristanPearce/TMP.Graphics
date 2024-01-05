using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace TMP.Graphics.Win32.Window;

public class Win32NativeWindowMessageHandler : IWin32NativeWindowMessageHandler
{
    public Win32NativeWindowMessageHandler()
    {

    }

    public virtual void WM_ACTIVATEAPP(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_CANCELMODE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_CHILDACTIVATE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_CLOSE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_COMPACTING(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_CREATE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_DESTROY(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_ENABLE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_ENTERSIZEMOVE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_EXITSIZEMOVE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_GETICON(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_GETMINMAXINFO(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_INPUTLANGCHANGE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_INPUTLANGCHANGEREQUEST(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_MOVE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_MOVING(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_NCACTIVATE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_NCCALCSIZE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_NCCREATE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_NCDESTROY(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_NULL(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_PAINT(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_QUERYDRAGICON(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_QUERYOPEN(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_QUIT(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_SHOWWINDOW(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_SIZE(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_SIZING(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_STYLECHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_STYLECHANGING(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_THEMECHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_USERCHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_WINDOWPOSCHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
    public virtual void WM_WINDOWPOSCHANGING(HWND hWnd, IntPtr wParam, IntPtr lParam) { }
}
