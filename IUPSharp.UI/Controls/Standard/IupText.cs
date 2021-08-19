using IUPSharp.UI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUPSharp.UI.Controls.Standard
{
    public sealed class IupText : IupControl
    {
        public IupText() : base(Iup.IupText(null))
        {
            SetCallback("VALUECHANGED_CB", ValueChangedCallback);
        }

        public event EventHandler<ValueChangedArgs> ValueChanged;

        public string Value
        {
            get => Get("VALUE");
            set => Set("VALUE", value);
        }

        private int ValueChangedCallback(IntPtr handle)
        {
            ValueChanged?.Invoke(this, new ValueChangedArgs());
            return Iup.IUP_DEFAULT;
        }
    }
}
