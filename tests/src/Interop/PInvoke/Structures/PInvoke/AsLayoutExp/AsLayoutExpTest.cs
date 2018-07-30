// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using CoreFXTestLibrary;

public class Managed
{
    enum StructID
    {
        InnerExplicit1id,
        InnerExplicit2id,
        InnerArrayExplicit1id,
        InnerArrayExplicit2id,
        NumberExplicitid,
        ByteStructPack2Explicitid,
        ShortStructPack4Explicitid,
        IntStructPack8Explicitid,
        LongStructPack16Explicitid,
        StringExplicitid
    }

    public static int Main()
    {
        try
        {
            RunMarshalStructAsParamAsExpByVal();
            RunMarshalStructAsParamAsExpByRef();
            RunMarshalStructAsParamAsExpByValIn();
            RunMarshalStructAsParamAsExpByRefIn();
            RunMarshalStructAsParamAsExpByValOut();
            RunMarshalStructAsParamAsExpByRefOut();
            RunMarshalStructAsParamAsExpByValInOut();
            RunMarshalStructAsParamAsExpByRefInOut();

            return 100;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Test Failure: {e}");
            return 101;
        }
    }

    #region	Struct with Layout Explicit scenario1
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByValInnerExplicit1(InnerExplicit1 str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefInnerExplicit1(ref InnerExplicit1 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerExplicit1")]
    static extern bool MarshalStructAsParam_AsExpByValInInnerExplicit1([In] InnerExplicit1 str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefInInnerExplicit1([In] ref InnerExplicit1 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerExplicit1")]
    static extern bool MarshalStructAsParam_AsExpByValOutInnerExplicit1([Out] InnerExplicit1 str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefOutInnerExplicit1(out InnerExplicit1 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerExplicit1")]
    static extern bool MarshalStructAsParam_AsExpByValInOutInnerExplicit1([In, Out] InnerExplicit1 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefInnerExplicit1")]
    static extern bool MarshalStructAsParam_AsExpByRefInOutInnerExplicit1([In, Out] ref InnerExplicit1 str1);

    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefInOutStringExplicit")]
    static extern bool MarshalStructAsParam_AsExpByRefInOutStringExplicit([In, Out] ref StringExplicit str1);

    #endregion
    #region Struct with Layout Explicit scenario2
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByValInnerExplicit2(InnerExplicit2 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefInnerExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByRefInnerExplicit2(ref InnerExplicit2 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByValInInnerExplicit2([In] InnerExplicit2 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefInInnerExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByRefInInnerExplicit2([In] ref InnerExplicit2 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByValOutInnerExplicit2([Out] InnerExplicit2 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefOutInnerExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByRefOutInnerExplicit2(out InnerExplicit2 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByValInOutInnerExplicit2([In, Out] InnerExplicit2 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefInnerExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByRefInOutInnerExplicit2([In, Out] ref InnerExplicit2 str1);
    #endregion
    #region Struct with Layout Explicit scenario3
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByValInnerArrayExplicit1(InnerArrayExplicit1 str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefInnerArrayExplicit1(ref InnerArrayExplicit1 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerArrayExplicit1")]
    static extern bool MarshalStructAsParam_AsExpByValInInnerArrayExplicit1([In] InnerArrayExplicit1 str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefInInnerArrayExplicit1([In] ref InnerArrayExplicit1 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerArrayExplicit1")]
    static extern bool MarshalStructAsParam_AsExpByValOutInnerArrayExplicit1([Out] InnerArrayExplicit1 str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefOutInnerArrayExplicit1(out InnerArrayExplicit1 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerArrayExplicit1")]
    static extern bool MarshalStructAsParam_AsExpByValInOutInnerArrayExplicit1([In, Out] InnerArrayExplicit1 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefInnerArrayExplicit1")]
    static extern bool MarshalStructAsParam_AsExpByRefInOutInnerArrayExplicit1([In, Out] ref InnerArrayExplicit1 str1);
    #endregion
    #region Struct with Layout Explicit scenario4
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByValInnerArrayExplicit2(InnerArrayExplicit2 str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefInnerArrayExplicit2(ref InnerArrayExplicit2 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerArrayExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByValInInnerArrayExplicit2([In] InnerArrayExplicit2 str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefInInnerArrayExplicit2([In] ref InnerArrayExplicit2 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerArrayExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByValOutInnerArrayExplicit2([Out] InnerArrayExplicit2 str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefOutInnerArrayExplicit2(out InnerArrayExplicit2 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValInnerArrayExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByValInOutInnerArrayExplicit2([In, Out] InnerArrayExplicit2 str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefInnerArrayExplicit2")]
    static extern bool MarshalStructAsParam_AsExpByRefInOutInnerArrayExplicit2([In, Out] ref InnerArrayExplicit2 str1);
    #endregion
    #region Struct(NumberExplicit) with Layout Explicit scenario5
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByValNumberExplicit(NumberExplicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefNumberExplicit(ref NumberExplicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValNumberExplicit")]
    static extern bool MarshalStructAsParam_AsExpByValInNumberExplicit([In] NumberExplicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefInNumberExplicit([In] ref NumberExplicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValNumberExplicit")]
    static extern bool MarshalStructAsParam_AsExpByValOutNumberExplicit([Out] NumberExplicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefOutNumberExplicit(out NumberExplicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValNumberExplicit")]
    static extern bool MarshalStructAsParam_AsExpByValInOutNumberExplicit([In, Out] NumberExplicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefNumberExplicit")]
    static extern bool MarshalStructAsParam_AsExpByRefInOutNumberExplicit([In, Out] ref NumberExplicit str1);
    #endregion

    #region Struct(ByteStructPack2Explicit) with Layout Explicit scenario6
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByValByteStructPack2Explicit(ByteStructPack2Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefByteStructPack2Explicit(ref ByteStructPack2Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValByteStructPack2Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValInByteStructPack2Explicit([In] ByteStructPack2Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefInByteStructPack2Explicit([In] ref ByteStructPack2Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValByteStructPack2Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValOutByteStructPack2Explicit([Out] ByteStructPack2Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefOutByteStructPack2Explicit(out ByteStructPack2Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValByteStructPack2Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValInOutByteStructPack2Explicit([In, Out] ByteStructPack2Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefByteStructPack2Explicit")]
    static extern bool MarshalStructAsParam_AsExpByRefInOutByteStructPack2Explicit([In, Out] ref ByteStructPack2Explicit str1);

    #endregion
    #region Struct(ShortStructPack4Explicit) with Layout Explicit scenario7
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByValShortStructPack4Explicit(ShortStructPack4Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefShortStructPack4Explicit(ref ShortStructPack4Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValShortStructPack4Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValInShortStructPack4Explicit([In] ShortStructPack4Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefInShortStructPack4Explicit([In] ref ShortStructPack4Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValShortStructPack4Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValOutShortStructPack4Explicit([Out] ShortStructPack4Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefOutShortStructPack4Explicit(out ShortStructPack4Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValShortStructPack4Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValInOutShortStructPack4Explicit([In, Out] ShortStructPack4Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefShortStructPack4Explicit")]
    static extern bool MarshalStructAsParam_AsExpByRefInOutShortStructPack4Explicit([In, Out] ref ShortStructPack4Explicit str1);
    #endregion
    #region Struct(IntStructPack8Explicit) with Layout Explicit scenario8
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByValIntStructPack8Explicit(IntStructPack8Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefIntStructPack8Explicit(ref IntStructPack8Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValIntStructPack8Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValInIntStructPack8Explicit([In] IntStructPack8Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefInIntStructPack8Explicit([In] ref IntStructPack8Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValIntStructPack8Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValOutIntStructPack8Explicit([Out] IntStructPack8Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefOutIntStructPack8Explicit(out IntStructPack8Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValIntStructPack8Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValInOutIntStructPack8Explicit([In, Out] IntStructPack8Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefIntStructPack8Explicit")]
    static extern bool MarshalStructAsParam_AsExpByRefInOutIntStructPack8Explicit([In, Out] ref IntStructPack8Explicit str1);
    #endregion
    #region Struct(LongStructPack16Explicit) with Layout Explicit scenario9
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByValLongStructPack16Explicit(LongStructPack16Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefLongStructPack16Explicit(ref LongStructPack16Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValLongStructPack16Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValInLongStructPack16Explicit([In] LongStructPack16Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefInLongStructPack16Explicit([In] ref LongStructPack16Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValLongStructPack16Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValOutLongStructPack16Explicit([Out] LongStructPack16Explicit str1);
    [DllImport("AsParamNative.dll")]
    static extern bool MarshalStructAsParam_AsExpByRefOutLongStructPack16Explicit(out LongStructPack16Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByValLongStructPack16Explicit")]
    static extern bool MarshalStructAsParam_AsExpByValInOutLongStructPack16Explicit([In, Out] LongStructPack16Explicit str1);
    [DllImport("AsParamNative.dll", EntryPoint = "MarshalStructAsParam_AsExpByRefLongStructPack16Explicit")]
    static extern bool MarshalStructAsParam_AsExpByRefInOutLongStructPack16Explicit([In, Out] ref LongStructPack16Explicit str1);
    #endregion

    #region Marshal Explicit struct method

    private static void MarshalStructAsParam_AsExpByVal(StructID id)
    {
        switch (id)
        {
            case StructID.InnerExplicit1id:
                InnerExplicit1 sourceInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");
                InnerExplicit1 cloneInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInnerExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInnerExplicit1(sourceInnerExplicit1));
                Assert.IsTrue(Helper.ValidateInnerExplicit1(sourceInnerExplicit1, cloneInnerExplicit1, "MarshalStructAsParam_AsExpByValInnerExplicit1"));
                break;
            case StructID.InnerExplicit2id:
                InnerExplicit2 sourceInnerExplicit2 = new InnerExplicit2();
                sourceInnerExplicit2.f1 = 1;
                sourceInnerExplicit2.f3 = "some string";
                InnerExplicit2 cloneInnerExplicit2 = new InnerExplicit2();
                cloneInnerExplicit2.f1 = 1;
                cloneInnerExplicit2.f3 = "some string";

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInnerExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInnerExplicit2(sourceInnerExplicit2));
                Assert.IsTrue(Helper.ValidateInnerExplicit2(sourceInnerExplicit2, cloneInnerExplicit2, "MarshalStructAsParam_AsExpByValInnerExplicit2"));
                break;
            case StructID.InnerArrayExplicit1id:
                InnerArrayExplicit1 sourceInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");
                InnerArrayExplicit1 cloneInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInnerArrayExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInnerArrayExplicit1(sourceInnerArrayExplicit1));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit1(sourceInnerArrayExplicit1, cloneInnerArrayExplicit1, "MarshalStructAsParam_AsExpByValInnerArrayExplicit1"));
                break;
            case StructID.InnerArrayExplicit2id:
                InnerArrayExplicit2 sourceInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");
                InnerArrayExplicit2 cloneInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInnerArrayExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInnerArrayExplicit2(sourceInnerArrayExplicit2));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit2(sourceInnerArrayExplicit2, cloneInnerArrayExplicit2, "MarshalStructAsParam_AsExpByValInnerArrayExplicit2"));
                break;
            case StructID.NumberExplicitid:
                NumberExplicit sourceNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);
                NumberExplicit cloneNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValNumberExplicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValNumberExplicit(sourceNumberExplicit));
                Assert.IsTrue(Helper.ValidateNumberExplicit(sourceNumberExplicit, cloneNumberExplicit, "MarshalStructAsParam_AsExpByValNumberExplicit"));
                break;
            case StructID.ByteStructPack2Explicitid:
                ByteStructPack2Explicit sourceByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                ByteStructPack2Explicit cloneByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValByteStructPack2Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValByteStructPack2Explicit(sourceByteStructPack2Explicit));
                Assert.IsTrue(Helper.ValidateByteStructPack2Explicit(sourceByteStructPack2Explicit, 
                    cloneByteStructPack2Explicit, "MarshalStructAsParam_AsExpByValByteStructPack2Explicit"));
                break;
            case StructID.ShortStructPack4Explicitid:
                ShortStructPack4Explicit sourceShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                ShortStructPack4Explicit cloneShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValShortStructPack4Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValShortStructPack4Explicit(sourceShortStructPack4Explicit));
                Assert.IsTrue(Helper.ValidateShortStructPack4Explicit(sourceShortStructPack4Explicit, 
                    cloneShortStructPack4Explicit, "MarshalStructAsParam_AsExpByValShortStructPack4Explicit"));
                break;
            case StructID.IntStructPack8Explicitid:
                IntStructPack8Explicit sourceIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                IntStructPack8Explicit cloneIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValIntStructPack8Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValIntStructPack8Explicit(sourceIntStructPack8Explicit));
                Assert.IsTrue(Helper.ValidateIntStructPack8Explicit(sourceIntStructPack8Explicit, 
                    cloneIntStructPack8Explicit, "MarshalStructAsParam_AsExpByValIntStructPack8Explicit"));
                break;
            case StructID.LongStructPack16Explicitid:
                LongStructPack16Explicit sourceLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                LongStructPack16Explicit cloneLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValLongStructPack16Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValLongStructPack16Explicit(sourceLongStructPack16Explicit));
                Assert.IsTrue(Helper.ValidateLongStructPack16Explicit(sourceLongStructPack16Explicit, 
                    cloneLongStructPack16Explicit, "MarshalStructAsParam_AsExpByValLongStructPack16Explicit"));
                break;
            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }

    private static void MarshalStructAsParam_AsExpByRef(StructID id)
    {
        switch (id)
        {
            case StructID.InnerExplicit1id:
                InnerExplicit1 sourceInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");
                InnerExplicit1 changeInnerExplicit1 = Helper.NewInnerExplicit1(77, 77.0F, "changed string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInnerExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInnerExplicit1(ref sourceInnerExplicit1));
                Assert.IsTrue(Helper.ValidateInnerExplicit1(sourceInnerExplicit1, changeInnerExplicit1, "MarshalStructAsParam_AsExpByRefInnerExplicit1"));
                break;
            case StructID.InnerExplicit2id:
                InnerExplicit2 sourceInnerExplicit2 = new InnerExplicit2();
                sourceInnerExplicit2.f1 = 1;
                sourceInnerExplicit2.f3 = "some string";
                InnerExplicit2 changeInnerExplicit2 = new InnerExplicit2();
                changeInnerExplicit2.f1 = 77;
                changeInnerExplicit2.f3 = "changed string";

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInnerExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInnerExplicit2(ref sourceInnerExplicit2));
                Assert.IsTrue(Helper.ValidateInnerExplicit2(sourceInnerExplicit2, changeInnerExplicit2, "MarshalStructAsParam_AsExpByRefInnerExplicit2"));
                break;
            case StructID.InnerArrayExplicit1id:
                InnerArrayExplicit1 sourceInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");
                InnerArrayExplicit1 changeInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(77, 77.0F, "change string1", "change string2");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInnerArrayExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInnerArrayExplicit1(ref sourceInnerArrayExplicit1));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit1(sourceInnerArrayExplicit1, changeInnerArrayExplicit1, "MarshalStructAsParam_AsExpByRefInnerArrayExplicit1"));
                break;
            case StructID.InnerArrayExplicit2id:
                InnerArrayExplicit2 sourceInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");
                InnerArrayExplicit2 changeInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(77, 77.0F, "changed string", "changed string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInnerArrayExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInnerArrayExplicit2(ref sourceInnerArrayExplicit2));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit2(sourceInnerArrayExplicit2, changeInnerArrayExplicit2, "MarshalStructAsParam_AsExpByRefInnerArrayExplicit2"));
                break;
            case StructID.NumberExplicitid:
                NumberExplicit sourceNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);
                NumberExplicit changeNumberExplicit = Helper.NewNumberExplicit(Int32.MaxValue, UInt32.MinValue, new IntPtr(-64), 
                    new UIntPtr(64), short.MaxValue, ushort.MinValue, byte.MaxValue, sbyte.MinValue, long.MaxValue, ulong.MinValue, 64.0F, 6.4);

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefNumberExplicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefNumberExplicit(ref sourceNumberExplicit));
                Assert.IsTrue(Helper.ValidateNumberExplicit(sourceNumberExplicit, changeNumberExplicit, "MarshalStructAsParam_AsExpByRefNumberExplicit"));
                break;
            case StructID.ByteStructPack2Explicitid:
                ByteStructPack2Explicit sourceByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                ByteStructPack2Explicit changeByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(64, 64);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefByteStructPack2Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefByteStructPack2Explicit(ref sourceByteStructPack2Explicit));
                Assert.IsTrue(Helper.ValidateByteStructPack2Explicit(sourceByteStructPack2Explicit, 
                    changeByteStructPack2Explicit, "MarshalStructAsParam_AsExpByRefByteStructPack2Explicit"));
                break;
            case StructID.ShortStructPack4Explicitid:
                ShortStructPack4Explicit sourceShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                ShortStructPack4Explicit changeShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(64, 64);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefShortStructPack4Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefShortStructPack4Explicit(ref sourceShortStructPack4Explicit));
                Assert.IsTrue(Helper.ValidateShortStructPack4Explicit(sourceShortStructPack4Explicit, 
                    changeShortStructPack4Explicit, "MarshalStructAsParam_AsExpByRefShortStructPack4Explicit"));
                break;
            case StructID.IntStructPack8Explicitid:
                IntStructPack8Explicit sourceIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                IntStructPack8Explicit changeIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(64, 64);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefIntStructPack8Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefIntStructPack8Explicit(ref sourceIntStructPack8Explicit));
                Assert.IsTrue(Helper.ValidateIntStructPack8Explicit(sourceIntStructPack8Explicit, 
                    changeIntStructPack8Explicit, "MarshalStructAsParam_AsExpByRefIntStructPack8Explicit"));
                break;
            case StructID.LongStructPack16Explicitid:
                LongStructPack16Explicit sourceLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                LongStructPack16Explicit changeLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(64, 64);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefLongStructPack16Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefLongStructPack16Explicit(ref sourceLongStructPack16Explicit));
                Assert.IsTrue(Helper.ValidateLongStructPack16Explicit(sourceLongStructPack16Explicit, 
                    changeLongStructPack16Explicit, "MarshalStructAsParam_AsExpByRefLongStructPack16Explicit"));
                break;
            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }

    private static void MarshalStructAsParam_AsExpByValIn(StructID id)
    {
        switch (id)
        {
            case StructID.InnerExplicit1id:
                InnerExplicit1 sourceInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");
                InnerExplicit1 cloneInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInInnerExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInInnerExplicit1(sourceInnerExplicit1));
                Assert.IsTrue(Helper.ValidateInnerExplicit1(sourceInnerExplicit1, cloneInnerExplicit1, "MarshalStructAsParam_AsExpByValInInnerExplicit1"));
                break;
            case StructID.InnerExplicit2id:
                InnerExplicit2 sourceInnerExplicit2 = new InnerExplicit2();
                sourceInnerExplicit2.f1 = 1;
                sourceInnerExplicit2.f3 = "some string";
                InnerExplicit2 cloneInnerExplicit2 = new InnerExplicit2();
                cloneInnerExplicit2.f1 = 1;
                cloneInnerExplicit2.f3 = "some string";

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInInnerExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInInnerExplicit2(sourceInnerExplicit2));
                Assert.IsTrue(Helper.ValidateInnerExplicit2(sourceInnerExplicit2, cloneInnerExplicit2, "MarshalStructAsParam_AsExpByValInInnerExplicit2"));
                break;
            case StructID.InnerArrayExplicit1id:
                InnerArrayExplicit1 sourceInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");
                InnerArrayExplicit1 cloneInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInInnerArrayExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInInnerArrayExplicit1(sourceInnerArrayExplicit1));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit1(sourceInnerArrayExplicit1, cloneInnerArrayExplicit1, "MarshalStructAsParam_AsExpByValInInnerArrayExplicit1"));
                break;
            case StructID.InnerArrayExplicit2id:
                InnerArrayExplicit2 sourceInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");
                InnerArrayExplicit2 cloneInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInInnerArrayExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInInnerArrayExplicit2(sourceInnerArrayExplicit2));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit2(sourceInnerArrayExplicit2, cloneInnerArrayExplicit2, "MarshalStructAsParam_AsExpByValInInnerArrayExplicit2"));
                break;
            case StructID.NumberExplicitid:
                NumberExplicit sourceNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);
                NumberExplicit cloneNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInNumberExplicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInNumberExplicit(sourceNumberExplicit));
                Assert.IsTrue(Helper.ValidateNumberExplicit(sourceNumberExplicit, cloneNumberExplicit, "MarshalStructAsParam_AsExpByValInNumberExplicit"));
                break;
            case StructID.ByteStructPack2Explicitid:
                ByteStructPack2Explicit sourceByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                ByteStructPack2Explicit cloneByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInByteStructPack2Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInByteStructPack2Explicit(sourceByteStructPack2Explicit));
                Assert.IsTrue(Helper.ValidateByteStructPack2Explicit(sourceByteStructPack2Explicit, 
                    cloneByteStructPack2Explicit, "MarshalStructAsParam_AsExpByValInByteStructPack2Explicit"));
                break;
            case StructID.ShortStructPack4Explicitid:
                ShortStructPack4Explicit sourceShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                ShortStructPack4Explicit cloneShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInShortStructPack4Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInShortStructPack4Explicit(sourceShortStructPack4Explicit));
                Assert.IsTrue(Helper.ValidateShortStructPack4Explicit(sourceShortStructPack4Explicit, 
                    cloneShortStructPack4Explicit, "MarshalStructAsParam_AsExpByValInShortStructPack4Explicit"));
                break;
            case StructID.IntStructPack8Explicitid:
                IntStructPack8Explicit sourceIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                IntStructPack8Explicit cloneIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInIntStructPack8Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInIntStructPack8Explicit(sourceIntStructPack8Explicit));
                Assert.IsTrue(Helper.ValidateIntStructPack8Explicit(sourceIntStructPack8Explicit, 
                    cloneIntStructPack8Explicit, "MarshalStructAsParam_AsExpByValInIntStructPack8Explicit"));
                break;
            case StructID.LongStructPack16Explicitid:
                LongStructPack16Explicit sourceLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                LongStructPack16Explicit cloneLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInLongStructPack16Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInLongStructPack16Explicit(sourceLongStructPack16Explicit));
                Assert.IsTrue(Helper.ValidateLongStructPack16Explicit(sourceLongStructPack16Explicit, 
                    cloneLongStructPack16Explicit, "MarshalStructAsParam_AsExpByValInLongStructPack16Explicit"));
                break;
            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }

    private static void MarshalStructAsParam_AsExpByRefIn(StructID id)
    {
        switch (id)
        {
            case StructID.InnerExplicit1id:
                InnerExplicit1 sourceInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");
                InnerExplicit1 changeInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInInnerExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInInnerExplicit1(ref sourceInnerExplicit1));
                Assert.IsTrue(Helper.ValidateInnerExplicit1(sourceInnerExplicit1, changeInnerExplicit1, "MarshalStructAsParam_AsExpByRefInInnerExplicit1"));
                break;
            case StructID.InnerExplicit2id:
                InnerExplicit2 sourceInnerExplicit2 = new InnerExplicit2();
                sourceInnerExplicit2.f1 = 1;
                sourceInnerExplicit2.f3 = "some string";
                InnerExplicit2 changeInnerExplicit2 = new InnerExplicit2();
                changeInnerExplicit2.f1 = 1;
                changeInnerExplicit2.f3 = "some string";

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInInnerExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInInnerExplicit2(ref sourceInnerExplicit2));
                Assert.IsTrue(Helper.ValidateInnerExplicit2(sourceInnerExplicit2, changeInnerExplicit2, "MarshalStructAsParam_AsExpByRefInInnerExplicit2"));
                break;
            case StructID.InnerArrayExplicit1id:
                InnerArrayExplicit1 sourceInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");
                InnerArrayExplicit1 changeInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInInnerArrayExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInInnerArrayExplicit1(ref sourceInnerArrayExplicit1));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit1(sourceInnerArrayExplicit1, changeInnerArrayExplicit1, "MarshalStructAsParam_AsExpByRefInInnerArrayExplicit1"));
                break;
            case StructID.InnerArrayExplicit2id:
                InnerArrayExplicit2 sourceInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");
                InnerArrayExplicit2 changeInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInInnerArrayExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInInnerArrayExplicit2(ref sourceInnerArrayExplicit2));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit2(sourceInnerArrayExplicit2, changeInnerArrayExplicit2, "MarshalStructAsParam_AsExpByRefInInnerArrayExplicit2"));
                break;
            case StructID.NumberExplicitid:
                NumberExplicit sourceNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);
                NumberExplicit changeNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInNumberExplicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInNumberExplicit(ref sourceNumberExplicit));
                Assert.IsTrue(Helper.ValidateNumberExplicit(sourceNumberExplicit, changeNumberExplicit, "MarshalStructAsParam_AsExpByRefInNumberExplicit"));
                break;
            case StructID.ByteStructPack2Explicitid:
                ByteStructPack2Explicit sourceByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                ByteStructPack2Explicit changeByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInByteStructPack2Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInByteStructPack2Explicit(ref sourceByteStructPack2Explicit));
                Assert.IsTrue(Helper.ValidateByteStructPack2Explicit(sourceByteStructPack2Explicit, 
                    changeByteStructPack2Explicit, "MarshalStructAsParam_AsExpByRefInByteStructPack2Explicit"));
                break;
            case StructID.ShortStructPack4Explicitid:
                ShortStructPack4Explicit sourceShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                ShortStructPack4Explicit changeShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInShortStructPack4Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInShortStructPack4Explicit(ref sourceShortStructPack4Explicit));
                Assert.IsTrue(Helper.ValidateShortStructPack4Explicit(sourceShortStructPack4Explicit, 
                    changeShortStructPack4Explicit, "MarshalStructAsParam_AsExpByRefInShortStructPack4Explicit"));
                break;
            case StructID.IntStructPack8Explicitid:
                IntStructPack8Explicit sourceIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                IntStructPack8Explicit changeIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInIntStructPack8Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInIntStructPack8Explicit(ref sourceIntStructPack8Explicit));
                Assert.IsTrue(Helper.ValidateIntStructPack8Explicit(sourceIntStructPack8Explicit, 
                    changeIntStructPack8Explicit, "MarshalStructAsParam_AsExpByRefInIntStructPack8Explicit"));
                break;
            case StructID.LongStructPack16Explicitid:
                LongStructPack16Explicit sourceLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                LongStructPack16Explicit changeLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInLongStructPack16Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInLongStructPack16Explicit(ref sourceLongStructPack16Explicit));
                Assert.IsTrue(Helper.ValidateLongStructPack16Explicit(sourceLongStructPack16Explicit, 
                    changeLongStructPack16Explicit, "MarshalStructAsParam_AsExpByRefInLongStructPack16Explicit"));
                break;
            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }

    private static void MarshalStructAsParam_AsExpByValOut(StructID id)
    {
        switch (id)
        {
            case StructID.InnerExplicit1id:
                InnerExplicit1 sourceInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");
                InnerExplicit1 cloneInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValOutInnerExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValOutInnerExplicit1(sourceInnerExplicit1));
                Assert.IsTrue(Helper.ValidateInnerExplicit1(sourceInnerExplicit1, cloneInnerExplicit1, "MarshalStructAsParam_AsExpByValOutInnerExplicit1"));
                break;
            case StructID.InnerExplicit2id:
                InnerExplicit2 sourceInnerExplicit2 = new InnerExplicit2();
                sourceInnerExplicit2.f1 = 1;
                sourceInnerExplicit2.f3 = "some string";
                InnerExplicit2 cloneInnerExplicit2 = new InnerExplicit2();
                cloneInnerExplicit2.f1 = 1;
                cloneInnerExplicit2.f3 = "some string";

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValOutInnerExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValOutInnerExplicit2(sourceInnerExplicit2));
                Assert.IsTrue(Helper.ValidateInnerExplicit2(sourceInnerExplicit2, cloneInnerExplicit2, "MarshalStructAsParam_AsExpByValOutInnerExplicit2"));
                break;
            case StructID.InnerArrayExplicit1id:
                InnerArrayExplicit1 sourceInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");
                InnerArrayExplicit1 cloneInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValOutInnerArrayExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValOutInnerArrayExplicit1(sourceInnerArrayExplicit1));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit1(sourceInnerArrayExplicit1, cloneInnerArrayExplicit1, "MarshalStructAsParam_AsExpByValOutInnerArrayExplicit1"));
                break;
            case StructID.InnerArrayExplicit2id:
                InnerArrayExplicit2 sourceInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");
                InnerArrayExplicit2 cloneInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValOutInnerArrayExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValOutInnerArrayExplicit2(sourceInnerArrayExplicit2));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit2(sourceInnerArrayExplicit2, cloneInnerArrayExplicit2, "MarshalStructAsParam_AsExpByValOutInnerArrayExplicit2"));
                break;
            case StructID.NumberExplicitid:
                NumberExplicit sourceNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);
                NumberExplicit cloneNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValOutNumberExplicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValOutNumberExplicit(sourceNumberExplicit));
                Assert.IsTrue(Helper.ValidateNumberExplicit(sourceNumberExplicit, cloneNumberExplicit, "MarshalStructAsParam_AsExpByValOutNumberExplicit"));
                break;
            case StructID.ByteStructPack2Explicitid:
                ByteStructPack2Explicit sourceByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                ByteStructPack2Explicit cloneByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValOutByteStructPack2Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValOutByteStructPack2Explicit(sourceByteStructPack2Explicit));
                Assert.IsTrue(Helper.ValidateByteStructPack2Explicit(sourceByteStructPack2Explicit, 
                    cloneByteStructPack2Explicit, "MarshalStructAsParam_AsExpByValOutByteStructPack2Explicit"));
                break;
            case StructID.ShortStructPack4Explicitid:
                ShortStructPack4Explicit sourceShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                ShortStructPack4Explicit cloneShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValOutShortStructPack4Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValOutShortStructPack4Explicit(sourceShortStructPack4Explicit));
                Assert.IsTrue(Helper.ValidateShortStructPack4Explicit(sourceShortStructPack4Explicit, 
                    cloneShortStructPack4Explicit, "MarshalStructAsParam_AsExpByValOutShortStructPack4Explicit"));
                break;
            case StructID.IntStructPack8Explicitid:
                IntStructPack8Explicit sourceIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                IntStructPack8Explicit cloneIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValOutIntStructPack8Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValOutIntStructPack8Explicit(sourceIntStructPack8Explicit));
                Assert.IsTrue(Helper.ValidateIntStructPack8Explicit(sourceIntStructPack8Explicit, 
                    cloneIntStructPack8Explicit, "MarshalStructAsParam_AsExpByValOutIntStructPack8Explicit"));
                break;
            case StructID.LongStructPack16Explicitid:
                LongStructPack16Explicit sourceLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                LongStructPack16Explicit cloneLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValOutLongStructPack16Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValOutLongStructPack16Explicit(sourceLongStructPack16Explicit));
                Assert.IsTrue(Helper.ValidateLongStructPack16Explicit(sourceLongStructPack16Explicit, 
                    cloneLongStructPack16Explicit, "MarshalStructAsParam_AsExpByValOutLongStructPack16Explicit"));
                break;
            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }
   
    private static void MarshalStructAsParam_AsExpByRefOut(StructID id)
    {
            switch (id)
            {
                case StructID.InnerExplicit1id:
                    InnerExplicit1 sourceInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");
                    InnerExplicit1 changeInnerExplicit1 = Helper.NewInnerExplicit1(77, 77.0F, "changed string");

                    Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefOutInnerExplicit1...");
                    Assert.IsTrue(MarshalStructAsParam_AsExpByRefOutInnerExplicit1(out sourceInnerExplicit1));
                    Assert.IsTrue(Helper.ValidateInnerExplicit1(sourceInnerExplicit1, changeInnerExplicit1, "MarshalStructAsParam_AsExpByRefOutInnerExplicit1"));
                    break;
                case StructID.InnerExplicit2id:
                    InnerExplicit2 sourceInnerExplicit2 = new InnerExplicit2();
                    sourceInnerExplicit2.f1 = 1;
                    sourceInnerExplicit2.f3 = "some string";
                    InnerExplicit2 changeInnerExplicit2 = new InnerExplicit2();
                    changeInnerExplicit2.f1 = 77;
                    changeInnerExplicit2.f3 = "changed string";

                    Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefOutInnerExplicit2...");
                    Assert.IsTrue(MarshalStructAsParam_AsExpByRefOutInnerExplicit2(out sourceInnerExplicit2));
                    Assert.IsTrue(Helper.ValidateInnerExplicit2(sourceInnerExplicit2, changeInnerExplicit2, "MarshalStructAsParam_AsExpByRefOutInnerExplicit2"));
                    break;
                case StructID.InnerArrayExplicit1id:
                    InnerArrayExplicit1 sourceInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");
                    InnerArrayExplicit1 changeInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(77, 77.0F, "change string1", "change string2");

                    Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefOutInnerArrayExplicit1...");
                    Assert.IsTrue(MarshalStructAsParam_AsExpByRefOutInnerArrayExplicit1(out sourceInnerArrayExplicit1));
                    Assert.IsTrue(Helper.ValidateInnerArrayExplicit1(sourceInnerArrayExplicit1, changeInnerArrayExplicit1, "MarshalStructAsParam_AsExpByRefOutInnerArrayExplicit1"));
                    break;
                case StructID.InnerArrayExplicit2id:
                    InnerArrayExplicit2 sourceInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");
                    InnerArrayExplicit2 changeInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(77, 77.0F, "changed string", "changed string");

                    Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefOutInnerArrayExplicit2...");
                    Assert.IsTrue(MarshalStructAsParam_AsExpByRefOutInnerArrayExplicit2(out sourceInnerArrayExplicit2));
                    Assert.IsTrue(Helper.ValidateInnerArrayExplicit2(sourceInnerArrayExplicit2, changeInnerArrayExplicit2, "MarshalStructAsParam_AsExpByRefOutInnerArrayExplicit2"));
                    break;
                case StructID.NumberExplicitid:
                    NumberExplicit sourceNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                        new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);
                    NumberExplicit changeNumberExplicit = Helper.NewNumberExplicit(Int32.MaxValue, UInt32.MinValue, new IntPtr(-64), 
                        new UIntPtr(64), short.MaxValue, ushort.MinValue, byte.MaxValue, sbyte.MinValue, long.MaxValue, ulong.MinValue, 64.0F, 6.4);

                    Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefOutNumberExplicit...");
                    Assert.IsTrue(MarshalStructAsParam_AsExpByRefOutNumberExplicit(out sourceNumberExplicit));
                    Assert.IsTrue(Helper.ValidateNumberExplicit(sourceNumberExplicit, changeNumberExplicit, "MarshalStructAsParam_AsExpByRefOutNumberExplicit"));
                    break;
                case StructID.ByteStructPack2Explicitid:
                    ByteStructPack2Explicit sourceByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                    ByteStructPack2Explicit changeByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(64, 64);
                    Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefOutByteStructPack2Explicit...");
                    Assert.IsTrue(MarshalStructAsParam_AsExpByRefOutByteStructPack2Explicit(out sourceByteStructPack2Explicit));
                    Assert.IsTrue(Helper.ValidateByteStructPack2Explicit(sourceByteStructPack2Explicit, 
                        changeByteStructPack2Explicit, "MarshalStructAsParam_AsExpByRefOutByteStructPack2Explicit"));
                    break;
                case StructID.ShortStructPack4Explicitid:
                    ShortStructPack4Explicit sourceShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                    ShortStructPack4Explicit changeShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(64, 64);
                    Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefOutShortStructPack4Explicit...");
                    Assert.IsTrue(MarshalStructAsParam_AsExpByRefOutShortStructPack4Explicit(out sourceShortStructPack4Explicit));
                    Assert.IsTrue(Helper.ValidateShortStructPack4Explicit(sourceShortStructPack4Explicit, 
                        changeShortStructPack4Explicit, "MarshalStructAsParam_AsExpByRefOutShortStructPack4Explicit"));
                    break;
                case StructID.IntStructPack8Explicitid:
                    IntStructPack8Explicit sourceIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                    IntStructPack8Explicit changeIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(64, 64);
                    Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefOutIntStructPack8Explicit...");
                    Assert.IsTrue(MarshalStructAsParam_AsExpByRefOutIntStructPack8Explicit(out sourceIntStructPack8Explicit));
                    Assert.IsTrue(Helper.ValidateIntStructPack8Explicit(sourceIntStructPack8Explicit, 
                    changeIntStructPack8Explicit, "MarshalStructAsParam_AsExpByRefOutIntStructPack8Explicit"));
                break;
            case StructID.LongStructPack16Explicitid:
                LongStructPack16Explicit sourceLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                LongStructPack16Explicit changeLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(64, 64);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefOutLongStructPack16Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefOutLongStructPack16Explicit(out sourceLongStructPack16Explicit));
                Assert.IsTrue(Helper.ValidateLongStructPack16Explicit(sourceLongStructPack16Explicit, 
                    changeLongStructPack16Explicit, "MarshalStructAsParam_AsExpByRefOutLongStructPack16Explicit"));
                break;
            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }

    private static void MarshalStructAsParam_AsExpByValInOut(StructID id)
    {
        switch (id)
        {
            case StructID.InnerExplicit1id:
                InnerExplicit1 sourceInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");
                InnerExplicit1 cloneInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInOutInnerExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInOutInnerExplicit1(sourceInnerExplicit1));
                Assert.IsTrue(Helper.ValidateInnerExplicit1(sourceInnerExplicit1, cloneInnerExplicit1, "MarshalStructAsParam_AsExpByValInOutInnerExplicit1"));
                break;
            case StructID.InnerExplicit2id:
                InnerExplicit2 sourceInnerExplicit2 = new InnerExplicit2();
                sourceInnerExplicit2.f1 = 1;
                sourceInnerExplicit2.f3 = "some string";
                InnerExplicit2 cloneInnerExplicit2 = new InnerExplicit2();
                cloneInnerExplicit2.f1 = 1;
                cloneInnerExplicit2.f3 = "some string";

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInOutInnerExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInOutInnerExplicit2(sourceInnerExplicit2));
                Assert.IsTrue(Helper.ValidateInnerExplicit2(sourceInnerExplicit2, cloneInnerExplicit2, "MarshalStructAsParam_AsExpByValInOutInnerExplicit2"));
                break;
            case StructID.InnerArrayExplicit1id:
                InnerArrayExplicit1 sourceInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");
                InnerArrayExplicit1 cloneInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInOutInnerArrayExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInOutInnerArrayExplicit1(sourceInnerArrayExplicit1));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit1(sourceInnerArrayExplicit1, cloneInnerArrayExplicit1, "MarshalStructAsParam_AsExpByValInOutInnerArrayExplicit1"));
                break;
            case StructID.InnerArrayExplicit2id:
                InnerArrayExplicit2 sourceInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");
                InnerArrayExplicit2 cloneInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInOutInnerArrayExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInOutInnerArrayExplicit2(sourceInnerArrayExplicit2));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit2(sourceInnerArrayExplicit2, cloneInnerArrayExplicit2, "MarshalStructAsParam_AsExpByValInOutInnerArrayExplicit2"));
                break;
            case StructID.NumberExplicitid:
                NumberExplicit sourceNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);
                NumberExplicit cloneNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInOutNumberExplicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInOutNumberExplicit(sourceNumberExplicit));
                Assert.IsTrue(Helper.ValidateNumberExplicit(sourceNumberExplicit, cloneNumberExplicit, "MarshalStructAsParam_AsExpByValInOutNumberExplicit"));
                break;
            case StructID.ByteStructPack2Explicitid:
                ByteStructPack2Explicit sourceByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                ByteStructPack2Explicit cloneByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInOutByteStructPack2Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInOutByteStructPack2Explicit(sourceByteStructPack2Explicit));
                Assert.IsTrue(Helper.ValidateByteStructPack2Explicit(sourceByteStructPack2Explicit, 
                    cloneByteStructPack2Explicit, "MarshalStructAsParam_AsExpByValInOutByteStructPack2Explicit"));
                break;
            case StructID.ShortStructPack4Explicitid:
                ShortStructPack4Explicit sourceShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                ShortStructPack4Explicit cloneShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInOutShortStructPack4Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInOutShortStructPack4Explicit(sourceShortStructPack4Explicit));
                Assert.IsTrue(Helper.ValidateShortStructPack4Explicit(sourceShortStructPack4Explicit, 
                    cloneShortStructPack4Explicit, "MarshalStructAsParam_AsExpByValInOutShortStructPack4Explicit"));
                break;
            case StructID.IntStructPack8Explicitid:
                IntStructPack8Explicit sourceIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                IntStructPack8Explicit cloneIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInOutIntStructPack8Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInOutIntStructPack8Explicit(sourceIntStructPack8Explicit));
                Assert.IsTrue(Helper.ValidateIntStructPack8Explicit(sourceIntStructPack8Explicit, 
                    cloneIntStructPack8Explicit, "MarshalStructAsParam_AsExpByValInOutIntStructPack8Explicit"));
                break;
            case StructID.LongStructPack16Explicitid:
                LongStructPack16Explicit sourceLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                LongStructPack16Explicit cloneLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByValInOutLongStructPack16Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByValInOutLongStructPack16Explicit(sourceLongStructPack16Explicit));
                Assert.IsTrue(Helper.ValidateLongStructPack16Explicit(sourceLongStructPack16Explicit, 
                    cloneLongStructPack16Explicit, "MarshalStructAsParam_AsExpByValInOutLongStructPack16Explicit"));
                break;
            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }

    private static void MarshalStructAsParam_AsExpByRefInOut(StructID id)
    {
        switch (id)
        {
            case StructID.InnerExplicit1id:
                InnerExplicit1 sourceInnerExplicit1 = Helper.NewInnerExplicit1(1, 1.0F, "some string");
                InnerExplicit1 changeInnerExplicit1 = Helper.NewInnerExplicit1(77, 77.0F, "changed string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInOutInnerExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInOutInnerExplicit1(ref sourceInnerExplicit1));
                Assert.IsTrue(Helper.ValidateInnerExplicit1(sourceInnerExplicit1, changeInnerExplicit1, "MarshalStructAsParam_AsExpByRefInOutInnerExplicit1"));
                break;
            case StructID.InnerExplicit2id:
                InnerExplicit2 sourceInnerExplicit2 = new InnerExplicit2();
                sourceInnerExplicit2.f1 = 1;
                sourceInnerExplicit2.f3 = "some string";
                InnerExplicit2 changeInnerExplicit2 = new InnerExplicit2();
                changeInnerExplicit2.f1 = 77;
                changeInnerExplicit2.f3 = "changed string";

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInOutInnerExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInOutInnerExplicit2(ref sourceInnerExplicit2));
                Assert.IsTrue(Helper.ValidateInnerExplicit2(sourceInnerExplicit2, changeInnerExplicit2, "MarshalStructAsParam_AsExpByRefInOutInnerExplicit2"));
                break;
            case StructID.InnerArrayExplicit1id:
                InnerArrayExplicit1 sourceInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(1, 1.0F, "some string1", "some string2");
                InnerArrayExplicit1 changeInnerArrayExplicit1 = Helper.NewInnerArrayExplicit1(77, 77.0F, "change string1", "change string2");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInOutInnerArrayExplicit1...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInOutInnerArrayExplicit1(ref sourceInnerArrayExplicit1));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit1(sourceInnerArrayExplicit1, changeInnerArrayExplicit1, "MarshalStructAsParam_AsExpByRefInOutInnerArrayExplicit1"));
                break;
            case StructID.InnerArrayExplicit2id:
                InnerArrayExplicit2 sourceInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(1, 1.0F, "some string", "some string");
                InnerArrayExplicit2 changeInnerArrayExplicit2 = Helper.NewInnerArrayExplicit2(77, 77.0F, "changed string", "changed string");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInOutInnerArrayExplicit2...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInOutInnerArrayExplicit2(ref sourceInnerArrayExplicit2));
                Assert.IsTrue(Helper.ValidateInnerArrayExplicit2(sourceInnerArrayExplicit2, changeInnerArrayExplicit2, "MarshalStructAsParam_AsExpByRefInOutInnerArrayExplicit2"));
                break;
            case StructID.NumberExplicitid:
                NumberExplicit sourceNumberExplicit = Helper.NewNumberExplicit(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), 
                    new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);
                NumberExplicit changeNumberExplicit = Helper.NewNumberExplicit(Int32.MaxValue, UInt32.MinValue, new IntPtr(-64), 
                    new UIntPtr(64), short.MaxValue, ushort.MinValue, byte.MaxValue, sbyte.MinValue, long.MaxValue, ulong.MinValue, 64.0F, 6.4);

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInOutNumberExplicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInOutNumberExplicit(ref sourceNumberExplicit));
                Assert.IsTrue(Helper.ValidateNumberExplicit(sourceNumberExplicit, changeNumberExplicit, "MarshalStructAsParam_AsExpByRefInOutNumberExplicit"));
                break;
            case StructID.ByteStructPack2Explicitid:
                ByteStructPack2Explicit sourceByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(32, 32);
                ByteStructPack2Explicit changeByteStructPack2Explicit = Helper.NewByteStructPack2Explicit(64, 64);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInOutByteStructPack2Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInOutByteStructPack2Explicit(ref sourceByteStructPack2Explicit));
                Assert.IsTrue(Helper.ValidateByteStructPack2Explicit(sourceByteStructPack2Explicit, 
                    changeByteStructPack2Explicit, "MarshalStructAsParam_AsExpByRefInOutByteStructPack2Explicit"));
                break;
            case StructID.ShortStructPack4Explicitid:
                ShortStructPack4Explicit sourceShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(32, 32);
                ShortStructPack4Explicit changeShortStructPack4Explicit = Helper.NewShortStructPack4Explicit(64, 64);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInOutShortStructPack4Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInOutShortStructPack4Explicit(ref sourceShortStructPack4Explicit));
                Assert.IsTrue(Helper.ValidateShortStructPack4Explicit(sourceShortStructPack4Explicit, 
                    changeShortStructPack4Explicit, "MarshalStructAsParam_AsExpByRefInOutShortStructPack4Explicit"));
                break;
            case StructID.IntStructPack8Explicitid:
                IntStructPack8Explicit sourceIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(32, 32);
                IntStructPack8Explicit changeIntStructPack8Explicit = Helper.NewIntStructPack8Explicit(64, 64);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInOutIntStructPack8Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInOutIntStructPack8Explicit(ref sourceIntStructPack8Explicit));
                Assert.IsTrue(Helper.ValidateIntStructPack8Explicit(sourceIntStructPack8Explicit, 
                    changeIntStructPack8Explicit, "MarshalStructAsParam_AsExpByRefInOutIntStructPack8Explicit"));
                break;
            case StructID.LongStructPack16Explicitid:
                LongStructPack16Explicit sourceLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(32, 32);
                LongStructPack16Explicit changeLongStructPack16Explicit = Helper.NewLongStructPack16Explicit(64, 64);
                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInOutLongStructPack16Explicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInOutLongStructPack16Explicit(ref sourceLongStructPack16Explicit));
                Assert.IsTrue(Helper.ValidateLongStructPack16Explicit(sourceLongStructPack16Explicit, 
                    changeLongStructPack16Explicit, "MarshalStructAsParam_AsExpByRefInOutLongStructPack16Explicit"));
                break;
            case StructID.StringExplicitid:
                StringExplicit sourceStringExplicit = Helper.NewStringExplicit("Native_LPCSTR", "Native_LPCSTR", "ggggggggg\0");
                StringExplicit changeStringExplicit = Helper.NewStringExplicit("Managed_LPCSTR", "Managed_LPCSTR", "bbbbbbbbb\0");

                Console.WriteLine("Calling MarshalStructAsParam_AsExpByRefInOutStringExplicit...");
                Assert.IsTrue(MarshalStructAsParam_AsExpByRefInOutStringExplicit(ref sourceStringExplicit));
                Assert.IsTrue(Helper.ValidateStringExplicit(sourceStringExplicit, changeStringExplicit, "MarshalStructAsParam_AsExpByRefInOutStringExplicit"));
                break;
            default:
                Console.WriteLine("There is not the struct id");
                break;
        }
    }

    #endregion

    private static void RunMarshalStructAsParamAsExpByVal()
    {
        Console.WriteLine("Verify marshal Explicit layout struct as param as ByVal");
        MarshalStructAsParam_AsExpByVal(StructID.InnerExplicit1id);
        MarshalStructAsParam_AsExpByVal(StructID.InnerExplicit2id);
        MarshalStructAsParam_AsExpByVal(StructID.InnerArrayExplicit1id);
        MarshalStructAsParam_AsExpByVal(StructID.InnerArrayExplicit2id);
        MarshalStructAsParam_AsExpByVal(StructID.NumberExplicitid);
        MarshalStructAsParam_AsExpByVal(StructID.ByteStructPack2Explicitid);
        MarshalStructAsParam_AsExpByVal(StructID.ShortStructPack4Explicitid);
        MarshalStructAsParam_AsExpByVal(StructID.IntStructPack8Explicitid);
        MarshalStructAsParam_AsExpByVal(StructID.LongStructPack16Explicitid);
    }

    private static void RunMarshalStructAsParamAsExpByRef()
    {
        Console.WriteLine("Verify marshal Explicit layout struct as param as ByRef");
        MarshalStructAsParam_AsExpByRef(StructID.InnerExplicit1id);
        MarshalStructAsParam_AsExpByRef(StructID.InnerExplicit2id);
        MarshalStructAsParam_AsExpByRef(StructID.InnerArrayExplicit1id);
        MarshalStructAsParam_AsExpByRef(StructID.InnerArrayExplicit2id);
        MarshalStructAsParam_AsExpByRef(StructID.NumberExplicitid);
        MarshalStructAsParam_AsExpByRef(StructID.ByteStructPack2Explicitid);
        MarshalStructAsParam_AsExpByRef(StructID.ShortStructPack4Explicitid);
        MarshalStructAsParam_AsExpByRef(StructID.IntStructPack8Explicitid);
        MarshalStructAsParam_AsExpByRef(StructID.LongStructPack16Explicitid);
    }

    private static void RunMarshalStructAsParamAsExpByValIn()
    {
        Console.WriteLine("Verify marshal Explicit layout struct as param as ByValIn");
        MarshalStructAsParam_AsExpByValIn(StructID.InnerExplicit1id);
        MarshalStructAsParam_AsExpByValIn(StructID.InnerExplicit2id);
        MarshalStructAsParam_AsExpByValIn(StructID.InnerArrayExplicit1id);
        MarshalStructAsParam_AsExpByValIn(StructID.InnerArrayExplicit2id);
        MarshalStructAsParam_AsExpByValIn(StructID.NumberExplicitid);
        MarshalStructAsParam_AsExpByValIn(StructID.ByteStructPack2Explicitid);
        MarshalStructAsParam_AsExpByValIn(StructID.ShortStructPack4Explicitid);
        MarshalStructAsParam_AsExpByValIn(StructID.IntStructPack8Explicitid);
        MarshalStructAsParam_AsExpByValIn(StructID.LongStructPack16Explicitid);
    }

    private static void RunMarshalStructAsParamAsExpByRefIn()
    {
        Console.WriteLine("Verify marshal Explicit layout struct as param as ByRefIn");
        MarshalStructAsParam_AsExpByRefIn(StructID.InnerExplicit1id);
        MarshalStructAsParam_AsExpByRefIn(StructID.InnerExplicit2id);
        MarshalStructAsParam_AsExpByRefIn(StructID.InnerArrayExplicit1id);
        MarshalStructAsParam_AsExpByRefIn(StructID.InnerArrayExplicit2id);
        MarshalStructAsParam_AsExpByRefIn(StructID.NumberExplicitid);
        MarshalStructAsParam_AsExpByRefIn(StructID.ByteStructPack2Explicitid);
        MarshalStructAsParam_AsExpByRefIn(StructID.ShortStructPack4Explicitid);
        MarshalStructAsParam_AsExpByRefIn(StructID.IntStructPack8Explicitid);
        MarshalStructAsParam_AsExpByRefIn(StructID.LongStructPack16Explicitid);
    }

    private static void RunMarshalStructAsParamAsExpByValOut()
    {
        Console.WriteLine("Verify marshal Explicit layout struct as param as ByValOut");
        MarshalStructAsParam_AsExpByValOut(StructID.InnerExplicit1id);
        MarshalStructAsParam_AsExpByValOut(StructID.InnerExplicit2id);
        MarshalStructAsParam_AsExpByValOut(StructID.InnerArrayExplicit1id);
        MarshalStructAsParam_AsExpByValOut(StructID.InnerArrayExplicit2id);
        MarshalStructAsParam_AsExpByValOut(StructID.NumberExplicitid);
        MarshalStructAsParam_AsExpByValOut(StructID.ByteStructPack2Explicitid);
        MarshalStructAsParam_AsExpByValOut(StructID.ShortStructPack4Explicitid);
        MarshalStructAsParam_AsExpByValOut(StructID.IntStructPack8Explicitid);
        MarshalStructAsParam_AsExpByValOut(StructID.LongStructPack16Explicitid);
    }

    private static void RunMarshalStructAsParamAsExpByRefOut()
    {
        Console.WriteLine("Verify marshal Explicit layout struct as param as ByRefOut");
        MarshalStructAsParam_AsExpByRefOut(StructID.InnerExplicit1id);
        MarshalStructAsParam_AsExpByRefOut(StructID.InnerExplicit2id);
        MarshalStructAsParam_AsExpByRefOut(StructID.InnerArrayExplicit1id);
        MarshalStructAsParam_AsExpByRefOut(StructID.InnerArrayExplicit2id);
        MarshalStructAsParam_AsExpByRefOut(StructID.NumberExplicitid);
        MarshalStructAsParam_AsExpByRefOut(StructID.ByteStructPack2Explicitid);
        MarshalStructAsParam_AsExpByRefOut(StructID.ShortStructPack4Explicitid);
        MarshalStructAsParam_AsExpByRefOut(StructID.IntStructPack8Explicitid);
        MarshalStructAsParam_AsExpByRefOut(StructID.LongStructPack16Explicitid);
    }

    private static void RunMarshalStructAsParamAsExpByValInOut()
    {
        Console.WriteLine("Verify marshal Explicit layout struct as param as ByValInOut");
        MarshalStructAsParam_AsExpByValInOut(StructID.InnerExplicit1id);
        MarshalStructAsParam_AsExpByValInOut(StructID.InnerExplicit2id);
        MarshalStructAsParam_AsExpByValInOut(StructID.InnerArrayExplicit1id);
        MarshalStructAsParam_AsExpByValInOut(StructID.InnerArrayExplicit2id);
        MarshalStructAsParam_AsExpByValInOut(StructID.NumberExplicitid);
        MarshalStructAsParam_AsExpByValInOut(StructID.ByteStructPack2Explicitid);
        MarshalStructAsParam_AsExpByValInOut(StructID.ShortStructPack4Explicitid);
        MarshalStructAsParam_AsExpByValInOut(StructID.IntStructPack8Explicitid);
        MarshalStructAsParam_AsExpByValInOut(StructID.LongStructPack16Explicitid);
    }

    private static void RunMarshalStructAsParamAsExpByRefInOut()
    {
        Console.WriteLine("Verify marshal Explicit layout struct as param as ByRefInOut");
        MarshalStructAsParam_AsExpByRefInOut(StructID.InnerExplicit1id);
        MarshalStructAsParam_AsExpByRefInOut(StructID.StringExplicitid);
        MarshalStructAsParam_AsExpByRefInOut(StructID.InnerExplicit2id);
        MarshalStructAsParam_AsExpByRefInOut(StructID.InnerArrayExplicit1id);
        MarshalStructAsParam_AsExpByRefInOut(StructID.InnerArrayExplicit2id);
        MarshalStructAsParam_AsExpByRefInOut(StructID.NumberExplicitid);
        MarshalStructAsParam_AsExpByRefInOut(StructID.ByteStructPack2Explicitid);
        MarshalStructAsParam_AsExpByRefInOut(StructID.ShortStructPack4Explicitid);
        MarshalStructAsParam_AsExpByRefInOut(StructID.IntStructPack8Explicitid);
        MarshalStructAsParam_AsExpByRefInOut(StructID.LongStructPack16Explicitid);
    }

}