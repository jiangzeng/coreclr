using System;
using System.Runtime.InteropServices;

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
    [DllImport("PInvoke_Decimal_NativeServer.dll")]
    static extern bool TakeDecAsInOutParamAsLPStructByRef([MarshalAs(UnmanagedType.LPStruct), In, Out] ref decimal dec);
    [DllImport("PInvoke_Decimal_NativeServer.dll")]
    static extern bool TakeDecAsOutParamAsLPStructByRef([MarshalAs(UnmanagedType.LPStruct), Out] out decimal dec);
#if UNSUPPORTED
    // ProjectN fails the build while desktop throws MarshalDirectiveException    
    [DllImport("PInvoke_Decimal_NativeServer.dll")]
    [return: MarshalAs(UnmanagedType.LPStruct)]
    static extern decimal RetDec();

    // ProjectN fails the build while desktop throws MarshalDirectiveException
    [DllImport("PInvoke_Decimal_NativeServer.dll")]
    static extern bool TakeStru_Seq_DecAsLPStructAsFldByInOutRef([In, Out] ref Stru_Seq_DecAsLPStructAsFld s);
#endif

    //CY
    [DllImport("PInvoke_Decimal_NativeServer.dll")]
    static extern bool TakeCYAsInOutParamAsLPStructByRef([MarshalAs(UnmanagedType.Currency), In, Out] ref decimal cy);
    [DllImport("PInvoke_Decimal_NativeServer.dll")]
    static extern bool TakeCYAsOutParamAsLPStructByRef([MarshalAs(UnmanagedType.Currency), Out] out decimal cy);
    [DllImport("PInvoke_Decimal_NativeServer.dll")]
    [return: MarshalAs(UnmanagedType.Currency)]
    static extern decimal RetCY();
    [DllImport("PInvoke_Decimal_NativeServer.dll")]
    static extern bool TakeStru_Exp_DecAsCYAsFldByInOutRef([Out] out Stru_Exp_DecAsCYAsFld s);

    static int fails = 0;
    static decimal CY_MAX_VALUE = 922337203685477.5807M;
    static decimal CY_MIN_VALUE = -922337203685477.5808M;
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

    static void MarshalAsLPStruct()
    {
        // DECIMAL
        Console.WriteLine("Test 001.01# -- System.Decimal(As LPStruct / Param / In / Out / Ref) -> DECIMAL .");
        try
        {
            decimal dec = decimal.MaxValue;
            if (TakeDecAsInOutParamAsLPStructByRef(ref dec))
            {
                if (!Equals("001.01", decimal.MinValue, dec))
                    ++fails;
            }
            else
                ++fails;
        }
        catch (Exception ex)
        {
            ++fails;
            Console.WriteLine(ex);
        }

        Console.WriteLine("Test 001.02# -- System.Decimal(As LPStruct / Param / Out / Ref) -> DECIMAL .");
        try
        {
            decimal dec = decimal.Zero;
            if (TakeDecAsOutParamAsLPStructByRef(out dec))
            {
                if (!Equals("001.02", decimal.MinValue, dec))
                    ++fails;
            }
            else
                ++fails;
        }
        catch (Exception ex)
        {
            ++fails;
            Console.WriteLine(ex);
        }

#if UNSUPPORTED        
        // Nagtive 
        Console.WriteLine("Test 001.03# -- Return DECIMAL From Native Side.");
        try
        {
            RetDec();
            ++fails;
            Console.WriteLine("\t#Net Side Err {0}# -- Expected MarshalDirectiveException is not thrown.", "001.03");
        }
        catch (MarshalDirectiveException)
        { }
        catch (Exception ex)
        {
            ++fails;
            Console.WriteLine(ex);
        }

        Console.WriteLine("Test 001.04# -- System.Decimal(As LPStruct / Field / In / Out / Ref) -> DECIMAL .");
        try
        {
            Stru_Seq_DecAsLPStructAsFld s = new Stru_Seq_DecAsLPStructAsFld();
            s.dblVal = 1.23;
            s.cVal = 'I';
            s.dec = decimal.MinValue;

            if (!TakeStru_Seq_DecAsLPStructAsFldByInOutRef(ref s))
            {
                if (!Equals("001.04.01", decimal.MaxValue, s.dec) && !Equals("001.04.02", 3.21, s.dblVal) && !Equals("001.05.03", 'C', s.cVal))
                    ++fails;
            }
            else
                ++fails;
        }
        catch (MarshalDirectiveException)
        { }          
        catch (Exception ex)
        {
            ++fails;
            Console.WriteLine(ex);
        }
#endif

    }

    static void MarshalAsCurrencyScenario()
    {
        //CY
        Console.WriteLine("Test 002.01# -- System.Decimal(As Currency / Param / In / Out / Ref) -> CY");
        try
        {
            decimal cy = CY_MAX_VALUE;
            if (TakeCYAsInOutParamAsLPStructByRef(ref cy))
            {
                if (!Equals("002", CY_MIN_VALUE, cy))
                    ++fails;
            }
            else
                ++fails;
        }
        catch (Exception ex)
        {
            ++fails;
            Console.WriteLine(ex);
        }

        Console.WriteLine("Test 002.02# -- System.Decimal(As Currency / Param / Out / Ref) -> CY");
        try
        {
            decimal cy = decimal.MaxValue;
            if (TakeCYAsOutParamAsLPStructByRef(out cy))
            {
                if (!Equals("002.02", CY_MIN_VALUE, cy))
                    ++fails;
            }
            else
                ++fails;
        }
        catch (Exception ex)
        {
            ++fails;
            Console.WriteLine(ex);
        }

        Console.WriteLine("Test 002.03# -- Return CY From Native Side.");
        try
        {
            Equals("002.03", CY_MIN_VALUE, RetCY());
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

        Console.WriteLine("Test 002.04# -- System.Decimal(As Currency / Field / Out / Ref) -> CY .");
        try
        {
            Stru_Exp_DecAsCYAsFld s = new Stru_Exp_DecAsCYAsFld();
            s.cy = CY_MAX_VALUE;
            s.wc = 'I';

            if (TakeStru_Exp_DecAsCYAsFldByInOutRef(out s))
            {
                if (!Equals("002.04.01", CY_MAX_VALUE, s.cy) && !Equals("002.04.02", 'C', s.wc))
                    ++fails;
            }
            else
                ++fails;
        }
        catch (Exception ex)
        {
            ++fails;
            Console.WriteLine(ex);
        }
    }
    static int Main()
    {
        MarshalAsLPStruct();
#if UNSUPPORTED
        //see BUG730358 for more info
        MarshalAsCurrencyScenario();
#endif
        Console.WriteLine(0 == fails ? "\nPASSED !" : "\nFAILED !");
        return 0 == fails ? 100 : 101;
    }
}