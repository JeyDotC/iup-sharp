using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUPSharp.UI.Events
{
    public class ValueChangedArgs : EventArgs
    {
        public string Value { get; init; }
    }
}
