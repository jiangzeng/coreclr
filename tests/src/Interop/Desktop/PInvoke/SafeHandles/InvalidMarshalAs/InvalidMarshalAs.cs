// PInvoke Invalid MarshalAs/SH tests
using System;
using System.Runtime.InteropServices;

public class SHTester_MA
{
    public static int Main()
    {
        int retVal = 100;

        ///////////////////////////////////Tests/////////////////////////////////////

        if (!RunSHInvalidMATests() || !RunSHInvalidretMATests() || !RunSHFldInvalidMATests())
            retVal = 0;

        /////////////////////////////////////////////////////////////////////////////

        Console.WriteLine((retVal == 0) ? "FAILED!" : "PASSED!");
        return retVal;

    } //end of Main

    /// <summary>
    /// All the invalid MarshalAs signatures follow
    /// </summary>
    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA1([MarshalAs(UnmanagedType.AnsiBStr)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA2([MarshalAs(UnmanagedType.AsAny)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA3([MarshalAs(UnmanagedType.Bool)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA4([MarshalAs(UnmanagedType.BStr)]SafeFileHandle sh);

    // NOTE: Specified unmanaged type is only valid on fields.
    //[DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError=true)]
    //public static extern bool SHInvalid_MA5([MarshalAs(UnmanagedType.ByValArray)]SafeFileHandle sh);

    //NOTE: Specified unmanaged type is only valid on fields.
    //[DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError=true)]
    //public static extern bool SHInvalid_MA6([MarshalAs(UnmanagedType.ByValTStr, SizeConst=10)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA7([MarshalAs(UnmanagedType.Currency)]SafeFileHandle sh);

    //NOTE: Specified unmanaged type also needs MarshalType or MarshalTypeRef which indicates the custom marshaler
    //[DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError=true)]
    //public static extern bool SHInvalid_MA8([MarshalAs(UnmanagedType.CustomMarshaler)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA9([MarshalAs(UnmanagedType.Error)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA10([MarshalAs(UnmanagedType.FunctionPtr)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA11([MarshalAs(UnmanagedType.I1)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA12([MarshalAs(UnmanagedType.I2)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA13([MarshalAs(UnmanagedType.I4)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA14([MarshalAs(UnmanagedType.I8)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA15([MarshalAs(UnmanagedType.IDispatch)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA16([MarshalAs(UnmanagedType.Interface)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA17([MarshalAs(UnmanagedType.IUnknown)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA18([MarshalAs(UnmanagedType.LPArray)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA19([MarshalAs(UnmanagedType.LPStr)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA20([MarshalAs(UnmanagedType.LPStruct)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA21([MarshalAs(UnmanagedType.LPTStr)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA22([MarshalAs(UnmanagedType.LPWStr)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA23([MarshalAs(UnmanagedType.R4)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA24([MarshalAs(UnmanagedType.R8)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA25([MarshalAs(UnmanagedType.SafeArray)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA26([MarshalAs(UnmanagedType.Struct)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA27([MarshalAs(UnmanagedType.SysInt)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA28([MarshalAs(UnmanagedType.SysUInt)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA29([MarshalAs(UnmanagedType.TBStr)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA30([MarshalAs(UnmanagedType.U1)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA31([MarshalAs(UnmanagedType.U2)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA32([MarshalAs(UnmanagedType.U4)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA33([MarshalAs(UnmanagedType.U8)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA34([MarshalAs(UnmanagedType.VariantBool)]SafeFileHandle sh);

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_MA", SetLastError = true)]
    public static extern bool SHInvalid_MA35([MarshalAs(UnmanagedType.VBByRefStr)]SafeFileHandle sh);

    /// <summary>
    ///runs all tests involving pinvoke signatures with invalid MarshalAs attributes
    /// </summary>
    public static bool RunSHInvalidMATests()
    {
        Console.WriteLine("\nRunSHInvalidMATests():");

        SafeFileHandle hnd = Helper.NewSFH();

        Console.WriteLine("Testing SHInvalid_MA1...");
        try
        {
            SHInvalid_MA1(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA2...");
        try
        {
            SHInvalid_MA2(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA3...");
        try
        {
            SHInvalid_MA3(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA4...");
        try
        {
            SHInvalid_MA4(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("SHInvalid_MA5 cannot be tested (see PInvoke signatures in test source for comments)...");
        Console.WriteLine("SHInvalid_MA6 cannot be tested (see PInvoke signatures in test source for comments)...");

        Console.WriteLine("Testing SHInvalid_MA7...");
        try
        {
            SHInvalid_MA7(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("SHInvalid_MA8 cannot be tested (see PInvoke signatures in test source for comments)...");

        Console.WriteLine("Testing SHInvalid_MA9...");
        try
        {
            SHInvalid_MA9(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA10...");
        try
        {
            SHInvalid_MA10(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA11...");
        try
        {
            SHInvalid_MA11(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA12...");
        try
        {
            SHInvalid_MA12(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA13...");
        try
        {
            SHInvalid_MA13(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA14...");
        try
        {
            SHInvalid_MA14(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA15...");
        try
        {
            SHInvalid_MA15(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        //NOTE: UnmanagedType.Interface is the only MA attribute that is valid
        //Console.WriteLine("Testing SHInvalid_MA16...");

        Console.WriteLine("Testing SHInvalid_MA17...");
        try
        {
            SHInvalid_MA17(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA18...");
        try
        {
            SHInvalid_MA18(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA19...");
        try
        {
            SHInvalid_MA19(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA20...");
        try
        {
            SHInvalid_MA20(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA21...");
        try
        {
            SHInvalid_MA21(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA22...");
        try
        {
            SHInvalid_MA22(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA23...");
        try
        {
            SHInvalid_MA23(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA24...");
        try
        {
            SHInvalid_MA24(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA25...");
        try
        {
            SHInvalid_MA25(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA26...");
        try
        {
            SHInvalid_MA26(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA27...");
        try
        {
            SHInvalid_MA27(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA28...");
        try
        {
            SHInvalid_MA28(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA29...");
        try
        {
            SHInvalid_MA29(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA30...");
        try
        {
            SHInvalid_MA30(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA31...");
        try
        {
            SHInvalid_MA31(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA32...");
        try
        {
            SHInvalid_MA32(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA33...");
        try
        {
            SHInvalid_MA33(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA34...");
        try
        {
            SHInvalid_MA34(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_MA35...");
        try
        {
            SHInvalid_MA35(hnd);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        return true;
    } //end of RunSHInvalidMATests

    /// <summary>
    /// All the invalid return MarshalAs signatures follow
    /// </summary>
    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.AnsiBStr)]
    public static extern SafeFileHandle SHInvalid_retMA1();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.AsAny)]
    public static extern SafeFileHandle SHInvalid_retMA2();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern SafeFileHandle SHInvalid_retMA3();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.BStr)]
    public static extern SafeFileHandle SHInvalid_retMA4();

    //NOTE: Specified unmanaged type is only valid on fields.
    //[DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError=true)]
    //[return:MarshalAs(UnmanagedType.ByValArray)]
    //public static extern SafeFileHandle SHInvalid_retMA5();

    //NOTE: Specified unmanaged type is only valid on fields.
    //[DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError=true)]
    //[return:MarshalAs(UnmanagedType.ByValTStr)]
    //public static extern SafeFileHandle SHInvalid_retMA6();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Currency)]
    public static extern SafeFileHandle SHInvalid_retMA7();

    //NOTE: Specified unmanaged type also needs MarshalType or MarshalTypeRef which indicate the custom marshaler
    //[DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError=true)]
    //[return:MarshalAs(UnmanagedType.CustomMarshaler)]
    //public static extern SafeFileHandle SHInvalid_retMA8();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Error)]
    public static extern SafeFileHandle SHInvalid_retMA9();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.FunctionPtr)]
    public static extern SafeFileHandle SHInvalid_retMA10();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern SafeFileHandle SHInvalid_retMA11();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.I2)]
    public static extern SafeFileHandle SHInvalid_retMA12();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.I4)]
    public static extern SafeFileHandle SHInvalid_retMA13();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.I8)]
    public static extern SafeFileHandle SHInvalid_retMA14();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    public static extern SafeFileHandle SHInvalid_retMA15();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Interface)]
    public static extern SafeFileHandle SHInvalid_retMA16();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.IUnknown)]
    public static extern SafeFileHandle SHInvalid_retMA17();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.LPArray)]
    public static extern SafeFileHandle SHInvalid_retMA18();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    public static extern SafeFileHandle SHInvalid_retMA19();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.LPStruct)]
    public static extern SafeFileHandle SHInvalid_retMA20();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.LPTStr)]
    public static extern SafeFileHandle SHInvalid_retMA21();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.LPWStr)]
    public static extern SafeFileHandle SHInvalid_retMA22();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.R4)]
    public static extern SafeFileHandle SHInvalid_retMA23();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.R8)]
    public static extern SafeFileHandle SHInvalid_retMA24();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.SafeArray)]
    public static extern SafeFileHandle SHInvalid_retMA25();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Struct)]
    public static extern SafeFileHandle SHInvalid_retMA26();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.SysInt)]
    public static extern SafeFileHandle SHInvalid_retMA27();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.SysUInt)]
    public static extern SafeFileHandle SHInvalid_retMA28();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.TBStr)]
    public static extern SafeFileHandle SHInvalid_retMA29();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern SafeFileHandle SHInvalid_retMA30();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.U2)]
    public static extern SafeFileHandle SHInvalid_retMA31();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.U4)]
    public static extern SafeFileHandle SHInvalid_retMA32();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.U8)]
    public static extern SafeFileHandle SHInvalid_retMA33();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    public static extern SafeFileHandle SHInvalid_retMA34();

    [DllImport("PInvoke_SafeHandle", EntryPoint="SHInvalid_retMA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.VBByRefStr)]
    public static extern SafeFileHandle SHInvalid_retMA35();

    /// <summary>
    ///runs all tests involving pinvoke signatures with invalid return MarshalAs attributes
    /// </summary>
    public static bool RunSHInvalidretMATests()
    {
        Console.WriteLine("\nRunSHInvalidretMATests():");

        Console.WriteLine("Testing SHInvalid_retMA1...");
        try
        {
            SHInvalid_retMA1();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA2...");
        try
        {
            SHInvalid_retMA2();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA3...");
        try
        {
            SHInvalid_retMA3();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA4...");
        try
        {
            SHInvalid_retMA4();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("SHInvalid_retMA5 cannot be tested (see PInvoke signatures in test source for comments)...");
        Console.WriteLine("SHInvalid_retMA6 cannot be tested (see PInvoke signatures in test source for comments)...");

        Console.WriteLine("Testing SHInvalid_retMA7...");
        try
        {
            SHInvalid_retMA7();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("SHInvalid_retMA8 cannot be tested (see PInvoke signatures in test source for comments)...");

        Console.WriteLine("Testing SHInvalid_retMA9...");
        try
        {
            SHInvalid_retMA9();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA10...");
        try
        {
            SHInvalid_retMA10();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA11...");
        try
        {
            SHInvalid_retMA11();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA12...");
        try
        {
            SHInvalid_retMA12();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA13...");
        try
        {
            SHInvalid_retMA13();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA14...");
        try
        {
            SHInvalid_retMA14();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA15...");
        try
        {
            SHInvalid_retMA15();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        //NOTE: If the return type is marked as Unman.Intf, then the unmanaged code should return an Interface
        //		pointer and not an integer---doing so will cause unexpected behavior
        /*	Console.WriteLine("Testing SHInvalid_retMA16...");
            try
            {
                SHInvalid_retMA16();
                Console.WriteLine("\tFAILED!  Exception not thrown.");
                return false;
            }
            catch(MarshalDirectiveException e)
            {
                Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
            }
        */
        Console.WriteLine("Testing SHInvalid_retMA17...");
        try
        {
            SHInvalid_retMA17();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA18...");
        try
        {
            SHInvalid_retMA18();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA19...");
        try
        {
            SHInvalid_retMA19();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA20...");
        try
        {
            SHInvalid_retMA20();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA21...");
        try
        {
            SHInvalid_retMA21();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA22...");
        try
        {
            SHInvalid_retMA22();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA23...");
        try
        {
            SHInvalid_retMA23();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA24...");
        try
        {
            SHInvalid_retMA24();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA25...");
        try
        {
            SHInvalid_retMA25();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA26...");
        try
        {
            SHInvalid_retMA26();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA27...");
        try
        {
            SHInvalid_retMA27();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA28...");
        try
        {
            SHInvalid_retMA28();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA29...");
        try
        {
            SHInvalid_retMA29();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA30...");
        try
        {
            SHInvalid_retMA30();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA31...");
        try
        {
            SHInvalid_retMA31();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA32...");
        try
        {
            SHInvalid_retMA32();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA33...");
        try
        {
            SHInvalid_retMA33();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA34...");
        try
        {
            SHInvalid_retMA34();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        Console.WriteLine("Testing SHInvalid_retMA35...");
        try
        {
            SHInvalid_retMA35();
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (MarshalDirectiveException e)
        {
            Console.WriteLine("\tCaught expected MarshalDirectiveException:\n\t\t " + e.ToString() + "\n");
        }

        return true;
    } //end of RunSHInvalidretretMATests

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA1 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA2 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA3 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA4 s);

    //[DllImport("PInvoke_SafeHandle", SetLastError = true)]
    //public static extern bool SHFldInvalid_MA(StructMA5 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA6 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA7 s);

    //NOTE: no corresponding struct definition
    //[DllImport("PInvoke_SafeHandle", SetLastError=true)]
    //public static extern bool SHFldInvalid_MA(StructMA8 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA9 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA10 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA11 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA12 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA13 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA14 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA15 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA16 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA17 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA18 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA19 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA20 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA21 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA22 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA23 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA24 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA25 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA26 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA27 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA28 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA29 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA30 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA31 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA32 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA33 s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHFldInvalid_MA(StructMA34 s);

    /// <summary>
    ///runs all tests involving pinvoke signatures passing/returning structures 
    ///containing SH fields with invalid MarshalAs attributes
    /// </summary>
    public static bool RunSHFldInvalidMATests()
    {
        Console.WriteLine("\nRunSHFldInvalidMATests():");

        StructMA1 s1 = new StructMA1();
        s1.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA1...");
        try
        {
            SHFldInvalid_MA(s1);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA2 s2 = new StructMA2();
        s2.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA2...");
        try
        {
            SHFldInvalid_MA(s2);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA3 s3 = new StructMA3();
        s3.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA3...");
        try
        {
            SHFldInvalid_MA(s3);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA4 s4 = new StructMA4();
        s4.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA4...");
        try
        {
            SHFldInvalid_MA(s4);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        //StructMA5 s5 = new StructMA5();
        //s5.hnd = Helper.NewSFH();
        //Console.WriteLine("Testing StructMA5...");
        //try
        //{
        //    SHFldInvalid_MA(s5);
        //    Console.WriteLine("\tFAILED!  Exception not thrown.");
        //    return false;
        //}
        //catch (TypeLoadException e)
        //{
        //    Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        //}

        StructMA6 s6 = new StructMA6();
        s6.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA6...");
        try
        {
            SHFldInvalid_MA(s6);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA7 s7 = new StructMA7();
        s7.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA7...");
        try
        {
            SHFldInvalid_MA(s7);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA9 s9 = new StructMA9();
        s9.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA9...");
        try
        {
            SHFldInvalid_MA(s9);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA10 s10 = new StructMA10();
        s10.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA10...");
        try
        {
            SHFldInvalid_MA(s10);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA11 s11 = new StructMA11();
        s11.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA11...");
        try
        {
            SHFldInvalid_MA(s11);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA12 s12 = new StructMA12();
        s12.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA12...");
        try
        {
            SHFldInvalid_MA(s12);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA13 s13 = new StructMA13();
        s13.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA13...");
        try
        {
            SHFldInvalid_MA(s13);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA14 s14 = new StructMA14();
        s14.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA14...");
        try
        {
            SHFldInvalid_MA(s14);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA15 s15 = new StructMA15();
        s15.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA15...");
        try
        {
            SHFldInvalid_MA(s15);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        //NOTE: UnmanagedType.Interface is the only MA attribute allowed
        //StructMA16 s16 = new StructMA16();
        //s16.hnd = Helper.NewSFH();
        //Console.WriteLine("Testing StructMA16...");
        //try
        //{
        //	SHFldInvalid_MA(s16);
        //	Console.WriteLine("\tFAILED!  Exception not thrown.");
        //	return false;
        //}
        //catch(TypeLoadException e)
        //{
        //	Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        //}

        StructMA17 s17 = new StructMA17();
        s17.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA17...");
        try
        {
            SHFldInvalid_MA(s17);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA18 s18 = new StructMA18();
        s18.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA18...");
        try
        {
            SHFldInvalid_MA(s18);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA19 s19 = new StructMA19();
        s19.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA19...");
        try
        {
            SHFldInvalid_MA(s19);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA20 s20 = new StructMA20();
        s20.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA20...");
        try
        {
            SHFldInvalid_MA(s20);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA21 s21 = new StructMA21();
        s21.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA21...");
        try
        {
            SHFldInvalid_MA(s21);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA22 s22 = new StructMA22();
        s22.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA22...");
        try
        {
            SHFldInvalid_MA(s22);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA23 s23 = new StructMA23();
        s23.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA23...");
        try
        {
            SHFldInvalid_MA(s23);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA24 s24 = new StructMA24();
        s24.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA24...");
        try
        {
            SHFldInvalid_MA(s24);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA25 s25 = new StructMA25();
        s25.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA25...");
        try
        {
            SHFldInvalid_MA(s25);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA26 s26 = new StructMA26();
        s26.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA26...");
        try
        {
            SHFldInvalid_MA(s26);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA27 s27 = new StructMA27();
        s27.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA27...");
        try
        {
            SHFldInvalid_MA(s27);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA28 s28 = new StructMA28();
        s28.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA28...");
        try
        {
            SHFldInvalid_MA(s28);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA29 s29 = new StructMA29();
        s29.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA29...");
        try
        {
            SHFldInvalid_MA(s29);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA30 s30 = new StructMA30();
        s30.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA30...");
        try
        {
            SHFldInvalid_MA(s30);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA31 s31 = new StructMA31();
        s31.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA31...");
        try
        {
            SHFldInvalid_MA(s31);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA32 s32 = new StructMA32();
        s32.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA32...");
        try
        {
            SHFldInvalid_MA(s32);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA33 s33 = new StructMA33();
        s33.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA33...");
        try
        {
            SHFldInvalid_MA(s33);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        StructMA34 s34 = new StructMA34();
        s34.hnd = Helper.NewSFH();
        Console.WriteLine("Testing StructMA34...");
        try
        {
            SHFldInvalid_MA(s34);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (TypeLoadException e)
        {
            Console.WriteLine("\tCaught expected TypeLoadException:\n\t\t " + e.ToString() + "\n");
        }

        return true;
    } //end of RunSHFldInvalidMATests

} //end of class SHTester_MA






