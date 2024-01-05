using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Data.Common;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics.Contracts;

using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace TMP.Graphics.Win32.Window;

public interface IWin32NativeWindowMessageHandler
{
    /// <summary>
    /// Sent when a window belonging to a different application than the active window 
    /// is about to be activated. The message is sent to the application whose window is being 
    /// activated and to the application whose window is being deactivated.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-activateapp"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// Indicates whether the window is being activated or deactivated. 
    /// This parameter is TRUE if the window is being activated;  it is FALSE if the window is being deactivated.
    /// </param>
    /// <param name="lParam">
    /// The thread identifier. If the wParam parameter is TRUE, lParam is the 
    /// identifier of the thread that owns the window being deactivated. If wParam 
    /// is FALSE, lParam is the identifier of the thread that owns the window being activated.
    /// </param>
    public void WM_ACTIVATEAPP(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to cancel certain modes, such as mouse capture. For example, 
    /// the system sends this message to the active window when a dialog box or message 
    /// box is displayed. Certain functions also send this message explicitly to the 
    /// specified window regardless of whether it is the active window. For example, 
    /// the EnableWindow function sends this message when disabling the specified window.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-cancelmode"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_CANCELMODE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a child window when the user clicks the window's title 
    /// bar or when the window is activated, moved, or sized.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-childactivate"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_CHILDACTIVATE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent as a signal that a window or an application should terminate.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-close"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_CLOSE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to all top-level windows when the system detects more than 12.5 percent 
    /// of system time over a 30- to 60-second interval is being spent compacting memory. 
    /// This indicates that system memory is low.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-compacting"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// The ratio of central processing unit (CPU) time currently spent by the system compacting 
    /// memory to CPU time currently spent by the system performing other operations. For example, 
    /// 0x8000 represents 50 percent of CPU time spent compacting memory.
    /// </param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_COMPACTING(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent when an application requests that a window be created by calling the CreateWindowEx
    /// or CreateWindow function. (The message is sent before the function returns.) The window 
    /// procedure of the new window receives this message after the window is created, but 
    /// before the window becomes visible.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-create"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">
    /// A pointer to a CREATESTRUCT structure that contains 
    /// information about the window being created.
    /// </param>
    /// <returns>
    /// If an application processes this message, it should return zero to continue 
    /// creation of the window. If the application returns –1, the window is destroyed 
    /// and the CreateWindowEx or CreateWindow function returns a NULL handle.
    /// </returns>
    public void WM_CREATE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent when a window is being destroyed. It is sent to the window procedure 
    /// of the window being destroyed after the window is removed from the screen
    /// This message is sent first to the window being destroyed and then to the child 
    /// windows(if any) as they are destroyed.During the processing of the message, it can 
    /// be assumed that all child windows still exist.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-destroy"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_DESTROY(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent when an application changes the enabled state of a window. It is sent 
    /// to the window whose enabled state is changing. This message is sent before 
    /// the EnableWindow function returns, but after the enabled state 
    /// (WS_DISABLED style bit) of the window has changed.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-enable"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// Indicates whether the window has been enabled or disabled. 
    /// This parameter is TRUE if the window has been enabled or 
    /// FALSE if the window has been disabled.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_ENABLE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent one time to a window after it enters the moving or sizing modal loop. 
    /// The window enters the moving or sizing modal loop when the user clicks the 
    /// window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND 
    /// message to the DefWindowProc function and the wParam parameter of the message 
    /// specifies the SC_MOVE or SC_SIZE value. The operation is complete when DefWindowProc 
    /// returns.The system sends the WM_ENTERSIZEMOVE message regardless of whether the 
    /// dragging of full windows is enabled.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-entersizemove"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_ENTERSIZEMOVE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent one time to a window, after it has exited the moving or sizing modal loop. 
    /// The window enters the moving or sizing modal loop when the user clicks the 
    /// window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND 
    /// message to the DefWindowProc function and the wParam parameter of the message specifies 
    /// the SC_MOVE or SC_SIZE value. The operation is complete when DefWindowProc returns.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-exitsizemove"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_EXITSIZEMOVE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a window to retrieve a handle to the large or small icon associated with 
    /// a window. The system displays the large icon in the ALT+TAB dialog, and 
    /// the small icon in the window caption.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-geticon"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// The type of icon being retrieved. This parameter can be one of the following values.
    /// ICON_BIG: 1, ICON_SMALL: 0, ICON_SMALL2: 2
    /// </param>
    /// <param name="lParam">
    /// The DPI of the icon being retrieved. This can be used to
    /// provide different icons depending on the icon size.
    /// </param>
    public void WM_GETICON(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a window when the size or position of the window is about to 
    /// change. An application can use this message to override the window's 
    /// default maximized size and position, or its default minimum or 
    /// maximum tracking size.
    /// </summary>
    /// <remarks>
    /// The maximum tracking size is the largest window size that can be produced 
    /// by using the borders to size the window. The minimum tracking size is the 
    /// smallest window size that can be produced by using the borders 
    /// to size the window.
    /// </remarks>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-getminmaxinfo"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">
    /// A pointer to a MINMAXINFO structure that contains the default 
    /// maximized position and dimensions, and the default minimum and 
    /// maximum tracking sizes. An application can override the defaults 
    /// by setting the members of this structure.
    /// </param>
    public void WM_GETMINMAXINFO(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to the topmost affected window after an application's input language has 
    /// been changed. You should make any application-specific settings and pass the 
    /// message to the DefWindowProc function, which passes the message to all first-level 
    /// child windows. These child windows can pass the message to DefWindowProc to have it 
    /// pass the message to their child windows, and so on.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-inputlangchange"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// The BYTE font character set for the input language.
    /// See iCharSet parameter of the CreateFont function for a list of possible values.
    /// </param>
    /// <param name="lParam">
    /// The HKL input locale identifier.The low word contains a Language 
    /// Identifier for the input language.The high word contains a device handle.
    /// </param>
    public void WM_INPUTLANGCHANGE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Posted to the window with the focus when the user chooses a new input language, 
    /// either with the hotkey (specified in the Keyboard control panel application) or 
    /// from the indicator on the system taskbar. An application can accept the change 
    /// by passing the message to the DefWindowProc function or reject the change (and 
    /// prevent it from taking place) by returning immediately.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-inputlangchangerequest"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// The new input locale. This parameter can be a combination of the following flags.
    /// INPUTLANGCHANGE_BACKWARD : 0x0004, INPUTLANGCHANGE_FORWARD : 0x0002, INPUTLANGCHANGE_SYSCHARSET : 0x0001.
    /// </param>
    /// <param name="lParam">
    /// The input locale identifier. For more information, 
    /// see Languages, Locales, and Keyboard Layouts.
    /// </param>
    public void WM_INPUTLANGCHANGEREQUEST(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent after a window has been moved.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-move"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">
    /// The x and y coordinates of the upper-left corner of the client area of the window. 
    /// The low-order word contains the x-coordinate while the high-order word 
    /// contains the y coordinate.
    /// </param>
    public void WM_MOVE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a window that the user is moving. By processing this message, 
    /// an application can monitor the position of the drag rectangle and, 
    /// if needed, change its position.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-moving"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">
    /// A pointer to a RECT structure with the current position of the window, 
    /// in screen coordinates. To change the position of the drag rectangle, 
    /// an application must change the members of this structure.
    /// </param>
    public void WM_MOVING(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a window when its nonclient area needs to be changed to indicate an active or inactive state.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-ncactivate"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// Indicates when a title bar or icon needs to be changed to indicate an active 
    /// or inactive state. If an active title bar or icon is to be drawn, the wParam 
    /// parameter is TRUE. If an inactive title bar or icon is to be drawn, wParam is FALSE.
    /// </param>
    /// <param name="lParam">
    /// When a visual style is active for this window, this parameter is not used.
    /// When a visual style is not active for this window, this parameter is a 
    /// handle to an optional update region for the nonclient area of the window. If 
    /// this parameter is set to -1, DefWindowProc does not repaint the nonclient 
    /// area to reflect the state change.
    /// </param>
    public void WM_NCACTIVATE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent when the size and position of a window's client area must be calculated. 
    /// By processing this message, an application can control the content of the 
    /// window's client area when the size or position of the window changes.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-nccalcsize"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">If wParam is TRUE, it specifies that the application should indicate 
    /// which part of the client area contains valid information. The system copies the valid 
    /// information to the specified area within the new client area.If wParam is FALSE, the 
    /// application does not need to indicate the valid part of the client area.
    /// </param>
    /// <param name="lParam">
    /// If wParam is TRUE, lParam points to an NCCALCSIZE_PARAMS structure that contains 
    /// information an application can use to calculate the new size and position of the 
    /// client rectangle. If wParam is FALSE, lParam points to a RECT structure. 
    /// On entry, the structure contains the proposed window rectangle for the window. 
    /// On exit, the structure should contain the screen coordinates of the corresponding window client area.
    /// </param>
    public void WM_NCCALCSIZE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent prior to the WM_CREATE message when a window is first created.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-nccreate"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">
    /// A pointer to the CREATESTRUCT structure that contains information about 
    /// the window being created. The members of CREATESTRUCT are identical to 
    /// the parameters of the CreateWindowEx function.
    /// </param>
    public void WM_NCCREATE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Notifies a window that its nonclient area is being destroyed. The DestroyWindow 
    /// function sends the WM_NCDESTROY message to the window following the WM_DESTROY 
    /// message.WM_DESTROY is used to free the allocated memory object associated with 
    /// the window. The WM_NCDESTROY message is sent after the child windows have been
    /// destroyed.In contrast, WM_DESTROY is sent before the child windows are destroyed.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-ncdestroy"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_NCDESTROY(HWND hWnd, IntPtr wParam, IntPtr lParam);


    /// <summary>
    /// Performs no operation. An application sends the WM_NULL message if it 
    /// wants to post a message that the recipient window will ignore.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-null"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    /// <returns>An application returns zero if it processes this message.</returns>
    public void WM_NULL(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// The WM_PAINT message is sent when the system or another application makes a 
    /// request to paint a portion of an application's window. The message is sent 
    /// when the UpdateWindow or RedrawWindow function is called, or by the DispatchMessage 
    /// function when the application obtains a WM_PAINT message by using the GetMessage 
    /// or PeekMessage function.
    /// </summary>
    /// <param name="hWnd"></param>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-paint"/>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_PAINT(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a minimized (iconic) window. The window is about to be dragged by 
    /// the user but does not have an icon defined for its class. An application 
    /// can return a handle to an icon or cursor. The system displays this cursor 
    /// or icon while the user drags the icon.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-querydragicon"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_QUERYDRAGICON(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to an icon when the user requests that the window be restored to its previous size and position.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-queryopen"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_QUERYOPEN(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Indicates a request to terminate an application, and is generated when 
    /// the application calls the PostQuitMessage function. This message 
    /// causes the GetMessage function to return zero.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-quit"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">The exit code given in the PostQuitMessage function.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_QUIT(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a window when the window is about to be hidden or shown.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-showwindow"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// Indicates whether a window is being shown. If wParam is TRUE, the window is
    /// being shown. If wParam is FALSE, the window is being hidden.
    /// </param>
    /// <param name="lParam">
    /// The status of the window being shown. If lParam is zero, the message was sent because 
    /// of a call to the ShowWindow function; otherwise, lParam is one of the following values.
    /// SW_OTHERUNZOOM : 4, SW_OTHERZOOM : 2, SW_PARENTCLOSING : 1, SW_PARENTOPENING : 3.
    /// </param>
    public void WM_SHOWWINDOW(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a window after its size has changed.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-size"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// The type of resizing requested. This parameter can be one of the following values:
    /// SIZE_RESTORED : 0, SIZE_MINIMIZED : 1, SIZE_MAXIMIZED : 2, SIZE_MAXSHOW : 3, SIZE_MAXHIDE : 4. 
    /// </param>
    /// <param name="lParam">
    /// The low-order word of lParam specifies the new width of the client area. 
    /// The high-order word of lParam specifies the new height of the client area.
    /// </param>
    public void WM_SIZE(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a window that the user is resizing. By processing this message, an application 
    /// can monitor the size and position of the drag rectangle and, if needed, change its size or position.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-sizing"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// The edge of the window that is being sized. This parameter can be one of the following values.
    /// WMSZ_LEFT : 1, WMSZ_RIGHT : 2, WMSZ_TOP : 3, WMSZ_TOPLEFT : 4, 
    /// WMSZ_TOPRIGHT : 5, WMSZ_BOTTOM : 6, WMSZ_BOTTOMLEFT : 7, WMSZ_BOTTOMRIGHT : 8.
    /// </param>
    /// <param name="lParam">
    /// A pointer to a RECT structure with the screen coordinates of the drag rectangle. To change the 
    /// size or position of the drag rectangle, an application must change the members of this structure.
    /// </param>
    public void WM_SIZING(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a window after the SetWindowLong function has changed one or more of the window's styles.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-stylechanged"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// Indicates whether the window's styles or extended window styles have changed. 
    /// This parameter can be one or more of the following values.
    /// GWL_EXSTYLE : -20, GWL_STYLE : -16.
    /// </param>
    /// <param name="lParam">
    /// A pointer to a STYLESTRUCT structure that contains the new styles for the window. 
    /// An application can examine the styles, but cannot change them.
    /// </param>
    /// <returns>An application should return zero if it processes this message.</returns>
    public void WM_STYLECHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a window when the SetWindowLong function is about to change one or more of the window's styles.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-stylechanging"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">
    /// Indicates whether the window's styles or extended window styles are changing. 
    /// This parameter can be one or more of the following values.
    /// GWL_EXSTYLE : -20, GWL_STYLE : -16.
    /// </param>
    /// <param name="lParam">
    /// A pointer to a STYLESTRUCT structure that contains the proposed new styles for the window. 
    /// An application can examine the styles and, if necessary, change them.
    /// </param>
    public void WM_STYLECHANGING(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Broadcast to every window following a theme change event. Examples of theme change 
    /// events are the activation of a theme, the deactivation of a theme, or a transition 
    /// from one theme to another.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-themechanged"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is reserved.</param>
    /// <param name="lParam">This parameter is reserved.</param>
    public void WM_THEMECHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to all windows after the user has logged on or off. When the user logs on or off, 
    /// the system updates the user-specific settings. The system sends this message immediately 
    /// after updating the settings.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-userchanged"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">This parameter is not used.</param>
    public void WM_USERCHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a window whose size, position, or place in the Z order has changed as 
    /// a result of a call to the SetWindowPos function or another window-management function.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-windowposchanged"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">
    /// A pointer to a WINDOWPOS structure that contains information about the window's new size and position.
    /// </param>
    public void WM_WINDOWPOSCHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sent to a window whose size, position, or place in the Z order is about to change as a 
    /// result of a call to the SetWindowPos function or another window-management function.
    /// </summary>
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-windowposchanging"/>
    /// <param name="hWnd"></param>
    /// <param name="wParam">This parameter is not used.</param>
    /// <param name="lParam">
    /// A pointer to a WINDOWPOS structure that contains information 
    /// about the window's new size and position.
    /// </param>
    public void WM_WINDOWPOSCHANGING(HWND hWnd, IntPtr wParam, IntPtr lParam);
}