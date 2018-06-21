using System;
using System.Runtime.InteropServices;

public class ArrayMarshal
{
    private static int NumArrOfStructElements1 = 10;

    public struct TestStruct
    {
        public int x;
        public double d;
        public long l;
        public string str;
    }
    public struct S2
    {
        public int i32;
        public uint ui32;
        public short s1;
        public ushort us1;
        public Byte b;
        public SByte sb;
        public Int16 i16;
        public UInt16 ui16;
        public Int64 i64;
        public UInt64 ui64;
        public Single sgl;
        public Double d;
    }

    delegate int TestDelegate();

    #region ByVal PInvoke method with no attributes applied
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Int([MarshalAs(UnmanagedType.LPArray)] int[] actual, int cActual);

#if BUG747966
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Object([MarshalAs(UnmanagedType.LPArray)] object[] actual, int cActual);
#endif

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Uint([MarshalAs(UnmanagedType.LPArray)] uint[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Short([MarshalAs(UnmanagedType.LPArray)] short[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Word([MarshalAs(UnmanagedType.LPArray)] ushort[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Long64([MarshalAs(UnmanagedType.LPArray)] long[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_ULong64([MarshalAs(UnmanagedType.LPArray)] ulong[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Double([MarshalAs(UnmanagedType.LPArray)] double[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Float([MarshalAs(UnmanagedType.LPArray)] float[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Byte([MarshalAs(UnmanagedType.LPArray)] byte[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Char([MarshalAs(UnmanagedType.LPArray)] char[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_LPCSTR([MarshalAs(UnmanagedType.LPArray)] string[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_LPSTR([MarshalAs(UnmanagedType.LPArray)] string[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Struct([MarshalAs(UnmanagedType.LPArray)] TestStruct[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Bool([MarshalAs(UnmanagedType.LPArray)] bool[] actual, int cActual);
#if BUG659954
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Delegate([MarshalAs(UnmanagedType.LPArray)] TestDelegate[] actual, int cActual);
#endif
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool MarshalArrayOfStructAsLPArrayByVal([MarshalAs(UnmanagedType.LPArray, SizeConst = ARRAY_SIZE)] S2[] arrS2, int cActual, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = ARRAY_SIZE)]S2[] pExpect);

    #endregion

    #region ByVal PInvoke method with InAttribute applied
    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Int")]
    private static extern bool CStyle_Array_Int_In([In, MarshalAs(UnmanagedType.LPArray)] int[] actual, int cActual);

#if BUG747966
    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Object")]
    private static extern bool CStyle_Array_Object_In(
        [In, MarshalAs(UnmanagedType.LPArray)] object[] actual, int cActual);
#endif

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Uint")]
    private static extern bool CStyle_Array_Uint_In([In, MarshalAs(UnmanagedType.LPArray)] uint[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Short")]
    private static extern bool CStyle_Array_Short_In([In, MarshalAs(UnmanagedType.LPArray)] short[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Word")]
    private static extern bool CStyle_Array_Word_In([In, MarshalAs(UnmanagedType.LPArray)] ushort[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Long64")]
    private static extern bool CStyle_Array_Long64_In([In, MarshalAs(UnmanagedType.LPArray)] long[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_ULong64")]
    private static extern bool CStyle_Array_ULong64_In([In, MarshalAs(UnmanagedType.LPArray)] ulong[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Double")]
    private static extern bool CStyle_Array_Double_In([In, MarshalAs(UnmanagedType.LPArray)] double[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Float")]
    private static extern bool CStyle_Array_Float_In([In, MarshalAs(UnmanagedType.LPArray)] float[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Byte")]
    private static extern bool CStyle_Array_Byte_In([In, MarshalAs(UnmanagedType.LPArray)] byte[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Char")]
    private static extern bool CStyle_Array_Char_In([In, MarshalAs(UnmanagedType.LPArray)] char[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_LPCSTR")]
    private static extern bool CStyle_Array_LPCSTR_In([In, MarshalAs(UnmanagedType.LPArray)] string[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_LPSTR")]
    private static extern bool CStyle_Array_LPSTR_In([In, MarshalAs(UnmanagedType.LPArray)] string[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Struct")]
    private static extern bool CStyle_Array_Struct_In([In, MarshalAs(UnmanagedType.LPArray)] TestStruct[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Bool")]
    private static extern bool CStyle_Array_Bool_In([In, MarshalAs(UnmanagedType.LPArray)] bool[] actual, int cActual);

#if BUG659954
    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "CStyle_Array_Delegate")]
    private static extern bool CStyle_Array_Delegate_In([In, MarshalAs(UnmanagedType.LPArray)] TestDelegate[] actual, int cActual);
#endif

    [DllImport("MarshalArrayLPArrayNative", EntryPoint = "MarshalArrayOfStructAsLPArrayByVal")]
    private static extern bool MarshalArrayOfStructAsLPArrayByValIn([In, MarshalAs(UnmanagedType.LPArray, SizeConst = ARRAY_SIZE)] S2[] arrS2, int cActual, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = ARRAY_SIZE)]S2[] pExpect);
    #endregion

    #region ByVal PInvoke method with InAttribute and OutAttribute applied
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Int_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] int[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Int_InOut_Null([In, Out, MarshalAs(UnmanagedType.LPArray)] int[] actual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Int_InOut_ZeroLength([In, Out, MarshalAs(UnmanagedType.LPArray)] int[] actual);

#if BUG747966
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Object_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] object[] actual, int cActual);
#endif

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Uint_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] uint[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Short_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] short[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Word_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] ushort[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Long64_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] long[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_ULong64_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] ulong[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Double_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] double[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Float_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] float[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Byte_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] byte[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Char_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] char[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_LPSTR_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] string[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Struct_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] TestStruct[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Bool_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] bool[] actual, int cActual);
#if BUG659954
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Delegate_InOut([In, Out, MarshalAs(UnmanagedType.LPArray)] TestDelegate[] actual, int cActual);
#endif
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool MarshalArrayOfStructAsLPArrayByValInOut([In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = ARRAY_SIZE)] S2[] arrS2, int cActual, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = ARRAY_SIZE)]S2[] pExpect);

    #endregion

    #region ByVal PInvoke method with OutAttribute applied
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Int_Out([Out, MarshalAs(UnmanagedType.LPArray)] int[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Int_Out_Null([Out, MarshalAs(UnmanagedType.LPArray)] int[] actual);
    
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Int_Out_ZeroLength([Out, MarshalAs(UnmanagedType.LPArray)] int[] actual);

#if BUG747966
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Object_Out([Out, MarshalAs(UnmanagedType.LPArray)] object[] actual, int cActual);
#endif

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Uint_Out([Out, MarshalAs(UnmanagedType.LPArray)] uint[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Short_Out([Out, MarshalAs(UnmanagedType.LPArray)] short[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Word_Out([Out, MarshalAs(UnmanagedType.LPArray)] ushort[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Long64_Out([Out, MarshalAs(UnmanagedType.LPArray)] long[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_ULong64_Out([Out, MarshalAs(UnmanagedType.LPArray)] ulong[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Double_Out([Out, MarshalAs(UnmanagedType.LPArray)] double[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Float_Out([Out, MarshalAs(UnmanagedType.LPArray)] float[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Byte_Out([Out, MarshalAs(UnmanagedType.LPArray)] byte[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Char_Out([Out, MarshalAs(UnmanagedType.LPArray)] char[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_LPSTR_Out([Out, MarshalAs(UnmanagedType.LPArray)] string[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Struct_Out([Out, MarshalAs(UnmanagedType.LPArray)] TestStruct[] actual, int cActual);

    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Bool_Out([Out, MarshalAs(UnmanagedType.LPArray)] bool[] actual, int cActual);
#if BUG659954
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool CStyle_Array_Delegate_Out([Out, MarshalAs(UnmanagedType.LPArray)] TestDelegate[] actual, int cActual);
#endif
    [DllImport("MarshalArrayLPArrayNative")]
    private static extern bool MarshalArrayOfStructAsLPArrayByValOut([Out, MarshalAs(UnmanagedType.LPArray, SizeConst = ARRAY_SIZE)] S2[] arrS2, int cActual);

    #endregion

    #region Marshal ByVal
    private const int ARRAY_SIZE = 100;

    private static T[] InitArray<T>(int size)
    {
        T[] array = new T[size];

        for (int i = 0; i < array.Length; ++i)
            array[i] = (T)Convert.ChangeType(i, typeof(T));

        return array;
    }

    private static T[] CopyArray<T>(T[] srcarr, int size)
    {
        T[] array = new T[size];

        Array.Copy(srcarr, array, ARRAY_SIZE);
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

    private static TestStruct[] InitStructArray(int size)
    {
        TestStruct[] array = new TestStruct[size];

        for (int i = 0; i < array.Length; ++i)
        {
            array[i].x = i;
            array[i].d = i;
            array[i].l = i;
            array[i].str = i.ToString();
        }

        return array;
    }
    static int Delegate0()
    {
        return 0;
    }
    static int Delegate1()
    {
        return 1;
    }
    static int Delegate2()
    {
        return 2;
    }
    private static TestDelegate[] InitDelegateArray()
    {
        TestDelegate[] array = new TestDelegate[] { 
            new TestDelegate(Delegate0),
            new TestDelegate(Delegate1),
            new TestDelegate(Delegate2),
            new TestDelegate(delegate() { return 3; }),
            null};

        return array;
    }

    private static void TestMarshalByVal_NoAttributes()
    {
        TestHelper.BeginSubScenario("ByVal marshaling CLR array as c-style-array no attributes");

        TestHelper.Assert(CStyle_Array_Int(InitArray<int>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Int");
        TestHelper.Assert(CStyle_Array_Uint(InitArray<uint>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Uint");
        TestHelper.Assert(CStyle_Array_Short(InitArray<short>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Short");
        TestHelper.Assert(CStyle_Array_Word(InitArray<ushort>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Word");
        TestHelper.Assert(CStyle_Array_Long64(InitArray<long>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Long64");
        TestHelper.Assert(CStyle_Array_ULong64(InitArray<ulong>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_ULong64");
        TestHelper.Assert(CStyle_Array_Double(InitArray<double>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Double");
        TestHelper.Assert(CStyle_Array_Float(InitArray<float>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Float");
        TestHelper.Assert(CStyle_Array_Byte(InitArray<byte>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Byte");
        TestHelper.Assert(CStyle_Array_Char(InitArray<char>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Char");

#if BUG743703
        string[] strArr = InitArray<string>(ARRAY_SIZE);
        // Test nesting null value scenario
        strArr[strArr.Length / 2] = null;
        TestHelper.Assert(CStyle_Array_LPCSTR(strArr, ARRAY_SIZE), "CStyle_Array_LPCSTR");
        TestHelper.Assert(CStyle_Array_LPSTR(strArr, ARRAY_SIZE), "CStyle_Array_LPSTRs");
        TestHelper.Assert(CStyle_Array_Struct(InitStructArray(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Struct");
#endif

#if BUG748396
        TestHelper.Assert(CStyle_Array_Bool(InitBoolArray(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Bool");
#endif

#if BUG747966
        object[] oArr = InitArray<object>(ARRAY_SIZE);
        // Test nesting null value scenario
        oArr[oArr.Length / 2] = null;
        TestHelper.Assert(CStyle_Array_Object(oArr, ARRAY_SIZE), "CStyle_Array_Object");
#endif

#if BUG659954
        TestDelegate[] dels = InitDelegateArray();
        TestHelper.Assert(CStyle_Array_Delegate(dels, dels.Length), "CStyle_Array_Delegate");
#endif

    }

    private static void TestMarshalByVal_In()
    {
        TestHelper.BeginSubScenario("ByVal marshaling  CLR array as c-style-array with InAttribute applied");

        TestHelper.Assert(CStyle_Array_Int_In(InitArray<int>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Int_In");
        TestHelper.Assert(CStyle_Array_Uint_In(InitArray<uint>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Uint_In");
        TestHelper.Assert(CStyle_Array_Short_In(InitArray<short>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Short_In");
        TestHelper.Assert(CStyle_Array_Word_In(InitArray<ushort>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Word_In");
        TestHelper.Assert(CStyle_Array_Long64_In(InitArray<long>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Long64_In");
        TestHelper.Assert(CStyle_Array_ULong64_In(InitArray<ulong>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_ULong64_In");
        TestHelper.Assert(CStyle_Array_Double_In(InitArray<double>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Double_In");
        TestHelper.Assert(CStyle_Array_Float_In(InitArray<float>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Float_In");
        TestHelper.Assert(CStyle_Array_Byte_In(InitArray<byte>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Byte_In");
        TestHelper.Assert(CStyle_Array_Char_In(InitArray<char>(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Char_In");
#if BUG743703

        string[] strArr = InitArray<string>(ARRAY_SIZE);
        // Test nesting null value scenario
        strArr[strArr.Length / 2] = null;
        TestHelper.Assert(CStyle_Array_LPCSTR_In(strArr, ARRAY_SIZE), "CStyle_Array_LPCSTR_In");
        TestHelper.Assert(CStyle_Array_LPSTR_In(strArr, ARRAY_SIZE), "CStyle_Array_LPSTR_In");
        TestHelper.Assert(CStyle_Array_Struct_In(InitStructArray(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Struct_In");
#endif

#if BUG748396
        TestHelper.Assert(CStyle_Array_Bool_In(InitBoolArray(ARRAY_SIZE), ARRAY_SIZE), "CStyle_Array_Bool_In");
#endif

#if BUG747966
        object[] oArr = InitArray<object>(ARRAY_SIZE);
        // Test nesting null value scenario
        oArr[oArr.Length / 2] = null;
        TestHelper.Assert(CStyle_Array_Object_In(oArr, ARRAY_SIZE), "CStyle_Array_Object_In");

        TestDelegate[] dels = InitDelegateArray();
        TestHelper.Assert(CStyle_Array_Delegate(dels, dels.Length), "CStyle_Array_Delegate");
#endif
    }
    #endregion

    #region Marshal InOut ByVal
    private static void TestMarshalByVal_InOut()
    {
        TestHelper.BeginSubScenario("By value marshaling CLR array as c-style-array with InAttribute and OutAttribute applied");
        int[] iArr = InitArray<int>(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_Int_InOut(iArr, ARRAY_SIZE), "CStyle_Array_Int_InOut");
        TestHelper.Assert(Equals<int>(iArr, GetExpectedOutArray<int>(ARRAY_SIZE)), "CStyle_Array_Int_InOut:Equals<int>");

        int[] iArrNull = null;
        TestHelper.Assert(CStyle_Array_Int_InOut_Null(iArrNull), "CStyle_Array_Int_InOut_Null");
        TestHelper.Assert(iArrNull == null, "CStyle_Array_Int_InOut_Null:Equals<null>");

        int[] iArrLength0 = InitArray<int>(0);
        TestHelper.Assert(CStyle_Array_Int_InOut_ZeroLength(iArrLength0), "CStyle_Array_Int_InOut_ZeroLength");
        TestHelper.Assert(iArrLength0.Length == 0, "CStyle_Array_Int_InOut_ZeroLength:Length<!0>");

        uint[] uiArr = InitArray<uint>(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_Uint_InOut(uiArr, ARRAY_SIZE), "CStyle_Array_Uint_InOut");
        TestHelper.Assert(Equals<uint>(uiArr, GetExpectedOutArray<uint>(ARRAY_SIZE)), "CStyle_Array_Uint_InOut:Equals<uint>");

        short[] sArr = InitArray<short>(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_Short_InOut(sArr, ARRAY_SIZE), "CStyle_Array_Short_InOut");
        TestHelper.Assert(Equals<short>(sArr, GetExpectedOutArray<short>(ARRAY_SIZE)), "CStyle_Array_Short_InOut:Equals<short>");

        ushort[] usArr = InitArray<ushort>(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_Word_InOut(usArr, ARRAY_SIZE), "CStyle_Array_Word_InOut");
        TestHelper.Assert(Equals<ushort>(usArr, GetExpectedOutArray<ushort>(ARRAY_SIZE)), "CStyle_Array_Word_InOut:Equals<ushort>");

        long[] lArr = InitArray<long>(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_Long64_InOut(lArr, ARRAY_SIZE), "CStyle_Array_Long64_InOut");
        TestHelper.Assert(Equals<long>(lArr, GetExpectedOutArray<long>(ARRAY_SIZE)), "CStyle_Array_Long64_InOut:Equals<long>");

        ulong[] ulArr = InitArray<ulong>(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_ULong64_InOut(ulArr, ARRAY_SIZE), "CStyle_Array_ULong64_InOut");
        TestHelper.Assert(Equals<ulong>(ulArr, GetExpectedOutArray<ulong>(ARRAY_SIZE)), "CStyle_Array_ULong64_InOut:Equals<ulong>");

        double[] dArr = InitArray<double>(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_Double_InOut(dArr, ARRAY_SIZE), "CStyle_Array_Double_InOut");
        TestHelper.Assert(Equals<double>(dArr, GetExpectedOutArray<double>(ARRAY_SIZE)), "CStyle_Array_Double_InOut:Equals<double>");

        float[] fArr = InitArray<float>(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_Float_InOut(fArr, ARRAY_SIZE), "CStyle_Array_Float_InOut");
        TestHelper.Assert(Equals<float>(fArr, GetExpectedOutArray<float>(ARRAY_SIZE)), "CStyle_Array_Float_InOut:Equals<float>");

        byte[] bArr = InitArray<byte>(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_Byte_InOut(bArr, ARRAY_SIZE), "CStyle_Array_Byte_InOut");
        TestHelper.Assert(Equals<byte>(bArr, GetExpectedOutArray<byte>(ARRAY_SIZE)), "CStyle_Array_Byte_InOut:Equals<byte>");

        char[] cArr = InitArray<char>(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_Char_InOut(cArr, ARRAY_SIZE), "CStyle_Array_Char_InOut");
        TestHelper.Assert(Equals<char>(cArr, GetExpectedOutArray<char>(ARRAY_SIZE)), "CStyle_Array_Char_InOut:Equals<char>");

#if BUG743703
        string[] strArr = InitArray<string>(ARRAY_SIZE);
        strArr[strArr.Length / 2] = null;
        TestHelper.Assert(CStyle_Array_LPSTR_InOut(strArr, ARRAY_SIZE), "CStyle_Array_LPSTR_InOut");

        string[] expectedArr = GetExpectedOutArray<string>(ARRAY_SIZE);
        // Test nesting null value scenario
        expectedArr[expectedArr.Length / 2 - 1] = null;
        TestHelper.Assert(Equals<string>(strArr, expectedArr), "CStyle_Array_LPSTR_InOut:Equals<string>");

        TestStruct[] tsArr = InitStructArray(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_Struct_InOut(tsArr, ARRAY_SIZE), "CStyle_Array_Struct_InOut");
        TestHelper.Assert(Equals<TestStruct>(tsArr, GetExpectedOutStructArray(ARRAY_SIZE)), "CStyle_Array_Struct_InOut:Equals<TestStruct>");
#endif

#if BUG748396
        bool[] boolArr = InitBoolArray(ARRAY_SIZE);
        TestHelper.Assert(CStyle_Array_Bool_InOut(boolArr, ARRAY_SIZE), "CStyle_Array_Bool_InOut");
        TestHelper.Assert(Equals<bool>(boolArr, GetExpectedOutBoolArray(ARRAY_SIZE)), "CStyle_Array_Bool_InOut:Equals<bool>");
#endif

#if BUG659954
        TestDelegate[] delArr = InitDelegateArray();
        TestHelper.Assert(CStyle_Array_Delegate_InOut(delArr, delArr.Length), "CStyle_Array_Delegate_InOut");
        TestHelper.Assert(CheckOutDelegates(delArr), "CheckOutDelegates");
#endif

#if BUG747966
        object[] oArr = InitArray<object>(ARRAY_SIZE);
        strArr[oArr.Length / 2] = null;
        TestHelper.Assert(CStyle_Array_Object_InOut(oArr, ARRAY_SIZE), "CStyle_Array_Object_InOut");

        object[] expectedOArr = GetExpectedOutArray<object>(ARRAY_SIZE);
        // Test nesting null value scenario
        expectedOArr[expectedOArr.Length / 2 - 1] = null;
        TestHelper.Assert(Equals<object>(oArr, expectedOArr), "CStyle_Array_Object_InOut:Equals<object>");
#endif

    }

    private static bool CheckOutDelegates(TestDelegate[] arr)
    {
        if (arr == null)
            return false;

        int size = arr.Length;
        for (int i = 0; i < size; ++i)
        {
            if ((arr[i] == null) && (i == 0))
            {
                continue;
            }

            int expected = size - 1 - i;
            int actual = arr[i]();
            if (expected != actual)
            {
                Console.WriteLine("WARNING: delegate is not marshaling correctly from unmanaged side");
                return false;
            }
        }

        return true;
    }

    private static bool Equals<T>(T[] arr1, T[] arr2)
    {
        if (arr1 == null && arr2 == null)
            return true;
        else if (arr1 == null && arr2 != null)
            return false;
        else if (arr1 != null && arr2 == null)
            return false;
        else if (arr1.Length != arr2.Length)
            return false;

        for (int i = 0; i < arr2.Length; ++i)
        {
            if (!Object.Equals(arr1[i], arr2[i]))
            {
                Console.WriteLine("Array marshaling error, Index: {0} , Expected:{1}, Actual:{2}", i, arr2[i], arr1[i]);
                return false;
            }
        }
        return true;
    }

    private static T[] GetExpectedOutArray<T>(int size)
    {
        T[] array = new T[size];
        for (int i = array.Length - 1; i >= 0; --i)
            array[i] = (T)Convert.ChangeType(array.Length - 1 - i, typeof(T));
        return array;
    }

    private static bool[] GetExpectedOutBoolArray(int size)
    {
        bool[] array = new bool[size];
        for (int i = 0; i < array.Length; ++i)
        {
            if (i % 2 != 0)
                array[i] = true;
            else
                array[i] = false;
        }
        return array;
    }

    private static TestStruct[] GetExpectedOutStructArray(int size)
    {
        TestStruct[] array = new TestStruct[size];
        for (int i = array.Length - 1; i >= 0; --i)
        {
            int v = array.Length - 1 - i;
            array[i].x = v;
            array[i].d = v;
            array[i].l = v;
            array[i].str = v.ToString();
        }
        return array;
    }
    #endregion

    #region Marshal InOut ByVal
    private static void TestMarshalByVal_Out()
    {
        TestHelper.BeginSubScenario("By value marshaling CLR array as c-style-array with OutAttribute applied");

        int[] iArr = new int[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Int_Out(iArr, ARRAY_SIZE), "CStyle_Array_Int_Out");
        TestHelper.Assert(Equals<int>(iArr, GetExpectedOutArray<int>(ARRAY_SIZE)), "CStyle_Array_Int_Out:Equals<int>");

        int[] iArrNull = null;
        TestHelper.Assert(CStyle_Array_Int_Out_Null(iArrNull), "CStyle_Array_Int_Out_Null");
        TestHelper.Assert(iArrNull == null, "CStyle_Array_Int_Out_Null:Equals<null>");

        int[] iArrLength0 = new int[0];
        TestHelper.Assert(CStyle_Array_Int_Out_ZeroLength(iArrLength0), "CStyle_Array_Int_Out_ZeroLength");
        TestHelper.Assert(iArrLength0.Length == 0, "CStyle_Array_Int_Out_ZeroLength:Length<!0>");

        uint[] uiArr = new uint[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Uint_Out(uiArr, ARRAY_SIZE), "CStyle_Array_Uint_Out");
        TestHelper.Assert(Equals<uint>(uiArr, GetExpectedOutArray<uint>(ARRAY_SIZE)), "CStyle_Array_Uint_Out:Equals<uint>");

        short[] sArr = new short[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Short_Out(sArr, ARRAY_SIZE), "CStyle_Array_Short_Out");
        TestHelper.Assert(Equals<short>(sArr, GetExpectedOutArray<short>(ARRAY_SIZE)), "CStyle_Array_Short_Out:Equals<short>");

        ushort[] usArr = new ushort[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Word_Out(usArr, ARRAY_SIZE), "CStyle_Array_Word_Out");
        TestHelper.Assert(Equals<ushort>(usArr, GetExpectedOutArray<ushort>(ARRAY_SIZE)), "CStyle_Array_Word_Out:Equals<ushort>");

        long[] lArr = new long[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Long64_Out(lArr, ARRAY_SIZE), "CStyle_Array_Long64_Out");
        TestHelper.Assert(Equals<long>(lArr, GetExpectedOutArray<long>(ARRAY_SIZE)), "CStyle_Array_Long64_Out:Equals<long>");

        ulong[] ulArr = new ulong[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_ULong64_Out(ulArr, ARRAY_SIZE), "CStyle_Array_ULong64_Out");
        TestHelper.Assert(Equals<ulong>(ulArr, GetExpectedOutArray<ulong>(ARRAY_SIZE)), "CStyle_Array_ULong64_Out:Equals<ulong>");

        double[] dArr = new double[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Double_Out(dArr, ARRAY_SIZE), "CStyle_Array_Double_Out");
        TestHelper.Assert(Equals<double>(dArr, GetExpectedOutArray<double>(ARRAY_SIZE)), "CStyle_Array_Double_Out:Equals<double>");

        float[] fArr = new float[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Float_Out(fArr, ARRAY_SIZE), "CStyle_Array_Float_Out");
        TestHelper.Assert(Equals<float>(fArr, GetExpectedOutArray<float>(ARRAY_SIZE)), "CStyle_Array_Float_Out:Equals<float>");

        byte[] bArr = new byte[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Byte_Out(bArr, ARRAY_SIZE), "CStyle_Array_Byte_Out");
        TestHelper.Assert(Equals<byte>(bArr, GetExpectedOutArray<byte>(ARRAY_SIZE)), "CStyle_Array_Byte_Out:Equals<byte>");

        char[] cArr = new char[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Char_Out(cArr, ARRAY_SIZE), "CStyle_Array_Char_Out");
        TestHelper.Assert(Equals<char>(cArr, GetExpectedOutArray<char>(ARRAY_SIZE)), "CStyle_Array_Char_Out:Equals<char>");

#if BUG743703
        string[] strArr = new string[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_LPSTR_Out(strArr, ARRAY_SIZE), "CStyle_Array_LPSTR_Out");

        string[] expectedArr = GetExpectedOutArray<string>(ARRAY_SIZE);
        // Test nesting null value scenario
        expectedArr[expectedArr.Length / 2 - 1] = null;
        TestHelper.Assert(Equals<string>(strArr, expectedArr), "CStyle_Array_LPSTR_Out:Equals<string>");

        TestStruct[] tsArr = new TestStruct[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Struct_Out(tsArr, ARRAY_SIZE), "CStyle_Array_Struct_Out");
        TestHelper.Assert(Equals<TestStruct>(tsArr, GetExpectedOutStructArray(ARRAY_SIZE)), "CStyle_Array_Struct_Out:Equals<TestStruct>");
#endif

#if BUG748396
        bool[] boolArr = new bool[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Bool_Out(boolArr, ARRAY_SIZE), "CStyle_Array_Bool_Out");
        TestHelper.Assert(Equals<bool>(boolArr, GetExpectedOutBoolArray(ARRAY_SIZE)), "CStyle_Array_Bool_Out:Equals<bool>");
#endif

#if BUG659954
        TestDelegate[] delArr = InitDelegateArray();
        TestHelper.Assert(CStyle_Array_Delegate_InOut(delArr, delArr.Length), "CStyle_Array_Delegate_InOut");
        TestHelper.Assert(CheckOutDelegates(delArr), "CheckOutDelegates");
#endif

#if BUG747966
        object[] oArr = new object[ARRAY_SIZE];
        TestHelper.Assert(CStyle_Array_Object_Out(oArr, ARRAY_SIZE), "CStyle_Array_Object_Out");
        object[] expectedOArr = GetExpectedOutArray<object>(ARRAY_SIZE);
        // Test nesting null value scenario
        expectedOArr[expectedOArr.Length / 2 - 1] = null;
        TestHelper.Assert(Equals<object>(oArr, expectedOArr), "CStyle_Array_Object_Out:Equals<object>");
#endif

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
    public static bool IsCorrect(S2[] actual, S2[] expected)
    {
        if (actual.Length != expected.Length)
        {
            return false;
        }
        for (int i = 0; i < actual.Length; i++)
        {
            if (actual[i].i32 != expected[i].i32 || actual[i].ui32 != expected[i].ui32 || actual[i].s1 != expected[i].s1 || actual[i].us1 != expected[i].us1 ||
                actual[i].b != expected[i].b || actual[i].sb != expected[i].sb || actual[i].i16 != expected[i].i16 ||
                actual[i].ui16 != expected[i].ui16 || actual[i].i64 != expected[i].i64 || actual[i].ui64 != expected[i].ui64 ||
                actual[i].sgl != expected[i].sgl || actual[i].d != expected[i].d)
            {
                //PrintS2arr("actual",actual);
                //PrintS2arr("expected", expected);
                return false;
            }
        }
        return true;
    }
    #endregion

    public static int Main()
    {
        TestMarshalByVal_NoAttributes();
        TestMarshalByVal_In();
        TestMarshalByVal_InOut();
        TestMarshalByVal_Out();

        if (TestHelper.Pass)
        {
            return 100;
        }
        else
        {
            return 101;
        }
    }
}
