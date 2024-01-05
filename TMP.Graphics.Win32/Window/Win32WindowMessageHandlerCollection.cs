using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanara.PInvoke;

namespace TMP.Graphics.Win32.Window
{
    public class Win32WindowMessageHandlerCollection
    {
        private IList<IWin32NativeWindowMessageHandler> _nativeHandlers;

        public Win32WindowMessageHandlerCollection() 
        {
            _nativeHandlers = new List<IWin32NativeWindowMessageHandler>();
        }

        public void Add(IWin32NativeWindowMessageHandler handler)
        {
            _nativeHandlers.Add(handler);
        }

        public bool Remove(IWin32NativeWindowMessageHandler handler)
        {
            return _nativeHandlers?.Remove(handler) ?? false;
        }

        /// <summary>
        /// dispatches messages to all other handlers in the handler collection.
        /// </summary>
        internal class Win32DispatchMessageHandler : IWin32NativeWindowMessageHandler
        {
            private readonly Win32WindowMessageHandlerCollection _collection;

            public Win32DispatchMessageHandler(Win32WindowMessageHandlerCollection collection)
            {
                _collection = collection;
            }

            public void WM_ACTIVATEAPP(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach(var handler in _collection._nativeHandlers)
                    handler.WM_ACTIVATEAPP(hWnd, wParam, lParam);
            }

            public void WM_CANCELMODE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_CANCELMODE(hWnd, wParam, lParam);
            }

            public void WM_CHILDACTIVATE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_CHILDACTIVATE(hWnd, wParam, lParam);
            }

            public void WM_CLOSE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_CLOSE(hWnd, wParam, lParam);
            }

            public void WM_COMPACTING(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_COMPACTING(hWnd, wParam, lParam);
            }

            public void WM_CREATE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_CREATE(hWnd, wParam, lParam);
            }

            public void WM_DESTROY(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_DESTROY(hWnd, wParam, lParam);
            }

            public void WM_ENABLE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_ENABLE(hWnd, wParam, lParam);
            }

            public void WM_ENTERSIZEMOVE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_ENTERSIZEMOVE(hWnd, wParam, lParam);
            }

            public void WM_EXITSIZEMOVE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_EXITSIZEMOVE(hWnd, wParam, lParam);
            }

            public void WM_GETICON(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_GETICON(hWnd, wParam, lParam);
            }

            public void WM_GETMINMAXINFO(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_GETMINMAXINFO(hWnd, wParam, lParam);
            }

            public void WM_INPUTLANGCHANGE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_INPUTLANGCHANGE(hWnd, wParam, lParam);
            }

            public void WM_INPUTLANGCHANGEREQUEST(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_INPUTLANGCHANGEREQUEST(hWnd, wParam, lParam);
            }

            public void WM_MOVE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_MOVE(hWnd, wParam, lParam);
            }

            public void WM_MOVING(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_MOVING(hWnd, wParam, lParam);
            }

            public void WM_NCACTIVATE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_NCACTIVATE(hWnd, wParam, lParam);
            }

            public void WM_NCCALCSIZE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_NCCALCSIZE(hWnd, wParam, lParam);
            }

            public void WM_NCCREATE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_NCCREATE(hWnd, wParam, lParam);
            }

            public void WM_NCDESTROY(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_NCDESTROY(hWnd, wParam, lParam);
            }

            public void WM_NULL(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_NULL(hWnd, wParam, lParam);
            }

            public void WM_PAINT(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_PAINT(hWnd, wParam, lParam);
            }

            public void WM_QUERYDRAGICON(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_QUERYDRAGICON(hWnd, wParam, lParam);
            }

            public void WM_QUERYOPEN(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_QUERYOPEN(hWnd, wParam, lParam);
            }

            public void WM_QUIT(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_QUIT(hWnd, wParam, lParam);
            }

            public void WM_SHOWWINDOW(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_SHOWWINDOW(hWnd, wParam, lParam);
            }

            public void WM_SIZE(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_SIZE(hWnd, wParam, lParam);
            }

            public void WM_SIZING(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_SIZING(hWnd, wParam, lParam);
            }

            public void WM_STYLECHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_STYLECHANGED(hWnd, wParam, lParam);
            }

            public void WM_STYLECHANGING(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_STYLECHANGING(hWnd, wParam, lParam);
            }

            public void WM_THEMECHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_THEMECHANGED(hWnd, wParam, lParam);
            }

            public void WM_USERCHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_USERCHANGED(hWnd, wParam, lParam);
            }

            public void WM_WINDOWPOSCHANGED(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_WINDOWPOSCHANGED(hWnd, wParam, lParam);
            }

            public void WM_WINDOWPOSCHANGING(HWND hWnd, IntPtr wParam, IntPtr lParam)
            {
                foreach (var handler in _collection._nativeHandlers)
                    handler.WM_WINDOWPOSCHANGING(hWnd, wParam, lParam);
            }
        }
    }
}
