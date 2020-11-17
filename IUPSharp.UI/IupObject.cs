
using IUPSharp.UI.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI
{
    public abstract class IupObject
    {
        private readonly IDictionary<IntPtr, IupObject> _childrenRegistry = new Dictionary<IntPtr, IupObject>();

        internal IupObject(IntPtr handle) => Handle = handle;

        static internal TIupObject CreateFromHandle<TIupObject>(IntPtr handle)
            where TIupObject : IupObject
            => typeof(TIupObject).GetConstructor(new Type[] { typeof(IntPtr) }).Invoke(new object[] { handle }) as TIupObject;


        internal IntPtr Handle { get; } = IntPtr.Zero;

        // Public API

        public string Name { get => Get("NAME"); set => Set("NAME", value); }

        public IupObject Parent { get; private set; }

        public IupDialog Root => CreateFromHandle<IupDialog>(Iup.IupGetDialog(Handle));

        public IEnumerable<IupObject> Children => _childrenRegistry.Values;

        public string Get(string attribute) => Iup.IupGetAttribute(Handle, attribute);

        public void Set(string attribute, string value) => Iup.IupSetAttribute(Handle, attribute, value);

        public TControl GetByName<TControl>(string name)
            where TControl : IupObject
        {
            var handle = Iup.IupGetDialogChild(Handle, name);
            if (handle == IntPtr.Zero)
            {
                return null;
            }

            return CreateFromHandle<TControl>(handle);
        }

        private void AddInternal(IupObject iupObject)
        {

            iupObject.Parent = this;
            _childrenRegistry[iupObject.Handle] = iupObject;

            // Do the actual append.
            Iup.IupAppend(Handle, iupObject.Handle);
            Iup.IupMap(iupObject.Handle);
        }

        // Hierarchy methods
        public void Add(IupObject iupObject)
        {
            AddInternal(iupObject);
            Iup.IupRefresh(Handle);
        }

        public void AddAll(params IupObject[] children)
        {
            foreach (var child in children)
            {
                AddInternal(child);
            }
        }

        public void Remove()
        {
            Iup.IupDetach(Handle);
            if (Parent != null && Parent.Handle != IntPtr.Zero)
            {
                Iup.IupRefresh(Parent.Handle);
            }
            Parent = null;
        }

        public override bool Equals(object obj) => (obj as IupObject)?.Handle == Handle;

        public override int GetHashCode() => Handle.ToInt32();
    }
}
