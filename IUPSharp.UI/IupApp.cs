using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI
{
    public class IupApp : IDisposable
    {
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
