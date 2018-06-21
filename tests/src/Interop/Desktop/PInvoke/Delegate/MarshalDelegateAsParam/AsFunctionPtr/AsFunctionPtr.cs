using System;
using System.Runtime.InteropServices;

class Test
{
    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static int CommonMethodCalled1();

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static int CommonMethodCalled2();

    delegate int Dele();

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByValParam([MarshalAs(UnmanagedType.FunctionPtr)]Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByInValParam([In, MarshalAs(UnmanagedType.FunctionPtr)]Dele dele);

#if BUG_869118
    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByOutValParam([Out, MarshalAs(UnmanagedType.FunctionPtr)]Dele dele);
#endif
    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByInOutValParam([In, Out, MarshalAs(UnmanagedType.FunctionPtr)]Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByRefParam([MarshalAs(UnmanagedType.FunctionPtr)]ref Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByInRefParam([In, MarshalAs(UnmanagedType.FunctionPtr)]ref Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByOutRefParam([MarshalAs(UnmanagedType.FunctionPtr)]out Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByInOutRefParam([In, Out, MarshalAs(UnmanagedType.FunctionPtr)]ref Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    [return: MarshalAs(UnmanagedType.FunctionPtr)]
    extern static Dele ReturnDelegateByVal();

    const int COMMONMETHODCALLED1_RIGHT_RETVAL = 10;
    const int COMMONMETHODCALLED2_RIGHT_RETVAL = 20;


    static int Main(string[] args)
    {
        TestHelper.BeginSubScenario("Scenario 1 : Delegate marshaled by val with attribute [MarshalAs(UnmanagedType.FunctionPtr)].");
        Dele dele1 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByValParam(dele1), "TakeDelegateByValParam");

        TestHelper.BeginSubScenario("Scenario 2 : Delegate marshaled by ref with attribute [MarshalAs(UnmanagedType.FunctionPtr)].");
        Dele dele2 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByRefParam(ref dele2), "TakeDelegateByRefParam");
        TestHelper.Assert(COMMONMETHODCALLED2_RIGHT_RETVAL, dele2(), "dele2 is not point to method CommonMethodCalled2() correctly.");

        TestHelper.BeginSubScenario("Scenario 3 : Delegate marshaled by val with attribute [In,MarshalAs(UnmanagedType.FunctionPtr)].");
        Dele dele3 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByInValParam(dele3), "TakeDelegateByInValParam");

        TestHelper.BeginSubScenario("Scenario 4 : Delegate marshaled by ref with attribute [In,MarshalAs(UnmanagedType.FunctionPtr)].");
        Dele dele4 = new Dele(CommonMethodCalled1);
        Dele tempDele4 = dele4;
        TestHelper.Assert(TakeDelegateByInRefParam(ref dele4), "TakeDelegateByInRefParam");
        TestHelper.Assert(dele4 == tempDele4, "dele4 isnt equal to tempDele4");
#if BUG_869118
        TestHelper.BeginSubScenario("Scenario 5 : Delegate marshaled by val with attribute [Out,MarshalAs(UnmanagedType.FunctionPtr)].");
        Dele dele5 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByOutValParam(dele5), "TakeDelegateByOutValParam");
#endif
        TestHelper.BeginSubScenario("Scenario 6 : Delegate marshaled by ref with attribute [Out,MarshalAs(UnmanagedType.FunctionPtr)].");
        Dele dele6 = new Dele(CommonMethodCalled1);
        Dele tempDele6 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByOutRefParam(out dele6), "TakeDelegateByOutRefParam");
        TestHelper.Assert(dele6 != tempDele6, "dele6 shouldn't equal to tempDele6");
        TestHelper.Assert(COMMONMETHODCALLED2_RIGHT_RETVAL, dele6(), "dele6 is not point to method CommonMethodCalled2() correctly.");

        TestHelper.BeginSubScenario("Scenario 7 : Delegate marshaled by val with attribute [In,Out,MarshalAs(UnmanagedType.FunctionPtr)].");
        Dele dele7 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByInOutValParam(dele7), "TakeDelegateByInOutValParam");
        TestHelper.Assert(dele7 != null, "dele7 is null");

        TestHelper.BeginSubScenario("Scenario 8 : Delegate marshaled  by ref with attribute [In,Out,MarshalAs(UnmanagedType.FunctionPtr)].");
        Dele dele8 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByInOutRefParam(ref dele8), "TakeDelegateByInOutRefParam");
        TestHelper.Assert(COMMONMETHODCALLED2_RIGHT_RETVAL, dele8(), "dele8 is not point to method CommonMethodCalled2() correctly");

        TestHelper.BeginSubScenario("Scenario 9 : return Delegate marshaled by val with attribute [return:MarshalAs(UnmanagedType.FunctionPtr)].");
        Dele dele9 = ReturnDelegateByVal();
        TestHelper.Assert(COMMONMETHODCALLED1_RIGHT_RETVAL, dele9(), "dele9() return wrong value");
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