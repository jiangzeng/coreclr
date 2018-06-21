using System;
using System.Runtime.InteropServices;

class Test
{
#if UNSPPORTED_Delegate_MarshalAs_Interface
    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static void CommonMethod1();

    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static void CommonMethod2();

    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static void CommonMethod3();

    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static bool Take_DelegatePtrAsFieldInStruct_Seq(Struct3_InterfacePtrAsField1_Seq sis);

    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static bool Take_DelegatePtrAsFieldInStruct_Exp(Struct3_InterfacePtrAsField2_Exp sie);

    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static bool Take_DelegatePtrAsFieldInClass_Seq(Class3_InterfacePtrAsField3_Seq cis);

    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static bool Take_DelegatePtrAsFieldInClass_Exp(Class3_InterfacePtrAsField4_Exp cie);
#endif

    static int Main()
    {
#if UNSPPORTED_Delegate_MarshalAs_Interface
        TestHelper.BeginSubScenario("Scenario 1 : Delegate marshaled as field in struct with Sequential.");
        Struct3_InterfacePtrAsField1_Seq sis = new Struct3_InterfacePtrAsField1_Seq();
        sis.verification = true;
        sis.dele = new Dele2(CommonMethod1);
        sis.dele += new Dele2(CommonMethod2);
        sis.dele += new Dele2(CommonMethod3);
        TestHelper.Assert(Take_DelegatePtrAsFieldInStruct_Seq(sis), "Delegate marshaled as field in struct with Sequential.");

        TestHelper.BeginSubScenario("Scenario 2 : Delegate marshaled as field in struct with Explicit.");
        Struct3_InterfacePtrAsField2_Exp sie = new Struct3_InterfacePtrAsField2_Exp();
        sie.verification = true;
        sie.dele = new Dele2(CommonMethod1);
        sie.dele += new Dele2(CommonMethod2);
        sie.dele += new Dele2(CommonMethod3);
        TestHelper.Assert(Take_DelegatePtrAsFieldInStruct_Exp(sie), "Delegate marshaled as field in struct with Explicit.");

        TestHelper.BeginSubScenario("Scenario 3 : Delegate marshaled as field in class with Sequential.");
        Class3_InterfacePtrAsField3_Seq cis = new Class3_InterfacePtrAsField3_Seq();
        cis.verification = true;
        cis.dele = new Dele2(CommonMethod1);
        cis.dele += new Dele2(CommonMethod2);
        cis.dele += new Dele2(CommonMethod3);
        TestHelper.Assert(Take_DelegatePtrAsFieldInClass_Seq(cis), "Delegate marshaled as field in class with Sequential");

        TestHelper.BeginSubScenario("Scenario 4 : Delegate marshaled as field in class with Sequential.");
        Class3_InterfacePtrAsField4_Exp cie = new Class3_InterfacePtrAsField4_Exp();
        cie.verification = true;
        cie.dele = new Dele2(CommonMethod1);
        cie.dele += new Dele2(CommonMethod2);
        cie.dele += new Dele2(CommonMethod3);
        TestHelper.Assert(Take_DelegatePtrAsFieldInClass_Exp(cie), "Delegate marshaled as field in class with Sequential");
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
