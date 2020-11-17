using IUPSharp.Dom;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.Renderer
{
    public abstract class RenderableElement : IUPSharpDomElement 
    {
        protected IntPtr _handle;
    }
}
