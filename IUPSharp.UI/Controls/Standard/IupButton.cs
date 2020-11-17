using IUPSharp.UI.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI.Controls.Standard
{
    public sealed class IupButton : IupControl
    {
        internal IupButton(IntPtr handle) : base(handle) {
        }

        public IupButton(string title = "")
            : this(Iup.IupFlatButton(title))
        {

        }

        public IupButton OnAction(EventHandler<ButtonActionArgs> handler)
        {
            SetCallback("FLAT_ACTION", handle => {
                
                handler?.Invoke(this, new ButtonActionArgs());

                return Iup.IUP_NOERROR;
            });
            return this;
        }
    }
}
