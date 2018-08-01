// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using CoreFXTestLibrary;

#pragma warning disable 618
[StructLayout(LayoutKind.Sequential)]
public struct Stru_Seq_DecAsStructAsFld
{
    public int number;

    [MarshalAs(UnmanagedType.Struct)]
    public decimal dec;
}

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
public struct Stru_Exp_DecAsCYAsFld
{
    [FieldOffset(0)]
    public char wc;

    [FieldOffset(8)]
    [MarshalAs(UnmanagedType.Currency)]
    public decimal dec;
}

[StructLayout(LayoutKind.Sequential,CharSet=CharSet.Ansi)]
public struct Stru_Seq_DecAsLPStructAsFld
{
    public double dblVal;

    public char cVal;

    [MarshalAs(UnmanagedType.LPStruct)]
    public decimal dec;
}

public class CMain
{
    #region Func Sig   
    
    // Dec As Struct
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_TakeDecByInOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecInOutRef dele);
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_TakeDecByOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecOutRef dele);
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_DecRet([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecRet dele);
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_TakeStru_Seq_DecAsStructAsFldByInOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_Stru_Seq_DecAsStructAsFldInOutRef dele);

    // Dec As CY
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_TakeCYByInOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_CYInOutRef dele);
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_TakeCYByOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_CYOutRef dele);
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_CYRet([MarshalAs(UnmanagedType.FunctionPtr)] Dele_CYRet dele);
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_TakeStru_Exp_DecAsCYAsFldByOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_Stru_Exp_DecAsCYAsFldOutRef dele);

    // Dec As LPStruct
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_TakeDecByInOutRefAsLPStruct([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecInOutRefAsLPStruct dele);
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_TakeDecByOutRefAsLPStruct([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecOutRefAsLPStruct dele);
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_DecAsLPStructRet([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecAsLPStructRet dele);
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_TakeStru_Seq_DecAsLPStructAsFldByInOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_Stru_Seq_DecAsLPStructAsFldInOutRef dele);
    //************** ReverseCall Return Int From Net **************//
    [DllImport("RevNative.dll")]
    static extern bool ReverseCall_IntRet([MarshalAs(UnmanagedType.FunctionPtr)] Dele_IntRet dele);

    #endregion

    #region Delegate Set
    
    // Dec As Struct
    delegate bool Dele_DecInOutRef([MarshalAs(UnmanagedType.Struct), In, Out]ref decimal dec);
    delegate bool Dele_DecOutRef([MarshalAs(UnmanagedType.Struct), Out]out decimal dec);
    [return: MarshalAs(UnmanagedType.Struct)]
    delegate decimal Dele_DecRet();
    delegate bool Dele_Stru_Seq_DecAsStructAsFldInOutRef([In, Out]ref Stru_Seq_DecAsStructAsFld s);

    // Dec As CY
    delegate bool Dele_CYInOutRef([MarshalAs(UnmanagedType.Currency), In, Out]ref decimal dec);
    delegate bool Dele_CYOutRef([MarshalAs(UnmanagedType.Currency), Out]out decimal dec);
    [return: MarshalAs(UnmanagedType.Currency)]
    delegate decimal Dele_CYRet();
    delegate bool Dele_Stru_Exp_DecAsCYAsFldOutRef([Out]out Stru_Exp_DecAsCYAsFld s);

    // Dec As LPStruct
    delegate bool Dele_DecInOutRefAsLPStruct([MarshalAs(UnmanagedType.LPStruct), In, Out]ref decimal dec);
    delegate bool Dele_DecOutRefAsLPStruct([MarshalAs(UnmanagedType.LPStruct), Out]out decimal dec);

    [return:MarshalAs(UnmanagedType.LPStruct)]
    delegate decimal Dele_DecAsLPStructRet();
    delegate bool Dele_Stru_Seq_DecAsLPStructAsFldInOutRef([In, Out]ref Stru_Seq_DecAsLPStructAsFld s);

    //************** ReverseCall Return Int From Net **************//
    delegate int Dele_IntRet();

    #endregion

    #region AUX For Testing
    const decimal CY_MAX_VALUE = 922337203685477.5807M;
    const decimal CY_MIN_VALUE = -922337203685477.5808M;

    static bool Equals<T>(T expected, T actual)
    {
        if (expected.Equals(actual))
            return true;
        else
            return false;
    }

    #endregion

    #region Method For Testing

    //Dec As Struct
    static bool TakeDecByInOutRef([MarshalAs(UnmanagedType.Struct), In, Out] ref decimal dec)
    {
        if (Equals(decimal.MaxValue, dec))
        {
            dec = decimal.MinValue;
            return true;
        }
        else
            return false;
    }

    static bool TakeDecByOutRef([MarshalAs(UnmanagedType.Struct), Out] out decimal dec)
    {
        dec = decimal.Zero;

        return true;
    }

    [return: MarshalAs(UnmanagedType.Struct)]
    static decimal DecRet()
    {
        return decimal.MinValue;
    }

    static bool TakeStru_Seq_DecAsStructAsFldByInOutRef([In, Out] ref Stru_Seq_DecAsStructAsFld s)
    {
        if (Equals(decimal.MaxValue, s.dec) && Equals(1, s.number))
        {
            s.dec = decimal.MinValue;
            s.number = 2;
            return true;
        }
        else
            return false;
    }

    // Dec As CY
    static bool TakeCYByInOutRef([MarshalAs(UnmanagedType.Currency), In, Out] ref decimal cy)
    {
        if (Equals(CY_MAX_VALUE, cy))
        {
            cy = CY_MIN_VALUE;
            return true;
        }
        else
            return false;
    }

    [return: MarshalAs(UnmanagedType.Currency)]
    static decimal CYRet()
    {
        return CY_MIN_VALUE;
    }

    static bool TakeCYByOutRef([MarshalAs(UnmanagedType.Currency), Out] out decimal dec)
    {
        dec = decimal.Zero;

        return true;
    }

    static bool ReverseCall_TakeStru_Exp_DecAsCYAsFldByOutRef([Out] out Stru_Exp_DecAsCYAsFld s)
    {
        s.dec = CY_MAX_VALUE;
        s.wc = 'C';

        return true;
    }

    //Dec As LPStruct
    static bool TakeDecByInOutRefAsLPStruct([MarshalAs(UnmanagedType.LPStruct), In, Out] ref decimal dec)
    {
        if (Equals(decimal.MaxValue, dec))
        {
            dec = decimal.MinValue;
            return true;
        }
        else
            return false;
    }

    static bool TakeDecByOutRefAsLPStruct([MarshalAs(UnmanagedType.LPStruct), Out] out decimal dec)
    {
        dec = decimal.Zero;

        return true;
    }

    [return: MarshalAs(UnmanagedType.LPStruct)]
    static decimal DecAsLPStructRet()
    {
        return decimal.MinValue;
    }

    static bool TakeStru_Seq_DecAsLPStructAsFldByInOutRef([In, Out] ref Stru_Seq_DecAsLPStructAsFld s)
    {
        if (Equals(decimal.MaxValue, s.dec) && Equals('I', s.cVal) && Equals(1.23, s.dblVal))
        {
            s.dec = decimal.MinValue;
            s.cVal = 'C';
            s.dblVal = 3.21;
            return true;
        }
        else
            return false;
    }

    //************** ReverseCall Return Int From Net **************//
    [return: MarshalAs(UnmanagedType.I4)]
    static int IntRet()
    {
        return 0x12345678;
    }

    #endregion

    static void AsStruct()
    {
        // Dec As Struct
        Assert.IsTrue(ReverseCall_TakeDecByInOutRef(new Dele_DecInOutRef(TakeDecByInOutRef)), "Decimal <-> DECIMAL, Marshal As Struct/Param, Passed By In / Out / Ref .");
        Assert.IsTrue(ReverseCall_TakeDecByOutRef(new Dele_DecOutRef(TakeDecByOutRef)), "Decimal <-> DECIMAL, Marshal As Struct/Param, Passed By Out / Ref .");
        Assert.IsTrue(ReverseCall_DecRet(new Dele_DecRet(DecRet)),"Decimal <-> DECIMAL, Marshal As Struct/RetVal .");
        Assert.IsTrue(ReverseCall_TakeStru_Seq_DecAsStructAsFldByInOutRef(new Dele_Stru_Seq_DecAsStructAsFldInOutRef(TakeStru_Seq_DecAsStructAsFldByInOutRef)), "Decimal <-> DECIMAL, Marshal As Struct/Field, Passed By In / Out / Ref .");
    }

    static void AsCY()
    {
        // Dec As CY
        Assert.IsTrue(ReverseCall_TakeCYByInOutRef(new Dele_CYInOutRef(TakeCYByInOutRef)));
        Assert.IsTrue(ReverseCall_TakeCYByOutRef(new Dele_CYOutRef(TakeCYByOutRef)));
        Assert.Throws<MarshalDirectiveException>(() => ReverseCall_CYRet(new Dele_CYRet(CYRet)), "Expected MarshalDirectiveException from TakeDecAsInOutParamAsLPStructByRef(ref dec) not thrown");
        Assert.IsTrue(ReverseCall_TakeStru_Exp_DecAsCYAsFldByOutRef(new Dele_Stru_Exp_DecAsCYAsFldOutRef(ReverseCall_TakeStru_Exp_DecAsCYAsFldByOutRef)));
    }

    static void AsLPStruct()
    {
        Assert.IsTrue(ReverseCall_TakeDecByInOutRefAsLPStruct(new Dele_DecInOutRefAsLPStruct(TakeDecByInOutRefAsLPStruct)), "Decimal <-> DECIMAL, Marshal As LPStruct/Param, Passed By In / Out / Ref");
        Assert.IsTrue(ReverseCall_TakeDecByOutRefAsLPStruct(new Dele_DecOutRefAsLPStruct(TakeDecByOutRefAsLPStruct)), "Decimal <-> DECIMAL, Marshal As LPStruct/Param, Passed By Out / Ref");
        // MCG would fail to compile these methods while desktop throws MarshalDirectiveException
        //TODO: failed test scenarios
        /* Test failed with exception: 
         * System.Runtime.InteropServices.MarshalDirectiveException: Method's type signature is not PInvoke compatible.
        Assert.IsTrue(ReverseCall_DecAsLPStructRet(new Dele_DecAsLPStructRet(DecAsLPStructRet)), "Decimal <-> DECIMAL, Marshal As LPStruct/RetVal");
        */
        /* Test failed with exception:
         * Cannot marshal field 'dec' of type 'Stru_Seq_DecAsLPStructAsFld': Invalid managed/unmanaged type combination (Decimal fields must be paired with Struct)
        Assert.IsTrue(ReverseCall_TakeStru_Seq_DecAsLPStructAsFldByInOutRef(new Dele_Stru_Seq_DecAsLPStructAsFldInOutRef(TakeStru_Seq_DecAsLPStructAsFldByInOutRef)), "Decimal <-> DECIMAL, Marshal As LPStruct/Field, Passed By In / Out / Ref");
        */
    }
    
    static void RunTest()
    {
        AsStruct();
        AsCY();
        AsLPStruct();
    }

    static int Main()
    {
        try{
            RunTest();
            // test int type
            Assert.IsTrue(ReverseCall_IntRet(new Dele_IntRet(IntRet)), "RET INT");
            return 100;
        } catch (Exception e){
            Console.WriteLine($"Test Failure: {e}"); 
            return 101; 
        }
    }
}
#pragma warning restore 618