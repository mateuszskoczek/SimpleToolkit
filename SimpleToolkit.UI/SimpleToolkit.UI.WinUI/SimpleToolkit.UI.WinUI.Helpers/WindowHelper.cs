using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToolkit.UI.WinUI.Helpers
{
    public static partial class WindowHelper
    {
        #region PUBLIC METHODS

        public static void ShowWindow(Window window)
        {
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

            ShowWindow(hwnd, 0x00000009);

            SetForegroundWindow(hwnd);
        }

        #endregion



        #region PRIVATE METHODS

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion
    }
}
