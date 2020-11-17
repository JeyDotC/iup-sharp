using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IUPSharp.UI.Events
{
    public class DialogResizeArgs : EventArgs
    {

        public DialogResizeArgs(Size newClientSize) => NewClientSize = newClientSize;

        public Size NewClientSize { get; }
    }
}
