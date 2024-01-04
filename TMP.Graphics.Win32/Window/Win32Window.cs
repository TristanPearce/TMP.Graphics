using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vanara.PInvoke;
using TMP.Graphics.Utils;
using TMP.Graphics.Window;
using static Vanara.PInvoke.User32;
using System.Numerics;

namespace TMP.Graphics.Win32.Window;

public sealed class Win32Window : IWindow
{

    private const string CLASS_NAME = "Sample Window Class";

    private WNDCLASS _wc;
    private SafeHWND _windowPointer;

    public Vector2 Position { get; set; }
    public Vector2 Size { get; set; }
    public WindowMode WindowMode { get; set; }

    public IWin32NativeWindowMessageHandler MessageHandler { get; init; }

    public Win32Window()
    {
        MessageHandler = new Win32NativeWindowMessageHandler();
        unsafe
        {
            _wc = new WNDCLASS();
            _wc.lpfnWndProc = WindowProc;
            _wc.hInstance = Kernel32.GetModuleHandle(null);
            _wc.lpszClassName = CLASS_NAME;

            RegisterClass(in _wc);

            _windowPointer = CreateWindowEx(
                WindowStylesEx.WS_EX_ACCEPTFILES,                              // Optional window styles.
                CLASS_NAME,                     // Window class
                "Learn to Program Windows",    // Window text
                WindowStyles.WS_OVERLAPPEDWINDOW,            // Window style

                // Size and position
                100, 100, 400, 400,

                HWND.NULL,       // Parent window    
                HMENU.NULL,       // Menu
                Kernel32.GetModuleHandle(null),  // Instance handle
                IntPtr.Zero        // Additional application data
                );

            if (_windowPointer.IsInvalid)
            {
                throw new Exception($"Window could not be created : {Kernel32.GetLastError()}");
            }
        }
    }

    public void PumpEvents()
    {
        MSG msg = new MSG();
        GetMessage(out msg, _windowPointer, 0, 0);
        TranslateMessage(in msg);
        DispatchMessage(in msg);
    }

    unsafe IntPtr WindowProc(HWND hwnd, uint message, IntPtr wParam, IntPtr lParam)
    {
        switch ((WindowMessage)message)
        {
            case WindowMessage.WM_ACTIVATEAPP:
                MessageHandler.WM_ACTIVATEAPP(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_CANCELMODE:
                MessageHandler.WM_CANCELMODE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_CHILDACTIVATE:
                MessageHandler.WM_CHILDACTIVATE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_CLOSE:
                MessageHandler.WM_CLOSE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_COMPACTING:
                MessageHandler.WM_COMPACTING(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_CREATE:
                MessageHandler.WM_CREATE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_DESTROY:
                MessageHandler.WM_DESTROY(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_ENABLE:
                MessageHandler.WM_ENABLE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_ENTERSIZEMOVE:
                MessageHandler.WM_ENTERSIZEMOVE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_EXITSIZEMOVE:
                MessageHandler.WM_EXITSIZEMOVE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_GETICON:
                MessageHandler.WM_GETICON(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_GETMINMAXINFO:
                MessageHandler.WM_GETMINMAXINFO(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_INPUTLANGCHANGE:
                MessageHandler.WM_INPUTLANGCHANGE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_INPUTLANGCHANGEREQUEST:
                MessageHandler.WM_INPUTLANGCHANGEREQUEST(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_MOVE:
                MessageHandler.WM_MOVE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_MOVING:
                MessageHandler.WM_MOVING(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_NCACTIVATE:
                MessageHandler.WM_NCACTIVATE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_NCCALCSIZE:
                MessageHandler.WM_NCCALCSIZE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_NCCREATE:
                MessageHandler.WM_NCCREATE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_NCDESTROY:
                MessageHandler.WM_NCDESTROY(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_NULL:
                MessageHandler.WM_NULL(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_QUERYDRAGICON:
                MessageHandler.WM_QUERYDRAGICON(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_QUERYOPEN:
                MessageHandler.WM_QUERYOPEN(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_QUIT:
                MessageHandler.WM_QUIT(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_SHOWWINDOW:
                MessageHandler.WM_SHOWWINDOW(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_SIZE:
                MessageHandler.WM_SIZE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_SIZING:
                MessageHandler.WM_SIZING(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_STYLECHANGED:
                MessageHandler.WM_STYLECHANGED(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_STYLECHANGING:
                MessageHandler.WM_STYLECHANGING(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_THEMECHANGED:
                MessageHandler.WM_THEMECHANGED(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_USERCHANGED:
                MessageHandler.WM_USERCHANGED(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_WINDOWPOSCHANGED:
                MessageHandler.WM_WINDOWPOSCHANGED(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_WINDOWPOSCHANGING:
                MessageHandler.WM_WINDOWPOSCHANGING(hwnd, (nint)wParam, (nint)lParam);
                break;
        }
        return DefWindowProc(hwnd, message, (nint)wParam, (nint)lParam);
    }

    public void Show()
    {
        ShowWindow(_windowPointer, ShowWindowCommand.SW_SHOW);
    }

    public void Hide()
    {
        ShowWindow(_windowPointer, ShowWindowCommand.SW_HIDE);
    }


}
