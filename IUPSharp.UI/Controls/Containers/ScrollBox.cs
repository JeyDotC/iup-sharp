using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI.Controls.Containers
{
    public class ScrollBox : IupControl
    {
        public ScrollBox(): this(new IupNoObject())
        {

        }

        public ScrollBox(IupObject child) : base(Iup.IupFlatScrollBox(child.Handle))
        {
        }
    }
}
