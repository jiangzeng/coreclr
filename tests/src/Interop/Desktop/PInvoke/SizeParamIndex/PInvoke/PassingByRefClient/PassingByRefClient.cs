using System;
using System.Runtime.InteropServices;

/// <summary>
///  Pass LPArray Size by ref keyword using SizeParamIndex Attributes
/// </summary>

public class ClientMarshalArrayAsSizeParamIndexByRef
{

    #region ByRef

    [DllImport("PInvoke_PassingByRefServer")]
    private static extern bool MarshalCStyleArrayByte_AsByRef_AsSizeParamIndex(
        ref byte arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ref byte[] arrByte);

    [DllImport("PInvoke_PassingByRefServer")]
    private static extern bool MarshalCStyleArraySbyte_AsByRef_AsSizeParamIndex(
        ref sbyte arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ref sbyte[] arrSbyte);

    [DllImport("PInvoke_PassingByRefServer")]
    private static extern bool MarshalCStyleArrayShort_AsByRef_AsSizeParamIndex(
        ref short arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ref short[] arrShort);

    [DllImport("PInvoke_PassingByRefServer")]
    private static extern bool MarshalCStyleArrayShortReturnNegative_AsByRef_AsSizeParamIndex(
        ref short arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ref short[] arrShort);

    [DllImport("PInvoke_PassingByRefServer")]
    private static extern bool MarshalCStyleArrayUshort_AsByRef_AsSizeParamIndex(
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ref ushort[] arrUshort, ref ushort arrSize);

    [DllImport("PInvoke_PassingByRefServer")]
    private static extern bool MarshalCStyleArrayInt_AsByRef_AsSizeParamIndex(
        ref Int32 arrSize, Int32 unused, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ref Int32[] arrInt32);

    [DllImport("PInvoke_PassingByRefServer")]
    private static extern bool MarshalCStyleArrayUInt_AsByRef_AsSizeParamIndex(
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ref UInt32[] arrUInt32, UInt32 unused, ref UInt32 arrSize);

    [DllImport("PInvoke_PassingByRefServer")]
    private static extern bool MarshalCStyleArrayLong_AsByRef_AsSizeParamIndex(
        ref long arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ref long[] arrLong);

    [DllImport("PInvoke_PassingByRefServer")]
    private static extern bool MarshalCStyleArrayUlong_AsByRef_AsSizeParamIndex(
        ref ulong arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ref ulong[] arrUlong);

    [DllImport("PInvoke_PassingByRefServer")]
    private static extern bool MarshalCStyleArrayString_AsByRef_AsSizeParamIndex(
        ref int arrSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0, ArraySubType = UnmanagedType.BStr)] ref string[] arrStr,
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0, ArraySubType = UnmanagedType.LPStr)] ref string[] arrStr2);

    #endregion

    static bool SizeParamTypeIsByte()
    {
        string strDescription = "Scenario(byte==>BYTE):Array_Size(M->N)=1,Array_Size(N->M)= byte.MinValue";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            byte byte_Array_Size = 1;
            byte[] arrByte = Helper.InitArray<byte>(byte_Array_Size);

            if (!MarshalCStyleArrayByte_AsByRef_AsSizeParamIndex(ref byte_Array_Size, ref arrByte))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct Expected array
            int expected_ByteArray_Size = Byte.MinValue;
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
        string strDescription = "Scenario(sbyte==>CHAR): Array_Size(M->N) = 10, Array_Size(N->M) = sbyte.Max";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            sbyte sbyte_Array_Size = (sbyte)10;
            sbyte[] arrSbyte = Helper.InitArray<sbyte>(sbyte_Array_Size);

            if (!MarshalCStyleArraySbyte_AsByRef_AsSizeParamIndex(ref sbyte_Array_Size, ref arrSbyte))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct Expected
            sbyte[] expectedArrSbyte = Helper.GetExpChangeArray<sbyte>(sbyte.MaxValue);

            //Verify
            if (!Helper.EqualArray<sbyte>(arrSbyte, (int)sbyte_Array_Size, expectedArrSbyte, (int)sbyte.MaxValue))
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
        string strDescription = "Scenario(short==>SHORT)1: Array_Size(M->N) = -1, Array_Size(N->M) = 20";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            short short_Array_Size = (short)-1;
            short[] arrShort = Helper.InitArray<short>(10);
            int expected_ByteArraySize = 20;

            if (!MarshalCStyleArrayShort_AsByRef_AsSizeParamIndex(ref short_Array_Size, ref arrShort))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct Expected
            short[] expectedArrShort = Helper.GetExpChangeArray<short>(expected_ByteArraySize);

            //Verify
            if (!Helper.EqualArray<short>(arrShort, (int)short_Array_Size, expectedArrShort, expectedArrShort.Length))
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
        string strDescription = "Scenario(short==>SHORT)2: Array_Size(M->N) = 10, Array_Size(N->M) = -1";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            short short_Array_Size = (short)10;
            short[] arrShort = Helper.InitArray<short>(10);

            MarshalCStyleArrayShortReturnNegative_AsByRef_AsSizeParamIndex(ref short_Array_Size, ref arrShort);

            //Dont get exception
            bResult = false;
            Console.WriteLine("Doesnt get expected exception(OverflowException)");
            Console.WriteLine(strDescription + " Ends!");
            return bResult;
        }
        catch (OverflowException)
        {
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

    static bool SizeParamTypeIsUShort()
    {
        string strDescription = "Scenario(ushort==>USHORT): Array_Size(M->N) = 0, Array_Size(N->M) = ushort.MaxValue";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            ushort ushort_Array_Size = 20;
            ushort[] arrUshort = Helper.InitArray<ushort>(ushort_Array_Size);

            int expected_UshortArraySize = ushort.MaxValue;

            if (!MarshalCStyleArrayUshort_AsByRef_AsSizeParamIndex(ref arrUshort, ref ushort_Array_Size))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct Expected
            ushort[] expectedArrShort = Helper.GetExpChangeArray<ushort>(expected_UshortArraySize);

            //Verify
            if (!Helper.EqualArray<ushort>(arrUshort, (int)ushort_Array_Size, expectedArrShort, expectedArrShort.Length))
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
        string strDescription = "Scenario(Int32==>LONG):Array_Size(M->N)=10, Array_Size(N->M)=1";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            Int32 Int32_Array_Size = (Int32)10;
            Int32[] arrInt32 = Helper.InitArray<Int32>(Int32_Array_Size);

            if (!MarshalCStyleArrayInt_AsByRef_AsSizeParamIndex(ref Int32_Array_Size, Int32.MaxValue, ref arrInt32))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct Expected
            int expected_UshortArraySize = 1;
            Int32[] expectedArrInt32 = Helper.GetExpChangeArray<Int32>(expected_UshortArraySize);

            //Verify
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
        string strDescription = "Scenario(UInt32==>ULONG):Array_Size(M->N)=1234,Array_Size(N->M)=4321";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            UInt32 UInt32_Array_Size = (UInt32)1234;
            UInt32[] arrUInt32 = Helper.InitArray<UInt32>((Int32)UInt32_Array_Size);

            if (!MarshalCStyleArrayUInt_AsByRef_AsSizeParamIndex(ref arrUInt32, 1234, ref UInt32_Array_Size))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct Expected
            int expected_UInt32ArraySize = 4321;
            UInt32[] expectedArrUInt32 = Helper.GetExpChangeArray<UInt32>(expected_UInt32ArraySize);

            //Verify
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
        string strDescription = "Scenario(long==>LONGLONG):Array_Size(M->N)=10,Array_Size(N->M)=20";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            long long_Array_Size = (long)10;
            long[] arrLong = Helper.InitArray<long>((Int32)long_Array_Size);

            if (!MarshalCStyleArrayLong_AsByRef_AsSizeParamIndex(ref long_Array_Size, ref arrLong))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct Expected Array
            int expected_LongArraySize = 20;
            long[] expectedArrLong = Helper.GetExpChangeArray<long>(expected_LongArraySize);

            //Verify
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
        string strDescription = "Scenario(ulong==>ULONGLONG):Array_Size(M->N)=0, Array_Size(N->M)=0";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            ulong ulong_Array_Size = (ulong)0;
            ulong[] arrUlong = Helper.InitArray<ulong>((Int32)ulong_Array_Size);

            if (!MarshalCStyleArrayUlong_AsByRef_AsSizeParamIndex(ref ulong_Array_Size, ref arrUlong))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct Expected
            int expected_ULongArraySize = 0;
            ulong[] expectedArrUlong = Helper.GetExpChangeArray<ulong>(expected_ULongArraySize);

            //Verify
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
        string strDescription = "Scenario(String==>BSTR):Array_Size(M->N)= 20, Array_Size(N->M)=10";
        Console.WriteLine();
        Console.WriteLine(strDescription + " Starts!");

        bool bResult = true;
        try
        {
            int array_Size = 20;
            String[] arrString = Helper.InitArray<String>(array_Size);
            String[] arrString2 = Helper.InitArray<String>(array_Size);

            if (!MarshalCStyleArrayString_AsByRef_AsSizeParamIndex(ref array_Size, ref arrString, ref arrString2))
            {
                bResult = false;
                Console.WriteLine(" Failed: the pinvoke funcion return wrong value");
            }

            //Construct Expected
            int expected_StringArraySize = 10;
            String[] expArrString = Helper.GetExpChangeArray<String>(expected_StringArraySize);

            //Verify
            if (!Helper.EqualArray<String>(arrString, array_Size, expArrString, expArrString.Length))
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

        result = SizeParamTypeIsByte() && result;
        result = SizeParamTypeIsSByte() && result;
        result = SizeParamTypeIsShort1() && result;
        result = SizeParamTypeIsShort2() && result;
        result = SizeParamTypeIsUShort() && result;
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