using System;
using System.Runtime.InteropServices;

class MultipleAssembliesWithSamePInvoke
{
    [DllImport(@"NativeDll", CallingConvention = CallingConvention.StdCall)]
    private static extern int GetInt();

    public static int Main(string[] args)
    {
        TestHelper.Assert(24, GetInt(), "MultipleAssembliesWithSamePInvoke.GetInt()");
        TestHelper.Assert(24, ManagedDll1.Class1.GetInt(), "ManagedDll1.Class1.GetInt()");
        TestHelper.Assert(24, ManagedDll2.Class2.GetInt(), "ManagedDll2.Class2.GetInt()");

        if(TestHelper.Pass)
        {
            TestHelper.InformationWriteLine("Test PASSED");
            return 100;
        }
        else
        {
            TestHelper.InformationWriteLine("Test FAILED");
            return 99;
        }        
    }
}
