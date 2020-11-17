using IUPSharp.Dom.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IUPSharp.Dom
{
    public abstract class IUPSharpDomElement : IUPSharpDomNode
    {
        public Style Style { get; protected set; } = new Style();

        public abstract Style DefaultStyle { get; }
    }
}
