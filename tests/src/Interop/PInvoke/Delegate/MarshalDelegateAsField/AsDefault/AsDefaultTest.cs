// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using CoreFXTestLibrary;

class AsDefaultTest
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
        try{
            Console.WriteLine("Scenario 1 : Delegate marshaled as field in struct with Sequential.");
            Struct2_FuncPtrAsField1_Seq s = new Struct2_FuncPtrAsField1_Seq();
            s.verification = true;
            s.dele = new Dele(CommonMethod);
            Assert.IsTrue(TakeDelegateAsFieldInStruct_Seq(s), "Delegate marshaled as field in struct with Sequential.");

            Console.WriteLine("Scenario 2 : Delegate marshaled as field in struct with Explicit.");
            Struct2_FuncPtrAsField2_Exp s2 = new Struct2_FuncPtrAsField2_Exp();
            s2.verification = true;
            s2.dele = new Dele(CommonMethod);
            Assert.IsTrue(TakeDelegateAsFieldInStruct_Exp(s2), "Delegate marshaled as field in struct with Explicit");

            Console.WriteLine("Scenario 3 : Delegate marshaled as field in class with Sequential.");
            Class2_FuncPtrAsField3_Seq c3 = new Class2_FuncPtrAsField3_Seq();
            c3.verification = true;
            c3.dele = new Dele(CommonMethod);
            Assert.IsTrue(TakeDelegateAsFieldInClass_Seq(c3), "Delegate marshaled as field in class with Sequential.");

            Console.WriteLine("Scenario 4 : Delegate marshaled as field in class with Explicit.");
            Class2_FuncPtrAsField4_Exp c4 = new Class2_FuncPtrAsField4_Exp();
            c4.verification = true;
            c4.dele = new Dele(CommonMethod);
            Assert.IsTrue(TakeDelegateAsFieldInClass_Exp(c4), "Delegate marshaled as field in class with Explicit.");
            
            return 100;
        } catch (Exception e){
            Console.WriteLine($"Test Failure: {e}"); 
            return 101; 
        }
    }
}