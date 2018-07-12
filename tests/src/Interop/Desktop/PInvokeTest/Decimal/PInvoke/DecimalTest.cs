using System;
using System.Runtime.InteropServices;
using CoreFXTestLibrary;

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
#if UNSUPPORTED
    // ProjectN fails the build while desktop throws MarshalDirectiveException    
    [DllImport("DecNative.dll")]
    [return: MarshalAs(UnmanagedType.LPStruct)]
    static extern decimal RetDec();

    // ProjectN fails the build while desktop throws MarshalDirectiveException
    [DllImport("DecNative.dll")]
    static extern bool TakeStru_Seq_DecAsLPStructAsFldByInOutRef([In, Out] ref Stru_Seq_DecAsLPStructAsFld s);
#endif

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
        if (TakeDecAsInOutParamAsLPStructByRef(ref dec))
            Assert.AreEqual(decimal.MinValue, dec);
        else
            Assert.Fail("TakeDecAsInOutParamAsLPStructByRef : Returned false");

        dec = decimal.Zero;
        if (TakeDecAsOutParamAsLPStructByRef(out dec))
            Assert.AreEqual(decimal.MinValue, dec);
        else
            Assert.Fail("TakeDecAsOutParamAsLPStructByRef : Returned false");

#if UNSUPPORTED        
        // Nagtive 
        try
        {
            RetDec();
            Assert.Fail("Expected MarshalDirectiveException is not thrown");
        }
        catch (MarshalDirectiveException)
        {

        }

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
#endif
    }

    static void MarshalAsCurrencyScenario()
    {
        //CY
        decimal cy = CY_MAX_VALUE;
        if (TakeCYAsInOutParamAsLPStructByRef(ref cy))
            Assert.AreEqual(CY_MIN_VALUE, cy);
        else
            Assert.Fail("TakeCYAsInOutParamAsLPStructByRef : Returned false");

        cy = decimal.MaxValue;
        if (TakeCYAsOutParamAsLPStructByRef(out cy))
            Assert.AreEqual(CY_MIN_VALUE, cy);
        else
            Assert.Fail("TakeCYAsOutParamAsLPStructByRef : Returned false");

        try
        {
            CY_MIN_VALUE.Equals(RetCY());
            Assert.Fail("Expected MarshalDirectiveException is not thrown");
        }
        catch (MarshalDirectiveException)
        {

        }

        Stru_Exp_DecAsCYAsFld s = new Stru_Exp_DecAsCYAsFld();
        s.cy = CY_MAX_VALUE;
        s.wc = 'I';

        if (TakeStru_Exp_DecAsCYAsFldByInOutRef(out s))
        {
            Assert.AreEqual(CY_MAX_VALUE, s.cy);
            Assert.AreEqual('C', s.wc);
        }
        else
            Assert.Fail("TakeStru_Exp_DecAsCYAsFldByInOutRef : Returned false");
    }

    static int Main()
    {
        try{
            MarshalAsLPStruct();
#if UNSUPPORTED
            //see BUG730358 for more info
            MarshalAsCurrencyScenario();
#endif
            return 100;
        } catch (Exception e){
            Console.WriteLine("Test failure: " + e.Message); 
            return 101; 
        }
    }
}