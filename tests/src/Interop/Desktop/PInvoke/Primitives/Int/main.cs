using System.Runtime.InteropServices;
using System;
using System.Reflection;
using System.Text;

class Test
{
    [DllImport(@"PInvoke_Int", CallingConvention = CallingConvention.Winapi)]
    private static extern int Marshal_In([In]int intValue);

    [DllImport(@"PInvoke_Int", CallingConvention = CallingConvention.Winapi)]
    private static extern int Marshal_InOut([In, Out]int intValue);

    [DllImport(@"PInvoke_Int", CallingConvention = CallingConvention.Winapi)]
    private static extern int Marshal_Out([Out]int intValue);

    [DllImport(@"PInvoke_Int", CallingConvention = CallingConvention.Winapi)]
    private static extern int MarshalPointer_In([In]ref int pintValue);

    [DllImport(@"PInvoke_Int", CallingConvention = CallingConvention.Winapi)]
    private static extern int MarshalPointer_InOut(ref int pintValue);

    [DllImport(@"PInvoke_Int", CallingConvention = CallingConvention.Winapi)]
    private static extern int MarshalPointer_Out(out int pintValue);


    public static int Main(string[] args)
    {
        int intManaged = (int)1000;
        int intNative = (int)2000;
        int intReturn = (int)3000;

        TestHelper.BeginSubScenario("Marshal_In");
        int int1 = intManaged;
        TestHelper.Assert(intReturn, Marshal_In(int1), "The return value is wrong");

        TestHelper.BeginSubScenario("Marshal_InOut");
        int int2 = intManaged;
        TestHelper.Assert(intReturn, Marshal_InOut(int2), "The return value is wrong");
        TestHelper.Assert(intManaged, int2, "The parameter value is changed");

        TestHelper.BeginSubScenario("Marshal_Out");
        int int3 = intManaged;
        TestHelper.Assert(intReturn, Marshal_Out(int3), "The return value is wrong");
        TestHelper.Assert(intManaged, int3, "The parameter value is changed");

        TestHelper.BeginSubScenario("MarshalPointer_In");
        int int4 = intManaged;
        TestHelper.Assert(intReturn, MarshalPointer_In(ref int4), "The return value is wrong");
        TestHelper.Assert(intManaged, int4, "The parameter value is changed");

        TestHelper.BeginSubScenario("MarshalPointer_InOut");
        int int5 = intManaged;
        TestHelper.Assert(intReturn, MarshalPointer_InOut(ref int5), "The return value is wrong");
        TestHelper.Assert(intNative, int5, "The passed value is wrong");

        TestHelper.BeginSubScenario("MarshalPointer_Out");
        int int6 = intManaged;
        TestHelper.Assert(intReturn, MarshalPointer_Out(out int6), "The return value is wrong");
        TestHelper.Assert(intNative, int6, "The passed value is wrong");

        if (TestHelper.Pass)
        {
            Console.WriteLine("Passed!");
            return 100;
        }
        else
        {
            Console.WriteLine("Failed");
            return 101;
        }
    }
}