using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI.Controls.Containers
{
    public class VBox : IupContainerControl
    {
        public VBox(params IupObject[] children) : base(Iup.IupVboxv(), children)
        {
        }
    }
}
