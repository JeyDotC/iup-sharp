using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI
{
    public class IupApp : IDisposable
    {
        public string Version => Iup.IupVersion();

        public IupApp()
        {
            Iup.IupOpen(IntPtr.Zero, new string[] { });
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
