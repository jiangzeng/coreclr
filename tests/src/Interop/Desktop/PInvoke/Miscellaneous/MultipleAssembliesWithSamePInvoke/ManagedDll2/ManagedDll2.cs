using System;
using System.Runtime.InteropServices;

namespace ManagedDll2
{
    public class Class2
    {
        [DllImport(@"NativeDll", EntryPoint="GetInt", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetIntNative();

        public static int GetInt()
        {
            return GetIntNative();
        }
    }
}