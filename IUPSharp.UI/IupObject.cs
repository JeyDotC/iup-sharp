
using IUPSharp.UI.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IUPSharp.UI
{
    public abstract class IupObject
    {
        private static readonly IDictionary<IntPtr, Type> _typeMap = new Dictionary<IntPtr, Type>();

        internal IupObject(IntPtr handle)
        {
            Handle = handle;
            _typeMap[handle] = GetType();
        }

        static internal TIupObject CreateFromHandle<TIupObject>(IntPtr handle)
            where TIupObject : IupObject
            => CreateFromHandle(handle, typeof(TIupObject)) as TIupObject;

        static private IupObject CreateFromHandle(IntPtr handle, Type type)
           => type.GetConstructor(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(IntPtr) }, null).Invoke(new object[] { handle }) as IupObject;


        internal IntPtr Handle { get; } = IntPtr.Zero;

        // Public API

        public string Name { get => Get("NAME"); set => Set("NAME", value); }

        public IupObject Parent
        {
            get
            {
                var parentHandle = Iup.IupGetParent(Handle);

                if (parentHandle == IntPtr.Zero)
                {
                    return null;
                }

                var parentType = _typeMap[parentHandle];

                return CreateFromHandle(parentHandle, parentType);
            }
        }

        public IupDialog Root => CreateFromHandle<IupDialog>(Iup.IupGetDialog(Handle));

        public int ChildCount => Iup.IupGetChildCount(Handle);

        public IEnumerable<IupObject> Children
        {
            get
            {
                foreach (var childIndex in Enumerable.Range(0, ChildCount))
                {
                    var childHandle = Iup.IupGetChild(Handle, childIndex);
                    var childType = _typeMap[childHandle];

                    yield return CreateFromHandle(childHandle, childType);
                }
            }
        }

        public string Get(string attribute) => Iup.IupGetAttribute(Handle, attribute);

        public void Set(string attribute, string value) => Iup.IupSetAttribute(Handle, attribute, value);

        protected void SetCallback(string callbackName, Icallback callback) => Iup.IupSetCallback(Handle, callbackName, callback);

        protected void SetCallback(string callbackName, ISizecallback callback) => Iup.IupSetCallback(Handle, callbackName, callback);

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
            // Do the actual append.
            Iup.IupAppend(Handle, iupObject.Handle);
            Iup.IupMap(iupObject.Handle);
        }

        // Hierarchy methods
        public void Add(IupObject iupObject)
        {
            AddInternal(iupObject);
            Refresh();
        }

        public void AddAll(params IupObject[] children)
        {
            foreach (var child in children)
            {
                AddInternal(child);
            }

            Refresh();
        }

        public void Remove()
        {
            Iup.IupDetach(Handle);
            Parent?.Refresh();
        }

        public void Refresh()
        {
            if (Handle != IntPtr.Zero)
            {
                Iup.IupRefresh(Handle);
            }
        }

        public override bool Equals(object obj) => (obj as IupObject)?.Handle == Handle;

        public override int GetHashCode() => Handle.ToInt32();
    }
}
