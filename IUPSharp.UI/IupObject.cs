
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
        private static readonly IDictionary<IntPtr, IupObject> _objectReferenceMap = new Dictionary<IntPtr, IupObject>();

        internal IupObject(IntPtr handle)
        {
            Handle = handle;
            _objectReferenceMap[handle] = this;
            SetCallback("LDESTROY_CB", OnDestroy);
        }

        private int OnDestroy(IntPtr handle)
        {
            _objectReferenceMap.Remove(Handle);
            return Iup.IUP_DEFAULT;
        }

        static internal TIupObject GetFromHandle<TIupObject>(IntPtr handle)
            where TIupObject : IupObject
            => GetFromHandle(handle) as TIupObject;

        static private IupObject GetFromHandle(IntPtr handle)
           => handle != IntPtr.Zero ? _objectReferenceMap[handle] : null;


        internal IntPtr Handle { get; } = IntPtr.Zero;

        // Public API

        public string Name { get => Get("NAME"); set => Set("NAME", value); }

        public IupObject Parent => GetFromHandle(Iup.IupGetParent(Handle));

        public IupDialog Root => GetFromHandle<IupDialog>(Iup.IupGetDialog(Handle));

        public int ChildCount => Iup.IupGetChildCount(Handle);

        public IEnumerable<IupObject> Children
        {
            get
            {
                foreach (var childIndex in Enumerable.Range(0, ChildCount))
                {
                    var childHandle = Iup.IupGetChild(Handle, childIndex);

                    yield return GetFromHandle(childHandle);
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

            return GetFromHandle<TControl>(handle);
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
