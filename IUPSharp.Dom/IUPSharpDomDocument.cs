using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.Dom
{
    /// <summary>
    /// Serves as root for IUPSharp DOM
    /// </summary>
    public class IUPSharpDomDocument : IUPSharpDomNode
    {
        public IUPSharpDomDocument(IUPSharpDomElement body)
        {
            Body = body;
            Add(body);
        }

        
        public IUPSharpDomElement Body { get; }
    }
}
