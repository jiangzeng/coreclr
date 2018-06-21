using System;
using System.Runtime.InteropServices;

public class Managed
{
    static int failures = 0;
    private static string strOne;
    private static string strTwo;

    enum StructID
    {
        InnerSequentialid,
        InnerArraySequentialid,
        CharSetAnsiSequentialid,
        CharSetUnicodeSequentialid,
        NumberSequentialid,
        StructSeqWithArrayFieldid,
        StructSeqWithEnumFieldid,
        StringStructSequentialAnsiid,
        StringStructSequentialUnicodeid,
        PritypeStructSeqWithUnmanagedTypeid,
        StructSequentialWithDelegateFieldid,
        IncludeOuterIntergerStructSequentialid,
        StructSequentialWithPointerFieldid
    }

    private static void InitialArray(int[] iarr, int[] icarr)
    {
        for (int i = 0; i < iarr.Length; i++)
        {
            iarr[i] = i;
        }

        for (int i = 1; i < icarr.Length + 1; i++)
        {
            icarr[i - 1] = i;
        }
    }

    private static void testMethod(StructSequentialWithDelegateField s9)
    {
        Console.WriteLine("\tThe first field of s9 is:"/*, s9.i32*/);
    }

    public static int Main()
    {
        RunMarshalSeqStructAsParamByVal();
        RunMarshalSeqStructAsParamByRef();
        RunMarshalSeqStructAsParamByValIn();
        RunMarshalSeqStructAsParamByRefIn();
        RunMarshalSeqStructAsParamByValOut();
        RunMarshalSeqStructAsParamByRefOut();
        RunMarshalSeqStructAsParamByValInOut();
        RunMarshalSeqStructAsParamByRefInOut();

        if (failures > 0)
        {
            Console.WriteLine("\nTEST FAILED!");
            return 101;
        }
        else
        {
            Console.WriteLine("\nTEST PASSED!");
            return 100;
        }
    }

    #region Struct with Layout Sequential scenario1
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal(InnerSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef(ref InnerSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal")]
    static extern bool MarshalStructAsParam_AsSeqByValIn([In] InnerSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn([In] ref InnerSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut([Out] InnerSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut(out InnerSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut([In, Out] InnerSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut([In, Out] ref InnerSequential str1);
    #endregion
    #region Struct with Layout Sequential scenario2
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal2(InnerArraySequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef2(ref InnerArraySequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal2")]
    static extern bool MarshalStructAsParam_AsSeqByValIn2([In] InnerArraySequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn2([In] ref InnerArraySequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut2([Out] InnerArraySequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut2(out InnerArraySequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal2")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut2([In, Out] InnerArraySequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef2")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut2([In, Out] ref InnerArraySequential str1);
    #endregion
    #region Struct with Layout Sequential scenario3
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal3(CharSetAnsiSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef3(ref CharSetAnsiSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal3")]
    static extern bool MarshalStructAsParam_AsSeqByValIn3([In] CharSetAnsiSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn3([In] ref CharSetAnsiSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut3([Out] CharSetAnsiSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut3(out CharSetAnsiSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal3")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut3([In, Out] CharSetAnsiSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef3")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut3([In, Out] ref CharSetAnsiSequential str1);
    #endregion
    #region Struct with Layout Sequential scenario4
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal4(CharSetUnicodeSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef4(ref CharSetUnicodeSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal4")]
    static extern bool MarshalStructAsParam_AsSeqByValIn4([In] CharSetUnicodeSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn4([In] ref CharSetUnicodeSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut4([Out] CharSetUnicodeSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut4(out CharSetUnicodeSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal4")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut4([In, Out] CharSetUnicodeSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef4")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut4([In, Out] ref CharSetUnicodeSequential str1);
    #endregion
    #region Struct with Layout Sequential scenario5
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal6(NumberSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef6(ref NumberSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal6")]
    static extern bool MarshalStructAsParam_AsSeqByValIn6([In] NumberSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn6([In] ref NumberSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut6([Out] NumberSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut6(out NumberSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal6")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut6([In, Out] NumberSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef6")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut6([In, Out] ref NumberSequential str1);
    #endregion
    #region Struct with Layout Sequential scenario6
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal7(StructSeqWithArrayField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef7(ref StructSeqWithArrayField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal7")]
    static extern bool MarshalStructAsParam_AsSeqByValIn7([In] StructSeqWithArrayField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn7([In] ref StructSeqWithArrayField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut7(out StructSeqWithArrayField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef7")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut7([In, Out] ref StructSeqWithArrayField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut7([Out] StructSeqWithArrayField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal7")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut7([In, Out] StructSeqWithArrayField str1);
    #endregion
    #region Struct with Layout Sequential scenario7
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal8(StructSeqWithEnumField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef8(ref StructSeqWithEnumField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal8")]
    static extern bool MarshalStructAsParam_AsSeqByValIn8([In] StructSeqWithEnumField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn8([In] ref StructSeqWithEnumField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal8")]
    static extern bool MarshalStructAsParam_AsSeqByValOut8([Out] StructSeqWithEnumField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut8(out StructSeqWithEnumField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal8")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut8([In, Out] StructSeqWithEnumField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef8")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut8([In, Out] ref StructSeqWithEnumField str1);
    #endregion
    #region Struct with Layout Sequential scenario8
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal9(StringStructSequentialAnsi str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef9(ref StringStructSequentialAnsi str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal9")]
    static extern bool MarshalStructAsParam_AsSeqByValIn9([In] StringStructSequentialAnsi str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn9([In] ref StringStructSequentialAnsi str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut9([Out] StringStructSequentialAnsi str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut9(out StringStructSequentialAnsi str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal9")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut9([In, Out] StringStructSequentialAnsi str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef9")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut9([In, Out] ref StringStructSequentialAnsi str1);
    #endregion
    #region Struct with Layout Sequential scenario9
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal10(StringStructSequentialUnicode str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef10(ref StringStructSequentialUnicode str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal10")]
    static extern bool MarshalStructAsParam_AsSeqByValIn10([In] StringStructSequentialUnicode str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn10([In] ref StringStructSequentialUnicode str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut10([Out] StringStructSequentialUnicode str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut10(out StringStructSequentialUnicode str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal10")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut10([In, Out] StringStructSequentialUnicode str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef10")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut10([In, Out] ref StringStructSequentialUnicode str1);
    #endregion
    #region Struct with Layout Sequential scenario10
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal11(PritypeStructSeqWithUnmanagedType str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef11(ref PritypeStructSeqWithUnmanagedType str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal11")]
    static extern bool MarshalStructAsParam_AsSeqByValIn11([In] PritypeStructSeqWithUnmanagedType str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn11([In] ref PritypeStructSeqWithUnmanagedType str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut11([Out] PritypeStructSeqWithUnmanagedType str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut11(out PritypeStructSeqWithUnmanagedType str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal11")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut11([In, Out] PritypeStructSeqWithUnmanagedType str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef11")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut11([In, Out] ref PritypeStructSeqWithUnmanagedType str1);
    #endregion
    #region Struct with Layout Sequential scenario11
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal12(StructSequentialWithDelegateField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef12(ref StructSequentialWithDelegateField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal12")]
    static extern bool MarshalStructAsParam_AsSeqByValIn12(StructSequentialWithDelegateField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef12")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn12([In] ref StructSequentialWithDelegateField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut12([Out] StructSequentialWithDelegateField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut12(out StructSequentialWithDelegateField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal12")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut12([In, Out] StructSequentialWithDelegateField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef12")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut12([In, Out] ref StructSequentialWithDelegateField str1);
    #endregion
    #region Struct with Layout Sequential scenario12
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal13(IncludeOuterIntergerStructSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef13(ref IncludeOuterIntergerStructSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal13")]
    static extern bool MarshalStructAsParam_AsSeqByValIn13([In] IncludeOuterIntergerStructSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn13([In] ref IncludeOuterIntergerStructSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut13([Out] IncludeOuterIntergerStructSequential str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut13(out IncludeOuterIntergerStructSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal13")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut13([In, Out] IncludeOuterIntergerStructSequential str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef13")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut13([In, Out] ref IncludeOuterIntergerStructSequential str1);
    #endregion
    #region Struct with Layout Sequential scenario13
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal14(StructSequentialWithPointerField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef14(ref StructSequentialWithPointerField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal14")]
    static extern bool MarshalStructAsParam_AsSeqByValIn14([In] StructSequentialWithPointerField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn14([In] ref StructSequentialWithPointerField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal14")]
    static extern bool MarshalStructAsParam_AsSeqByValOut14([Out] StructSequentialWithPointerField str1);
    [DllImport("MarshalStructAsParam.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut14(out StructSequentialWithPointerField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal14")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut14([In, Out] StructSequentialWithPointerField str1);
    [DllImport("MarshalStructAsParam.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef14")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut14([In, Out] ref StructSequentialWithPointerField str1);
    #endregion

    #region Marshal struct method in PInvoke
   
    unsafe private static void MarshalStructAsParam_AsSeqByVal(StructID id)
    {
        try
        {
            switch (id)
            {
                case StructID.InnerSequentialid:
                    InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                    InnerSequential cloneInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal...");
                    if (!MarshalStructAsParam_AsSeqByVal(sourceInnerSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerSequential(sourceInnerSequential, cloneInnerSequential, "MarshalStructAsParam_AsSeqByVal"))
                    {
                        failures++;
                    }
                    break;
                case StructID.InnerArraySequentialid:
                    InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                    InnerArraySequential cloneInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal2...");
                    if (!MarshalStructAsParam_AsSeqByVal2(sourceInnerArraySequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal2.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerArraySequential(sourceInnerArraySequential, cloneInnerArraySequential, "MarshalStructAsParam_AsSeqByVal2"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetAnsiSequentialid:
                    CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                    CharSetAnsiSequential cloneStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal3...");
                    if (!MarshalStructAsParam_AsSeqByVal3(sourceStr1))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal3.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetAnsiSequential(sourceStr1, cloneStr1, "MarshalStructAsParam_AsSeqByVal3"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetUnicodeSequentialid:
                    CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                    CharSetUnicodeSequential cloneStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal4...");
                    if (!MarshalStructAsParam_AsSeqByVal4(sourceStr2))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal4.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetUnicodeSequential(sourceStr2, cloneStr2, "MarshalStructAsParam_AsSeqByVal4"))
                    {
                        failures++;
                    }
                    break;
                case StructID.NumberSequentialid:
                    NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                    NumberSequential cloneNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal6...");
                    if (!MarshalStructAsParam_AsSeqByVal6(sourceNumberSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal6.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateNumberSequential(sourceNumberSequential, cloneNumberSequential, "MarshalStructAsParam_AsSeqByVal6"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithArrayFieldid:
                    int[] iarr = new int[256];
                    int[] icarr = new int[256];
                    InitialArray(iarr, icarr);

                    StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                    StructSeqWithArrayField cloneStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal7...");
                    if (!MarshalStructAsParam_AsSeqByVal7(sourceStructSeqWithArrayField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal7.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, cloneStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByVal7"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithEnumFieldid:
                    Enum1 enums = Enum1.e1;
                    Enum1 enumcl = Enum1.e1;
                    //Enum1 enumch = Enum1.e2;
                    StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                    StructSeqWithEnumField cloneStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enumcl);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal8...");
                    if (!MarshalStructAsParam_AsSeqByVal8(sourceStructSeqWithEnumField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal8.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, cloneStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByVal8"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialAnsiid:
                    strOne = new String('a', 512);
                    strTwo = new String('b', 512);
                    StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                    StringStructSequentialAnsi cloneStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal9...");
                    if (!MarshalStructAsParam_AsSeqByVal9(sourceStringStructSequentialAnsi))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal9.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, cloneStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByVal9"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialUnicodeid:
                    strOne = new String('a', 256);
                    strTwo = new String('b', 256);
                    StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                    StringStructSequentialUnicode cloneStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal10...");
                    if (!MarshalStructAsParam_AsSeqByVal10(sourceStringStructSequentialUnicode))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal10.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                        cloneStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByVal10"))
                    {
                        failures++;
                    }
                    break;
                case StructID.PritypeStructSeqWithUnmanagedTypeid:
                    PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                    PritypeStructSeqWithUnmanagedType clonePritypeStructSeqWithUnmanagedType =
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal11...");
                    if (!MarshalStructAsParam_AsSeqByVal11(sourcePritypeStructSeqWithUnmanagedType))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal11.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                        clonePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByVal11"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithDelegateFieldid:
                    StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                    StructSequentialWithDelegateField cloneStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal12...");
                    if (!MarshalStructAsParam_AsSeqByVal12(sourceStructSequentialWithDelegateField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal12.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                        cloneStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByVal12"))
                    {
                        failures++;
                    }
                    break;
                case StructID.IncludeOuterIntergerStructSequentialid:
                    IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                    IncludeOuterIntergerStructSequential cloneIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal13...");
                    if (!MarshalStructAsParam_AsSeqByVal13(sourceIncludeOuterIntergerStructSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal13.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                        cloneIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByVal13"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithPointerFieldid:
                    StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                    StructSequentialWithPointerField cloneStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByVal14...");
                    if (!MarshalStructAsParam_AsSeqByVal14(sourceStructSequentialWithPointerField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByVal14.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                        cloneStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByVal14"))
                    {
                        failures++;
                    }
                    break;

                default:
                    Console.WriteLine("\tThere is not the struct id");
                    failures++;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            failures++;
        }

    }
    
    unsafe private static void MarshalStructAsParam_AsSeqByRef(StructID id)
    {
        try
        {
            switch (id)
            {
                case StructID.InnerSequentialid:
                    InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                    InnerSequential changeInnerSequential = Helper.NewInnerSequential(77, 77.0F, "changed string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef...");
                    if (!MarshalStructAsParam_AsSeqByRef(ref sourceInnerSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerSequential(sourceInnerSequential, changeInnerSequential, "MarshalStructAsParam_AsSeqByRef"))
                    {
                        failures++;
                    }
                    break;
                case StructID.InnerArraySequentialid:
                    InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                    InnerArraySequential changeInnerArraySequential = Helper.NewInnerArraySequential(77, 77.0F, "changed string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef2...");
                    if (!MarshalStructAsParam_AsSeqByRef2(ref sourceInnerArraySequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef2.Expected:True;Actual:False");
                    }
                    if (!Helper.ValidateInnerArraySequential(sourceInnerArraySequential, changeInnerArraySequential, "MarshalStructAsParam_AsSeqByRef2"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetAnsiSequentialid:
                    CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                    CharSetAnsiSequential changeStr1 = Helper.NewCharSetAnsiSequential("change string", 'n');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef3...");
                    if (!MarshalStructAsParam_AsSeqByRef3(ref sourceStr1))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef3.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetAnsiSequential(sourceStr1, changeStr1, "MarshalStructAsParam_AsSeqByRef3"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetUnicodeSequentialid:
                    CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                    CharSetUnicodeSequential changeStr2 = Helper.NewCharSetUnicodeSequential("change string", 'n');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef4...");
                    if (!MarshalStructAsParam_AsSeqByRef4(ref sourceStr2))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef4.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetUnicodeSequential(sourceStr2, changeStr2, "MarshalStructAsParam_AsSeqByRef4"))
                    {
                        failures++;
                    }
                    break;
                case StructID.NumberSequentialid:
                    NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                    NumberSequential changeNumberSequential = Helper.NewNumberSequential(0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef6...");
                    if (!MarshalStructAsParam_AsSeqByRef6(ref sourceNumberSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef6.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateNumberSequential(sourceNumberSequential, changeNumberSequential, "MarshalStructAsParam_AsSeqByRef6"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithArrayFieldid:
                    int[] iarr = new int[256];
                    int[] icarr = new int[256];
                    InitialArray(iarr, icarr);

                    StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                    StructSeqWithArrayField changeStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(false, "change string", icarr);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef7...");
                    if (!MarshalStructAsParam_AsSeqByRef7(ref sourceStructSeqWithArrayField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef7.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, changeStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByRef7"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithEnumFieldid:
                    Enum1 enums = Enum1.e1;
                    Enum1 enumch = Enum1.e2;
                    StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                    StructSeqWithEnumField changeStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(64, "change string", enumch);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef8...");
                    if (!MarshalStructAsParam_AsSeqByRef8(ref sourceStructSeqWithEnumField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef8.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, changeStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByRef8"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialAnsiid:
                    strOne = new String('a', 512);
                    strTwo = new String('b', 512);
                    StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                    StringStructSequentialAnsi changeStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strTwo, strOne);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef9...");
                    if (!MarshalStructAsParam_AsSeqByRef9(ref sourceStringStructSequentialAnsi))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef9.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, changeStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByRef9"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialUnicodeid:
                    strOne = new String('a', 256);
                    strTwo = new String('b', 256);
                    StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                    StringStructSequentialUnicode changeStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strTwo, strOne);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef10...");
                    if (!MarshalStructAsParam_AsSeqByRef10(ref sourceStringStructSequentialUnicode))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef10.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                        changeStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByRef10"))
                    {
                        failures++;
                    }
                    break;
                case StructID.PritypeStructSeqWithUnmanagedTypeid:
                    PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                    PritypeStructSeqWithUnmanagedType changePritypeStructSeqWithUnmanagedType =
                        Helper.NewPritypeStructSeqWithUnmanagedType("world", false, /*256.00m,*/ 1, /*256, 256,*/ 64);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef11...");
                    if (!MarshalStructAsParam_AsSeqByRef11(ref sourcePritypeStructSeqWithUnmanagedType))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef11.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                        changePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByRef11"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithDelegateFieldid:
                    StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128, */new TestDelegate1(testMethod));
                    StructSequentialWithDelegateField changeStructSequentialWithDelegateField = Helper.NewStructSequentialWithDelegateField(/*256,*/ null);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef12...");
                    if (!MarshalStructAsParam_AsSeqByRef12(ref sourceStructSequentialWithDelegateField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef12.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                        changeStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByRef12"))
                    {
                        failures++;
                    }
                    break;
                case StructID.IncludeOuterIntergerStructSequentialid:
                    IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                    IncludeOuterIntergerStructSequential changeIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(64, 64);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef13...");
                    if (!MarshalStructAsParam_AsSeqByRef13(ref sourceIncludeOuterIntergerStructSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef13.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                        changeIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByRef13"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithPointerFieldid:
                    StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                    StructSequentialWithPointerField changeStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(32), 64);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRef14...");
                    if (!MarshalStructAsParam_AsSeqByRef14(ref sourceStructSequentialWithPointerField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRef14.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                        changeStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByRef14"))
                    {
                        failures++;
                    }
                    break;

                default:
                    Console.WriteLine("\tThere is not the struct id");
                    failures++;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            failures++;
        }
    }
  
    unsafe private static void MarshalStructAsParam_AsSeqByValIn(StructID id)
    {
        try
        {
            switch (id)
            {
                case StructID.InnerSequentialid:
                    InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                    InnerSequential cloneInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn...");
                    if (!MarshalStructAsParam_AsSeqByValIn(sourceInnerSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerSequential(sourceInnerSequential, cloneInnerSequential, "MarshalStructAsParam_AsSeqByValIn"))
                    {
                        failures++;
                    }
                    break;
                case StructID.InnerArraySequentialid:
                    InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                    InnerArraySequential cloneInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn2...");
                    if (!MarshalStructAsParam_AsSeqByValIn2(sourceInnerArraySequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn2.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerArraySequential(sourceInnerArraySequential, cloneInnerArraySequential, "MarshalStructAsParam_AsSeqByValIn2"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetAnsiSequentialid:
                    CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                    CharSetAnsiSequential cloneStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn3...");
                    if (!MarshalStructAsParam_AsSeqByValIn3(sourceStr1))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn3.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetAnsiSequential(sourceStr1, cloneStr1, "MarshalStructAsParam_AsSeqByValIn3"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetUnicodeSequentialid:
                    CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                    CharSetUnicodeSequential cloneStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn4...");
                    if (!MarshalStructAsParam_AsSeqByValIn4(sourceStr2))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn4.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetUnicodeSequential(sourceStr2, cloneStr2, "MarshalStructAsParam_AsSeqByValIn4"))
                    {
                        failures++;
                    }
                    break;
                case StructID.NumberSequentialid:
                    NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                    NumberSequential cloneNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn6...");
                    if (!MarshalStructAsParam_AsSeqByValIn6(sourceNumberSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn6.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateNumberSequential(sourceNumberSequential, cloneNumberSequential, "MarshalStructAsParam_AsSeqByValIn6"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithArrayFieldid:
                    int[] iarr = new int[256];
                    int[] icarr = new int[256];
                    InitialArray(iarr, icarr);

                    StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                    StructSeqWithArrayField cloneStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn7...");
                    if (!MarshalStructAsParam_AsSeqByValIn7(sourceStructSeqWithArrayField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn7.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, cloneStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByValIn7"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithEnumFieldid:
                    Enum1 enums = Enum1.e1;
                    Enum1 enumcl = Enum1.e1;
                    StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                    StructSeqWithEnumField cloneStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enumcl);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn8...");
                    if (!MarshalStructAsParam_AsSeqByValIn8(sourceStructSeqWithEnumField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn8.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, cloneStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByValIn8"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialAnsiid:
                    strOne = new String('a', 512);
                    strTwo = new String('b', 512);
                    StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                    StringStructSequentialAnsi cloneStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn9...");
                    if (!MarshalStructAsParam_AsSeqByValIn9(sourceStringStructSequentialAnsi))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn9.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, cloneStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByValIn9"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialUnicodeid:
                    strOne = new String('a', 256);
                    strTwo = new String('b', 256);
                    StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                    StringStructSequentialUnicode cloneStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn10...");
                    if (!MarshalStructAsParam_AsSeqByValIn10(sourceStringStructSequentialUnicode))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn10.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                        cloneStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByValIn10"))
                    {
                        failures++;
                    }
                    break;
                case StructID.PritypeStructSeqWithUnmanagedTypeid:
                    PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                    PritypeStructSeqWithUnmanagedType clonePritypeStructSeqWithUnmanagedType =
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn11...");
                    if (!MarshalStructAsParam_AsSeqByValIn11(sourcePritypeStructSeqWithUnmanagedType))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn11.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                        clonePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByValIn11"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithDelegateFieldid:
                    StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                    StructSequentialWithDelegateField cloneStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn12...");
                    if (!MarshalStructAsParam_AsSeqByValIn12(sourceStructSequentialWithDelegateField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn12.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                        cloneStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByValIn12"))
                    {
                        failures++;
                    }
                    break;
                case StructID.IncludeOuterIntergerStructSequentialid:
                    IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                    IncludeOuterIntergerStructSequential cloneIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn13...");
                    if (!MarshalStructAsParam_AsSeqByValIn13(sourceIncludeOuterIntergerStructSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn13.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                        cloneIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByValIn13"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithPointerFieldid:
                    StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                    StructSequentialWithPointerField cloneStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValIn14...");
                    if (!MarshalStructAsParam_AsSeqByValIn14(sourceStructSequentialWithPointerField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValIn14.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                        cloneStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByValIn14"))
                    {
                        failures++;
                    }
                    break;

                default:
                    Console.WriteLine("\tThere is not the struct id");
                    failures++;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            failures++;
        }
    }
    
    unsafe private static void MarshalStructAsParam_AsSeqByRefIn(StructID id)
    {
        try
        {
            switch (id)
            {
                case StructID.InnerSequentialid:
                    InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                    InnerSequential cloneInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn...");
                    if (!MarshalStructAsParam_AsSeqByRefIn(ref sourceInnerSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerSequential(sourceInnerSequential, cloneInnerSequential, "MarshalStructAsParam_AsSeqByRefIn"))
                    {
                        failures++;
                    }
                    break;
                case StructID.InnerArraySequentialid:
                    InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                    InnerArraySequential cloneInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn2...");
                    if (!MarshalStructAsParam_AsSeqByRefIn2(ref sourceInnerArraySequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn2.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerArraySequential(sourceInnerArraySequential, cloneInnerArraySequential, "MarshalStructAsParam_AsSeqByRefIn2"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetAnsiSequentialid:
                    CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                    CharSetAnsiSequential cloneStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn3...");
                    if (!MarshalStructAsParam_AsSeqByRefIn3(ref sourceStr1))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn3.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetAnsiSequential(sourceStr1, cloneStr1, "MarshalStructAsParam_AsSeqByRefIn3"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetUnicodeSequentialid:
                    CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                    CharSetUnicodeSequential cloneStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn4...");
                    if (!MarshalStructAsParam_AsSeqByRefIn4(ref sourceStr2))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn4.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetUnicodeSequential(sourceStr2, cloneStr2, "MarshalStructAsParam_AsSeqByRefIn4"))
                    {
                        failures++;
                    }
                    break;
                case StructID.NumberSequentialid:
                    NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                    NumberSequential changeNumberSequential = Helper.NewNumberSequential(0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn6...");
                    if (!MarshalStructAsParam_AsSeqByRefIn6(ref sourceNumberSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn6.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateNumberSequential(sourceNumberSequential, changeNumberSequential, "MarshalStructAsParam_AsSeqByRefIn6"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithArrayFieldid:
                    int[] iarr = new int[256];
                    int[] icarr = new int[256];
                    InitialArray(iarr, icarr);

                    StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                    StructSeqWithArrayField cloneStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn7...");
                    if (!MarshalStructAsParam_AsSeqByRefIn7(ref sourceStructSeqWithArrayField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn7.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, cloneStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByRefIn7"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithEnumFieldid:
                    Enum1 enums = Enum1.e1;
                    Enum1 enumcl = Enum1.e1;
                    StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                    StructSeqWithEnumField cloneStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enumcl);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn8...");
                    if (!MarshalStructAsParam_AsSeqByRefIn8(ref sourceStructSeqWithEnumField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn8.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, cloneStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByRefIn8"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialAnsiid:
                    strOne = new String('a', 512);
                    strTwo = new String('b', 512);
                    StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                    StringStructSequentialAnsi cloneStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn9...");
                    if (!MarshalStructAsParam_AsSeqByRefIn9(ref sourceStringStructSequentialAnsi))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn9.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, cloneStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByRefIn9"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialUnicodeid:
                    strOne = new String('a', 256);
                    strTwo = new String('b', 256);
                    StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                    StringStructSequentialUnicode cloneStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn10...");
                    if (!MarshalStructAsParam_AsSeqByRefIn10(ref sourceStringStructSequentialUnicode))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn10.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                        cloneStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByRefIn10"))
                    {
                        failures++;
                    }
                    break;
                case StructID.PritypeStructSeqWithUnmanagedTypeid:
                    PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                    PritypeStructSeqWithUnmanagedType clonePritypeStructSeqWithUnmanagedType =
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn11...");
                    if (!MarshalStructAsParam_AsSeqByRefIn11(ref sourcePritypeStructSeqWithUnmanagedType))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn11.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                        clonePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByRefIn11"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithDelegateFieldid:
                    StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                    StructSequentialWithDelegateField cloneStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn12...");
                    if (!MarshalStructAsParam_AsSeqByRefIn12(ref sourceStructSequentialWithDelegateField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn12.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                        cloneStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByRefIn12"))
                    {
                        failures++;
                    }
                    break;
                case StructID.IncludeOuterIntergerStructSequentialid:
                    IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                    IncludeOuterIntergerStructSequential changeIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn13...");
                    if (!MarshalStructAsParam_AsSeqByRefIn13(ref sourceIncludeOuterIntergerStructSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn13.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                        changeIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByRefIn13"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithPointerFieldid:
                    StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                    StructSequentialWithPointerField changeStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(32), 64);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefIn14...");
                    if (!MarshalStructAsParam_AsSeqByRefIn14(ref sourceStructSequentialWithPointerField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefIn14.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                        changeStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByRefIn14"))
                    {
                        failures++;
                    }
                    break;

                default:
                    Console.WriteLine("\tThere is not the struct id");
                    failures++;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            failures++;
        }
    }
   
    unsafe private static void MarshalStructAsParam_AsSeqByValOut(StructID id)
    {
        try
        {
            switch (id)
            {
                case StructID.InnerSequentialid:
                    InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                    InnerSequential cloneInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut...");
                    if (!MarshalStructAsParam_AsSeqByValOut(sourceInnerSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerSequential(sourceInnerSequential, cloneInnerSequential, "MarshalStructAsParam_AsSeqByValOut"))
                    {
                        failures++;
                    }
                    break;
                case StructID.InnerArraySequentialid:
                    InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                    InnerArraySequential cloneInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut2...");
                    if (!MarshalStructAsParam_AsSeqByValOut2(sourceInnerArraySequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut2.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerArraySequential(sourceInnerArraySequential, cloneInnerArraySequential, "MarshalStructAsParam_AsSeqByValOut2"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetAnsiSequentialid:
                    CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                    CharSetAnsiSequential cloneStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut3...");
                    if (!MarshalStructAsParam_AsSeqByValOut3(sourceStr1))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut3.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetAnsiSequential(sourceStr1, cloneStr1, "MarshalStructAsParam_AsSeqByValOut3"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetUnicodeSequentialid:
                    CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                    CharSetUnicodeSequential cloneStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut4...");
                    if (!MarshalStructAsParam_AsSeqByValOut4(sourceStr2))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut4.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetUnicodeSequential(sourceStr2, cloneStr2, "MarshalStructAsParam_AsSeqByValOut4"))
                    {
                        failures++;
                    }
                    break;
                case StructID.NumberSequentialid:
                    NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                    NumberSequential cloneNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut6...");
                    if (!MarshalStructAsParam_AsSeqByValOut6(sourceNumberSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut6.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateNumberSequential(sourceNumberSequential, cloneNumberSequential, "MarshalStructAsParam_AsSeqByValOut6"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithArrayFieldid:
                    int[] iarr = new int[256];
                    int[] icarr = new int[256];
                    InitialArray(iarr, icarr);

                    StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                    StructSeqWithArrayField cloneStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut7...");
                    if (!MarshalStructAsParam_AsSeqByValOut7(sourceStructSeqWithArrayField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut7.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, cloneStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByValOut7"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithEnumFieldid:
                    Enum1 enums = Enum1.e1;
                    Enum1 enumcl = Enum1.e1;
                    StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                    StructSeqWithEnumField cloneStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enumcl);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut8...");
                    if (!MarshalStructAsParam_AsSeqByValOut8(sourceStructSeqWithEnumField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut8.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, cloneStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByValOut8"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialAnsiid:
                    strOne = new String('a', 512);
                    strTwo = new String('b', 512);
                    StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                    StringStructSequentialAnsi cloneStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut9...");
                    if (!MarshalStructAsParam_AsSeqByValOut9(sourceStringStructSequentialAnsi))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut9.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, cloneStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByValOut9"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialUnicodeid:
                    strOne = new String('a', 256);
                    strTwo = new String('b', 256);
                    StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                    StringStructSequentialUnicode cloneStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut10...");
                    if (!MarshalStructAsParam_AsSeqByValOut10(sourceStringStructSequentialUnicode))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut10.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                        cloneStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByValOut10"))
                    {
                        failures++;
                    }
                    break;
                case StructID.PritypeStructSeqWithUnmanagedTypeid:
                    PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                    PritypeStructSeqWithUnmanagedType clonePritypeStructSeqWithUnmanagedType =
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut11...");
                    if (!MarshalStructAsParam_AsSeqByValOut11(sourcePritypeStructSeqWithUnmanagedType))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut11.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                        clonePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByValOut11"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithDelegateFieldid:
                    StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                    StructSequentialWithDelegateField cloneStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut12...");
                    if (!MarshalStructAsParam_AsSeqByValOut12(sourceStructSequentialWithDelegateField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut12.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                        cloneStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByValOut12"))
                    {
                        failures++;
                    }
                    break;
                case StructID.IncludeOuterIntergerStructSequentialid:
                    IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                    IncludeOuterIntergerStructSequential cloneIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut13...");
                    if (!MarshalStructAsParam_AsSeqByValOut13(sourceIncludeOuterIntergerStructSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut13.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                        cloneIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByValOut13"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithPointerFieldid:
                    StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                    StructSequentialWithPointerField cloneStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValOut14...");
                    if (!MarshalStructAsParam_AsSeqByValOut14(sourceStructSequentialWithPointerField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValOut14.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                        cloneStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByValOut14"))
                    {
                        failures++;
                    }
                    break;

                default:
                    Console.WriteLine("\tThere is not the struct id");
                    failures++;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            failures++;
        }

    }
  
    unsafe private static void MarshalStructAsParam_AsSeqByRefOut(StructID id)
    {
        try
        {
            switch (id)
            {
                case StructID.InnerSequentialid:
                    InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                    InnerSequential changeInnerSequential = Helper.NewInnerSequential(77, 77.0F, "changed string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut...");
                    if (!MarshalStructAsParam_AsSeqByRefOut(out sourceInnerSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerSequential(sourceInnerSequential, changeInnerSequential, "MarshalStructAsParam_AsSeqByRefOut"))
                    {
                        failures++;
                    }
                    break;
                case StructID.InnerArraySequentialid:
                    InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                    InnerArraySequential changeInnerArraySequential = Helper.NewInnerArraySequential(77, 77.0F, "changed string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut2...");
                    if (!MarshalStructAsParam_AsSeqByRefOut2(out sourceInnerArraySequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut2.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerArraySequential(sourceInnerArraySequential, changeInnerArraySequential, "MarshalStructAsParam_AsSeqByRefOut2"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetAnsiSequentialid:
                    CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                    CharSetAnsiSequential changeStr1 = Helper.NewCharSetAnsiSequential("change string", 'n');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut3...");
                    if (!MarshalStructAsParam_AsSeqByRefOut3(out sourceStr1))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut3.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetAnsiSequential(sourceStr1, changeStr1, "MarshalStructAsParam_AsSeqByRefOut3"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetUnicodeSequentialid:
                    CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                    CharSetUnicodeSequential changeStr2 = Helper.NewCharSetUnicodeSequential("change string", 'n');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut4...");
                    if (!MarshalStructAsParam_AsSeqByRefOut4(out sourceStr2))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut4.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetUnicodeSequential(sourceStr2, changeStr2, "MarshalStructAsParam_AsSeqByRefOut4"))
                    {
                        failures++;
                    }
                    break;
                case StructID.NumberSequentialid:
                    NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                    NumberSequential changeNumberSequential = Helper.NewNumberSequential(0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut6...");
                    if (!MarshalStructAsParam_AsSeqByRefOut6(out sourceNumberSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut6.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateNumberSequential(sourceNumberSequential, changeNumberSequential, "MarshalStructAsParam_AsSeqByRefOut6"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithArrayFieldid:
                    int[] iarr = new int[256];
                    int[] icarr = new int[256];
                    InitialArray(iarr, icarr);

                    StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                    StructSeqWithArrayField changeStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(false, "change string", icarr);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut7...");
                    if (!MarshalStructAsParam_AsSeqByRefOut7(out sourceStructSeqWithArrayField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut7.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, changeStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByRefOut7"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithEnumFieldid:
                    Enum1 enums = Enum1.e1;
                    Enum1 enumch = Enum1.e2;
                    StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                    StructSeqWithEnumField changeStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(64, "change string", enumch);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut8...");
                    if (!MarshalStructAsParam_AsSeqByRefOut8(out sourceStructSeqWithEnumField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut8.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, changeStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByRefOut8"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialAnsiid:
                    strOne = new String('a', 512);
                    strTwo = new String('b', 512);
                    StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                    StringStructSequentialAnsi changeStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strTwo, strOne);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut9...");
                    if (!MarshalStructAsParam_AsSeqByRefOut9(out sourceStringStructSequentialAnsi))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut9.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, changeStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByRefOut9"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialUnicodeid:
                    strOne = new String('a', 256);
                    strTwo = new String('b', 256);
                    StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                    StringStructSequentialUnicode changeStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strTwo, strOne);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut10...");
                    if (!MarshalStructAsParam_AsSeqByRefOut10(out sourceStringStructSequentialUnicode))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut10.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                        changeStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByRefOut10"))
                    {
                        failures++;
                    }
                    break;
                case StructID.PritypeStructSeqWithUnmanagedTypeid:
                    PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                    PritypeStructSeqWithUnmanagedType changePritypeStructSeqWithUnmanagedType =
                        Helper.NewPritypeStructSeqWithUnmanagedType("world", false, /*256.00m,*/ 1, /*256, 256,*/ 64);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut11...");
                    if (!MarshalStructAsParam_AsSeqByRefOut11(out sourcePritypeStructSeqWithUnmanagedType))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut11.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                        changePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByRefOut11"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithDelegateFieldid:
                    StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut12...");
                    if (!MarshalStructAsParam_AsSeqByRefOut12(out sourceStructSequentialWithDelegateField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut12.Expected:True;Actual:False");
                        failures++;
                    }
                    else if (/*sourceStructSequentialWithDelegateField.i32 != 256 || */sourceStructSequentialWithDelegateField.myDelegate1 == null)
                    {
                        Console.WriteLine("\tFAILED! Native to Managed failed in MarshalStructAsParam_AsSeqByRefOut12.");
                        failures++;
                    }
                    else
                    {
                        Console.WriteLine("\tPASSED!");
                    }
                    break;
                case StructID.IncludeOuterIntergerStructSequentialid:
                    IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                    IncludeOuterIntergerStructSequential changeIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(64, 64);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut13...");
                    if (!MarshalStructAsParam_AsSeqByRefOut13(out sourceIncludeOuterIntergerStructSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut13.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                        changeIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByRefOut13"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithPointerFieldid:
                    StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                    StructSequentialWithPointerField changeStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(32), 64);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefOut14...");
                    if (!MarshalStructAsParam_AsSeqByRefOut14(out sourceStructSequentialWithPointerField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefOut14.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                        changeStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByRefOut14"))
                    {
                        failures++;
                    }
                    break;

                default:
                    Console.WriteLine("\tThere is not the struct id");
                    failures++;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            failures++;
        }
    }
   
    unsafe private static void MarshalStructAsParam_AsSeqByValInOut(StructID id)
    {
        try
        {
            switch (id)
            {
                case StructID.InnerSequentialid:
                    InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                    InnerSequential cloneInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut...");
                    if (!MarshalStructAsParam_AsSeqByValInOut(sourceInnerSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerSequential(sourceInnerSequential, cloneInnerSequential, "MarshalStructAsParam_AsSeqByValInOut"))
                    {
                        failures++;
                    }
                    break;
                case StructID.InnerArraySequentialid:
                    InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                    InnerArraySequential cloneInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut2...");
                    if (!MarshalStructAsParam_AsSeqByValInOut2(sourceInnerArraySequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut2.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerArraySequential(sourceInnerArraySequential, cloneInnerArraySequential, "MarshalStructAsParam_AsSeqByValInOut2"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetAnsiSequentialid:
                    CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                    CharSetAnsiSequential cloneStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut3...");
                    if (!MarshalStructAsParam_AsSeqByValInOut3(sourceStr1))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut3.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetAnsiSequential(sourceStr1, cloneStr1, "MarshalStructAsParam_AsSeqByValInOut3"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetUnicodeSequentialid:
                    CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                    CharSetUnicodeSequential cloneStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut4...");
                    if (!MarshalStructAsParam_AsSeqByValInOut4(sourceStr2))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut4.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetUnicodeSequential(sourceStr2, cloneStr2, "MarshalStructAsParam_AsSeqByValInOut4"))
                    {
                        failures++;
                    }
                    break;
                case StructID.NumberSequentialid:
                    NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                    NumberSequential cloneNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut6...");
                    if (!MarshalStructAsParam_AsSeqByValInOut6(sourceNumberSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut6.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateNumberSequential(sourceNumberSequential, cloneNumberSequential, "MarshalStructAsParam_AsSeqByValInOut6"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithArrayFieldid:
                    int[] iarr = new int[256];
                    int[] icarr = new int[256];
                    InitialArray(iarr, icarr);

                    StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                    StructSeqWithArrayField cloneStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut7...");
                    if (!MarshalStructAsParam_AsSeqByValInOut7(sourceStructSeqWithArrayField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut7.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, cloneStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByValInOut7"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithEnumFieldid:
                    Enum1 enums = Enum1.e1;
                    Enum1 enumcl = Enum1.e1;
                    StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                    StructSeqWithEnumField cloneStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enumcl);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut8...");
                    if (!MarshalStructAsParam_AsSeqByValInOut8(sourceStructSeqWithEnumField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut8.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, cloneStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByValInOut8"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialAnsiid:
                    strOne = new String('a', 512);
                    strTwo = new String('b', 512);
                    StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                    StringStructSequentialAnsi cloneStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut9...");
                    if (!MarshalStructAsParam_AsSeqByValInOut9(sourceStringStructSequentialAnsi))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut9.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, cloneStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByValInOut9"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialUnicodeid:
                    strOne = new String('a', 256);
                    strTwo = new String('b', 256);
                    StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                    StringStructSequentialUnicode cloneStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut10...");
                    if (!MarshalStructAsParam_AsSeqByValInOut10(sourceStringStructSequentialUnicode))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut10.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                        cloneStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByValInOut10"))
                    {
                        failures++;
                    }
                    break;
                case StructID.PritypeStructSeqWithUnmanagedTypeid:
                    PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                    PritypeStructSeqWithUnmanagedType clonePritypeStructSeqWithUnmanagedType =
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut11...");
                    if (!MarshalStructAsParam_AsSeqByValInOut11(sourcePritypeStructSeqWithUnmanagedType))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut11.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                        clonePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByValInOut11"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithDelegateFieldid:
                    StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                    StructSequentialWithDelegateField cloneStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut12...");
                    if (!MarshalStructAsParam_AsSeqByValInOut12(sourceStructSequentialWithDelegateField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut12.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                        cloneStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByValInOut12"))
                    {
                        failures++;
                    }
                    break;
                case StructID.IncludeOuterIntergerStructSequentialid:
                    IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                    IncludeOuterIntergerStructSequential cloneIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut13...");
                    if (!MarshalStructAsParam_AsSeqByValInOut13(sourceIncludeOuterIntergerStructSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut13.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                        cloneIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByValInOut13"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithPointerFieldid:
                    StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                    StructSequentialWithPointerField cloneStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByValInOut14...");
                    if (!MarshalStructAsParam_AsSeqByValInOut14(sourceStructSequentialWithPointerField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByValInOut14.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                        cloneStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByValInOut14"))
                    {
                        failures++;
                    }
                    break;

                default:
                    Console.WriteLine("\tThere is not the struct id");
                    failures++;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            failures++;
        }

    }
   
    unsafe private static void MarshalStructAsParam_AsSeqByRefInOut(StructID id)
    {
        try
        {
            switch (id)
            {
                case StructID.InnerSequentialid:
                    InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                    InnerSequential changeInnerSequential = Helper.NewInnerSequential(77, 77.0F, "changed string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut(ref sourceInnerSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerSequential(sourceInnerSequential, changeInnerSequential, "MarshalStructAsParam_AsSeqByRefInOut"))
                    {
                        failures++;
                    }
                    break;
                case StructID.InnerArraySequentialid:
                    InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                    InnerArraySequential changeInnerArraySequential = Helper.NewInnerArraySequential(77, 77.0F, "changed string");

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut2...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut2(ref sourceInnerArraySequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut2.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateInnerArraySequential(sourceInnerArraySequential, changeInnerArraySequential, "MarshalStructAsParam_AsSeqByRefInOut2"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetAnsiSequentialid:
                    CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                    CharSetAnsiSequential changeStr1 = Helper.NewCharSetAnsiSequential("change string", 'n');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut3...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut3(ref sourceStr1))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut3.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetAnsiSequential(sourceStr1, changeStr1, "MarshalStructAsParam_AsSeqByRefInOut3"))
                    {
                        failures++;
                    }
                    break;
                case StructID.CharSetUnicodeSequentialid:
                    CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                    CharSetUnicodeSequential changeStr2 = Helper.NewCharSetUnicodeSequential("change string", 'n');

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut4...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut4(ref sourceStr2))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut4.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateCharSetUnicodeSequential(sourceStr2, changeStr2, "MarshalStructAsParam_AsSeqByRefInOut4"))
                    {
                        failures++;
                    }
                    break;
                case StructID.NumberSequentialid:
                    NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                        ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                    NumberSequential changeNumberSequential = Helper.NewNumberSequential(0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut6...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut6(ref sourceNumberSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut6.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateNumberSequential(sourceNumberSequential, changeNumberSequential, "MarshalStructAsParam_AsSeqByRefInOut6"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithArrayFieldid:
                    int[] iarr = new int[256];
                    int[] icarr = new int[256];
                    InitialArray(iarr, icarr);

                    StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                    StructSeqWithArrayField changeStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(false, "change string", icarr);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut7...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut7(ref sourceStructSeqWithArrayField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut7.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, changeStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByRefInOut7"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSeqWithEnumFieldid:
                    Enum1 enums = Enum1.e1;
                    Enum1 enumch = Enum1.e2;
                    StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                    StructSeqWithEnumField changeStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(64, "change string", enumch);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut8...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut8(ref sourceStructSeqWithEnumField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut8.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, changeStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByRefInOut8"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialAnsiid:
                    strOne = new String('a', 512);
                    strTwo = new String('b', 512);
                    StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                    StringStructSequentialAnsi changeStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strTwo, strOne);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut9...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut9(ref sourceStringStructSequentialAnsi))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut9.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, 
                        changeStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByRefInOut9"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StringStructSequentialUnicodeid:
                    strOne = new String('a', 256);
                    strTwo = new String('b', 256);
                    StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                    StringStructSequentialUnicode changeStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strTwo, strOne);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut10...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut10(ref sourceStringStructSequentialUnicode))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut10.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                        changeStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByRefInOut10"))
                    {
                        failures++;
                    }
                    break;
                case StructID.PritypeStructSeqWithUnmanagedTypeid:
                    PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                        Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                    PritypeStructSeqWithUnmanagedType changePritypeStructSeqWithUnmanagedType =
                        Helper.NewPritypeStructSeqWithUnmanagedType("world", false, /*256.00m,*/ 1, /*256, 256,*/ 64);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut11...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut11(ref sourcePritypeStructSeqWithUnmanagedType))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut11.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                        changePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByRefInOut11"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithDelegateFieldid:
                    StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                    StructSequentialWithDelegateField changeStructSequentialWithDelegateField = 
                        Helper.NewStructSequentialWithDelegateField(/*256,*/ null);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut12...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut12(ref sourceStructSequentialWithDelegateField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut12.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                        changeStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByRefInOut12"))
                    {
                        failures++;
                    }
                    break;
                case StructID.IncludeOuterIntergerStructSequentialid:
                    IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                    IncludeOuterIntergerStructSequential changeIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(64, 64);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut13...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut13(ref sourceIncludeOuterIntergerStructSequential))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut13.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                        changeIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByRefInOut13"))
                    {
                        failures++;
                    }
                    break;
                case StructID.StructSequentialWithPointerFieldid:
                    StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                    StructSequentialWithPointerField changeStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(32), 64);

                    Console.WriteLine("\tCalling MarshalStructAsParam_AsSeqByRefInOut14...");
                    if (!MarshalStructAsParam_AsSeqByRefInOut14(ref sourceStructSequentialWithPointerField))
                    {
                        Console.WriteLine("\tFAILED! Managed to Native failed in MarshalStructAsParam_AsSeqByRefInOut14.Expected:True;Actual:False");
                        failures++;
                    }
                    if (!Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                        changeStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByRefInOut14"))
                    {
                        failures++;
                    }
                    break;

                default:
                    Console.WriteLine("\tThere is not the struct id");
                    failures++;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            failures++;
        }
    }
  
    #endregion

    private static void RunMarshalSeqStructAsParamByVal()
    {
        Console.WriteLine("\nVerify marshal sequential layout struct as param as ByVal");
        MarshalStructAsParam_AsSeqByVal(StructID.InnerSequentialid);
        MarshalStructAsParam_AsSeqByVal(StructID.InnerArraySequentialid);
        MarshalStructAsParam_AsSeqByVal(StructID.CharSetAnsiSequentialid);
        MarshalStructAsParam_AsSeqByVal(StructID.CharSetUnicodeSequentialid);
        MarshalStructAsParam_AsSeqByVal(StructID.NumberSequentialid);
        MarshalStructAsParam_AsSeqByVal(StructID.StructSeqWithArrayFieldid);
        MarshalStructAsParam_AsSeqByVal(StructID.StructSeqWithEnumFieldid);
        MarshalStructAsParam_AsSeqByVal(StructID.StringStructSequentialAnsiid);
        MarshalStructAsParam_AsSeqByVal(StructID.StringStructSequentialUnicodeid);
        MarshalStructAsParam_AsSeqByVal(StructID.PritypeStructSeqWithUnmanagedTypeid);
        MarshalStructAsParam_AsSeqByVal(StructID.StructSequentialWithDelegateFieldid);
        MarshalStructAsParam_AsSeqByVal(StructID.IncludeOuterIntergerStructSequentialid);
        MarshalStructAsParam_AsSeqByVal(StructID.StructSequentialWithPointerFieldid);
    }
  
    private static void RunMarshalSeqStructAsParamByRef()
    {
        Console.WriteLine("\nVerify marshal sequential layout struct as param as ByRef");
        MarshalStructAsParam_AsSeqByRef(StructID.InnerSequentialid);
        MarshalStructAsParam_AsSeqByRef(StructID.InnerArraySequentialid);
        MarshalStructAsParam_AsSeqByRef(StructID.CharSetAnsiSequentialid);
        MarshalStructAsParam_AsSeqByRef(StructID.CharSetUnicodeSequentialid);
        MarshalStructAsParam_AsSeqByRef(StructID.NumberSequentialid);
        MarshalStructAsParam_AsSeqByRef(StructID.StructSeqWithArrayFieldid);
        MarshalStructAsParam_AsSeqByRef(StructID.StructSeqWithEnumFieldid);
        MarshalStructAsParam_AsSeqByRef(StructID.StringStructSequentialAnsiid);
        MarshalStructAsParam_AsSeqByRef(StructID.StringStructSequentialUnicodeid);
        MarshalStructAsParam_AsSeqByRef(StructID.PritypeStructSeqWithUnmanagedTypeid);
        MarshalStructAsParam_AsSeqByRef(StructID.StructSequentialWithDelegateFieldid);
        MarshalStructAsParam_AsSeqByRef(StructID.IncludeOuterIntergerStructSequentialid);
        MarshalStructAsParam_AsSeqByRef(StructID.StructSequentialWithPointerFieldid);
    }
   
    private static void RunMarshalSeqStructAsParamByValIn()
    {
        Console.WriteLine("\nVerify marshal sequential layout struct as param as ByValIn");
        MarshalStructAsParam_AsSeqByValIn(StructID.InnerSequentialid);
        MarshalStructAsParam_AsSeqByValIn(StructID.InnerArraySequentialid);
        MarshalStructAsParam_AsSeqByValIn(StructID.CharSetAnsiSequentialid);
        MarshalStructAsParam_AsSeqByValIn(StructID.CharSetUnicodeSequentialid);
        MarshalStructAsParam_AsSeqByValIn(StructID.NumberSequentialid);
        MarshalStructAsParam_AsSeqByValIn(StructID.StructSeqWithArrayFieldid);
        MarshalStructAsParam_AsSeqByValIn(StructID.StructSeqWithEnumFieldid);
        MarshalStructAsParam_AsSeqByValIn(StructID.StringStructSequentialAnsiid);
        MarshalStructAsParam_AsSeqByValIn(StructID.StringStructSequentialUnicodeid);
        MarshalStructAsParam_AsSeqByValIn(StructID.PritypeStructSeqWithUnmanagedTypeid);
        MarshalStructAsParam_AsSeqByValIn(StructID.StructSequentialWithDelegateFieldid);
        MarshalStructAsParam_AsSeqByValIn(StructID.IncludeOuterIntergerStructSequentialid);
        MarshalStructAsParam_AsSeqByValIn(StructID.StructSequentialWithPointerFieldid);
    }
    
    private static void RunMarshalSeqStructAsParamByRefIn()
    {
        Console.WriteLine("\nVerify marshal sequential layout struct as param as ByRefIn");
        MarshalStructAsParam_AsSeqByRefIn(StructID.InnerSequentialid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.InnerArraySequentialid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.CharSetAnsiSequentialid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.CharSetUnicodeSequentialid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.NumberSequentialid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.StructSeqWithArrayFieldid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.StructSeqWithEnumFieldid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.StringStructSequentialAnsiid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.StringStructSequentialUnicodeid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.PritypeStructSeqWithUnmanagedTypeid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.StructSequentialWithDelegateFieldid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.IncludeOuterIntergerStructSequentialid);
        MarshalStructAsParam_AsSeqByRefIn(StructID.StructSequentialWithPointerFieldid);
    }
    
    private static void RunMarshalSeqStructAsParamByValOut()
    {
        Console.WriteLine("\nVerify marshal sequential layout struct as param as ByValOut");
        MarshalStructAsParam_AsSeqByValOut(StructID.InnerSequentialid);
        MarshalStructAsParam_AsSeqByValOut(StructID.InnerArraySequentialid);
        MarshalStructAsParam_AsSeqByValOut(StructID.CharSetAnsiSequentialid);
        MarshalStructAsParam_AsSeqByValOut(StructID.CharSetUnicodeSequentialid);
        MarshalStructAsParam_AsSeqByValOut(StructID.NumberSequentialid);
        MarshalStructAsParam_AsSeqByValOut(StructID.StructSeqWithArrayFieldid);
        MarshalStructAsParam_AsSeqByValOut(StructID.StructSeqWithEnumFieldid);
        MarshalStructAsParam_AsSeqByValOut(StructID.StringStructSequentialAnsiid);
        MarshalStructAsParam_AsSeqByValOut(StructID.StringStructSequentialUnicodeid);
        MarshalStructAsParam_AsSeqByValOut(StructID.PritypeStructSeqWithUnmanagedTypeid);
        MarshalStructAsParam_AsSeqByValOut(StructID.StructSequentialWithDelegateFieldid);
        MarshalStructAsParam_AsSeqByValOut(StructID.IncludeOuterIntergerStructSequentialid);
        MarshalStructAsParam_AsSeqByValOut(StructID.StructSequentialWithPointerFieldid);
    }
    
    private static void RunMarshalSeqStructAsParamByRefOut()
    {
        Console.WriteLine("\nVerify marshal sequential layout struct as param as ByRefOut");
        MarshalStructAsParam_AsSeqByRefOut(StructID.InnerSequentialid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.InnerArraySequentialid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.CharSetAnsiSequentialid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.CharSetUnicodeSequentialid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.NumberSequentialid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.StructSeqWithArrayFieldid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.StructSeqWithEnumFieldid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.StringStructSequentialAnsiid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.StringStructSequentialUnicodeid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.PritypeStructSeqWithUnmanagedTypeid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.StructSequentialWithDelegateFieldid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.IncludeOuterIntergerStructSequentialid);
        MarshalStructAsParam_AsSeqByRefOut(StructID.StructSequentialWithPointerFieldid);
    }
    
    private static void RunMarshalSeqStructAsParamByValInOut()
    {
        Console.WriteLine("\nVerify marshal sequential layout struct as param as ByValInOut");
        MarshalStructAsParam_AsSeqByValInOut(StructID.InnerSequentialid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.InnerArraySequentialid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.CharSetAnsiSequentialid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.CharSetUnicodeSequentialid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.NumberSequentialid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.StructSeqWithArrayFieldid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.StructSeqWithEnumFieldid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.StringStructSequentialAnsiid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.StringStructSequentialUnicodeid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.PritypeStructSeqWithUnmanagedTypeid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.StructSequentialWithDelegateFieldid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.IncludeOuterIntergerStructSequentialid);
        MarshalStructAsParam_AsSeqByValInOut(StructID.StructSequentialWithPointerFieldid);
    }
    
    private static void RunMarshalSeqStructAsParamByRefInOut()
    {
        Console.WriteLine("\nVerify marshal sequential layout struct as param as ByRefInOut");
        MarshalStructAsParam_AsSeqByRefInOut(StructID.InnerSequentialid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.InnerArraySequentialid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.CharSetAnsiSequentialid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.CharSetUnicodeSequentialid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.NumberSequentialid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.StructSeqWithArrayFieldid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.StructSeqWithEnumFieldid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.StringStructSequentialAnsiid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.StringStructSequentialUnicodeid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.PritypeStructSeqWithUnmanagedTypeid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.StructSequentialWithDelegateFieldid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.IncludeOuterIntergerStructSequentialid);
        MarshalStructAsParam_AsSeqByRefInOut(StructID.StructSequentialWithPointerFieldid);
    }
}



