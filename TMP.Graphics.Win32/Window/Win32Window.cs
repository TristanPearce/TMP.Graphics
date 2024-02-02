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

using static Vanara.PInvoke.Gdi32;

namespace TMP.Graphics.Win32.Window;

public sealed class Win32Window : IWindow
{
    private string _windowClassName;

    private readonly Win32WindowMessageHandlerCollection.Win32DispatchMessageHandler _collectionDispatchMessageHandler;

    private WNDCLASS _wc;
    private SafeHWND _windowPointer;

    public Vector2 Position { get; set; }
    public Vector2 Size { get; set; }
    public WindowMode WindowMode { get; set; }

    public Win32WindowMessageHandlerCollection MessageHandlers { get; }

    public Win32Window()
    {
        MessageHandlers = new Win32WindowMessageHandlerCollection();
        _collectionDispatchMessageHandler = new Win32WindowMessageHandlerCollection.Win32DispatchMessageHandler(MessageHandlers);

        this.CreateClassName();
        this.RegisterWindowClass();
        this.CreateWindow();
        
    }

    private void RegisterWindowClass()
    {
        _wc = new WNDCLASS();
        _wc.lpfnWndProc = WindowProc;
        _wc.hInstance = Kernel32.GetModuleHandle(null);
        _wc.lpszClassName = _windowClassName;
        _wc.style = 0;

        RegisterClass(in _wc);
    }

    private void CreateClassName()
    {
        const string classNameFormat = "TMP.Graphics.Win32.Win32Window({0})";
        _windowClassName = string.Format(classNameFormat, Guid.NewGuid());
    }

    private void CreateWindow()
    {
        _windowPointer = CreateWindowEx(
            WindowStylesEx.WS_EX_LEFT,                              // Optional window styles.
            _windowClassName,                     // Window class
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

    public void PumpEvents()
    {
        MSG msg;
        while (PeekMessage(out msg, IntPtr.Zero, 0, 0, PM.PM_REMOVE))
        {
            TranslateMessage(in msg);
            DispatchMessage(in msg);
        }
    }

    unsafe IntPtr WindowProc(HWND hwnd, uint message, IntPtr wParam, IntPtr lParam)
    {
        if (_windowPointer != null && hwnd != _windowPointer)
            return DefWindowProc(hwnd, message, (nint)wParam, (nint)lParam); ;

        switch ((WindowMessage)message)
        {
            case WindowMessage.WM_ACTIVATEAPP:
                _collectionDispatchMessageHandler.WM_ACTIVATEAPP(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_CANCELMODE:
                _collectionDispatchMessageHandler.WM_CANCELMODE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_CHILDACTIVATE:
                _collectionDispatchMessageHandler.WM_CHILDACTIVATE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_CLOSE:
                _collectionDispatchMessageHandler.WM_CLOSE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_COMPACTING:
                _collectionDispatchMessageHandler.WM_COMPACTING(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_CREATE:
                _collectionDispatchMessageHandler.WM_CREATE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_DESTROY:
                _collectionDispatchMessageHandler.WM_DESTROY(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_ENABLE:
                _collectionDispatchMessageHandler.WM_ENABLE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_ENTERSIZEMOVE:
                _collectionDispatchMessageHandler.WM_ENTERSIZEMOVE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_EXITSIZEMOVE:
                _collectionDispatchMessageHandler.WM_EXITSIZEMOVE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_GETICON:
                _collectionDispatchMessageHandler.WM_GETICON(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_GETMINMAXINFO:
                _collectionDispatchMessageHandler.WM_GETMINMAXINFO(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_INPUTLANGCHANGE:
                _collectionDispatchMessageHandler.WM_INPUTLANGCHANGE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_INPUTLANGCHANGEREQUEST:
                _collectionDispatchMessageHandler.WM_INPUTLANGCHANGEREQUEST(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_MOVE:
                _collectionDispatchMessageHandler.WM_MOVE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_MOVING:
                _collectionDispatchMessageHandler.WM_MOVING(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_NCACTIVATE:
                _collectionDispatchMessageHandler.WM_NCACTIVATE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_NCCALCSIZE:
                _collectionDispatchMessageHandler.WM_NCCALCSIZE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_NCCREATE:
                _collectionDispatchMessageHandler.WM_NCCREATE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_NCDESTROY:
                _collectionDispatchMessageHandler.WM_NCDESTROY(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_NULL:
                _collectionDispatchMessageHandler.WM_NULL(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_QUERYDRAGICON:
                _collectionDispatchMessageHandler.WM_QUERYDRAGICON(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_QUERYOPEN:
                _collectionDispatchMessageHandler.WM_QUERYOPEN(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_QUIT:
                _collectionDispatchMessageHandler.WM_QUIT(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_SHOWWINDOW:
                _collectionDispatchMessageHandler.WM_SHOWWINDOW(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_SIZE:
                _collectionDispatchMessageHandler.WM_SIZE(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_SIZING:
                _collectionDispatchMessageHandler.WM_SIZING(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_STYLECHANGED:
                _collectionDispatchMessageHandler.WM_STYLECHANGED(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_STYLECHANGING:
                _collectionDispatchMessageHandler.WM_STYLECHANGING(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_THEMECHANGED:
                _collectionDispatchMessageHandler.WM_THEMECHANGED(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_USERCHANGED:
                _collectionDispatchMessageHandler.WM_USERCHANGED(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_WINDOWPOSCHANGED:
                _collectionDispatchMessageHandler.WM_WINDOWPOSCHANGED(hwnd, (nint)wParam, (nint)lParam);
                break;
            case WindowMessage.WM_WINDOWPOSCHANGING:
                _collectionDispatchMessageHandler.WM_WINDOWPOSCHANGING(hwnd, (nint)wParam, (nint)lParam);
                break;

            case WindowMessage.WM_PAINT:
                _collectionDispatchMessageHandler.WM_PAINT(hwnd, wParam, lParam);
                break;
            case WindowMessage.WM_ERASEBKGND:
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



    public static explicit operator IntPtr(Win32Window window)
    {
        return (IntPtr)window._windowPointer.DangerousGetHandle();
    }

    public static explicit operator SafeHWND(Win32Window window)
    {
        return window._windowPointer;
    }
}
