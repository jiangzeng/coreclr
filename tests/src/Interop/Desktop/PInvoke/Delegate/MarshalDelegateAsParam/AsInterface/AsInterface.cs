using System;
using System.Runtime.InteropServices;

class Test
{

#if UNSPPORTED_Delegate_MarshalAs_Interface
    public delegate void Dele();

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool Take_DelegatePtrByValParam([MarshalAs(UnmanagedType.Interface)] Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool Take_DelegatePtrByRefParam([MarshalAs(UnmanagedType.Interface)] ref Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool Take_DelegatePtrByInValParam([In, MarshalAs(UnmanagedType.Interface)] Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool Take_DelegatePtrByInRefParam([In, MarshalAs(UnmanagedType.Interface)] ref Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool Take_DelegatePtrByOutValParam([Out, MarshalAs(UnmanagedType.Interface)] Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool Take_DelegatePtrByOutRefParam([Out, MarshalAs(UnmanagedType.Interface)]out Dele dele, [MarshalAs(UnmanagedType.Interface)] Dele deleHelper);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool Take_DelegatePtrByInOutValParam([In, Out, MarshalAs(UnmanagedType.Interface)] Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool Take_DelegatePtrByInOutRefParam([In, Out, MarshalAs(UnmanagedType.Interface)] ref Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    [return: MarshalAs(UnmanagedType.Interface)]
    extern static Dele ReturnDelegatePtrByVal([MarshalAs(UnmanagedType.Interface)] Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static int RetFieldResult1();

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static int RetFieldResult2();

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static int RetFieldResult3();

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static void CommonMethod1();

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static void CommonMethod2();

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static void CommonMethod3();

    const int COMMONMETHOD1_RESULT = 10;
    const int COMMONMETHOD2_RESULT = 20;
    const int COMMONMETHOD3_RESULT = 30;
#endif
    static int Main()
    {
#if UNSPPORTED_Delegate_MarshalAs_Interface
        TestHelper.BeginSubScenario("Scenario 1 : Delegate marshaled by val with attribute [MarshalAs(UnmanagedType.Interface)].");
        Dele dele1 = new Dele(CommonMethod1);
        dele1 += CommonMethod2;
        dele1 += CommonMethod3;
        TestHelper.Assert(Take_DelegatePtrByValParam(dele1), "Take_DelegatePtrByValParam");

        TestHelper.BeginSubScenario("Scenario 2 : Delegate marshaled by ref with attribute [MarshalAs(MarshalAs(UnmanagedType.Interface)].");
        Dele dele2 = new Dele(CommonMethod1);
        dele2 += CommonMethod2;
        dele2 += CommonMethod3;
        TestHelper.Assert(Take_DelegatePtrByRefParam(ref dele2), "Take_DelegatePtrByRefParam");
        TestHelper.Assert(dele2 == null, "dele2 should equal to null");

        TestHelper.BeginSubScenario("Scenario 3 : Delegate marshaled by val with attribute [In,MarshalAs(UnmanagedType.Interface)].");
        Dele dele3 = new Dele(CommonMethod1);
        dele3 += CommonMethod2;
        dele3 += CommonMethod3;
        TestHelper.Assert(Take_DelegatePtrByInValParam(dele3), "Take_DelegatePtrByInValParam");

        TestHelper.BeginSubScenario("Scenario 4 : Delegate marshaled by ref with attribute [In,MarshalAs(UnmanagedType.Interface)].");
        Dele dele4 = new Dele(CommonMethod1);
        dele4 += CommonMethod2;
        dele4 += CommonMethod3;
        TestHelper.Assert(Take_DelegatePtrByInRefParam(ref dele4), "Take_DelegatePtrByInRefParam");
        TestHelper.Assert(dele4 != null, "dele4 does't set to null correctly.");

        TestHelper.BeginSubScenario("Scenario 5 : Delegate marshaled by val with attribute [Out,MarshalAs(UnmanagedType.Interface)].");
        Dele dele5 = new Dele(CommonMethod1);
        dele5 += CommonMethod2;
        dele5 += CommonMethod3;
        TestHelper.Assert(Take_DelegatePtrByOutValParam(dele5), "Take_DelegatePtrByOutValParam");
        TestHelper.Assert(dele5 != null, "dele5 does't set to null correctly");

        TestHelper.BeginSubScenario("Scenario 6 : Delegate marshaled by ref with attribute [Out,MarshalAs(UnmanagedType.Interface)].");
        Dele dele6 = null;
        Dele deleHelper = new Dele(CommonMethod1);
        deleHelper += CommonMethod2;
        TestHelper.Assert(Take_DelegatePtrByOutRefParam(out dele6, deleHelper), "Take_DelegatePtrByOutRefParam");
        dele6();
        TestHelper.Assert(COMMONMETHOD1_RESULT, RetFieldResult1(), "RetFieldResult1 return value is wrong");
        TestHelper.Assert(COMMONMETHOD2_RESULT, RetFieldResult2(), "RetFieldResult2 return value is wrong ");

        TestHelper.BeginSubScenario("Scenario 7 : Delegate marshaled by val with attribute [In,OutMarshalAs(UnmanagedType.Interface)].");
        Dele dele7 = new Dele(CommonMethod1);
        dele7 += CommonMethod2;
        dele7 += CommonMethod3;
        TestHelper.Assert(Take_DelegatePtrByInOutValParam(dele7), "Take_DelegatePtrByInOutValParam");

        TestHelper.BeginSubScenario("Scenario 8 : Delegate marshaled by ref with attribute [In,OutMarshalAs(MarshalAs(UnmanagedType.Interface)].");
        Dele dele8 = new Dele(CommonMethod1);
        dele8 += CommonMethod2;
        dele8 += CommonMethod3;
        TestHelper.Assert(Take_DelegatePtrByInOutRefParam(ref dele8), "Take_DelegatePtrByInOutRefParam");
        TestHelper.Assert(dele8 == null, "dele8 does't set to null correctly.");

        TestHelper.BeginSubScenario("Scenario 9 : return Delegate marshaled by val with attribute [return:MarshalAs(UnmanagedType.Interface)].");
        Dele dele9 = new Dele(CommonMethod1);
        dele9 += CommonMethod2;
        dele9 += CommonMethod3;
        Dele tempDele = ReturnDelegatePtrByVal(dele9);
        tempDele();
        TestHelper.Assert(COMMONMETHOD1_RESULT, RetFieldResult1(), "RetFieldResult1() return value is wrong");
        TestHelper.Assert(COMMONMETHOD2_RESULT, RetFieldResult2(), "RetFieldResult2() return value is wrong");
        TestHelper.Assert(COMMONMETHOD3_RESULT, RetFieldResult3(), "RetFieldResult3() return value is wrong");
#endif
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
