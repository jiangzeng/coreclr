using System;
using System.Runtime.InteropServices;

class Test
{
    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static int CommonMethod();

    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static bool TakeDelegateAsFieldInStruct_Seq(Struct2_FuncPtrAsField1_Seq s);

    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static bool TakeDelegateAsFieldInStruct_Exp(Struct2_FuncPtrAsField2_Exp s);

    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static bool TakeDelegateAsFieldInClass_Seq(Class2_FuncPtrAsField3_Seq s);

    [DllImport("PInvoke_Delegate_AsField.dll")]
    extern static bool TakeDelegateAsFieldInClass_Exp(Class2_FuncPtrAsField4_Exp s);

    static int Main()
    {
        TestHelper.BeginSubScenario("Scenario 1 : Delegate marshaled as field in struct with Sequential.");
        Struct2_FuncPtrAsField1_Seq s = new Struct2_FuncPtrAsField1_Seq();
        s.verification = true;
        s.dele = new Dele(CommonMethod);
        TestHelper.Assert(TakeDelegateAsFieldInStruct_Seq(s), "Delegate marshaled as field in struct with Sequential.");

        TestHelper.BeginSubScenario("Scenario 2 : Delegate marshaled as field in struct with Explicit.");
        Struct2_FuncPtrAsField2_Exp s2 = new Struct2_FuncPtrAsField2_Exp();
        s2.verification = true;
        s2.dele = new Dele(CommonMethod);
        TestHelper.Assert(TakeDelegateAsFieldInStruct_Exp(s2), "Delegate marshaled as field in struct with Explicit");

        TestHelper.BeginSubScenario("Scenario 3 : Delegate marshaled as field in class with Sequential.");
        Class2_FuncPtrAsField3_Seq c3 = new Class2_FuncPtrAsField3_Seq();
        c3.verification = true;
        c3.dele = new Dele(CommonMethod);
        TestHelper.Assert(TakeDelegateAsFieldInClass_Seq(c3), "Delegate marshaled as field in class with Sequential.");

        TestHelper.BeginSubScenario("Scenario 4 : Delegate marshaled as field in class with Explicit.");
        Class2_FuncPtrAsField4_Exp c4 = new Class2_FuncPtrAsField4_Exp();
        c4.verification = true;
        c4.dele = new Dele(CommonMethod);
        TestHelper.Assert(TakeDelegateAsFieldInClass_Exp(c4), "Delegate marshaled as field in class with Explicit.");

        if (TestHelper.Pass)
        {
            Console.WriteLine("Passed!");
            return 100;
        }
        else
        {
            Console.WriteLine("Passed!");
            return 101;
        }
    }
}