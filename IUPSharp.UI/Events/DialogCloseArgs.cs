using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI.Events
{
    public class DialogCloseArgs : EventArgs
    {
        public bool ShouldClose { get; set; } = true;
    }
}
