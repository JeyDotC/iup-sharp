using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI
{
    sealed class IupNoObject : IupObject
    {
        public IupNoObject(IntPtr handle)
            : base(handle)
        {

        }

        public IupNoObject()
            : base(IntPtr.Zero)
        {

        }
    }
}
