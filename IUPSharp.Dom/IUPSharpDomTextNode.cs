using IUPSharp.Dom.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IUPSharp.Dom
{
    public sealed class IUPSharpDomTextNode : IUPSharpDomNode
    {
        public string Text { get; set; }

        public FontStyles FontStyles { get; set; } = FontStyles.Default;

        // Break

        // Join
    }
}
