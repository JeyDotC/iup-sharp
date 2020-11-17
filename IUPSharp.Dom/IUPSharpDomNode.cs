using System;
using System.Collections.Generic;
using System.Drawing;

namespace IUPSharp.Dom
{
    public abstract class IUPSharpDomNode
    {
        private readonly IList<IUPSharpDomNode> _children = new List<IUPSharpDomNode>();

        private IUPSharpDomNode _parent;

        public IDictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

        public IUPSharpDomNode Parent
        {
            get => _parent;
            protected set
            {
                if (value == this)
                {
                    throw new InvalidOperationException("A node cannot be parent of itself");
                }
                _parent = value;
            }
        }

        public IEnumerable<IUPSharpDomNode> Children => _children;

        public IUPSharpDomNode Add(IUPSharpDomNode node)
        {
            if (node == this)
            {
                throw new InvalidOperationException("Adding a node to itself can cause infinite recursion!");
            }

            node.Parent = this;

            _children.Add(node);

            return this;
        }

        public IUPSharpDomNode Remove(IUPSharpDomNode node)
        {
            node.Parent = null;
            _children.Remove(node);

            return this;
        }

        public IUPSharpDomNode Clear()
        {
            foreach (var child in _children)
            {
                child.Parent = null;
            }

            _children.Clear();

            return this;
        }
    }
}
