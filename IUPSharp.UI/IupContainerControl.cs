using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IUPSharp.UI
{
    public abstract class IupContainerControl : IupControl
    {
        internal IupContainerControl(IntPtr handle): base(handle) { }

        protected IupContainerControl(IntPtr handle, params IupObject[] children) : base(handle) => AddAll(children);

        public Size ClientSize => GetSize("CLIENTSIZE");

        public Size ClientOffset => GetSize("CLIENTOFFSET");

    }
}
