using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Win32;

public class ConsoleLoggingWin32NativeWindowMessageHandler : Win32NativeWindowMessageHandler
{

    public override void WM_MOVE(nint hWnd, nint wParam, nint lParam)
    {
        int x = LOWORD(lParam);
        int y = HIWORD(lParam);

        Console.WriteLine($"Position ({x},{y})");
    }

    public override void WM_SIZE(nint hWnd, nint wParam, nint lParam)
    {
        int width = LOWORD(lParam);
        int height = HIWORD(lParam);

        Console.WriteLine($"Size ({width},{height})");
    }

    private static unsafe int LOWORD(nint ptr)
    {
        int low = ((int)ptr) & 0xFFFF;
        return low;
    }

    private static unsafe int HIWORD(nint ptr)
    {
        int high = ((int)ptr) >> 16;
        return high;
    }
}
