using System;
using System.Runtime.InteropServices;

namespace ManagedDll1
{
    public class Class1
    {
        [DllImport(@"NativeDll", EntryPoint="GetInt", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetIntNative();

        public static int GetInt()
        {
            return GetIntNative();
        }
    }
}