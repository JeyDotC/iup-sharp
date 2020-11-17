using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace IUPSharp
{
    class CharStarMarshaler : ICustomMarshaler
    {
        public static ICustomMarshaler GetInstance(string name) => new CharStarMarshaler();


        public void CleanUpManagedData(object ManagedObj) => throw new NotImplementedException();

        public void CleanUpNativeData(IntPtr pNativeData) => throw new NotImplementedException();

        public int GetNativeDataSize() => throw new NotImplementedException();

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            var managedString = "" + ManagedObj;
            var len = Encoding.UTF8.GetByteCount(managedString);
            var buffer = new byte[len + 1];
            Encoding.UTF8.GetBytes(managedString, 0, managedString.Length, buffer, 0);
            IntPtr nativeUtf8 = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, nativeUtf8, buffer.Length);
            return nativeUtf8;
        }

        public object MarshalNativeToManaged(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return "";
            int len = 0;
            while (System.Runtime.InteropServices.Marshal.ReadByte(ptr, len) != 0)
                len++;
            if (len == 0)
                return "";
            byte[] array = new byte[len];
            System.Runtime.InteropServices.Marshal.Copy(ptr, array, 0, len);

            return System.Text.Encoding.UTF8.GetString(array);
        }
    }
}
