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
    extern static bool TakeDelegateByValParam(Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByRefParam(ref Dele dele);
    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByInValParam([In] Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByInRefParam([In] ref Dele dele);

#if BUG_869118
    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByOutValParam([Out] Dele dele);
#endif

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByOutRefParam(out Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByInOutValParam([In, Out] Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static bool TakeDelegateByInOutRefParam([In, Out] ref Dele dele);

    [DllImport("PInvoke_Delegate_AsParam.dll")]
    extern static Dele ReturnDelegateByVal();

    #region "Auxiliary Verification Value"
    const int COMMONMETHODCALLED1_RIGHT_RETVAL = 10;
    const int COMMONMETHODCALLED2_RIGHT_RETVAL = 20;
    #endregion

    static int Main(string[] args)
    {
        TestHelper.BeginSubScenario("Scenario 1 : Delegate marshaled by val with default attribute.");
        Dele dele1 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByValParam(dele1), "The return value is wrong in TakeDelegateByValParam.");

        TestHelper.BeginSubScenario("Scenario 2 : Delegate marshaled by ref with default attribute.");
        Dele dele2 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByRefParam(ref dele2), "Call on Native side");
        Console.WriteLine("\n\tCalling method CommonMethodCalled2() on the managed side...");
        TestHelper.Assert(COMMONMETHODCALLED2_RIGHT_RETVAL, dele2(), "Now dele2 point to method CommonMethodCalled2()");

        TestHelper.BeginSubScenario("Scenario 3 : Delegate marshaled by val with default attribute.");
        Dele dele3 = new Dele(CommonMethodCalled1);
        Dele tempDele3 = dele3;
        TestHelper.Assert(TakeDelegateByInValParam(dele3), "Calling method CommonMethodCalled1() on the native side...");
        TestHelper.Assert<Dele>(tempDele3, dele3, "Delegate marshaled by val with default attribute.");

        TestHelper.BeginSubScenario("\n\nScenario 4 : Delegate marshaled by ref with default attribute.");
        Dele dele4 = new Dele(CommonMethodCalled1);
        Dele tempDele4 = dele4;
        TestHelper.Assert(TakeDelegateByInRefParam(ref dele4), "Calling method CommonMethodCalled1() on the native side");
        TestHelper.Assert<Dele>(tempDele4, dele4, "Delegate marshaled by val with default attribute.");
#if BUG_869118
        TestHelper.BeginSubScenario("\n\nScenario 5 : Delegate marshaled by val with default attribute.");
        Dele dele5 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByOutValParam(dele5), "Calling method CommonMethodCalled1() on the native side");
        TestHelper.Assert(COMMONMETHODCALLED1_RIGHT_RETVAL, dele5(), "The Delegate is wrong");
#endif
        TestHelper.BeginSubScenario("\n\nScenario 6 : Delegate marshaled by ref with default attribute.");
        Dele dele6 = new Dele(CommonMethodCalled1);
        Dele tempDele6 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByOutRefParam(out dele6), "TakeDelegateByOutRefParam");
        TestHelper.Assert(COMMONMETHODCALLED2_RIGHT_RETVAL, dele6(), "Delegate marshaled by ref with default attribute");

        TestHelper.BeginSubScenario("\n\nScenario 7 : Delegate marshaled by val with default attribute.");
        Dele dele7 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByInOutValParam(dele7), "TakeDelegateByInOutValParam");
        TestHelper.Assert(dele7 != null, "The variable dele7 is null!");

        TestHelper.BeginSubScenario("\n\nScenario 8 : Delegate marshaled  by ref with default attribute.");
        Dele dele8 = new Dele(CommonMethodCalled1);
        TestHelper.Assert(TakeDelegateByInOutRefParam(ref dele8), "TakeDelegateByInOutRefParam");
        TestHelper.Assert(COMMONMETHODCALLED2_RIGHT_RETVAL, dele8(), "dele8 is not point to method CommonMethodCalled2() correctly");

        TestHelper.BeginSubScenario("\n\nScenario 9 : return Delegate marshaled by val with default attribute.");
        Dele dele9 = ReturnDelegateByVal();
        TestHelper.Assert(COMMONMETHODCALLED1_RIGHT_RETVAL, dele9(), "return Delegate marshaled by val with default attribute");

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