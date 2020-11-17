using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI.Controls.Standard
{
    public sealed class IupButton : IupControl
    {
        public IupButton(string title = "")
            : base(Iup.IupFlatButton(title))
        {

        }
    }
}
