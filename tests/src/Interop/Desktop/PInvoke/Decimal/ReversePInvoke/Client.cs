using System;
using System.Runtime.InteropServices;

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

#if UNSUPPORTED 
[StructLayout(LayoutKind.Sequential,CharSet=CharSet.Ansi)]
public struct Stru_Seq_DecAsLPStructAsFld
{
    public double dblVal;

    public char cVal;

    [MarshalAs(UnmanagedType.LPStruct)]
    public decimal dec;
}
#endif

public class CMain
{
    #region Func Sig   
    
    // Dec As Struct
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_TakeDecByInOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecInOutRef dele);
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_TakeDecByOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecOutRef dele);
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_DecRet([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecRet dele);
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_TakeStru_Seq_DecAsStructAsFldByInOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_Stru_Seq_DecAsStructAsFldInOutRef dele);

#if NOTSUPPORTED
    // Dec As CY
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_TakeCYByInOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_CYInOutRef dele);
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_TakeCYByOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_CYOutRef dele);
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_CYRet([MarshalAs(UnmanagedType.FunctionPtr)] Dele_CYRet dele);
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_TakeStru_Exp_DecAsCYAsFldByOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_Stru_Exp_DecAsCYAsFldOutRef dele);
#endif

    // Dec As LPStruct
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_TakeDecByInOutRefAsLPStruct([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecInOutRefAsLPStruct dele);
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_TakeDecByOutRefAsLPStruct([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecOutRefAsLPStruct dele);
#if NOTSUPPORTED    
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_DecAsLPStructRet([MarshalAs(UnmanagedType.FunctionPtr)] Dele_DecAsLPStructRet dele);
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
    static extern bool ReverseCall_TakeStru_Seq_DecAsLPStructAsFldByInOutRef([MarshalAs(UnmanagedType.FunctionPtr)] Dele_Stru_Seq_DecAsLPStructAsFldInOutRef dele);
#endif
    //************** ReverseCall Return Int From Net **************//
    [DllImport("ReversePInvoke_Decimal_NativeServer.dll")]
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

#if NOTSUPPORTED    
    [return:MarshalAs(UnmanagedType.LPStruct)]
    delegate decimal Dele_DecAsLPStructRet();
    delegate bool Dele_Stru_Seq_DecAsLPStructAsFldInOutRef([In, Out]ref Stru_Seq_DecAsLPStructAsFld s);
#endif

    //************** ReverseCall Return Int From Net **************//
    delegate int Dele_IntRet();

    #endregion

    #region AUX For Testing
    const decimal CY_MAX_VALUE = 922337203685477.5807M;
    const decimal CY_MIN_VALUE = -922337203685477.5808M;

    static bool Equals<T>(string errID, T expected, T actual)
    {
        if (expected.Equals(actual))
            return true;
        else
        {
            Console.WriteLine("\t#Net Side Err {0}# | \n\texpected = {1}, \n\tactual = {2}", errID, expected, actual);
            return false;
        }
    }

    #endregion

    #region Method For Testing

    //Dec As Struct
    static bool TakeDecByInOutRef([MarshalAs(UnmanagedType.Struct), In, Out] ref decimal dec)
    {
        if (Equals("001.01", decimal.MaxValue, dec))
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
        if (Equals("001.02", decimal.MaxValue, s.dec) && Equals("001.03", 1, s.number))
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
        if (Equals("002.01", CY_MAX_VALUE, cy))
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
        if (Equals("003.01", decimal.MaxValue, dec))
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

#if UNSUPPORTED    
    static bool TakeStru_Seq_DecAsLPStructAsFldByInOutRef([In, Out] ref Stru_Seq_DecAsLPStructAsFld s)
    {
        if (Equals("003.02", decimal.MaxValue, s.dec) && Equals("003.03", 'I', s.cVal) && Equals("003.04", 1.23, s.dblVal))
        {
            s.dec = decimal.MinValue;
            s.cVal = 'C';
            s.dblVal = 3.21;
            return true;
        }
        else
            return false;
    }
#endif

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
        TestHelper.BeginSubScenario("Marshal Decimal as Struct");

        TestHelper.Assert(ReverseCall_TakeDecByInOutRef(new Dele_DecInOutRef(TakeDecByInOutRef)), "Decimal <-> DECIMAL, Marshal As Struct/Param, Passed By In / Out / Ref .");
        TestHelper.Assert(ReverseCall_TakeDecByOutRef(new Dele_DecOutRef(TakeDecByOutRef)), "Decimal <-> DECIMAL, Marshal As Struct/Param, Passed By Out / Ref .");
        TestHelper.Assert(ReverseCall_DecRet(new Dele_DecRet(DecRet)),"Decimal <-> DECIMAL, Marshal As Struct/RetVal .");
        TestHelper.Assert(ReverseCall_TakeStru_Seq_DecAsStructAsFldByInOutRef(new Dele_Stru_Seq_DecAsStructAsFldInOutRef(TakeStru_Seq_DecAsStructAsFldByInOutRef)), "Decimal <-> DECIMAL, Marshal As Struct/Field, Passed By In / Out / Ref .");
    }

#if UNSUPPORTED
    static void AsCY()
    {
        // Dec As CY
        Console.WriteLine("#Test {0}# : Reverse Invoke, {1}", "002-01", "Decimal <-> CY, Marshal As Currency/Param, Passed By In / Out / Ref .");
        try
        {
            if (!ReverseCall_TakeCYByInOutRef(new Dele_CYInOutRef(TakeCYByInOutRef)))
                ++fails;
        }
        catch (Exception ex)
        {
            ++fails;
            Console.WriteLine(ex);
        }

        Console.WriteLine("#Test {0}# : Reverse Invoke, {1}", "002-02", "Decimal <-> CY, Marshal As Currency/Param, Passed By Out / Ref .");
        try
        {
            if (!ReverseCall_TakeCYByOutRef(new Dele_CYOutRef(TakeCYByOutRef)))
                ++fails;
        }
        catch (Exception ex)
        {
            ++fails;
            Console.WriteLine(ex);
        }

        Console.WriteLine("#Test {0}# : Reverse Invoke, {1}", "002-03", "Decimal <-> CY, Marshal As Currency/RetVal .");
        try
        {
            ReverseCall_CYRet(new Dele_CYRet(CYRet));
            ++fails;
        }
        catch (MarshalDirectiveException)
        {
        }
        catch (Exception ex)
        {
            ++fails;
            Console.WriteLine(ex);
        }

        Console.WriteLine("#Test {0}# : Reverse Invoke, {1}", "002-04", "Decimal <-> CY, Marshal As Currency/Field, Passed By Out / Ref .");
        try
        {
            if (!ReverseCall_TakeStru_Exp_DecAsCYAsFldByOutRef(new Dele_Stru_Exp_DecAsCYAsFldOutRef(ReverseCall_TakeStru_Exp_DecAsCYAsFldByOutRef)))
                ++fails;
        }
        catch (Exception ex)
        {
            ++fails;
            Console.WriteLine(ex);
        }
        
    }
#endif

    static void AsLPStruct()
    {
        TestHelper.BeginSubScenario("Marshal Decimal as LPStruct");

        TestHelper.Assert(ReverseCall_TakeDecByInOutRefAsLPStruct(new Dele_DecInOutRefAsLPStruct(TakeDecByInOutRefAsLPStruct)), "Decimal <-> DECIMAL, Marshal As LPStruct/Param, Passed By In / Out / Ref");
        TestHelper.Assert(ReverseCall_TakeDecByOutRefAsLPStruct(new Dele_DecOutRefAsLPStruct(TakeDecByOutRefAsLPStruct)), "Decimal <-> DECIMAL, Marshal As LPStruct/Param, Passed By Out / Ref");
#if NOTSUPPORTED
        // MCG would fail to compile these methods while desktop throws MarshalDirectiveExceptions
        TestHelper.Assert(ReverseCall_DecAsLPStructRet(new Dele_DecAsLPStructRet(DecAsLPStructRet)), "Decimal <-> DECIMAL, Marshal As LPStruct/RetVal");
        TestHelper.Assert(ReverseCall_TakeStru_Seq_DecAsLPStructAsFldByInOutRef(new Dele_Stru_Seq_DecAsLPStructAsFldInOutRef(TakeStru_Seq_DecAsLPStructAsFldByInOutRef)), "Decimal <-> DECIMAL, Marshal As LPStruct/Field, Passed By In / Out / Ref");
#endif        
    }
    static void RunTest()
    {
        AsStruct();
#if UNSUPPORTED
        AsCY();
#endif
        AsLPStruct();
    }

    static int Main()
    {
        RunTest();

        // test int type
        TestHelper.Assert(ReverseCall_IntRet(new Dele_IntRet(IntRet)), "RET INT");

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
