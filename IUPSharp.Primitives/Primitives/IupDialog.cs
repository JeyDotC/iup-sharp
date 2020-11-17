using IUPSharp.Dom;
using IUPSharp.Dom.Styles;
using IUPSharp.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.Renderer.Primitives
{
    public class IupDialog : Component, IPrimitive
    {
        public override Component Render() => this;

        public IUPSharpDomElement ToElement() => new IupDialogElement
        {

        };
    }

    class IupDialogElement : RenderableElement
    {
        public override Style DefaultStyle => throw new NotImplementedException();
    }
}
