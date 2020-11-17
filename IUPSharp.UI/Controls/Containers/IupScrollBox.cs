using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI.Controls.Containers
{
    public class IupScrollBox : IupControl
    {
        internal IupScrollBox(IntPtr handle) : base(handle) { }

        public IupScrollBox(): this(new IupNoObject())
        {

        }

        public IupScrollBox(IupObject child) : base(Iup.IupFlatScrollBox(child.Handle))
        {
        }
    }
}
