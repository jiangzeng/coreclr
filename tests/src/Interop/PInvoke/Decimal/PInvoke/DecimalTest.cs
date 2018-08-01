// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using CoreFXTestLibrary;

#pragma warning disable 618
#region Struct Def
[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
public struct Stru_Exp_DecAsCYAsFld
{
    [FieldOffset(0)]
    public char wc;

    [FieldOffset(8)]
    [MarshalAs(UnmanagedType.Currency)]
    public decimal cy;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct Stru_Seq_DecAsLPStructAsFld
{
    public double dblVal;

    public char cVal;

    [MarshalAs(UnmanagedType.LPStruct)]
    public decimal dec;
}
#endregion

public class CMain
{
    //DECIMAL
    [DllImport("DecNative.dll")]
    static extern bool TakeDecAsInOutParamAsLPStructByRef([MarshalAs(UnmanagedType.LPStruct), In, Out] ref decimal dec);
    [DllImport("DecNative.dll")]
    static extern bool TakeDecAsOutParamAsLPStructByRef([MarshalAs(UnmanagedType.LPStruct), Out] out decimal dec);
    [DllImport("DecNative.dll")]
    [return: MarshalAs(UnmanagedType.LPStruct)]
    static extern decimal RetDec();
    [DllImport("DecNative.dll")]
    static extern bool TakeStru_Seq_DecAsLPStructAsFldByInOutRef([In, Out] ref Stru_Seq_DecAsLPStructAsFld s);

    //CY
    [DllImport("DecNative.dll")]
    static extern bool TakeCYAsInOutParamAsLPStructByRef([MarshalAs(UnmanagedType.Currency), In, Out] ref decimal cy);
    [DllImport("DecNative.dll")]
    static extern bool TakeCYAsOutParamAsLPStructByRef([MarshalAs(UnmanagedType.Currency), Out] out decimal cy);
    [DllImport("DecNative.dll")]
    [return: MarshalAs(UnmanagedType.Currency)]
    static extern decimal RetCY();
    [DllImport("DecNative.dll")]
    static extern bool TakeStru_Exp_DecAsCYAsFldByInOutRef([Out] out Stru_Exp_DecAsCYAsFld s);

    static int fails = 0;
    static decimal CY_MAX_VALUE = 922337203685477.5807M;
    static decimal CY_MIN_VALUE = -922337203685477.5808M;

    static void MarshalAsLPStruct()
    {
        // DECIMAL
        decimal dec = decimal.MaxValue;
        Assert.IsTrue(TakeDecAsInOutParamAsLPStructByRef(ref dec), "TakeDecAsInOutParamAsLPStructByRef : Returned false");
        Assert.AreEqual(decimal.MinValue, dec);

        dec = decimal.Zero;
        Assert.IsTrue(TakeDecAsOutParamAsLPStructByRef(out dec), "TakeDecAsOutParamAsLPStructByRef : Returned false");
        Assert.AreEqual(decimal.MinValue, dec);
        
        Assert.Throws<MarshalDirectiveException>(() => RetDec(), "Expected MarshalDirectiveException is not thrown");
        
        //TODO: failed test scenarios
        /* Test failed with exception:
         * Cannot marshal field 'dec' of type 'Stru_Seq_DecAsLPStructAsFld': Invalid managed/unmanaged type combination (Decimal fields must be paired with Struct)
        try
        {
            Stru_Seq_DecAsLPStructAsFld s = new Stru_Seq_DecAsLPStructAsFld();
            s.dblVal = 1.23;
            s.cVal = 'I';
            s.dec = decimal.MinValue;

            if (!TakeStru_Seq_DecAsLPStructAsFldByInOutRef(ref s))
            {
                Assert.AreEqual(decimal.MaxValue, s.dec);
                Assert.AreEqual(3.21, s.dblVal);
                Assert.AreEqual('C', s.cVal);
            }
            else
                Assert.Fail("TakeStru_Seq_DecAsLPStructAsFldByInOutRef : Returned false");
        }
        catch (MarshalDirectiveException)
        {

        } 
        */
    }

    static void MarshalAsCurrencyScenario()
    {
        //CY
        decimal cy = CY_MAX_VALUE;
        Assert.IsTrue(TakeCYAsInOutParamAsLPStructByRef(ref cy), "TakeCYAsInOutParamAsLPStructByRef : Returned false");
        Assert.AreEqual(CY_MIN_VALUE, cy);

        cy = decimal.MaxValue;
        Assert.IsTrue(TakeCYAsOutParamAsLPStructByRef(out cy), "TakeCYAsOutParamAsLPStructByRef : Returned false");
        Assert.AreEqual(CY_MIN_VALUE, cy);

        Assert.Throws<MarshalDirectiveException>(() => CY_MIN_VALUE.Equals(RetCY()), "Expected MarshalDirectiveException is not thrown");

        Stru_Exp_DecAsCYAsFld s = new Stru_Exp_DecAsCYAsFld();
        s.cy = CY_MAX_VALUE;
        s.wc = 'I';
        Assert.IsTrue(TakeStru_Exp_DecAsCYAsFldByInOutRef(out s), "TakeStru_Exp_DecAsCYAsFldByInOutRef : Returned false");
        if (TakeStru_Exp_DecAsCYAsFldByInOutRef(out s))
        Assert.AreEqual(CY_MAX_VALUE, s.cy);
        Assert.AreEqual('C', s.wc);
    }

    static int Main()
    {
        try{
            MarshalAsLPStruct();
            MarshalAsCurrencyScenario();
            return 100;
        } catch (Exception e){
            Console.WriteLine($"Test Failure: {e}"); 
            return 101; 
        }
    }
}
#pragma warning restore 618