using System;
using System.Runtime.InteropServices;

/// <summary>
///  Pass Array Size by out keyword using SizeParamIndex Attributes
/// </summary>
public class ClientMarshalArrayAsSizeParamIndexByOut
{

    #region ByOut

    [DllImport("PInvoke_PassingByOutServer")]
    private static extern bool MarshalCStyleArrayByte_AsByOut_AsSizeParamIndex(
        out byte arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out byte[] arrByte);

    [DllImport("PInvoke_PassingByOutServer")]
    private static extern bool MarshalCStyleArraySbyte_AsByOut_AsSizeParamIndex(
        out sbyte arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out sbyte[] arrSbyte);

    [DllImport("PInvoke_PassingByOutServer")]
    private static extern bool MarshalCStyleArrayShort_AsByOut_AsSizeParamIndex(
        out short arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out short[] arrShort);

    [DllImport("PInvoke_PassingByOutServer")]
    private static extern bool MarshalCStyleArrayShortReturnNegative_AsByOut_AsSizeParamIndex(
        out short arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out short[] arrShort);

    [DllImport("PInvoke_PassingByOutServer")]
    private static extern bool MarshalCStyleArrayUshort_AsByOut_AsSizeParamIndex(
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out ushort[] arrUshort, out ushort arrSize);

    [DllImport("PInvoke_PassingByOutServer")]
    private static extern bool MarshalCStyleArrayInt_AsByOut_AsSizeParamIndex(
        out Int32 arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out Int32[] arrInt32);

    [DllImport("PInvoke_PassingByOutServer")]
    private static extern bool MarshalCStyleArrayUInt_AsByOut_AsSizeParamIndex(
        out UInt32 arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out UInt32[] arrUInt32);

    [DllImport("PInvoke_PassingByOutServer")]
    private static extern bool MarshalCStyleArrayLong_AsByOut_AsSizeParamIndex(
        out long arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out long[] arrLong);

    [DllImport("PInvoke_PassingByOutServer")]
    private static extern bool MarshalCStyleArrayUlong_AsByOut_AsSizeParamIndex(
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out ulong[] arrUlong, out ulong arrSize, ulong unused);

    [DllImport("PInvoke_PassingByOutServer")]
    private static extern bool MarshalCStyleArrayString_AsByOut_AsSizeParamIndex(
    [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.BStr)] out string[] arrInt32, out int arrSize);

    #endregion

    static bool SizeParamTypeIsByte()
    {
        string strDescription = "Scenario(byte ==> BYTE): Array_Size(N->M) = 1";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            byte byte_Array_Size;
            byte[] arrByte;

            if (!MarshalCStyleArrayByte_AsByOut_AsSizeParamIndex(out byte_Array_Size, out arrByte))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct Expected array
            int expected_ByteArray_Size = 1;
            byte[] expectedArrByte = Helper.GetExpChangeArray<byte>(expected_ByteArray_Size);

            //Verify
            if (!Helper.EqualArray<byte>(arrByte, (int)byte_Array_Size, expectedArrByte, (int)expectedArrByte.Length))
            {
                bResult = false;
                Console.WriteLine(" Failed: the Helper.EqualArray funcion return wrong value");
            }

            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (Exception ex)
        {
            bResult = false;
            Console.WriteLine("Unexpected Exception: {0}", ex.Message);
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
    }

    static bool SizeParamTypeIsSByte()
    {
        string strDescription = "Scenario(sbyte ==> CHAR):Array_Size(N->M) = sbyte.Max";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            sbyte sbyte_Array_Size;
            sbyte[] arrSbyte;

            if (!MarshalCStyleArraySbyte_AsByOut_AsSizeParamIndex(out sbyte_Array_Size, out arrSbyte))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            sbyte[] expectedArrSbyte = Helper.GetExpChangeArray<sbyte>(sbyte.MaxValue);

            if (!Helper.EqualArray<sbyte>(arrSbyte, (int)sbyte_Array_Size, expectedArrSbyte, (int)expectedArrSbyte.Length))
            {
                bResult = false;
                Console.WriteLine(" Failed: the Helper.EqualArray funcion return wrong value");
            }

            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (Exception ex)
        {
            bResult = false;
            Console.WriteLine("Unexpected Exception: {0}", ex.Message);
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
    }

    static bool SizeParamTypeIsShort1()
    {
        string strDescription = "Scenario(short ==> SHORT)1,Array_Size(M->N) = -1, Array_Size(N->M)=(ShortMax+1)/2";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            short shortArray_Size = (short)-1;
            short[] arrShort = Helper.InitArray<short>(10);
            if (!MarshalCStyleArrayShort_AsByOut_AsSizeParamIndex(out shortArray_Size, out arrShort))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct Expected Array
            int expected_ShortArray_Size = 16384;//(SHRT_MAX+1)/2
            short[] expectedArrShort = Helper.GetExpChangeArray<short>(expected_ShortArray_Size);

            if (!Helper.EqualArray<short>(arrShort, (int)shortArray_Size, expectedArrShort, (int)expectedArrShort.Length))
            {
                bResult = false;
                Console.WriteLine(" Failed: the Helper.EqualArray funcion return wrong value");
            }

            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (Exception ex)
        {
            bResult = false;
            Console.WriteLine("Unexpected Exception: {0}", ex.Message);
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
    }

    static bool SizeParamTypeIsShort2()
    {
        string strDescription = "Scenario(short ==> SHORT)2, Array_Size = 10, Array_Size(N->M) = -1";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            short short_Array_Size = (short)10;
            short[] arrShort = Helper.InitArray<short>(short_Array_Size);

            MarshalCStyleArrayShortReturnNegative_AsByOut_AsSizeParamIndex(out short_Array_Size, out arrShort);

            //Dont get exception
            bResult = false;
            Console.WriteLine("Doesnt get expected exception(OverflowException)");
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (OverflowException)
        {
            //Expected Exception
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (Exception ex)
        {
            bResult = false;
            Console.WriteLine("Unexpected Exception: {0}", ex.Message);
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
    }

    static bool SizeParamTypeIsUshort()
    {
        string strDescription = "Scenario(ushort==>USHORT): Array_Size(N->M) = ushort.MaxValue";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {

            ushort ushort_Array_Size;
            ushort[] arrUshort;
            if (!MarshalCStyleArrayUshort_AsByOut_AsSizeParamIndex(out arrUshort, out ushort_Array_Size))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Expected Array
            ushort[] expectedArrUshort = Helper.GetExpChangeArray<ushort>(ushort.MaxValue);

            //Verify Array
            if (!Helper.EqualArray<ushort>(arrUshort, (int)ushort_Array_Size, expectedArrUshort, (ushort)expectedArrUshort.Length))
            {
                bResult = false;
                Console.WriteLine(" Failed: the Helper.EqualArray funcion return wrong value");
            }

            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (Exception ex)
        {
            bResult = false;
            Console.WriteLine("Unexpected Exception: {0}", ex.Message);
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
    }

    static bool SizeParamTypeIsInt32()
    {
        string strDescription = "Scenario(Int32 ==> LONG): Array_Size(N->M) = 0 ";

        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            Int32 Int32_Array_Size;
            Int32[] arrInt32;
            if (!MarshalCStyleArrayInt_AsByOut_AsSizeParamIndex(out Int32_Array_Size, out arrInt32))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Expected Array
            Int32[] expectedArrInt32 = Helper.GetExpChangeArray<Int32>(0);

            //Verify array
            if (!Helper.EqualArray<Int32>(arrInt32, Int32_Array_Size, expectedArrInt32, expectedArrInt32.Length))
            {
                bResult = false;
                Console.WriteLine(" Failed: the Helper.EqualArray funcion return wrong value");
            }

            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (Exception ex)
        {
            bResult = false;
            Console.WriteLine("Unexpected Exception: {0}", ex.Message);
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
    }

    static bool SizeParamTypeIsUInt32()
    {
        string strDescription = "Scenario(UInt32 ==> ULONG): Array_Size(N->M) = 20";

        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        int expected_UInt32ArraySize = 20;
        try
        {
            UInt32 UInt32_Array_Size = (UInt32)10;
            UInt32[] arrUInt32 = Helper.InitArray<UInt32>((Int32)UInt32_Array_Size);
            if (!MarshalCStyleArrayUInt_AsByOut_AsSizeParamIndex(out UInt32_Array_Size, out arrUInt32))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct expected
            UInt32[] expectedArrUInt32 = Helper.GetExpChangeArray<UInt32>(expected_UInt32ArraySize);

            //Verify Array
            if (!Helper.EqualArray<UInt32>(arrUInt32, (Int32)UInt32_Array_Size, expectedArrUInt32, (Int32)expectedArrUInt32.Length))
            {
                bResult = false;
                Console.WriteLine(" Failed: the Helper.EqualArray funcion return wrong value");
            }

            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (Exception ex)
        {
            bResult = false;
            Console.WriteLine("Unexpected Exception: {0}", ex.Message);
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
    }

    static bool SizeParamTypeIsLong()
    {
        string strDescription = "Scenario(long ==> LONGLONG): Array_Size(N->M) = 20";

        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        int expected_LongArraySize = 20;
        try
        {
            long long_Array_Size = (long)10;
            long[] arrLong = Helper.InitArray<long>((Int32)long_Array_Size);

            if (!MarshalCStyleArrayLong_AsByOut_AsSizeParamIndex(out long_Array_Size, out arrLong))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            long[] expectedArrLong = Helper.GetExpChangeArray<long>(expected_LongArraySize);

            if (!Helper.EqualArray<long>(arrLong, (Int32)long_Array_Size, expectedArrLong, (Int32)expectedArrLong.Length))
            {
                bResult = false;
                Console.WriteLine(" Failed: the Helper.EqualArray funcion return wrong value");
            }

            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (Exception ex)
        {
            bResult = false;
            Console.WriteLine("Unexpected Exception: {0}", ex.Message);
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
    }

    static bool SizeParamTypeIsULong()
    {
        string strDescription = "Scenario(ulong ==> ULONGLONG): Array_Size(N->M) = 1000";

        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");
        bool bResult = true;
        int expected_ULongArraySize = 1000;
        try
        {
            ulong ulong_Array_Size = (ulong)10;
            ulong[] arrUlong = Helper.InitArray<ulong>((Int32)ulong_Array_Size);
            if (!MarshalCStyleArrayUlong_AsByOut_AsSizeParamIndex(out arrUlong, out ulong_Array_Size, ulong_Array_Size))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            ulong[] expectedArrUlong = Helper.GetExpChangeArray<ulong>(expected_ULongArraySize);

            if (!Helper.EqualArray<ulong>(arrUlong, (Int32)ulong_Array_Size, expectedArrUlong, (Int32)expectedArrUlong.Length))
            {
                bResult = false;
                Console.WriteLine(" Failed: the Helper.EqualArray funcion return wrong value");
            }

            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (Exception ex)
        {
            bResult = false;
            Console.WriteLine("Unexpected Exception: {0}", ex.Message);
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
    }

    static bool SizeParamTypeIsString()
    {
        string strDescription = "Scenario(String ==> BSTR): Array_Size(N->M) = 20";

        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");
        bool bResult = true;
        try
        {
            int expected_StringArraySize = 20;
            int string_Array_Size = 10;
            String[] arrString = Helper.InitArray<String>(string_Array_Size);
            if (!MarshalCStyleArrayString_AsByOut_AsSizeParamIndex(out arrString, out string_Array_Size))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            String[] expArrString = Helper.GetExpChangeArray<String>(expected_StringArraySize);

            if (!Helper.EqualArray<String>(arrString, string_Array_Size, expArrString, expArrString.Length))
            {
                bResult = false;
                Console.WriteLine(" Failed: the Helper.EqualArray funcion return wrong value");
            }

            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (Exception ex)
        {
            bResult = false;
            Console.WriteLine("Unexpected Exception: {0}", ex.Message);
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
    }

    static int Main()
    {
        bool result = true;
        Console.WriteLine("C-Style Array marshaled by out with SizeParamIndex attribute(by out Array size).");

        result = SizeParamTypeIsByte() && result;

        result = SizeParamTypeIsSByte() && result;

        result = SizeParamTypeIsShort1() && result;

        result = SizeParamTypeIsShort2() && result;

        result = SizeParamTypeIsUshort() && result;

        result = SizeParamTypeIsInt32() && result;

        result = SizeParamTypeIsUInt32() && result;

        result = SizeParamTypeIsLong() && result;

        result = SizeParamTypeIsULong() && result;

        result = SizeParamTypeIsString() && result;

        if (!result)
        {
            Console.WriteLine("Test Failed!");
            return 101;
        }
        else
        {
            Console.WriteLine("Test Passed!");
            return 100;
        }
    }
}