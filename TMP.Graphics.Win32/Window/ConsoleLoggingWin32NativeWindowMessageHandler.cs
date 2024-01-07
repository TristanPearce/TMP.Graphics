using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanara.PInvoke;

namespace TMP.Graphics.Win32.Window;

public class ConsoleLoggingWin32NativeWindowMessageHandler : Win32NativeWindowMessageHandler
{

    public override void WM_MOVE(HWND hWnd, IntPtr wParam, IntPtr lParam)
    {
        int x = LOWORD(lParam);
        int y = HIWORD(lParam);

        Console.WriteLine($"Position ({x},{y})");
    }

    public override void WM_SIZE(HWND hWnd, IntPtr wParam, IntPtr lParam)
    {
        int width = LOWORD(lParam);
        int height = HIWORD(lParam);

        Console.WriteLine($"Size ({width},{height})");
    }

    public override void WM_PAINT(HWND hWnd, IntPtr wParam, IntPtr lParam)
    {
        Console.WriteLine("Paint");
    }

    private static unsafe int LOWORD(nint ptr)
    {
        int low = (int)ptr & 0xFFFF;
        return low;
    }

    private static unsafe int HIWORD(nint ptr)
    {
        int high = (int)ptr >> 16;
        return high;
    }
}
