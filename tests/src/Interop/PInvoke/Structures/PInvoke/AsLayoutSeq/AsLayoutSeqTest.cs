// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using CoreFXTestLibrary;

public class Managed
{
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
        Console.WriteLine("The first field of s9 is:"/*, s9.i32*/);
    }

    public static int Main()
    {
        try
        {
            RunMarshalSeqStructAsParamByVal();
            RunMarshalSeqStructAsParamByRef();
            RunMarshalSeqStructAsParamByValIn();
            RunMarshalSeqStructAsParamByRefIn();
            RunMarshalSeqStructAsParamByValOut();
            RunMarshalSeqStructAsParamByRefOut();
            RunMarshalSeqStructAsParamByValInOut();
            RunMarshalSeqStructAsParamByRefInOut();

            return 100;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Test Failure: {e}");
            return 101;
        }
    }

    #region Struct with Layout Sequential scenario1
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal(InnerSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef(ref InnerSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal")]
    static extern bool MarshalStructAsParam_AsSeqByValIn([In] InnerSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn([In] ref InnerSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut([Out] InnerSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut(out InnerSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut([In, Out] InnerSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut([In, Out] ref InnerSequential str1);
    #endregion
    #region Struct with Layout Sequential scenario2
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal2(InnerArraySequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef2(ref InnerArraySequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal2")]
    static extern bool MarshalStructAsParam_AsSeqByValIn2([In] InnerArraySequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn2([In] ref InnerArraySequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut2([Out] InnerArraySequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut2(out InnerArraySequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal2")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut2([In, Out] InnerArraySequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef2")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut2([In, Out] ref InnerArraySequential str1);
    #endregion
    #region Struct with Layout Sequential scenario3
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal3(CharSetAnsiSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef3(ref CharSetAnsiSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal3")]
    static extern bool MarshalStructAsParam_AsSeqByValIn3([In] CharSetAnsiSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn3([In] ref CharSetAnsiSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut3([Out] CharSetAnsiSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut3(out CharSetAnsiSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal3")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut3([In, Out] CharSetAnsiSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef3")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut3([In, Out] ref CharSetAnsiSequential str1);
    #endregion
    #region Struct with Layout Sequential scenario4
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal4(CharSetUnicodeSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef4(ref CharSetUnicodeSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal4")]
    static extern bool MarshalStructAsParam_AsSeqByValIn4([In] CharSetUnicodeSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn4([In] ref CharSetUnicodeSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut4([Out] CharSetUnicodeSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut4(out CharSetUnicodeSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal4")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut4([In, Out] CharSetUnicodeSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef4")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut4([In, Out] ref CharSetUnicodeSequential str1);
    #endregion
    #region Struct with Layout Sequential scenario5
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal6(NumberSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef6(ref NumberSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal6")]
    static extern bool MarshalStructAsParam_AsSeqByValIn6([In] NumberSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn6([In] ref NumberSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut6([Out] NumberSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut6(out NumberSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal6")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut6([In, Out] NumberSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef6")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut6([In, Out] ref NumberSequential str1);
    #endregion
    #region Struct with Layout Sequential scenario6
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal7(StructSeqWithArrayField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef7(ref StructSeqWithArrayField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal7")]
    static extern bool MarshalStructAsParam_AsSeqByValIn7([In] StructSeqWithArrayField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn7([In] ref StructSeqWithArrayField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut7(out StructSeqWithArrayField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef7")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut7([In, Out] ref StructSeqWithArrayField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut7([Out] StructSeqWithArrayField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal7")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut7([In, Out] StructSeqWithArrayField str1);
    #endregion
    #region Struct with Layout Sequential scenario7
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal8(StructSeqWithEnumField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef8(ref StructSeqWithEnumField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal8")]
    static extern bool MarshalStructAsParam_AsSeqByValIn8([In] StructSeqWithEnumField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn8([In] ref StructSeqWithEnumField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal8")]
    static extern bool MarshalStructAsParam_AsSeqByValOut8([Out] StructSeqWithEnumField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut8(out StructSeqWithEnumField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal8")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut8([In, Out] StructSeqWithEnumField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef8")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut8([In, Out] ref StructSeqWithEnumField str1);
    #endregion
    #region Struct with Layout Sequential scenario8
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal9(StringStructSequentialAnsi str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef9(ref StringStructSequentialAnsi str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal9")]
    static extern bool MarshalStructAsParam_AsSeqByValIn9([In] StringStructSequentialAnsi str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn9([In] ref StringStructSequentialAnsi str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut9([Out] StringStructSequentialAnsi str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut9(out StringStructSequentialAnsi str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal9")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut9([In, Out] StringStructSequentialAnsi str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef9")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut9([In, Out] ref StringStructSequentialAnsi str1);
    #endregion
    #region Struct with Layout Sequential scenario9
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal10(StringStructSequentialUnicode str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef10(ref StringStructSequentialUnicode str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal10")]
    static extern bool MarshalStructAsParam_AsSeqByValIn10([In] StringStructSequentialUnicode str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn10([In] ref StringStructSequentialUnicode str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut10([Out] StringStructSequentialUnicode str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut10(out StringStructSequentialUnicode str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal10")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut10([In, Out] StringStructSequentialUnicode str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef10")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut10([In, Out] ref StringStructSequentialUnicode str1);
    #endregion
    #region Struct with Layout Sequential scenario10
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal11(PritypeStructSeqWithUnmanagedType str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef11(ref PritypeStructSeqWithUnmanagedType str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal11")]
    static extern bool MarshalStructAsParam_AsSeqByValIn11([In] PritypeStructSeqWithUnmanagedType str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn11([In] ref PritypeStructSeqWithUnmanagedType str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut11([Out] PritypeStructSeqWithUnmanagedType str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut11(out PritypeStructSeqWithUnmanagedType str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal11")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut11([In, Out] PritypeStructSeqWithUnmanagedType str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef11")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut11([In, Out] ref PritypeStructSeqWithUnmanagedType str1);
    #endregion
    #region Struct with Layout Sequential scenario11
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal12(StructSequentialWithDelegateField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef12(ref StructSequentialWithDelegateField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal12")]
    static extern bool MarshalStructAsParam_AsSeqByValIn12(StructSequentialWithDelegateField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef12")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn12([In] ref StructSequentialWithDelegateField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut12([Out] StructSequentialWithDelegateField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut12(out StructSequentialWithDelegateField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal12")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut12([In, Out] StructSequentialWithDelegateField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef12")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut12([In, Out] ref StructSequentialWithDelegateField str1);
    #endregion
    #region Struct with Layout Sequential scenario12
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal13(IncludeOuterIntergerStructSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef13(ref IncludeOuterIntergerStructSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal13")]
    static extern bool MarshalStructAsParam_AsSeqByValIn13([In] IncludeOuterIntergerStructSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn13([In] ref IncludeOuterIntergerStructSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByValOut13([Out] IncludeOuterIntergerStructSequential str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut13(out IncludeOuterIntergerStructSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal13")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut13([In, Out] IncludeOuterIntergerStructSequential str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef13")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut13([In, Out] ref IncludeOuterIntergerStructSequential str1);
    #endregion
    #region Struct with Layout Sequential scenario13
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByVal14(StructSequentialWithPointerField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRef14(ref StructSequentialWithPointerField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal14")]
    static extern bool MarshalStructAsParam_AsSeqByValIn14([In] StructSequentialWithPointerField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefIn14([In] ref StructSequentialWithPointerField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal14")]
    static extern bool MarshalStructAsParam_AsSeqByValOut14([Out] StructSequentialWithPointerField str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsSeqByRefOut14(out StructSequentialWithPointerField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByVal14")]
    static extern bool MarshalStructAsParam_AsSeqByValInOut14([In, Out] StructSequentialWithPointerField str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsSeqByRef14")]
    static extern bool MarshalStructAsParam_AsSeqByRefInOut14([In, Out] ref StructSequentialWithPointerField str1);
    #endregion

    #region Marshal struct method in PInvoke
   
    unsafe private static void MarshalStructAsParam_AsSeqByVal(StructID id)
    {
        switch (id)
        {
            case StructID.InnerSequentialid:
                InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                InnerSequential cloneInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal(sourceInnerSequential));
                Assert.IsTrue(Helper.ValidateInnerSequential(sourceInnerSequential, cloneInnerSequential, "MarshalStructAsParam_AsSeqByVal"));
                break;
            case StructID.InnerArraySequentialid:
                InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                InnerArraySequential cloneInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal2...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal2(sourceInnerArraySequential));
                Assert.IsTrue(Helper.ValidateInnerArraySequential(sourceInnerArraySequential, cloneInnerArraySequential, "MarshalStructAsParam_AsSeqByVal2"));
                break;
            case StructID.CharSetAnsiSequentialid:
                CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                CharSetAnsiSequential cloneStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal3...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal3(sourceStr1));
                Assert.IsTrue(Helper.ValidateCharSetAnsiSequential(sourceStr1, cloneStr1, "MarshalStructAsParam_AsSeqByVal3"));
                break;
            case StructID.CharSetUnicodeSequentialid:
                CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                CharSetUnicodeSequential cloneStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal4...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal4(sourceStr2));
                Assert.IsTrue(Helper.ValidateCharSetUnicodeSequential(sourceStr2, cloneStr2, "MarshalStructAsParam_AsSeqByVal4"));
                break;
            case StructID.NumberSequentialid:
                NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                NumberSequential cloneNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal6...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal6(sourceNumberSequential));
                Assert.IsTrue(Helper.ValidateNumberSequential(sourceNumberSequential, cloneNumberSequential, "MarshalStructAsParam_AsSeqByVal6"));
                break;
            case StructID.StructSeqWithArrayFieldid:
                int[] iarr = new int[256];
                int[] icarr = new int[256];
                InitialArray(iarr, icarr);

                StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                StructSeqWithArrayField cloneStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal7...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal7(sourceStructSeqWithArrayField));
                Assert.IsTrue(Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, cloneStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByVal7"));
                break;
            case StructID.StructSeqWithEnumFieldid:
                Enum1 enums = Enum1.e1;
                Enum1 enumcl = Enum1.e1;
                //Enum1 enumch = Enum1.e2;
                StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                StructSeqWithEnumField cloneStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enumcl);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal8...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal8(sourceStructSeqWithEnumField));
                Assert.IsTrue(Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, cloneStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByVal8"));
                break;
            case StructID.StringStructSequentialAnsiid:
                strOne = new String('a', 512);
                strTwo = new String('b', 512);
                StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                StringStructSequentialAnsi cloneStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal9...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal9(sourceStringStructSequentialAnsi));
                Assert.IsTrue(Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, cloneStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByVal9"));
                break;
            case StructID.StringStructSequentialUnicodeid:
                strOne = new String('a', 256);
                strTwo = new String('b', 256);
                StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                StringStructSequentialUnicode cloneStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal10...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal10(sourceStringStructSequentialUnicode));
                Assert.IsTrue(Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                    cloneStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByVal10"));
                break;
            case StructID.PritypeStructSeqWithUnmanagedTypeid:
                PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                PritypeStructSeqWithUnmanagedType clonePritypeStructSeqWithUnmanagedType =
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal11...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal11(sourcePritypeStructSeqWithUnmanagedType));
                Assert.IsTrue(Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                    clonePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByVal11"));
                break;
            case StructID.StructSequentialWithDelegateFieldid:
                StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                StructSequentialWithDelegateField cloneStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal12...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal12(sourceStructSequentialWithDelegateField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                    cloneStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByVal12"));
                break;
            case StructID.IncludeOuterIntergerStructSequentialid:
                IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                IncludeOuterIntergerStructSequential cloneIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal13...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal13(sourceIncludeOuterIntergerStructSequential));
                Assert.IsTrue(Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                    cloneIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByVal13"));
                break;
            case StructID.StructSequentialWithPointerFieldid:
                StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                StructSequentialWithPointerField cloneStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByVal14...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByVal14(sourceStructSequentialWithPointerField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                    cloneStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByVal14"));
                break;

            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }
    
    unsafe private static void MarshalStructAsParam_AsSeqByRef(StructID id)
    {
        switch (id)
        {
            case StructID.InnerSequentialid:
                InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                InnerSequential changeInnerSequential = Helper.NewInnerSequential(77, 77.0F, "changed string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef(ref sourceInnerSequential));
                Assert.IsTrue(Helper.ValidateInnerSequential(sourceInnerSequential, changeInnerSequential, "MarshalStructAsParam_AsSeqByRef"));
                break;
            case StructID.InnerArraySequentialid:
                InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                InnerArraySequential changeInnerArraySequential = Helper.NewInnerArraySequential(77, 77.0F, "changed string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef2...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef2(ref sourceInnerArraySequential));
                Assert.IsTrue(Helper.ValidateInnerArraySequential(sourceInnerArraySequential, changeInnerArraySequential, "MarshalStructAsParam_AsSeqByRef2"));
                break;
            case StructID.CharSetAnsiSequentialid:
                CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                CharSetAnsiSequential changeStr1 = Helper.NewCharSetAnsiSequential("change string", 'n');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef3...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef3(ref sourceStr1));
                Assert.IsTrue(Helper.ValidateCharSetAnsiSequential(sourceStr1, changeStr1, "MarshalStructAsParam_AsSeqByRef3"));
                break;
            case StructID.CharSetUnicodeSequentialid:
                CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                CharSetUnicodeSequential changeStr2 = Helper.NewCharSetUnicodeSequential("change string", 'n');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef4...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef4(ref sourceStr2));
                Assert.IsTrue(Helper.ValidateCharSetUnicodeSequential(sourceStr2, changeStr2, "MarshalStructAsParam_AsSeqByRef4"));
                break;
            case StructID.NumberSequentialid:
                NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                NumberSequential changeNumberSequential = Helper.NewNumberSequential(0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef6...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef6(ref sourceNumberSequential));
                Assert.IsTrue(Helper.ValidateNumberSequential(sourceNumberSequential, changeNumberSequential, "MarshalStructAsParam_AsSeqByRef6"));
                break;
            case StructID.StructSeqWithArrayFieldid:
                int[] iarr = new int[256];
                int[] icarr = new int[256];
                InitialArray(iarr, icarr);

                StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                StructSeqWithArrayField changeStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(false, "change string", icarr);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef7...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef7(ref sourceStructSeqWithArrayField));
                Assert.IsTrue(Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, changeStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByRef7"));
                break;
            case StructID.StructSeqWithEnumFieldid:
                Enum1 enums = Enum1.e1;
                Enum1 enumch = Enum1.e2;
                StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                StructSeqWithEnumField changeStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(64, "change string", enumch);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef8...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef8(ref sourceStructSeqWithEnumField));
                Assert.IsTrue(Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, changeStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByRef8"));
                break;
            case StructID.StringStructSequentialAnsiid:
                strOne = new String('a', 512);
                strTwo = new String('b', 512);
                StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                StringStructSequentialAnsi changeStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strTwo, strOne);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef9...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef9(ref sourceStringStructSequentialAnsi));
                Assert.IsTrue(Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, changeStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByRef9"));
                break;
            case StructID.StringStructSequentialUnicodeid:
                strOne = new String('a', 256);
                strTwo = new String('b', 256);
                StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                StringStructSequentialUnicode changeStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strTwo, strOne);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef10...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef10(ref sourceStringStructSequentialUnicode));
                Assert.IsTrue(Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                    changeStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByRef10"));
                break;
            case StructID.PritypeStructSeqWithUnmanagedTypeid:
                PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                PritypeStructSeqWithUnmanagedType changePritypeStructSeqWithUnmanagedType =
                    Helper.NewPritypeStructSeqWithUnmanagedType("world", false, /*256.00m,*/ 1, /*256, 256,*/ 64);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef11...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef11(ref sourcePritypeStructSeqWithUnmanagedType));
                Assert.IsTrue(Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                    changePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByRef11"));
                break;
            case StructID.StructSequentialWithDelegateFieldid:
                StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128, */new TestDelegate1(testMethod));
                StructSequentialWithDelegateField changeStructSequentialWithDelegateField = Helper.NewStructSequentialWithDelegateField(/*256,*/ null);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef12...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef12(ref sourceStructSequentialWithDelegateField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                    changeStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByRef12"));
                break;
            case StructID.IncludeOuterIntergerStructSequentialid:
                IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                IncludeOuterIntergerStructSequential changeIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(64, 64);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef13...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef13(ref sourceIncludeOuterIntergerStructSequential));
                Assert.IsTrue(Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                    changeIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByRef13"));
                break;
            case StructID.StructSequentialWithPointerFieldid:
                StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                StructSequentialWithPointerField changeStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(32), 64);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRef14...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRef14(ref sourceStructSequentialWithPointerField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                    changeStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByRef14"));
                break;

            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }
  
    unsafe private static void MarshalStructAsParam_AsSeqByValIn(StructID id)
    {
        switch (id)
        {
            case StructID.InnerSequentialid:
                InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                InnerSequential cloneInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn(sourceInnerSequential));
                Assert.IsTrue(Helper.ValidateInnerSequential(sourceInnerSequential, cloneInnerSequential, "MarshalStructAsParam_AsSeqByValIn"));
                break;
            case StructID.InnerArraySequentialid:
                InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                InnerArraySequential cloneInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn2...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn2(sourceInnerArraySequential));
                Assert.IsTrue(Helper.ValidateInnerArraySequential(sourceInnerArraySequential, cloneInnerArraySequential, "MarshalStructAsParam_AsSeqByValIn2"));
                break;
            case StructID.CharSetAnsiSequentialid:
                CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                CharSetAnsiSequential cloneStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn3...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn3(sourceStr1));
                Assert.IsTrue(Helper.ValidateCharSetAnsiSequential(sourceStr1, cloneStr1, "MarshalStructAsParam_AsSeqByValIn3"));
                break;
            case StructID.CharSetUnicodeSequentialid:
                CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                CharSetUnicodeSequential cloneStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn4...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn4(sourceStr2));
                Assert.IsTrue(Helper.ValidateCharSetUnicodeSequential(sourceStr2, cloneStr2, "MarshalStructAsParam_AsSeqByValIn4"));
                break;
            case StructID.NumberSequentialid:
                NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                NumberSequential cloneNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn6...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn6(sourceNumberSequential));
                Assert.IsTrue(Helper.ValidateNumberSequential(sourceNumberSequential, cloneNumberSequential, "MarshalStructAsParam_AsSeqByValIn6"));
                break;
            case StructID.StructSeqWithArrayFieldid:
                int[] iarr = new int[256];
                int[] icarr = new int[256];
                InitialArray(iarr, icarr);

                StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                StructSeqWithArrayField cloneStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn7...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn7(sourceStructSeqWithArrayField));
                Assert.IsTrue(Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, cloneStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByValIn7"));
                break;
            case StructID.StructSeqWithEnumFieldid:
                Enum1 enums = Enum1.e1;
                Enum1 enumcl = Enum1.e1;
                StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                StructSeqWithEnumField cloneStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enumcl);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn8...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn8(sourceStructSeqWithEnumField));
                Assert.IsTrue(Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, cloneStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByValIn8"));
                break;
            case StructID.StringStructSequentialAnsiid:
                strOne = new String('a', 512);
                strTwo = new String('b', 512);
                StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                StringStructSequentialAnsi cloneStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn9...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn9(sourceStringStructSequentialAnsi));
                Assert.IsTrue(Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, cloneStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByValIn9"));
                break;
            case StructID.StringStructSequentialUnicodeid:
                strOne = new String('a', 256);
                strTwo = new String('b', 256);
                StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                StringStructSequentialUnicode cloneStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn10...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn10(sourceStringStructSequentialUnicode));
                Assert.IsTrue(Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                    cloneStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByValIn10"));
                break;
            case StructID.PritypeStructSeqWithUnmanagedTypeid:
                PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                PritypeStructSeqWithUnmanagedType clonePritypeStructSeqWithUnmanagedType =
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn11...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn11(sourcePritypeStructSeqWithUnmanagedType));
                Assert.IsTrue(Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                    clonePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByValIn11"));
                break;
            case StructID.StructSequentialWithDelegateFieldid:
                StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                StructSequentialWithDelegateField cloneStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn12...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn12(sourceStructSequentialWithDelegateField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                    cloneStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByValIn12"));
                break;
            case StructID.IncludeOuterIntergerStructSequentialid:
                IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                IncludeOuterIntergerStructSequential cloneIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn13...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn13(sourceIncludeOuterIntergerStructSequential));
                Assert.IsTrue(Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                    cloneIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByValIn13"));
                break;
            case StructID.StructSequentialWithPointerFieldid:
                StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                StructSequentialWithPointerField cloneStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValIn14...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValIn14(sourceStructSequentialWithPointerField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                    cloneStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByValIn14"));
                break;

            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }
    
    unsafe private static void MarshalStructAsParam_AsSeqByRefIn(StructID id)
    {
        switch (id)
        {
            case StructID.InnerSequentialid:
                InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                InnerSequential cloneInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn(ref sourceInnerSequential));
                Assert.IsTrue(Helper.ValidateInnerSequential(sourceInnerSequential, cloneInnerSequential, "MarshalStructAsParam_AsSeqByRefIn"));
                break;
            case StructID.InnerArraySequentialid:
                InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                InnerArraySequential cloneInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn2...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn2(ref sourceInnerArraySequential));
                Assert.IsTrue(Helper.ValidateInnerArraySequential(sourceInnerArraySequential, cloneInnerArraySequential, "MarshalStructAsParam_AsSeqByRefIn2"));
                break;
            case StructID.CharSetAnsiSequentialid:
                CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                CharSetAnsiSequential cloneStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn3...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn3(ref sourceStr1));
                Assert.IsTrue(Helper.ValidateCharSetAnsiSequential(sourceStr1, cloneStr1, "MarshalStructAsParam_AsSeqByRefIn3"));
                break;
            case StructID.CharSetUnicodeSequentialid:
                CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                CharSetUnicodeSequential cloneStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn4...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn4(ref sourceStr2));
                Assert.IsTrue(Helper.ValidateCharSetUnicodeSequential(sourceStr2, cloneStr2, "MarshalStructAsParam_AsSeqByRefIn4"));
                break;
            case StructID.NumberSequentialid:
                NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                NumberSequential changeNumberSequential = Helper.NewNumberSequential(0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn6...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn6(ref sourceNumberSequential));
                Assert.IsTrue(Helper.ValidateNumberSequential(sourceNumberSequential, changeNumberSequential, "MarshalStructAsParam_AsSeqByRefIn6"));
                break;
            case StructID.StructSeqWithArrayFieldid:
                int[] iarr = new int[256];
                int[] icarr = new int[256];
                InitialArray(iarr, icarr);

                StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                StructSeqWithArrayField cloneStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn7...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn7(ref sourceStructSeqWithArrayField));
                Assert.IsTrue(Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, cloneStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByRefIn7"));
                break;
            case StructID.StructSeqWithEnumFieldid:
                Enum1 enums = Enum1.e1;
                Enum1 enumcl = Enum1.e1;
                StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                StructSeqWithEnumField cloneStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enumcl);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn8...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn8(ref sourceStructSeqWithEnumField));
                Assert.IsTrue(Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, cloneStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByRefIn8"));
                break;
            case StructID.StringStructSequentialAnsiid:
                strOne = new String('a', 512);
                strTwo = new String('b', 512);
                StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                StringStructSequentialAnsi cloneStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn9...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn9(ref sourceStringStructSequentialAnsi));
                Assert.IsTrue(Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, cloneStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByRefIn9"));
                break;
            case StructID.StringStructSequentialUnicodeid:
                strOne = new String('a', 256);
                strTwo = new String('b', 256);
                StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                StringStructSequentialUnicode cloneStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn10...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn10(ref sourceStringStructSequentialUnicode));
                Assert.IsTrue(Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                    cloneStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByRefIn10"));
                break;
            case StructID.PritypeStructSeqWithUnmanagedTypeid:
                PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                PritypeStructSeqWithUnmanagedType clonePritypeStructSeqWithUnmanagedType =
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn11...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn11(ref sourcePritypeStructSeqWithUnmanagedType));
                Assert.IsTrue(Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                    clonePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByRefIn11"));
                break;
            case StructID.StructSequentialWithDelegateFieldid:
                StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                StructSequentialWithDelegateField cloneStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn12...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn12(ref sourceStructSequentialWithDelegateField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                    cloneStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByRefIn12"));
                break;
            case StructID.IncludeOuterIntergerStructSequentialid:
                IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                IncludeOuterIntergerStructSequential changeIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn13...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn13(ref sourceIncludeOuterIntergerStructSequential));
                Assert.IsTrue(Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                    changeIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByRefIn13"));
                break;
            case StructID.StructSequentialWithPointerFieldid:
                StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                StructSequentialWithPointerField changeStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(32), 64);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefIn14...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefIn14(ref sourceStructSequentialWithPointerField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                    changeStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByRefIn14"));
                break;

            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }
   
    unsafe private static void MarshalStructAsParam_AsSeqByValOut(StructID id)
    {
        switch (id)
        {
            case StructID.InnerSequentialid:
                InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                InnerSequential cloneInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut(sourceInnerSequential));
                Assert.IsTrue(Helper.ValidateInnerSequential(sourceInnerSequential, cloneInnerSequential, "MarshalStructAsParam_AsSeqByValOut"));
                break;
            case StructID.InnerArraySequentialid:
                InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                InnerArraySequential cloneInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut2...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut2(sourceInnerArraySequential));
                Assert.IsTrue(Helper.ValidateInnerArraySequential(sourceInnerArraySequential, cloneInnerArraySequential, "MarshalStructAsParam_AsSeqByValOut2"));
                break;
            case StructID.CharSetAnsiSequentialid:
                CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                CharSetAnsiSequential cloneStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut3...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut3(sourceStr1));
                Assert.IsTrue(Helper.ValidateCharSetAnsiSequential(sourceStr1, cloneStr1, "MarshalStructAsParam_AsSeqByValOut3"));
                break;
            case StructID.CharSetUnicodeSequentialid:
                CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                CharSetUnicodeSequential cloneStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut4...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut4(sourceStr2));
                Assert.IsTrue(Helper.ValidateCharSetUnicodeSequential(sourceStr2, cloneStr2, "MarshalStructAsParam_AsSeqByValOut4"));
                break;
            case StructID.NumberSequentialid:
                NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                NumberSequential cloneNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut6...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut6(sourceNumberSequential));
                Assert.IsTrue(Helper.ValidateNumberSequential(sourceNumberSequential, cloneNumberSequential, "MarshalStructAsParam_AsSeqByValOut6"));
                break;
            case StructID.StructSeqWithArrayFieldid:
                int[] iarr = new int[256];
                int[] icarr = new int[256];
                InitialArray(iarr, icarr);

                StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                StructSeqWithArrayField cloneStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut7...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut7(sourceStructSeqWithArrayField));
                Assert.IsTrue(Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, cloneStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByValOut7"));
                break;
            case StructID.StructSeqWithEnumFieldid:
                Enum1 enums = Enum1.e1;
                Enum1 enumcl = Enum1.e1;
                StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                StructSeqWithEnumField cloneStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enumcl);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut8...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut8(sourceStructSeqWithEnumField));
                Assert.IsTrue(Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, cloneStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByValOut8"));
                break;
            case StructID.StringStructSequentialAnsiid:
                strOne = new String('a', 512);
                strTwo = new String('b', 512);
                StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                StringStructSequentialAnsi cloneStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut9...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut9(sourceStringStructSequentialAnsi));
                Assert.IsTrue(Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, cloneStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByValOut9"));
                break;
            case StructID.StringStructSequentialUnicodeid:
                strOne = new String('a', 256);
                strTwo = new String('b', 256);
                StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                StringStructSequentialUnicode cloneStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut10...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut10(sourceStringStructSequentialUnicode));
                Assert.IsTrue(Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                    cloneStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByValOut10"));
                break;
            case StructID.PritypeStructSeqWithUnmanagedTypeid:
                PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                PritypeStructSeqWithUnmanagedType clonePritypeStructSeqWithUnmanagedType =
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut11...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut11(sourcePritypeStructSeqWithUnmanagedType));
                Assert.IsTrue(Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                    clonePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByValOut11"));
                break;
            case StructID.StructSequentialWithDelegateFieldid:
                StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                StructSequentialWithDelegateField cloneStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut12...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut12(sourceStructSequentialWithDelegateField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                    cloneStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByValOut12"));
                break;
            case StructID.IncludeOuterIntergerStructSequentialid:
                IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                IncludeOuterIntergerStructSequential cloneIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut13...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut13(sourceIncludeOuterIntergerStructSequential));
                Assert.IsTrue(Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                    cloneIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByValOut13"));
                break;
            case StructID.StructSequentialWithPointerFieldid:
                StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                StructSequentialWithPointerField cloneStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValOut14...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValOut14(sourceStructSequentialWithPointerField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                    cloneStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByValOut14"));
                break;

            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }
  
    unsafe private static void MarshalStructAsParam_AsSeqByRefOut(StructID id)
    {
        switch (id)
        {
            case StructID.InnerSequentialid:
                InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                InnerSequential changeInnerSequential = Helper.NewInnerSequential(77, 77.0F, "changed string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut(out sourceInnerSequential));
                Assert.IsTrue(Helper.ValidateInnerSequential(sourceInnerSequential, changeInnerSequential, "MarshalStructAsParam_AsSeqByRefOut"));
                break;
            case StructID.InnerArraySequentialid:
                InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                InnerArraySequential changeInnerArraySequential = Helper.NewInnerArraySequential(77, 77.0F, "changed string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut2...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut2(out sourceInnerArraySequential));
                Assert.IsTrue(Helper.ValidateInnerArraySequential(sourceInnerArraySequential, changeInnerArraySequential, "MarshalStructAsParam_AsSeqByRefOut2"));
                break;
            case StructID.CharSetAnsiSequentialid:
                CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                CharSetAnsiSequential changeStr1 = Helper.NewCharSetAnsiSequential("change string", 'n');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut3...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut3(out sourceStr1));
                Assert.IsTrue(Helper.ValidateCharSetAnsiSequential(sourceStr1, changeStr1, "MarshalStructAsParam_AsSeqByRefOut3"));
                break;
            case StructID.CharSetUnicodeSequentialid:
                CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                CharSetUnicodeSequential changeStr2 = Helper.NewCharSetUnicodeSequential("change string", 'n');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut4...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut4(out sourceStr2));
                Assert.IsTrue(Helper.ValidateCharSetUnicodeSequential(sourceStr2, changeStr2, "MarshalStructAsParam_AsSeqByRefOut4"));
                break;
            case StructID.NumberSequentialid:
                NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                NumberSequential changeNumberSequential = Helper.NewNumberSequential(0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut6...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut6(out sourceNumberSequential));
                Assert.IsTrue(Helper.ValidateNumberSequential(sourceNumberSequential, changeNumberSequential, "MarshalStructAsParam_AsSeqByRefOut6"));
                break;
            case StructID.StructSeqWithArrayFieldid:
                int[] iarr = new int[256];
                int[] icarr = new int[256];
                InitialArray(iarr, icarr);

                StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                StructSeqWithArrayField changeStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(false, "change string", icarr);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut7...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut7(out sourceStructSeqWithArrayField));
                Assert.IsTrue(Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, changeStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByRefOut7"));
                break;
            case StructID.StructSeqWithEnumFieldid:
                Enum1 enums = Enum1.e1;
                Enum1 enumch = Enum1.e2;
                StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                StructSeqWithEnumField changeStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(64, "change string", enumch);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut8...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut8(out sourceStructSeqWithEnumField));
                Assert.IsTrue(Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, changeStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByRefOut8"));
                break;
            case StructID.StringStructSequentialAnsiid:
                strOne = new String('a', 512);
                strTwo = new String('b', 512);
                StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                StringStructSequentialAnsi changeStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strTwo, strOne);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut9...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut9(out sourceStringStructSequentialAnsi));
                Assert.IsTrue(Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, changeStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByRefOut9"));
                break;
            case StructID.StringStructSequentialUnicodeid:
                strOne = new String('a', 256);
                strTwo = new String('b', 256);
                StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                StringStructSequentialUnicode changeStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strTwo, strOne);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut10...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut10(out sourceStringStructSequentialUnicode));
                Assert.IsTrue(Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                    changeStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByRefOut10"));
                break;
            case StructID.PritypeStructSeqWithUnmanagedTypeid:
                PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                PritypeStructSeqWithUnmanagedType changePritypeStructSeqWithUnmanagedType =
                    Helper.NewPritypeStructSeqWithUnmanagedType("world", false, /*256.00m,*/ 1, /*256, 256,*/ 64);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut11...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut11(out sourcePritypeStructSeqWithUnmanagedType));
                Assert.IsTrue(Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                    changePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByRefOut11"));
                break;
            case StructID.StructSequentialWithDelegateFieldid:
                StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut12...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut12(out sourceStructSequentialWithDelegateField));
                Assert.IsNotNull(sourceStructSequentialWithDelegateField.myDelegate1);
                break;
            case StructID.IncludeOuterIntergerStructSequentialid:
                IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                IncludeOuterIntergerStructSequential changeIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(64, 64);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut13...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut13(out sourceIncludeOuterIntergerStructSequential));
                Assert.IsTrue(Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                    changeIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByRefOut13"));
                break;
            case StructID.StructSequentialWithPointerFieldid:
                StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                StructSequentialWithPointerField changeStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(32), 64);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefOut14...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefOut14(out sourceStructSequentialWithPointerField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                    changeStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByRefOut14"));
                break;

            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }
   
    unsafe private static void MarshalStructAsParam_AsSeqByValInOut(StructID id)
    {
        switch (id)
        {
            case StructID.InnerSequentialid:
                InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                InnerSequential cloneInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut(sourceInnerSequential));
                Assert.IsTrue(Helper.ValidateInnerSequential(sourceInnerSequential, cloneInnerSequential, "MarshalStructAsParam_AsSeqByValInOut"));
                break;
            case StructID.InnerArraySequentialid:
                InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                InnerArraySequential cloneInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut2...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut2(sourceInnerArraySequential));
                Assert.IsTrue(Helper.ValidateInnerArraySequential(sourceInnerArraySequential, cloneInnerArraySequential, "MarshalStructAsParam_AsSeqByValInOut2"));
                break;
            case StructID.CharSetAnsiSequentialid:
                CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                CharSetAnsiSequential cloneStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut3...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut3(sourceStr1));
                Assert.IsTrue(Helper.ValidateCharSetAnsiSequential(sourceStr1, cloneStr1, "MarshalStructAsParam_AsSeqByValInOut3"));
                break;
            case StructID.CharSetUnicodeSequentialid:
                CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                CharSetUnicodeSequential cloneStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut4...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut4(sourceStr2));
                Assert.IsTrue(Helper.ValidateCharSetUnicodeSequential(sourceStr2, cloneStr2, "MarshalStructAsParam_AsSeqByValInOut4"));
                break;
            case StructID.NumberSequentialid:
                NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                NumberSequential cloneNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut6...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut6(sourceNumberSequential));
                Assert.IsTrue(Helper.ValidateNumberSequential(sourceNumberSequential, cloneNumberSequential, "MarshalStructAsParam_AsSeqByValInOut6"));
                break;
            case StructID.StructSeqWithArrayFieldid:
                int[] iarr = new int[256];
                int[] icarr = new int[256];
                InitialArray(iarr, icarr);

                StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                StructSeqWithArrayField cloneStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut7...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut7(sourceStructSeqWithArrayField));
                Assert.IsTrue(Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, cloneStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByValInOut7"));
                break;
            case StructID.StructSeqWithEnumFieldid:
                Enum1 enums = Enum1.e1;
                Enum1 enumcl = Enum1.e1;
                StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                StructSeqWithEnumField cloneStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enumcl);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut8...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut8(sourceStructSeqWithEnumField));
                Assert.IsTrue(Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, cloneStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByValInOut8"));
                break;
            case StructID.StringStructSequentialAnsiid:
                strOne = new String('a', 512);
                strTwo = new String('b', 512);
                StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                StringStructSequentialAnsi cloneStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut9...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut9(sourceStringStructSequentialAnsi));
                Assert.IsTrue(Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, cloneStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByValInOut9"));
                break;
            case StructID.StringStructSequentialUnicodeid:
                strOne = new String('a', 256);
                strTwo = new String('b', 256);
                StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                StringStructSequentialUnicode cloneStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut10...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut10(sourceStringStructSequentialUnicode));
                Assert.IsTrue(Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                    cloneStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByValInOut10"));
                break;
            case StructID.PritypeStructSeqWithUnmanagedTypeid:
                PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                PritypeStructSeqWithUnmanagedType clonePritypeStructSeqWithUnmanagedType =
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut11...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut11(sourcePritypeStructSeqWithUnmanagedType));
                Assert.IsTrue(Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                    clonePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByValInOut11"));
                break;
            case StructID.StructSequentialWithDelegateFieldid:
                StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                StructSequentialWithDelegateField cloneStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut12...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut12(sourceStructSequentialWithDelegateField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                    cloneStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByValInOut12"));
                break;
            case StructID.IncludeOuterIntergerStructSequentialid:
                IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                IncludeOuterIntergerStructSequential cloneIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut13...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut13(sourceIncludeOuterIntergerStructSequential));
                Assert.IsTrue(Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                    cloneIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByValInOut13"));
                break;
            case StructID.StructSequentialWithPointerFieldid:
                StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                StructSequentialWithPointerField cloneStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByValInOut14...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByValInOut14(sourceStructSequentialWithPointerField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                    cloneStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByValInOut14"));
                break;

            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }
   
    unsafe private static void MarshalStructAsParam_AsSeqByRefInOut(StructID id)
    {
        switch (id)
        {
            case StructID.InnerSequentialid:
                InnerSequential sourceInnerSequential = Helper.NewInnerSequential(1, 1.0F, "some string");
                InnerSequential changeInnerSequential = Helper.NewInnerSequential(77, 77.0F, "changed string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut(ref sourceInnerSequential));
                Assert.IsTrue(Helper.ValidateInnerSequential(sourceInnerSequential, changeInnerSequential, "MarshalStructAsParam_AsSeqByRefInOut"));
                break;
            case StructID.InnerArraySequentialid:
                InnerArraySequential sourceInnerArraySequential = Helper.NewInnerArraySequential(1, 1.0F, "some string");
                InnerArraySequential changeInnerArraySequential = Helper.NewInnerArraySequential(77, 77.0F, "changed string");

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut2...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut2(ref sourceInnerArraySequential));
                Assert.IsTrue(Helper.ValidateInnerArraySequential(sourceInnerArraySequential, changeInnerArraySequential, "MarshalStructAsParam_AsSeqByRefInOut2"));
                break;
            case StructID.CharSetAnsiSequentialid:
                CharSetAnsiSequential sourceStr1 = Helper.NewCharSetAnsiSequential("some string", 'c');
                CharSetAnsiSequential changeStr1 = Helper.NewCharSetAnsiSequential("change string", 'n');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut3...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut3(ref sourceStr1));
                Assert.IsTrue(Helper.ValidateCharSetAnsiSequential(sourceStr1, changeStr1, "MarshalStructAsParam_AsSeqByRefInOut3"));
                break;
            case StructID.CharSetUnicodeSequentialid:
                CharSetUnicodeSequential sourceStr2 = Helper.NewCharSetUnicodeSequential("some string", 'c');
                CharSetUnicodeSequential changeStr2 = Helper.NewCharSetUnicodeSequential("change string", 'n');

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut4...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut4(ref sourceStr2));
                Assert.IsTrue(Helper.ValidateCharSetUnicodeSequential(sourceStr2, changeStr2, "MarshalStructAsParam_AsSeqByRefInOut4"));
                break;
            case StructID.NumberSequentialid:
                NumberSequential sourceNumberSequential = Helper.NewNumberSequential(Int32.MinValue, UInt32.MaxValue, short.MinValue, 
                    ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
                NumberSequential changeNumberSequential = Helper.NewNumberSequential(0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut6...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut6(ref sourceNumberSequential));
                Assert.IsTrue(Helper.ValidateNumberSequential(sourceNumberSequential, changeNumberSequential, "MarshalStructAsParam_AsSeqByRefInOut6"));
                break;
            case StructID.StructSeqWithArrayFieldid:
                int[] iarr = new int[256];
                int[] icarr = new int[256];
                InitialArray(iarr, icarr);

                StructSeqWithArrayField sourceStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(true, "some string", iarr);
                StructSeqWithArrayField changeStructSeqWithArrayField = Helper.NewStructSeqWithArrayField(false, "change string", icarr);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut7...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut7(ref sourceStructSeqWithArrayField));
                Assert.IsTrue(Helper.ValidateStructSeqWithArrayField(sourceStructSeqWithArrayField, changeStructSeqWithArrayField, "MarshalStructAsParam_AsSeqByRefInOut7"));
                break;
            case StructID.StructSeqWithEnumFieldid:
                Enum1 enums = Enum1.e1;
                Enum1 enumch = Enum1.e2;
                StructSeqWithEnumField sourceStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(32, "some string", enums);
                StructSeqWithEnumField changeStructSeqWithEnumField = Helper.NewStructSeqWithEnumField(64, "change string", enumch);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut8...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut8(ref sourceStructSeqWithEnumField));
                Assert.IsTrue(Helper.ValidateStructSeqWithEnumField(sourceStructSeqWithEnumField, changeStructSeqWithEnumField, "MarshalStructAsParam_AsSeqByRefInOut8"));
                break;
            case StructID.StringStructSequentialAnsiid:
                strOne = new String('a', 512);
                strTwo = new String('b', 512);
                StringStructSequentialAnsi sourceStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strOne, strTwo);
                StringStructSequentialAnsi changeStringStructSequentialAnsi = Helper.NewStringStructSequentialAnsi(strTwo, strOne);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut9...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut9(ref sourceStringStructSequentialAnsi));
                Assert.IsTrue(Helper.ValidateStringStructSequentialAnsi(sourceStringStructSequentialAnsi, 
                    changeStringStructSequentialAnsi, "MarshalStructAsParam_AsSeqByRefInOut9"));
                break;
            case StructID.StringStructSequentialUnicodeid:
                strOne = new String('a', 256);
                strTwo = new String('b', 256);
                StringStructSequentialUnicode sourceStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strOne, strTwo);
                StringStructSequentialUnicode changeStringStructSequentialUnicode = Helper.NewStringStructSequentialUnicode(strTwo, strOne);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut10...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut10(ref sourceStringStructSequentialUnicode));
                Assert.IsTrue(Helper.ValidateStringStructSequentialUnicode(sourceStringStructSequentialUnicode, 
                    changeStringStructSequentialUnicode, "MarshalStructAsParam_AsSeqByRefInOut10"));
                break;
            case StructID.PritypeStructSeqWithUnmanagedTypeid:
                PritypeStructSeqWithUnmanagedType sourcePritypeStructSeqWithUnmanagedType = 
                    Helper.NewPritypeStructSeqWithUnmanagedType("hello", true, /*128.00m,*/ 10, /*128, 128,*/ 32);
                PritypeStructSeqWithUnmanagedType changePritypeStructSeqWithUnmanagedType =
                    Helper.NewPritypeStructSeqWithUnmanagedType("world", false, /*256.00m,*/ 1, /*256, 256,*/ 64);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut11...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut11(ref sourcePritypeStructSeqWithUnmanagedType));
                Assert.IsTrue(Helper.ValidatePritypeStructSeqWithUnmanagedType(sourcePritypeStructSeqWithUnmanagedType, 
                    changePritypeStructSeqWithUnmanagedType, "MarshalStructAsParam_AsSeqByRefInOut11"));
                break;
            case StructID.StructSequentialWithDelegateFieldid:
                StructSequentialWithDelegateField sourceStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*128,*/ new TestDelegate1(testMethod));
                StructSequentialWithDelegateField changeStructSequentialWithDelegateField = 
                    Helper.NewStructSequentialWithDelegateField(/*256,*/ null);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut12...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut12(ref sourceStructSequentialWithDelegateField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithDelegateField(sourceStructSequentialWithDelegateField, 
                    changeStructSequentialWithDelegateField, "MarshalStructAsParam_AsSeqByRefInOut12"));
                break;
            case StructID.IncludeOuterIntergerStructSequentialid:
                IncludeOuterIntergerStructSequential sourceIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(32, 32);
                IncludeOuterIntergerStructSequential changeIncludeOuterIntergerStructSequential = Helper.NewIncludeOuterIntergerStructSequential(64, 64);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut13...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut13(ref sourceIncludeOuterIntergerStructSequential));
                Assert.IsTrue(Helper.ValidateIncludeOuterIntergerStructSequential(sourceIncludeOuterIntergerStructSequential, 
                    changeIncludeOuterIntergerStructSequential, "MarshalStructAsParam_AsSeqByRefInOut13"));
                break;
            case StructID.StructSequentialWithPointerFieldid:
                StructSequentialWithPointerField sourceStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(16), 32);
                StructSequentialWithPointerField changeStructSequentialWithPointerField = Helper.NewStructSequentialWithPointerField((int*)(32), 64);

                Console.WriteLine("Calling MarshalStructAsParam_AsSeqByRefInOut14...");
                Assert.IsTrue(MarshalStructAsParam_AsSeqByRefInOut14(ref sourceStructSequentialWithPointerField));
                Assert.IsTrue(Helper.ValidateStructSequentialWithPointerField(sourceStructSequentialWithPointerField, 
                    changeStructSequentialWithPointerField, "MarshalStructAsParam_AsSeqByRefInOut14"));
                break;

            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }
  
    #endregion

    private static void RunMarshalSeqStructAsParamByVal()
    {
        Console.WriteLine("Verify marshal sequential layout struct as param as ByVal");
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
        Console.WriteLine("Verify marshal sequential layout struct as param as ByRef");
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
        Console.WriteLine("Verify marshal sequential layout struct as param as ByValIn");
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
        Console.WriteLine("Verify marshal sequential layout struct as param as ByRefIn");
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
        Console.WriteLine("Verify marshal sequential layout struct as param as ByValOut");
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
        Console.WriteLine("Verify marshal sequential layout struct as param as ByRefOut");
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
        Console.WriteLine("Verify marshal sequential layout struct as param as ByValInOut");
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
        Console.WriteLine("Verify marshal sequential layout struct as param as ByRefInOut");
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



