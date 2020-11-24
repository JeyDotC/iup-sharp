using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace IUPSharp.UI
{
    public class IupApp : IDisposable
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public string Version => Iup.IupVersion();

        private readonly IntPtr _consoleWindowHandle;

        private bool _consoleWindowIsVisible = false;

        private void UpdateConsoleWindowVisibility()
        {
            ShowWindow(_consoleWindowHandle, _consoleWindowIsVisible ? SW_SHOW : SW_HIDE);
        }

        public bool ShowConsoleWindow
        {
            set
            {
                _consoleWindowIsVisible = value;
                UpdateConsoleWindowVisibility();
            }
            get => _consoleWindowIsVisible;
        }

        public IupApp()
        {
            Console.WriteLine("Starting IUP app...");
           _consoleWindowHandle = Process.GetCurrentProcess().MainWindowHandle;

            Iup.IupOpen(IntPtr.Zero, new string[] { });

            Console.WriteLine($"Powered by IUP V {Version}");
        }

        public void MainLoop()
        {
            Iup.IupMainLoop();
        }

        public void Dispose()
        {
            Iup.IupClose();
        }
    }
}
