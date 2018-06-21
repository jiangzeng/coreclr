using System;
using System.Runtime.InteropServices;

class Test
{
    private static int NumArrOfStructElements1 = 10;

    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool SafeArray_In_Sequential_Struct(Struct_Sequential s);
    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool SafeArray_In_Explicit_Struct(Struct_Explicit s);
    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool SafeArray_In_Sequential_Class(Class_Sequential c);
    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool SafeArray_In_Explicit_Class(Class_Explicit c);

    #region Added marshal ArrayOfStruct as field
    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool MarshalArrayOfStructAsFieldInSeqStructByVal(Struct_SeqWithArrOfStr s, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool MarshalArrayOfStructAsFieldInSeqStructByRef(ref Struct_SeqWithArrOfStr s, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool MarshalArrayOfStructAsFieldInExpStructByVal(Struct_ExpWithArrOfStr s, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool MarshalArrayOfStructAsFieldInExpStructByRef(ref Struct_ExpWithArrOfStr s, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);

    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool MarshalArrayOfStructAsFieldInSeqClassByVal(Class_SeqWithArrOfStr s, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool MarshalArrayOfStructAsFieldInSeqClassByRef(ref Class_SeqWithArrOfStr s, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool MarshalArrayOfStructAsFieldInExpClassByVal(Class_ExpWithArrOfStr s, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArrayAsSafeArrayNative")]
    private static extern bool MarshalArrayOfStructAsFieldInExpClassByRef(ref Class_ExpWithArrOfStr s, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    #endregion

    #region Initialize Arrays
    private const int ARRAY_SIZE = 100;

    private static T[] InitArray<T>(int size)
    {
        T[] array = new T[size];

        for (int i = 0; i < array.Length; ++i)
            array[i] = (T)Convert.ChangeType(i, typeof(T));

        return array;
    }

    private static bool[] InitBoolArray(int size)
    {
        bool[] array = new bool[size];

        for (int i = 0; i < array.Length; ++i)
        {
            if (i % 2 == 0)
                array[i] = true;
            else
                array[i] = false;
        }

        return array;
    }

    #endregion
    #region methods for S2 struct array
    public static S2[] NewS2arr(int NumArrElements, int i32, uint ui32, short s1, ushort us1,
                   Byte b, SByte sb, Int16 i16, UInt16 ui16, Int64 i64, UInt64 ui64, Single sgl, Double d)
    {
        S2[] arrS2 = new S2[NumArrElements];
        for (int i = 0; i < NumArrElements; i++)
        {
            arrS2[i].i32 = i32;
            arrS2[i].ui32 = ui32;
            arrS2[i].s1 = s1;
            arrS2[i].us1 = us1;
            arrS2[i].b = b;
            arrS2[i].sb = sb;
            arrS2[i].i16 = i16;
            arrS2[i].ui16 = ui16;
            arrS2[i].i64 = i64;
            arrS2[i].ui64 = ui64;
            arrS2[i].sgl = sgl;
            arrS2[i].d = d;
        }
        return arrS2;
    }

    public static void PrintS2arr(string name, S2[] arrS2)
    {
        for (int i = 0; i < arrS2.Length; i++)
        {
            Console.WriteLine("{0}[{1}].i32 = {2}", name, i, arrS2[i].i32);
            Console.WriteLine("{0}[{1}].ui32 = {2}", name, i, arrS2[i].ui32);
            Console.WriteLine("{0}[{1}].s1 = {2}", name, i, arrS2[i].s1);
            Console.WriteLine("{0}[{1}].us1 = {2}", name, i, arrS2[i].us1);
            Console.WriteLine("{0}[{1}].b = {2}", name, i, arrS2[i].b);
            Console.WriteLine("{0}[{1}].sb = {2}", name, i, arrS2[i].sb);
            Console.WriteLine("{0}[{1}].i16 = {2}", name, i, arrS2[i].i16);
            Console.WriteLine("{0}[{1}].ui16 = {2}", name, i, arrS2[i].ui16);
            Console.WriteLine("{0}[{1}].i64 = {2}", name, i, arrS2[i].i64);
            Console.WriteLine("{0}[{1}].ui64 = {2}", name, i, arrS2[i].ui64);
            Console.WriteLine("{0}[{1}].sgl = {2}", name, i, arrS2[i].sgl);
            Console.WriteLine("{0}[{1}].d = {2}", name, i, arrS2[i].d);
        }
    }

    public static bool IsCorrect(S2[] arrS21, S2[] arrS22)
    {
        if (arrS21.Length != arrS22.Length)
        {
            return false;
        }
        for (int i = 0; i < arrS21.Length; i++)
        {
            if (arrS21[i].i32 != arrS22[i].i32 || arrS21[i].ui32 != arrS22[i].ui32 || arrS21[i].s1 != arrS22[i].s1 || arrS21[i].us1 != arrS22[i].us1 ||
                arrS21[i].b != arrS22[i].b || arrS21[i].sb != arrS22[i].sb || arrS21[i].i16 != arrS22[i].i16 ||
                arrS21[i].ui16 != arrS22[i].ui16 || arrS21[i].i64 != arrS22[i].i64 || arrS21[i].ui64 != arrS22[i].ui64 ||
                arrS21[i].sgl != arrS22[i].sgl || arrS21[i].d != arrS22[i].d)
            {
                return false;
            }
        }
        return true;
    }
    #endregion

    static bool RunTest1(string report)
    {
        Console.WriteLine(report);
        bool result = true;

        //init Struct_Sequential
        Struct_Sequential struct_Seq = new Struct_Sequential();
        struct_Seq.longArr = InitArray<int>(ARRAY_SIZE);
        struct_Seq.ulongArr = InitArray<uint>(ARRAY_SIZE);
        struct_Seq.shortArr = InitArray<short>(ARRAY_SIZE);
        struct_Seq.ushortArr = InitArray<ushort>(ARRAY_SIZE);
        struct_Seq.long64Arr = InitArray<long>(ARRAY_SIZE);
        struct_Seq.ulong64Arr = InitArray<ulong>(ARRAY_SIZE);
        struct_Seq.doubleArr = InitArray<double>(ARRAY_SIZE);
        struct_Seq.floatArr = InitArray<float>(ARRAY_SIZE);
        struct_Seq.byteArr = InitArray<byte>(ARRAY_SIZE);
        struct_Seq.bstrArr = InitArray<string>(ARRAY_SIZE);
        struct_Seq.boolArr = InitBoolArray(ARRAY_SIZE);

        result = SafeArray_In_Sequential_Struct(struct_Seq) && result;

        Console.WriteLine(result ? "PASS.\n" : "FAIL.\n");
        return result;
    }

    static bool RunTest2(string report)
    {
        Console.WriteLine(report);
        bool result = true;

        //init Struct_Explicit
        Struct_Explicit struct_Exp = new Struct_Explicit();
        struct_Exp.longArr = InitArray<int>(ARRAY_SIZE);
        struct_Exp.ulongArr = InitArray<uint>(ARRAY_SIZE);
        struct_Exp.shortArr = InitArray<short>(ARRAY_SIZE);
        struct_Exp.ushortArr = InitArray<ushort>(ARRAY_SIZE);
        struct_Exp.long64Arr = InitArray<long>(ARRAY_SIZE);
        struct_Exp.ulong64Arr = InitArray<ulong>(ARRAY_SIZE);
        struct_Exp.doubleArr = InitArray<double>(ARRAY_SIZE);
        struct_Exp.floatArr = InitArray<float>(ARRAY_SIZE);
        struct_Exp.byteArr = InitArray<byte>(ARRAY_SIZE);
        struct_Exp.bstrArr = InitArray<string>(ARRAY_SIZE);
        struct_Exp.boolArr = InitBoolArray(ARRAY_SIZE);

        result = SafeArray_In_Explicit_Struct(struct_Exp) && result;

        Console.WriteLine(result ? "PASS.\n" : "FAIL.\n");
        return result;
    }

    static bool RunTest3(string report)
    {
        Console.WriteLine(report);
        bool result = true;

        //init Class_Sequential
        Class_Sequential class_Seq = new Class_Sequential();
        class_Seq.longArr = InitArray<int>(ARRAY_SIZE);
        class_Seq.ulongArr = InitArray<uint>(ARRAY_SIZE);
        class_Seq.shortArr = InitArray<short>(ARRAY_SIZE);
        class_Seq.ushortArr = InitArray<ushort>(ARRAY_SIZE);
        class_Seq.long64Arr = InitArray<long>(ARRAY_SIZE);
        class_Seq.ulong64Arr = InitArray<ulong>(ARRAY_SIZE);
        class_Seq.doubleArr = InitArray<double>(ARRAY_SIZE);
        class_Seq.floatArr = InitArray<float>(ARRAY_SIZE);
        class_Seq.byteArr = InitArray<byte>(ARRAY_SIZE);
        class_Seq.bstrArr = InitArray<string>(ARRAY_SIZE);
        class_Seq.boolArr = InitBoolArray(ARRAY_SIZE);

        result = SafeArray_In_Sequential_Class(class_Seq) && result;

        Console.WriteLine(result ? "PASS.\n" : "FAIL.\n");
        return result;
    }

    static bool RunTest4(string report)
    {
        Console.WriteLine(report);
        bool result = true;

        //init Class_Explicit
        Class_Explicit class_Exp = new Class_Explicit();
        class_Exp.longArr = InitArray<int>(ARRAY_SIZE);
        class_Exp.ulongArr = InitArray<uint>(ARRAY_SIZE);
        class_Exp.shortArr = InitArray<short>(ARRAY_SIZE);
        class_Exp.ushortArr = InitArray<ushort>(ARRAY_SIZE);
        class_Exp.long64Arr = InitArray<long>(ARRAY_SIZE);
        class_Exp.ulong64Arr = InitArray<ulong>(ARRAY_SIZE);
        class_Exp.doubleArr = InitArray<double>(ARRAY_SIZE);
        class_Exp.floatArr = InitArray<float>(ARRAY_SIZE);
        class_Exp.byteArr = InitArray<byte>(ARRAY_SIZE);
        class_Exp.bstrArr = InitArray<string>(ARRAY_SIZE);
        class_Exp.boolArr = InitBoolArray(ARRAY_SIZE);

        result = SafeArray_In_Explicit_Class(class_Exp) && result;

        Console.WriteLine(result ? "PASS.\n" : "FAIL.\n");
        return result;
    }

    static bool RunTest5(string report)
    {
        bool result = true;
        Struct_SeqWithArrOfStr strParam = new Struct_SeqWithArrOfStr();

        S2[] sourceArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, 
            sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        S2[] cloneArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, 
            sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        S2[] changeArrS2 = NewS2arr(NumArrOfStructElements1, 0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

        strParam.arrS2 = sourceArrS2;

        #region MarshalArrayOfStructAsFieldInSeqStructByVal
        Console.WriteLine("\tMarshaling ArrayOfStruct AsSafeArray As Field In SeqStruct ByVal");
        try
        {
            if (!MarshalArrayOfStructAsFieldInSeqStructByVal(strParam, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsFieldInSeqStructByVal did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(strParam.arrS2, cloneArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByVal did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("strParam.arrS2", strParam.arrS2);
                Console.WriteLine("\tThe Expected is...");
                PrintS2arr("cloneArrS2", cloneArrS2);
                result = false;
            }
            else
            {
                Console.WriteLine("\tPASSED!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            result = false;
        }
        #endregion
        #region MarshalArrayOfStructAsFieldInSeqStructByRef
        Console.WriteLine("\tMarshaling ArrayOfStruct AsSafeArray As Field In SeqStruct ByRef");
        try
        {
            if (!MarshalArrayOfStructAsFieldInSeqStructByRef(ref strParam, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsFieldInSeqStructByRef did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(strParam.arrS2, changeArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByRef did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("strParam.arrS2", strParam.arrS2);
                Console.WriteLine("\tThe Expected is...");
                PrintS2arr("changeArrS2", changeArrS2);
                result = false;
            }
            else
            {
                Console.WriteLine("\tPASSED!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            result = false;
        }
        #endregion

        Console.WriteLine(result ? "PASS.\n" : "FAIL.\n");
        return result;
    }

    static bool RunTest6(string report)
    {
        bool result = true;
        Struct_ExpWithArrOfStr strParam = new Struct_ExpWithArrOfStr();

        S2[] sourceArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, 
            sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        S2[] cloneArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, 
            sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        S2[] changeArrS2 = NewS2arr(NumArrOfStructElements1, 0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

        strParam.arrS2 = sourceArrS2;

        #region MarshalArrayOfStructAsFieldInExpStructByVal
        Console.WriteLine("\tMarshaling ArrayOfStruct AsSafeArray As Field In ExpStruct ByVal");
        try
        {
            if (!MarshalArrayOfStructAsFieldInExpStructByVal(strParam, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsFieldInExpStructByVal did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(strParam.arrS2, cloneArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByVal did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("strParam.arrS2", strParam.arrS2);
                Console.WriteLine("\tThe Expected is...");
                PrintS2arr("cloneArrS2", cloneArrS2);
                result = false;
            }
            else
            {
                Console.WriteLine("\tPASSED!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            result = false;
        }
        #endregion
        #region MarshalArrayOfStructAsFieldInExpStructByRef
        Console.WriteLine("\tMarshaling ArrayOfStruct AsSafeArray As Field In ExpStruct ByRef");
        try
        {
            if (!MarshalArrayOfStructAsFieldInExpStructByRef(ref strParam, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsFieldInExpStructByRef did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(strParam.arrS2, changeArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByRef did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("strParam.arrS2", strParam.arrS2);
                Console.WriteLine("\tThe Expected is...");
                PrintS2arr("changeArrS2", changeArrS2);
                result = false;
            }
            else
            {
                Console.WriteLine("\tPASSED!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            result = false;
        }
        #endregion

        Console.WriteLine(result ? "PASS.\n" : "FAIL.\n");
        return result;
    }

    static bool RunTest7(string report)
    {
        bool result = true;
        Class_SeqWithArrOfStr strParam = new Class_SeqWithArrOfStr();

        S2[] sourceArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, 
            sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        S2[] cloneArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, 
            sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        S2[] changeArrS2 = NewS2arr(NumArrOfStructElements1, 0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

        strParam.arrS2 = sourceArrS2;

        #region MarshalArrayOfStructAsFieldInSeqClassByVal
        Console.WriteLine("\tMarshaling ArrayOfStruct AsSafeArray As Field In SeqClass ByVal");
        try
        {
            if (!MarshalArrayOfStructAsFieldInSeqClassByVal(strParam, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsFieldInSeqClassByVal did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(strParam.arrS2, cloneArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByVal did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("strParam.arrS2", strParam.arrS2);
                Console.WriteLine("\tThe Expected is...");
                PrintS2arr("cloneArrS2", cloneArrS2);
                result = false;
            }
            else
            {
                Console.WriteLine("\tPASSED!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            result = false;
        }
        #endregion
        #region MarshalArrayOfStructAsFieldInSeqClassByRef
        Console.WriteLine("\tMarshaling ArrayOfStruct AsSafeArray As Field In SeqClass ByRef");
        try
        {
            if (!MarshalArrayOfStructAsFieldInSeqClassByRef(ref strParam, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsFieldInSeqClassByRef did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(strParam.arrS2, changeArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByRef did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("strParam.arrS2", strParam.arrS2);
                Console.WriteLine("\tThe Expected is...");
                PrintS2arr("changeArrS2", changeArrS2);
                result = false;
            }
            else
            {
                Console.WriteLine("\tPASSED!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            result = false;
        }
        #endregion

        Console.WriteLine(result ? "PASS.\n" : "FAIL.\n");
        return result;
    }

    static bool RunTest8(string report)
    {
        bool result = true;
        Class_ExpWithArrOfStr strParam = new Class_ExpWithArrOfStr();

        S2[] sourceArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, 
            sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        S2[] cloneArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, 
            sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        S2[] changeArrS2 = NewS2arr(NumArrOfStructElements1, 0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

        strParam.arrS2 = sourceArrS2;

        #region MarshalArrayOfStructAsFieldInExpClassByVal
        Console.WriteLine("\tMarshaling ArrayOfStruct AsSafeArray As Field In ExpClass ByVal");
        try
        {
            if (!MarshalArrayOfStructAsFieldInExpClassByVal(strParam, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsFieldInExpClassByVal did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(strParam.arrS2, cloneArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByVal did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("strParam.arrS2", strParam.arrS2);
                Console.WriteLine("\tThe Expected is...");
                PrintS2arr("cloneArrS2", cloneArrS2);
                result = false;
            }
            else
            {
                Console.WriteLine("\tPASSED!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            result = false;
        }
        #endregion
        #region MarshalArrayOfStructAsFieldInExpClassByRef
        Console.WriteLine("\tMarshaling ArrayOfStruct AsSafeArray As Field In ExpClass ByRef");
        try
        {
            if (!MarshalArrayOfStructAsFieldInExpClassByRef(ref strParam, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsFieldInExpClassByRef did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(strParam.arrS2, changeArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByRef did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("strParam.arrS2", strParam.arrS2);
                Console.WriteLine("\tThe Expected is...");
                PrintS2arr("changeArrS2", changeArrS2);
                result = false;
            }
            else
            {
                Console.WriteLine("\tPASSED!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Exception:" + e.ToString());
            result = false;
        }
        #endregion

        Console.WriteLine(result ? "PASS.\n" : "FAIL.\n");
        return result;
    }

    static int Main()
    {
        bool result = true;

        result = RunTest1("RunTest 1 :Marshal array as field as SafeArray in squential struct.") && result;
        result = RunTest2("RunTest 2 :Marshal array as field as SafeArray in explicit struct.") && result;
        result = RunTest3("RunTest 3 :Marshal array as field as SafeArray in squential class.") && result;
        result = RunTest4("RunTest 4 :Marshal array as field as SafeArray in explicit class.") && result;
        result = RunTest5("RunTest 5 :Marshal array of struct as field in Sequential struct.") && result;
        result = RunTest6("RunTest 6 :Marshal array of struct as field in Explicit struct.") && result;
        result = RunTest7("RunTest 7 :Marshal array of struct as field in Sequential class.") && result;
        result = RunTest8("RunTest 8 :Marshal array of struct as field in Explicit class.") && result;

        if (result)
        {
            Console.WriteLine("\nTEST PASS!");
            return 100;
        }
        else
        {
            Console.WriteLine("\nTEST FAIL!");
            return 101;
        }
    }
}