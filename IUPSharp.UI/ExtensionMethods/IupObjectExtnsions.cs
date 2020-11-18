using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI
{
    public static class IupObjectExtnsions
    {
        public static TObject With<TObject>(this TObject iupObject, Action<TObject> configure)
            where TObject : IupObject
        {
            configure(iupObject);
            return iupObject;
        }
    }
}
