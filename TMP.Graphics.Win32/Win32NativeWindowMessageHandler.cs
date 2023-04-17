using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Win32;

public class Win32NativeWindowMessageHandler : IWin32NativeWindowMessageHandler
{
    public Win32NativeWindowMessageHandler() 
    {

    }

    public virtual void WM_ACTIVATEAPP(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_CANCELMODE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_CHILDACTIVATE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_CLOSE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_COMPACTING(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_CREATE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_DESTROY(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_ENABLE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_ENTERSIZEMOVE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_EXITSIZEMOVE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_GETICON(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_GETMINMAXINFO(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_INPUTLANGCHANGE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_INPUTLANGCHANGEREQUEST(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_MOVE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_MOVING(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_NCACTIVATE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_NCCALCSIZE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_NCCREATE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_NCDESTROY(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_NULL(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_QUERYDRAGICON(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_QUERYOPEN(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_QUIT(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_SHOWWINDOW(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_SIZE(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_SIZING(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_STYLECHANGED(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_STYLECHANGING(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_THEMECHANGED(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_USERCHANGED(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_WINDOWPOSCHANGED(nint hWnd, nint wParam, nint lParam) { }
    public virtual void WM_WINDOWPOSCHANGING(nint hWnd, nint wParam, nint lParam) { }
}
