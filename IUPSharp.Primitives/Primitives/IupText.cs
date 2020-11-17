using IUPSharp.Dom;
using IUPSharp.Dom.Styles;
using IUPSharp.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.Renderer.Primitives
{
    public class IupText : Component, IPrimitive
    {
        public string Value { get; set; }

        public override Component Render() => this;

        public IUPSharpDomElement ToElement() => new IupTextElement { 
            Value = Value
        };
    }

    class IupTextElement : RenderableElement
    {
        public override Style DefaultStyle => throw new NotImplementedException();

        public string Value
        {
            get => Iup.IupGetAttribute(_handle, "VALUE");
            set => Iup.IupSetAttribute(_handle, "VALUE", value);
        }

        public IupTextElement()
        {
            _handle = Iup.IupText("NoAction");
        }
    }
}
