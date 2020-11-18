using IUPSharp.UI.Events;
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
            SetCallback("FLAT_ACTION", FlatActionCallback);
        }

        public event EventHandler<ButtonActionArgs> Action;

        private int FlatActionCallback(IntPtr handle)
        {
            Action?.Invoke(this, new ButtonActionArgs());

            return Iup.IUP_NOERROR;
        }
    }
}
