using System;
using System.Runtime.InteropServices;

public class ArrayMarshalSafeArray
{
    private static int NumArrOfStructElements1 = 10;

    #region Data Structrures
    [ComVisible(true)]
    [StructLayout(LayoutKind.Sequential)]
    public struct TestStructSA
    {
        public int x;
        public double d;
        public long l;
        [MarshalAs(UnmanagedType.BStr)]
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
    #endregion

    #region No attributes applied
    // 1D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_1D(
        [MarshalAs(UnmanagedType.SafeArray)] int[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_1D(
        [MarshalAs(UnmanagedType.SafeArray)] string[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_1D(
        [MarshalAs(UnmanagedType.SafeArray)] double[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_1D(
        [MarshalAs(UnmanagedType.SafeArray)] byte[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_1D(
        [MarshalAs(UnmanagedType.SafeArray)] bool[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_1D(
        [MarshalAs(UnmanagedType.SafeArray)] TestDelegate[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_1D(
        [MarshalAs(UnmanagedType.SafeArray)] 
        object[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_1D(
        [MarshalAs(UnmanagedType.SafeArray)] TestStructSA[] actual);

    // 2D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_2D(
        [MarshalAs(UnmanagedType.SafeArray)] int[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_2D(
        [MarshalAs(UnmanagedType.SafeArray)] string[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_2D(
        [MarshalAs(UnmanagedType.SafeArray)] double[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_2D(
        [MarshalAs(UnmanagedType.SafeArray)] byte[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_2D(
        [MarshalAs(UnmanagedType.SafeArray)] bool[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_2D(
        [MarshalAs(UnmanagedType.SafeArray)] TestDelegate[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_2D(
        [MarshalAs(UnmanagedType.SafeArray)] object[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_2D(
        [MarshalAs(UnmanagedType.SafeArray)] TestStructSA[,] actual);
    #endregion

    #region InAttribute applied
    // 1D array
    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Int_1D")]
    private static extern bool SafeArray_Int_1D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] int[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_String_1D")]
    private static extern bool SafeArray_String_1D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] string[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Double_1D")]
    private static extern bool SafeArray_Double_1D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] double[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Byte_1D")]
    private static extern bool SafeArray_Byte_1D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] byte[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Bool_1D")]
    private static extern bool SafeArray_Bool_1D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] bool[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Delegate_1D")]
    private static extern bool SafeArray_Delegate_1D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Object_1D")]
    private static extern bool SafeArray_Object_1D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] object[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_TestStruct_1D")]
    private static extern bool SafeArray_TestStruct_1D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[] actual);

    // 2D array
    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Int_2D")]
    private static extern bool SafeArray_Int_2D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] int[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_String_2D")]
    private static extern bool SafeArray_String_2D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] string[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Double_2D")]
    private static extern bool SafeArray_Double_2D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] double[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Byte_2D")]
    private static extern bool SafeArray_Byte_2D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] byte[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Bool_2D")]
    private static extern bool SafeArray_Bool_2D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] bool[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Delegate_2D")]
    private static extern bool SafeArray_Delegate_2D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Object_2D")]
    private static extern bool SafeArray_Object_2D_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] object[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_TestStruct_2D")]
    private static extern bool SafeArray_TestStruct_2D_In(
        [MarshalAs(UnmanagedType.SafeArray)] TestStructSA[,] actual);
    #endregion

    #region ByRef marshaling no attributes applied
    // 1D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_1D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref int[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_1D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref string[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_1D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref double[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_1D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref byte[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_1D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref bool[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_1D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref TestDelegate[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_1D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref object[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_1D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref TestStructSA[] actual);

    // 2D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_2D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref int[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_2D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref string[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_2D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref double[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_2D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref byte[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_2D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref bool[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_2D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref TestDelegate[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_2D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref object[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_2D_ByRef(
        [MarshalAs(UnmanagedType.SafeArray)] ref TestStructSA[,] actual);
    #endregion

    #region ByRef marshaling with InAttribute applied
    // 1D array
    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Int_1D_ByRef")]
    private static extern bool SafeArray_Int_1D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref int[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_String_1D_ByRef")]
    private static extern bool SafeArray_String_1D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref string[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Double_1D_ByRef")]
    private static extern bool SafeArray_Double_1D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref double[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Byte_1D_ByRef")]
    private static extern bool SafeArray_Byte_1D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref byte[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Bool_1D_ByRef")]
    private static extern bool SafeArray_Bool_1D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref bool[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Delegate_1D_ByRef")]
    private static extern bool SafeArray_Delegate_1D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref TestDelegate[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Object_1D_ByRef")]
    private static extern bool SafeArray_Object_1D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref object[] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_TestStruct_1D_ByRef")]
    private static extern bool SafeArray_TestStruct_1D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref TestStructSA[] actual);

    // 2D array
    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Int_2D_ByRef")]
    private static extern bool SafeArray_Int_2D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref int[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_String_2D_ByRef")]
    private static extern bool SafeArray_String_2D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref string[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Double_2D_ByRef")]
    private static extern bool SafeArray_Double_2D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref double[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Byte_2D_ByRef")]
    private static extern bool SafeArray_Byte_2D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref byte[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Bool_2D_ByRef")]
    private static extern bool SafeArray_Bool_2D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref bool[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Delegate_2D_ByRef")]
    private static extern bool SafeArray_Delegate_2D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref TestDelegate[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_Object_2D_ByRef")]
    private static extern bool SafeArray_Object_2D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref object[,] actual);

    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "SafeArray_TestStruct_2D_ByRef")]
    private static extern bool SafeArray_TestStruct_2D_ByRef_In(
        [In, MarshalAs(UnmanagedType.SafeArray)] ref TestStructSA[,] actual);
    #endregion

    #region ByVal OutAttribute applied
    // 1D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_1D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] int[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_1D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] string[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_1D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] double[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_1D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] byte[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_1D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] bool[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_1D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[] expect);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_1D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] object[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_1D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[] expect);

    // 2D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_2D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] int[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_2D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] string[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_2D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] double[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_2D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] byte[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_2D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] bool[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_2D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[,] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[,] expect);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_2D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] object[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_2D_Out(
        [Out, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[,] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[,] expect);
    #endregion

    #region ByRef OutAttribute applied
    // 1D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_1D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out int[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_1D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out string[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_1D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out double[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_1D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out byte[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_1D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out bool[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_1D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out TestDelegate[] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[] expect);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_1D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out object[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_1D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out TestStructSA[] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[] expect);

    // 2D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_2D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out int[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_2D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out string[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_2D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out double[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_2D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out byte[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_2D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out bool[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_2D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out TestDelegate[,] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[,] expect);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_2D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out object[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_2D_Out_ByRef(
        [Out, MarshalAs(UnmanagedType.SafeArray)] out TestStructSA[,] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[,] expect);
    #endregion

    #region ByVal InAttribute OutAttribute applied
    // 1D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_1D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] int[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_1D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] string[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_1D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] double[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_1D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] byte[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_1D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] bool[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_1D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[] expect);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_1D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] object[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_1D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[] expect);

    // 2D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_2D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] int[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_2D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] string[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_2D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] double[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_2D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] byte[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_2D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] bool[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_2D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[,] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[,] expect);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_2D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] object[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_2D_InOut(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[,] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[,] expect);
    #endregion

    #region ByRef InAttribute OutAttribute applied
    // 1D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_1D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref int[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_1D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref string[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_1D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref double[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_1D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref byte[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_1D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref bool[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_1D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref TestDelegate[] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[] expect);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_1D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref object[] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_1D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref TestStructSA[] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[] expect);

    // 2D array
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Int_2D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref int[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_String_2D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref string[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Double_2D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref double[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Byte_2D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref byte[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Bool_2D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref bool[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Delegate_2D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref TestDelegate[,] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestDelegate[,] expect);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_Object_2D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref object[,] actual);

    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool SafeArray_TestStruct_2D_InOut_ByRef(
        [In, Out, MarshalAs(UnmanagedType.SafeArray)] ref TestStructSA[,] actual,
        [In, MarshalAs(UnmanagedType.SafeArray)] TestStructSA[,] expect);
    #endregion

    #region Added some Marshaling Array of Struct AsSafeArray
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool MarshalArrayOfStructAsParam_AsSafeArrayByVal([MarshalAs(UnmanagedType.SafeArray)] S2[] arrS2, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool MarshalArrayOfStructAsParam_AsSafeArrayByRef([MarshalAs(UnmanagedType.SafeArray)] ref S2[] arrS2, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "MarshalArrayOfStructAsParam_AsSafeArrayByVal")]
    private static extern bool MarshalArrayOfStructAsParam_AsSafeArrayByValIn([In, MarshalAs(UnmanagedType.SafeArray)] S2[] arrS2, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "MarshalArrayOfStructAsParam_AsSafeArrayByRef")]
    private static extern bool MarshalArrayOfStructAsParam_AsSafeArrayByRefIn([In, MarshalAs(UnmanagedType.SafeArray)] ref S2[] arrS2, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "MarshalArrayOfStructAsParam_AsSafeArrayByVal")]
    private static extern bool MarshalArrayOfStructAsParam_AsSafeArrayByValOut([Out, MarshalAs(UnmanagedType.SafeArray)] S2[] arrS2, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArraySafeArrayNative")]
    private static extern bool MarshalArrayOfStructAsParam_AsSafeArrayByRefOut([Out, MarshalAs(UnmanagedType.SafeArray)] out S2[] arrS2, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "MarshalArrayOfStructAsParam_AsSafeArrayByVal")]
    private static extern bool MarshalArrayOfStructAsParam_AsSafeArrayByValInOut([In, Out, MarshalAs(UnmanagedType.SafeArray)] S2[] arrS2, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);
    [DllImport("MarshalArraySafeArrayNative", EntryPoint = "MarshalArrayOfStructAsParam_AsSafeArrayByRef")]
    private static extern bool MarshalArrayOfStructAsParam_AsSafeArrayByRefInOut([In, Out, MarshalAs(UnmanagedType.SafeArray)] ref S2[] arrS2, [In, MarshalAs(UnmanagedType.SafeArray)] S2[] pExpect);

    #endregion

    #region Log functions
#if COLORFUL
    private static void LogPass(string message)
    {
        ConsoleColor saved = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = saved;

    }

    private static void LogFail(string message)
    {
        ConsoleColor saved = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = saved;
    }
#endif
    private static void LogVerifyError<T>(string message, T expect, T actual)
    {
#if COLORFUL
        ConsoleColor saved = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
#endif
        Console.WriteLine("{0}: Expect: {1}, Actual {2}", message, expect, actual);
#if COLORFUL
        Console.ForegroundColor = saved;
#endif
    }

    private static void LogVerifyError<T>(T expect, T actual)
    {
        LogVerifyError<T>("VERIFY ERROR", expect, actual);
    }

    private static void LogMsg(string message)
    {
        Console.WriteLine(message);
    }

    private static void LogResult(bool bSuccess)
    {
#if COLORFUL
        if ( bSuccess )
            LogPass("PASS");
        else
            LogFail("FAILED");
#else
        if (bSuccess)
            LogMsg("PASS");
        else
            LogMsg("FAILED");
#endif
    }
    #endregion

    #region Initialize Arrays
    private const int ARRAY_SIZE = 100;
    private const int ARRAY_ROWS = 2;
    private const int ARRAY_COLUMNS = 3;

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
                                   new TestDelegate(delegate() {
                                       return 3;
                                   }),
                                   null
                               };

        return array;
    }

    private static T[,] InitArray<T>(int rows, int columns)
    {
        T[,] array = new T[rows, columns];

        int value = 0;
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < columns; ++c)
            {
                array[r, c] = (T)Convert.ChangeType(value++, typeof(T));
            }
        }

        return array;
    }

    private static bool[,] InitBoolArray(int rows, int columns)
    {
        bool[,] array = new bool[rows, columns];

        int value = 0;
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < columns; ++c)
            {
                if ((value++) % 2 == 0)
                    array[r, c] = true;
                else
                    array[r, c] = false;
            }
        }

        return array;
    }

    private static TestDelegate[,] InitDelegateArray_2D()
    {
        TestDelegate[,] array = new TestDelegate[,] {
                                   {
                                       new TestDelegate(Delegate0),
                                       new TestDelegate(Delegate1)
                                   },
                                   {
                                       new TestDelegate(Delegate2),
                                       new TestDelegate(delegate() {
                                           return 3;
                                       })
                                   }
                               };

        return array;
    }

    private static T[] InitArrayForInOut<T>(int size)
    {
        T[] array = new T[size];

        for (int i = array.Length - 1; i >= 0; --i)
            array[i] = (T)Convert.ChangeType(i, typeof(T));

        return array;
    }

    private static bool[] InitBoolArrayForInOut(int size)
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

    private static TestDelegate[] InitDelegateArrayForInOut()
    {
        TestDelegate[] array = new TestDelegate[] {
                                   null,
                                   new TestDelegate(delegate() {
                                       return 3;
                                   }),
                                   new TestDelegate(Delegate2),
                                   new TestDelegate(Delegate1),
                                   new TestDelegate(Delegate0)
                               };

        return array;
    }

    private static T[,] InitArrayForInOut<T>(int rows, int columns)
    {
        T[,] array = new T[rows, columns];

        int value = 0;
        for (int r = rows - 1; r >= 0; --r)
        {
            for (int c = columns - 1; c >= 0; --c)
            {
                array[r, c] = (T)Convert.ChangeType(value++, typeof(T));
            }
        }

        return array;
    }

    private static bool[,] InitBoolArrayForInOut(int rows, int columns)
    {
        bool[,] array = new bool[rows, columns];

        int value = 0;
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < columns; ++c)
            {
                if ((value++) % 2 != 0)
                    array[r, c] = true;
                else
                    array[r, c] = false;
            }
        }

        return array;
    }

    private static TestDelegate[,] InitDelegateArray_2DForInOut()
    {
        TestDelegate[,] array = new TestDelegate[,] {
                                   {
                                       new TestDelegate(delegate() {
                                           return 3;
                                       }),
                                       new TestDelegate(Delegate2)
                                   },
                                   {
                                       new TestDelegate(Delegate1),
                                       new TestDelegate(Delegate0)
                                   }
                               };

        return array;
    }

    private static TestStructSA[] InitStructArrayForInOut(int size)
    {
        TestStructSA[] array = new TestStructSA[size];

        for (int i = array.Length - 1; i >= 0; --i)
        {
            array[i].x = i;
            array[i].d = i;
            array[i].l = i;
            array[i].str = i.ToString();
        }

        return array;
    }

    private static TestStructSA[,] InitStructArrayForInOut(int rows, int columns)
    {
        TestStructSA[,] array = new TestStructSA[rows, columns];

        int value = 0;
        for (int r = rows - 1; r >= 0; --r)
        {
            for (int c = columns - 1; c >= 0; --c)
            {
                array[r, c].x = value;
                array[r, c].d = value;
                array[r, c].l = value;
                array[r, c].str = value.ToString();
                value++;
            }
        }

        return array;
    }
    #endregion

    private static TestStructSA[] InitStructArray(int size)
    {
        TestStructSA[] array = new TestStructSA[size];

        for (int i = 0; i < array.Length; ++i)
        {
            array[i].x = i;
            array[i].d = i;
            array[i].l = i;
            array[i].str = i.ToString();
        }

        return array;
    }

    private static TestStructSA[,] InitStructArray(int rows, int columns)
    {
        TestStructSA[,] array = new TestStructSA[rows, columns];

        int i = 0;
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < columns; ++c)
            {
                array[r, c].x = i;
                array[r, c].d = i;
                array[r, c].l = i;
                array[r, c].str = i.ToString();
                i++;
            }
        }

        return array;
    }

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

    public static int Main()
    {
        bool result = true;

        result = TestMarshalByVal_NoAttributes_1D() && result;
        result = TestMarshalByVal_NoAttributes_2D() && result;
        result = TestMarshalByVal_1D_In() && result;
        result = TestMarshalByVal_2D_In() && result;
        result = TestMarshalByRef_NoAttributes_1D() && result;
        result = TestMarshalByRef_NoAttributes_2D() && result;
        result = TestMarshalByRef_1D_In() && result;
        result = TestMarshalByRef_2D_In() && result;
        result = TestMarshalByVal_1D_Out() && result;
        result = TestMarshalByVal_2D_Out() && result;
        result = TestMarshalByRef_1D_Out_ByRef() && result;
        result = TestMarshalByRef_2D_Out_ByRef() && result;
        result = TestMarshalByVal_1D_InOut() && result;
        result = TestMarshalByVal_2D_InOut() && result;
        result = TestMarshalByRef_1D_InOut_ByRef() && result;
        result = TestMarshalByRef_2D_InOut_ByRef() && result;
        result = CallMarshalArrayOfStructAsSafeArray() && result;
        Console.WriteLine();
        LogResult(result);

        if (result)
        {
            return 100;
        }
        else
        {
            return 101;
        }
    }

    #region ByVal marshal
    private static bool TestMarshalByVal_NoAttributes_1D()
    {
        bool result = true;

        Console.WriteLine("ByVal marshaling CLR 1D array as safearray no attributes");

        result = SafeArray_Int_1D(InitArray<int>(ARRAY_SIZE)) && result;

        result = SafeArray_Double_1D(InitArray<double>(ARRAY_SIZE)) && result;
        result = SafeArray_Byte_1D(InitArray<byte>(ARRAY_SIZE)) && result;
        result = SafeArray_Bool_1D(InitBoolArray(ARRAY_SIZE)) && result;
        result = SafeArray_Delegate_1D(InitDelegateArray()) && result;
        result = SafeArray_TestStruct_1D(InitStructArray(ARRAY_SIZE)) && result;

        string[] strArr = InitArray<string>(ARRAY_SIZE);
        strArr[strArr.Length / 2] = null;
        strArr[strArr.Length / 2 + 1] = "This is a nested \0 string";
        result = SafeArray_String_1D(strArr) && result;

        object[] oArr = InitArray<object>(ARRAY_SIZE);
        oArr[oArr.Length / 2] = null;
        result = SafeArray_Object_1D(oArr) && result;

        LogResult(result);
        return result;
    }

    private static bool TestMarshalByVal_NoAttributes_2D()
    {
        bool result = true;

        Console.WriteLine("ByVal marshaling CLR 2D array as safearray no attributes");

        result = SafeArray_Int_2D(InitArray<int>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;
        result = SafeArray_Double_2D(InitArray<double>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;
        result = SafeArray_Byte_2D(InitArray<byte>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;
        result = SafeArray_Bool_2D(InitBoolArray(ARRAY_ROWS, ARRAY_COLUMNS)) && result;
        result = SafeArray_Delegate_2D(InitDelegateArray_2D()) && result;
        result = SafeArray_TestStruct_2D(InitStructArray(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        string[,] strArr = InitArray<string>(ARRAY_ROWS, ARRAY_COLUMNS);
        strArr[1, 0] = null;
        strArr[1, 1] = "This is a nested \0 string";
        result = SafeArray_String_2D(strArr) && result;

        object[,] oArr = InitArray<object>(ARRAY_ROWS, ARRAY_COLUMNS);
        oArr[1, 0] = null;
        result = SafeArray_Object_2D(oArr) && result;

        LogResult(result);
        return result;
    }

    private static bool TestMarshalByVal_1D_In()
    {
        bool result = true;

        Console.WriteLine("ByVal marshaling CLR 1D array as safearray with InAttribute applied");

        result = SafeArray_Int_1D_In(InitArray<int>(ARRAY_SIZE)) && result;
        result = SafeArray_Double_1D_In(InitArray<double>(ARRAY_SIZE)) && result;
        result = SafeArray_Byte_1D_In(InitArray<byte>(ARRAY_SIZE)) && result;
        result = SafeArray_Bool_1D_In(InitBoolArray(ARRAY_SIZE)) && result;
        result = SafeArray_Delegate_1D_In(InitDelegateArray()) && result;
        result = SafeArray_TestStruct_1D_In(InitStructArray(ARRAY_SIZE)) && result;

        string[] strArr = InitArray<string>(ARRAY_SIZE);
        strArr[strArr.Length / 2] = null;
        strArr[strArr.Length / 2 + 1] = "This is a nested \0 string";
        result = SafeArray_String_1D_In(strArr) && result;

        object[] oArr = InitArray<object>(ARRAY_SIZE);
        oArr[oArr.Length / 2] = null;
        result = SafeArray_Object_1D_In(oArr) && result;

        LogResult(result);
        return result;
    }

    private static bool TestMarshalByVal_2D_In()
    {
        bool result = true;

        Console.WriteLine("ByVal marshaling CLR 2D array as safearray with InAttribute applied");

        result = SafeArray_Int_2D_In(InitArray<int>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;
        result = SafeArray_Double_2D_In(InitArray<double>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;
        result = SafeArray_Byte_2D_In(InitArray<byte>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;
        result = SafeArray_Bool_2D_In(InitBoolArray(ARRAY_ROWS, ARRAY_COLUMNS)) && result;
        result = SafeArray_Delegate_2D_In(InitDelegateArray_2D()) && result;
        result = SafeArray_TestStruct_2D_In(InitStructArray(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        string[,] strArr = InitArray<string>(ARRAY_ROWS, ARRAY_COLUMNS);
        strArr[1, 0] = null;
        strArr[1, 1] = "This is a nested \0 string";
        result = SafeArray_String_2D_In(strArr) && result;

        object[,] oArr = InitArray<object>(ARRAY_ROWS, ARRAY_COLUMNS);
        oArr[1, 0] = null;
        result = SafeArray_Object_2D_In(oArr) && result;

        LogResult(result);
        return result;
    }
    #endregion

    #region ByRef marshal
    private static bool TestMarshalByRef_NoAttributes_1D()
    {
        bool result = true;

        Console.WriteLine("ByRef marshaling CLR 1D array as safearray no attributes");

        int[] iArr = InitArray<int>(ARRAY_SIZE);
        result = SafeArray_Int_1D_ByRef(ref iArr) && result;

        double[] dArr = InitArray<double>(ARRAY_SIZE);
        result = SafeArray_Double_1D_ByRef(ref dArr) && result;

        byte[] byteArr = InitArray<byte>(ARRAY_SIZE);
        result = SafeArray_Byte_1D_ByRef(ref byteArr) && result;

        bool[] bArr = InitBoolArray(ARRAY_SIZE);
        result = SafeArray_Bool_1D_ByRef(ref bArr) && result;

        TestStructSA[] structArr = InitStructArray(ARRAY_SIZE);
        result = SafeArray_TestStruct_1D_ByRef(ref structArr) && result;

        TestDelegate[] deleArr = InitDelegateArray();
        result = SafeArray_Delegate_1D_ByRef(ref deleArr) && result;

        string[] strArr = InitArray<string>(ARRAY_SIZE);
        strArr[strArr.Length / 2] = null;
        strArr[strArr.Length / 2 + 1] = "This is a nested \0 string";
        result = SafeArray_String_1D_ByRef(ref strArr) && result;

        object[] oArr = InitArray<object>(ARRAY_SIZE);
        oArr[oArr.Length / 2] = null;
        result = SafeArray_Object_1D_ByRef(ref oArr) && result;

        LogResult(result);
        return result;
    }

    private static bool TestMarshalByRef_NoAttributes_2D()
    {
        bool result = true;

        Console.WriteLine("ByRef marshaling CLR 2D array as safearray no attributes");

        int[,] iArr = InitArray<int>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Int_2D_ByRef(ref iArr) && result;

        double[,] dArr = InitArray<double>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Double_2D_ByRef(ref dArr) && result;

        byte[,] byteArr = InitArray<byte>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Byte_2D_ByRef(ref byteArr) && result;

        bool[,] bArr = InitBoolArray(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Bool_2D_ByRef(ref bArr) && result;

        TestDelegate[,] deleArr = InitDelegateArray_2D();
        result = SafeArray_Delegate_2D_ByRef(ref deleArr) && result;

        TestStructSA[,] structArr = InitStructArray(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_TestStruct_2D_ByRef(ref structArr) && result;

        string[,] strArr = InitArray<string>(ARRAY_ROWS, ARRAY_COLUMNS);
        strArr[1, 0] = null;
        strArr[1, 1] = "This is a nested \0 string";
        result = SafeArray_String_2D_ByRef(ref strArr) && result;

        object[,] oArr = InitArray<object>(ARRAY_ROWS, ARRAY_COLUMNS);
        oArr[1, 0] = null;
        result = SafeArray_Object_2D_ByRef(ref oArr) && result;

        LogResult(result);
        return result;
    }

    private static bool TestMarshalByRef_1D_In()
    {
        bool result = true;

        Console.WriteLine("ByRef marshaling CLR 1D array as safearray with InAttribute");

        int[] iArr = InitArray<int>(ARRAY_SIZE);
        result = SafeArray_Int_1D_ByRef_In(ref iArr) && result;

        double[] dArr = InitArray<double>(ARRAY_SIZE);
        result = SafeArray_Double_1D_ByRef_In(ref dArr) && result;

        byte[] byteArr = InitArray<byte>(ARRAY_SIZE);
        result = SafeArray_Byte_1D_ByRef_In(ref byteArr) && result;

        bool[] bArr = InitBoolArray(ARRAY_SIZE);
        result = SafeArray_Bool_1D_ByRef_In(ref bArr) && result;

        TestDelegate[] deleArr = InitDelegateArray();
        result = SafeArray_Delegate_1D_ByRef_In(ref deleArr) && result;

        TestStructSA[] structArr = InitStructArray(ARRAY_SIZE);
        result = SafeArray_TestStruct_1D_ByRef_In(ref structArr) && result;

        string[] strArr = InitArray<string>(ARRAY_SIZE);
        strArr[strArr.Length / 2] = null;
        strArr[strArr.Length / 2 + 1] = "This is a nested \0 string";
        result = SafeArray_String_1D_ByRef_In(ref strArr) && result;

        object[] oArr = InitArray<object>(ARRAY_SIZE);
        oArr[oArr.Length / 2] = null;
        result = SafeArray_Object_1D_ByRef_In(ref oArr) && result;

        LogResult(result);
        return result;
    }

    private static bool TestMarshalByRef_2D_In()
    {
        bool result = true;

        Console.WriteLine("ByRef marshaling CLR 2D array as safearray InAttribute");

        int[,] iArr = InitArray<int>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Int_2D_ByRef_In(ref iArr) && result;

        double[,] dArr = InitArray<double>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Double_2D_ByRef_In(ref dArr) && result;

        byte[,] byteArr = InitArray<byte>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Byte_2D_ByRef_In(ref byteArr) && result;

        bool[,] bArr = InitBoolArray(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Bool_2D_ByRef_In(ref bArr) && result;

        TestDelegate[,] deleArr = InitDelegateArray_2D();
        result = SafeArray_Delegate_2D_ByRef_In(ref deleArr) && result;

        TestStructSA[,] structArr = InitStructArray(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_TestStruct_2D_ByRef_In(ref structArr) && result;

        string[,] strArr = InitArray<string>(ARRAY_ROWS, ARRAY_COLUMNS);
        strArr[1, 0] = null;
        strArr[1, 1] = "This is a nested \0 string";
        result = SafeArray_String_2D_ByRef_In(ref strArr) && result;

        object[,] oArr = InitArray<object>(ARRAY_ROWS, ARRAY_COLUMNS);
        oArr[1, 0] = null;
        result = SafeArray_Object_2D_ByRef_In(ref oArr) && result;

        LogResult(result);
        return result;
    }
    #endregion

    #region ByVal Out
    private static bool CheckOutDelegates(TestDelegate[] arr, TestDelegate[] expect)
    {
        if (arr == null)
            return false;

        int size = arr.Length;
        for (int i = 0; i < size; ++i)
        {
            if (expect[i] == null && arr[i] == null)
                continue;
            else if (expect[i] != null && arr[i] == null)
                return false;
            else if (expect[i] == null && arr[i] != null)
                return false;

            int expected = expect[i]();
            int actual = arr[i]();
            if (expected != actual)
            {
                LogVerifyError<int>("Delegate not marshaled", expected, actual);
                return false;
            }
        }

        return true;
    }

    private static bool CheckOutDelegates(TestDelegate[,] arr, TestDelegate[,] expect)
    {
        if (arr == null)
            return false;

        int l1 = arr.GetLowerBound(0);
        int l2 = arr.GetLowerBound(1);
        int u1 = arr.GetUpperBound(0);
        int u2 = arr.GetUpperBound(1);
        int value = 0;
        for (int i = l1; i < u1; ++i)
        {
            for (int j = l2; j < u2; ++j)
            {
                if (expect[i, j] == null && arr[i, j] == null)
                    continue;
                else if (expect[i, j] != null && arr[i, j] == null)
                    return false;
                else if (expect[i, j] == null && arr[i, j] != null)
                    return false;

                int expected = expect[i, j]();
                int actual = arr[i, j]();
                if (expected != actual)
                {
                    LogVerifyError<int>("Delegate not marshaled", expected, actual);
                    return false;
                }

                value++;
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
                LogVerifyError<T>(arr1[i], arr2[i]);
                return false;
            }
        }

        return true;
    }

    private static bool Equals<T>(T[,] arr1, T[,] arr2)
    {
        if (arr1 == null && arr2 == null)
            return true;
        else if (arr1 == null && arr2 != null)
            return false;
        else if (arr1 != null && arr2 == null)
            return false;
        else if (arr1.Length != arr2.Length)
            return false;

        int l1 = arr1.GetLowerBound(0);
        int l2 = arr1.GetLowerBound(1);
        int u1 = arr1.GetUpperBound(0);
        int u2 = arr1.GetUpperBound(1);

        for (int i = l1; i < u1; ++i)
        {
            for (int j = l2; j < u2; ++j)
            {
                if (!Object.Equals(arr1[i, j], arr2[i, j]))
                {
                    LogVerifyError<T>(arr1[i, j], arr2[i, j]);
                    return false;
                }
            }
        }

        return true;
    }

    private static bool TestMarshalByVal_1D_Out()
    {
        bool result = true;

        Console.WriteLine("ByVal marshaling CLR 1D array as safearray with OutAttribute");

        int[] iArr = new int[ARRAY_SIZE];
        result = SafeArray_Int_1D_Out(iArr) && result;
        result = Equals<int>(iArr, InitArray<int>(ARRAY_SIZE)) && result;

        object[] oArr = new object[ARRAY_SIZE];
        result = SafeArray_Object_1D_Out(oArr) && result;
        object[] expectedOArr = InitArray<object>(ARRAY_SIZE);
        expectedOArr[ARRAY_SIZE / 2 - 1] = null;
        result = Equals<object>(oArr, expectedOArr) && result;

        string[] sArr = new string[ARRAY_SIZE];
        result = SafeArray_String_1D_Out(sArr) && result;
        string[] expectedSArr = InitArray<string>(ARRAY_SIZE);
        expectedSArr[ARRAY_SIZE / 2 - 1] = null;
        expectedSArr[ARRAY_SIZE / 2 - 2] = "This is a nested \0 string";
        result = Equals<string>(sArr, expectedSArr) && result;

        double[] dArr = new double[ARRAY_SIZE];
        result = SafeArray_Double_1D_Out(dArr) && result;
        result = Equals<double>(dArr, InitArray<double>(ARRAY_SIZE)) && result;

        byte[] byteArr = new byte[ARRAY_SIZE];
        result = SafeArray_Byte_1D_Out(byteArr) && result;
        result = Equals<byte>(byteArr, InitArray<byte>(ARRAY_SIZE)) && result;

        bool[] bArr = new bool[ARRAY_SIZE];
        result = SafeArray_Bool_1D_Out(bArr) && result;
        result = Equals<bool>(bArr, InitBoolArrayForInOut(ARRAY_SIZE)) && result;

        TestStructSA[] structArr = new TestStructSA[ARRAY_SIZE];
        TestStructSA[] structExpect = InitStructArray(ARRAY_SIZE);
        result = SafeArray_TestStruct_1D_Out(structArr, structExpect) && result;
        result = Equals<TestStructSA>(structArr, structExpect) && result;

        TestDelegate[] deleArr = new TestDelegate[5];
        TestDelegate[] expect = InitDelegateArray();
        result = SafeArray_Delegate_1D_Out(deleArr, expect) && result;
        result = CheckOutDelegates(deleArr, expect) && result;

        LogResult(result);
        return result;
    }

    private static bool TestMarshalByVal_2D_Out()
    {
        bool result = true;

        Console.WriteLine("ByVal marshaling CLR 2D array as safearray with OutAttribute");

        int[,] iArr = new int[ARRAY_ROWS, ARRAY_COLUMNS];
        result = SafeArray_Int_2D_Out(iArr) && result;
        result = Equals<int>(iArr, InitArrayForInOut<int>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        object[,] oArr = new object[ARRAY_ROWS, ARRAY_COLUMNS];
        result = SafeArray_Object_2D_Out(oArr) && result;
        object[,] expectedOArr = InitArrayForInOut<object>(ARRAY_ROWS, ARRAY_COLUMNS);
        expectedOArr[0, 0] = null;
        result = Equals<object>(oArr, expectedOArr) && result;

        string[,] sArr = new string[ARRAY_ROWS, ARRAY_COLUMNS];
        result = SafeArray_String_2D_Out(sArr) && result;
        string[,] expectedSArr = InitArrayForInOut<string>(ARRAY_ROWS, ARRAY_COLUMNS);
        expectedSArr[0, 0] = null;
        expectedSArr[0, 1] = "This is a nested \0 string";
        result = Equals<string>(sArr, expectedSArr) && result;

        double[,] dArr = new double[ARRAY_ROWS, ARRAY_COLUMNS];
        result = SafeArray_Double_2D_Out(dArr) && result;
        result = Equals<double>(dArr, InitArrayForInOut<double>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        byte[,] byteArr = new byte[ARRAY_ROWS, ARRAY_COLUMNS];
        result = SafeArray_Byte_2D_Out(byteArr) && result;
        result = Equals<byte>(byteArr, InitArrayForInOut<byte>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        bool[,] bArr = new bool[ARRAY_ROWS, ARRAY_COLUMNS];
        result = SafeArray_Bool_2D_Out(bArr) && result;
        result = Equals<bool>(bArr, InitBoolArrayForInOut(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        TestDelegate[,] deleArr = new TestDelegate[2, 2];
        TestDelegate[,] expect = InitDelegateArray_2D();
        result = SafeArray_Delegate_2D_Out(deleArr, expect) && result;
        result = CheckOutDelegates(deleArr, expect) && result;

        TestStructSA[,] structArr = new TestStructSA[ARRAY_ROWS, ARRAY_COLUMNS];
        TestStructSA[,] structExpect = InitStructArrayForInOut(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_TestStruct_2D_Out(structArr, structExpect) && result;
        result = Equals<TestStructSA>(structArr, structExpect) && result;

        LogResult(result);
        return result;
    }
    #endregion

    #region ByRef Out
    private static bool TestMarshalByRef_1D_Out_ByRef()
    {
        bool result = true;

        Console.WriteLine("ByRef marshaling CLR 1D array as safearray with OutAttribute");

        int[] iArr;
        result = SafeArray_Int_1D_Out_ByRef(out iArr) && result;
        result = Equals<int>(iArr, InitArray<int>(ARRAY_SIZE)) && result;

        object[] oArr;
        result = SafeArray_Object_1D_Out_ByRef(out oArr) && result;
        object[] expectedOArr = InitArray<object>(ARRAY_SIZE);
        expectedOArr[ARRAY_SIZE / 2 - 1] = null;
        result = Equals<object>(oArr, expectedOArr) && result;

        string[] sArr;
        result = SafeArray_String_1D_Out_ByRef(out sArr) && result;
        string[] expectedSArr = InitArray<string>(ARRAY_SIZE);
        expectedSArr[ARRAY_SIZE / 2 - 1] = null;
        expectedSArr[ARRAY_SIZE / 2 - 2] = "This is a nested \0 string";
        result = Equals<string>(sArr, expectedSArr) && result;

        double[] dArr;
        result = SafeArray_Double_1D_Out_ByRef(out dArr) && result;
        result = Equals<double>(dArr, InitArray<double>(ARRAY_SIZE)) && result;

        byte[] byteArr;
        result = SafeArray_Byte_1D_Out_ByRef(out byteArr) && result;
        result = Equals<byte>(byteArr, InitArray<byte>(ARRAY_SIZE)) && result;

        bool[] bArr;
        result = SafeArray_Bool_1D_Out_ByRef(out bArr) && result;
        result = Equals<bool>(bArr, InitBoolArrayForInOut(ARRAY_SIZE)) && result;

        TestDelegate[] deleArr;
        TestDelegate[] expect = InitDelegateArray();
        result = SafeArray_Delegate_1D_Out_ByRef(out deleArr, expect) && result;
        result = CheckOutDelegates(deleArr, expect) && result;

        TestStructSA[] structArr;
        TestStructSA[] structExpect = InitStructArray(ARRAY_SIZE);
        result = SafeArray_TestStruct_1D_Out_ByRef(out structArr, structExpect) && result;
        result = Equals<TestStructSA>(structArr, structExpect) && result;

        LogResult(result);
        return result;
    }

    private static bool TestMarshalByRef_2D_Out_ByRef()
    {
        bool result = true;

        Console.WriteLine("ByRef marshaling CLR 2D array as safearray with OutAttribute");

        int[,] iArr;
        result = SafeArray_Int_2D_Out_ByRef(out iArr) && result;
        result = Equals<int>(iArr, InitArrayForInOut<int>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        object[,] oArr;
        result = SafeArray_Object_2D_Out_ByRef(out oArr) && result;
        object[,] expectedOArr = InitArrayForInOut<object>(ARRAY_ROWS, ARRAY_COLUMNS);
        expectedOArr[0, 0] = null;
        result = Equals<object>(oArr, expectedOArr) && result;

        string[,] sArr;
        result = SafeArray_String_2D_Out_ByRef(out sArr) && result;
        string[,] expectedSArr = InitArrayForInOut<string>(ARRAY_ROWS, ARRAY_COLUMNS);
        expectedSArr[0, 0] = null;
        expectedSArr[0, 1] = "This is a nested \0 string";
        result = Equals<string>(sArr, expectedSArr) && result;

        double[,] dArr;
        result = SafeArray_Double_2D_Out_ByRef(out dArr) && result;
        result = Equals<double>(dArr, InitArrayForInOut<double>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        byte[,] byteArr;
        result = SafeArray_Byte_2D_Out_ByRef(out byteArr) && result;
        result = Equals<byte>(byteArr, InitArrayForInOut<byte>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        bool[,] bArr;
        result = SafeArray_Bool_2D_Out_ByRef(out bArr) && result;
        result = Equals<bool>(bArr, InitBoolArrayForInOut(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        TestStructSA[,] structArr;
        TestStructSA[,] structExpect = InitStructArray(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_TestStruct_2D_Out_ByRef(out structArr, structExpect) && result;
        result = Equals<TestStructSA>(structArr, structExpect) && result;

        TestDelegate[,] deleArr;
        TestDelegate[,] expect = InitDelegateArray_2D();
        result = SafeArray_Delegate_2D_Out_ByRef(out deleArr, expect) && result;
        result = CheckOutDelegates(deleArr, expect) && result;

        LogResult(result);
        return result;
    }
    #endregion

    #region ByVal In Out
    private static bool TestMarshalByVal_1D_InOut()
    {
        bool result = true;

        Console.WriteLine("ByVal marshaling CLR 1D array as safearray with InAttribute and OutAttribute");

        int[] iArr = InitArray<int>(ARRAY_SIZE);
        result = SafeArray_Int_1D_InOut(iArr) && result;
        result = Equals<int>(iArr, InitArrayForInOut<int>(ARRAY_SIZE)) && result;

        object[] oArr = InitArray<object>(ARRAY_SIZE);
        oArr[oArr.Length / 2] = null;
        result = SafeArray_Object_1D_InOut(oArr) && result;
        object[] expectedOArr = InitArrayForInOut<object>(ARRAY_SIZE);
        expectedOArr[ARRAY_SIZE / 2 - 1] = null;
        result = Equals<object>(oArr, expectedOArr) && result;

        string[] strArr = InitArray<string>(ARRAY_SIZE);
        strArr[strArr.Length / 2] = null;
        strArr[strArr.Length / 2 + 1] = "This is a nested \0 string";
        result = SafeArray_String_1D_InOut(strArr) && result;
        string[] expectedSArr = InitArrayForInOut<string>(ARRAY_SIZE);
        expectedSArr[ARRAY_SIZE / 2 - 1] = null;
        expectedSArr[ARRAY_SIZE / 2 - 2] = "This is a nested \0 string";
        result = Equals<object>(strArr, expectedSArr) && result;

        double[] dArr = InitArray<double>(ARRAY_SIZE);
        result = SafeArray_Double_1D_InOut(dArr) && result;
        result = Equals<double>(dArr, InitArrayForInOut<double>(ARRAY_SIZE)) && result;

        byte[] byteArr = InitArray<byte>(ARRAY_SIZE);
        result = SafeArray_Byte_1D_InOut(byteArr) && result;
        result = Equals<byte>(byteArr, InitArrayForInOut<byte>(ARRAY_SIZE)) && result;

        bool[] bArr = InitBoolArray(ARRAY_SIZE);
        result = SafeArray_Bool_1D_InOut(bArr) && result;
        result = Equals<bool>(bArr, InitBoolArrayForInOut(ARRAY_SIZE)) && result;

        TestDelegate[] deleArr = InitDelegateArray();
        TestDelegate[] expect = InitDelegateArrayForInOut();
        result = SafeArray_Delegate_1D_InOut(deleArr, expect) && result;
        result = CheckOutDelegates(deleArr, expect) && result;

        TestStructSA[] structArr = InitStructArray(ARRAY_SIZE);
        TestStructSA[] structExpect = InitStructArrayForInOut(ARRAY_SIZE);
        result = SafeArray_TestStruct_1D_InOut(structArr, structExpect) && result;
        result = Equals<TestStructSA>(structArr, structExpect) && result;

        LogResult(result);
        return result;
    }

    private static bool TestMarshalByVal_2D_InOut()
    {
        bool result = true;

        Console.WriteLine("ByVal marshaling CLR 2D array as safearray with InAttribute and OutAttribute");

        int[,] iArr = InitArray<int>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Int_2D_InOut(iArr) && result;
        result = Equals<int>(iArr, InitArrayForInOut<int>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        object[,] oArr = InitArray<object>(ARRAY_ROWS, ARRAY_COLUMNS);
        oArr[1, 0] = null;
        result = SafeArray_Object_2D_InOut(oArr) && result;
        object[,] expectedOArr = InitArrayForInOut<object>(ARRAY_ROWS, ARRAY_COLUMNS);
        expectedOArr[0, 0] = null;
        result = Equals<object>(oArr, expectedOArr) && result;

        string[,] strArr = InitArray<string>(ARRAY_ROWS, ARRAY_COLUMNS);
        strArr[1, 0] = null;
        strArr[1, 1] = "This is a nested \0 string";
        result = SafeArray_String_2D_InOut(strArr) && result;
        string[,] expectedSArr = InitArrayForInOut<string>(ARRAY_ROWS, ARRAY_COLUMNS);
        expectedSArr[0, 0] = null;
        expectedSArr[0, 1] = "This is a nested \0 string";
        result = Equals<string>(strArr, expectedSArr) && result;

        double[,] dArr = InitArray<double>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Double_2D_InOut(dArr) && result;
        result = Equals<double>(dArr, InitArrayForInOut<double>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        byte[,] byteArr = InitArray<byte>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Byte_2D_InOut(byteArr) && result;
        result = Equals<byte>(byteArr, InitArrayForInOut<byte>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        bool[,] bArr = InitBoolArray(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Bool_2D_InOut(bArr) && result;
        result = Equals<bool>(bArr, InitBoolArrayForInOut(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        TestDelegate[,] deleArr = InitDelegateArray_2D();
        TestDelegate[,] expect = InitDelegateArray_2DForInOut();
        result = SafeArray_Delegate_2D_InOut(deleArr, expect) && result;
        result = CheckOutDelegates(deleArr, expect) && result;

        TestStructSA[,] structArr = InitStructArray(ARRAY_ROWS, ARRAY_COLUMNS);
        TestStructSA[,] structExpect = InitStructArrayForInOut(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_TestStruct_2D_InOut(structArr, structExpect) && result;
        result = Equals<TestStructSA>(structArr, structExpect) && result;

        LogResult(result);
        return result;
    }
    #endregion

    #region ByRef In Out
    private static bool TestMarshalByRef_1D_InOut_ByRef()
    {
        bool result = true;

        Console.WriteLine("ByRef marshaling CLR 1D array as safearray with InAttribute and OutAttribute");

        int[] iArr = InitArray<int>(ARRAY_SIZE);
        result = SafeArray_Int_1D_InOut_ByRef(ref iArr) && result;
        result = Equals<int>(iArr, InitArrayForInOut<int>(ARRAY_SIZE)) && result;

        object[] oArr = InitArray<object>(ARRAY_SIZE);
        oArr[oArr.Length / 2] = null;
        result = SafeArray_Object_1D_InOut_ByRef(ref oArr) && result;
        object[] expectedOArr = InitArrayForInOut<object>(ARRAY_SIZE);
        expectedOArr[ARRAY_SIZE / 2 - 1] = null;
        result = Equals<object>(oArr, expectedOArr) && result;

        string[] strArr = InitArray<string>(ARRAY_SIZE);
        strArr[strArr.Length / 2] = null;
        strArr[strArr.Length / 2 + 1] = "This is a nested \0 string";
        result = SafeArray_String_1D_InOut_ByRef(ref strArr) && result;
        string[] expectedSArr = InitArrayForInOut<string>(ARRAY_SIZE);
        expectedSArr[expectedSArr.Length / 2 - 1] = null;
        expectedSArr[expectedSArr.Length / 2 - 2] = "This is a nested \0 string";
        result = Equals<string>(strArr, expectedSArr) && result;

        double[] dArr = InitArray<double>(ARRAY_SIZE);
        result = SafeArray_Double_1D_InOut_ByRef(ref dArr) && result;
        result = Equals<double>(dArr, InitArrayForInOut<double>(ARRAY_SIZE)) && result;

        byte[] byteArr = InitArray<byte>(ARRAY_SIZE);
        result = SafeArray_Byte_1D_InOut_ByRef(ref byteArr) && result;
        result = Equals<byte>(byteArr, InitArrayForInOut<byte>(ARRAY_SIZE)) && result;

        bool[] bArr = InitBoolArray(ARRAY_SIZE);
        result = SafeArray_Bool_1D_InOut_ByRef(ref bArr) && result;
        result = Equals<bool>(bArr, InitBoolArrayForInOut(ARRAY_SIZE)) && result;

        TestStructSA[] structArr = InitStructArray(ARRAY_SIZE);
        TestStructSA[] structExpect = InitStructArrayForInOut(ARRAY_SIZE);
        result = SafeArray_TestStruct_1D_InOut_ByRef(ref structArr, structExpect) && result;
        result = Equals<TestStructSA>(structArr, structExpect) && result;

        TestDelegate[] deleArr = InitDelegateArray();
        TestDelegate[] expect = InitDelegateArrayForInOut();
        result = SafeArray_Delegate_1D_InOut_ByRef(ref deleArr, expect) && result;
        result = CheckOutDelegates(deleArr, expect) && result;

        LogResult(result);
        return result;
    }

    private static bool TestMarshalByRef_2D_InOut_ByRef()
    {
        bool result = true;

        Console.WriteLine("ByRef marshaling CLR 2D array as safearray with InAttribute and OutAttribute");

        int[,] iArr = InitArray<int>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Int_2D_InOut_ByRef(ref iArr) && result;
        result = Equals<int>(iArr, InitArrayForInOut<int>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        object[,] oArr = InitArray<object>(ARRAY_ROWS, ARRAY_COLUMNS);
        oArr[1, 0] = null;
        result = SafeArray_Object_2D_InOut_ByRef(ref oArr) && result;
        object[,] expectedOArr = InitArrayForInOut<object>(ARRAY_ROWS, ARRAY_COLUMNS);
        expectedOArr[0, 0] = null;
        result = Equals<object>(oArr, expectedOArr) && result;

        string[,] strArr = InitArray<string>(ARRAY_ROWS, ARRAY_COLUMNS);
        strArr[1, 0] = null;
        strArr[1, 1] = "This is a nested \0 string";
        result = SafeArray_String_2D_InOut_ByRef(ref strArr) && result;
        string[,] expectedSArr = InitArrayForInOut<string>(ARRAY_ROWS, ARRAY_COLUMNS);
        expectedSArr[0, 0] = null;
        expectedSArr[0, 1] = "This is a nested \0 string";
        result = Equals<string>(strArr, expectedSArr) && result;

        double[,] dArr = InitArray<double>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Double_2D_InOut_ByRef(ref dArr) && result;
        result = Equals<double>(dArr, InitArrayForInOut<double>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        byte[,] byteArr = InitArray<byte>(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Byte_2D_InOut_ByRef(ref byteArr) && result;
        result = Equals<byte>(byteArr, InitArrayForInOut<byte>(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        bool[,] bArr = InitBoolArray(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_Bool_2D_InOut_ByRef(ref bArr) && result;
        result = Equals<bool>(bArr, InitBoolArrayForInOut(ARRAY_ROWS, ARRAY_COLUMNS)) && result;

        TestDelegate[,] deleArr = InitDelegateArray_2D();
        TestDelegate[,] expect = InitDelegateArray_2DForInOut();
        result = SafeArray_Delegate_2D_InOut_ByRef(ref deleArr, expect) && result;
        result = CheckOutDelegates(deleArr, expect) && result;

        TestStructSA[,] structArr = InitStructArray(ARRAY_ROWS, ARRAY_COLUMNS);
        TestStructSA[,] structExpect = InitStructArrayForInOut(ARRAY_ROWS, ARRAY_COLUMNS);
        result = SafeArray_TestStruct_2D_InOut_ByRef(ref structArr, structExpect) && result;
        result = Equals<TestStructSA>(structArr, structExpect) && result;

        LogResult(result);
        return result;
    }
    #endregion

    #region Added some Marshaling Array of Struct AsSafeArray
    private static bool CallMarshalArrayOfStructAsSafeArray()
    {
        bool result = true;
        S2[] sourceArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        S2[] cloneArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        S2[] changeArrS2 = NewS2arr(NumArrOfStructElements1, 0, 32, 0, 16, 0, 8, 0, 16, 0, 64, 64.0F, 6.4);

        #region MarshalArrayOfStructAsParam_AsSafeArrayByVal
        Console.WriteLine("\tMarshaling Array Of Struct AsSafeArray ByVal");
        try
        {
            if (!MarshalArrayOfStructAsParam_AsSafeArrayByVal(sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsParam_AsSafeArrayByVal did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(sourceArrS2, cloneArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByVal did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("sourceArrS2", sourceArrS2);
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
        #region MarshalArrayOfStructAsParam_AsSafeArrayByRef
        Console.WriteLine("\tMarshaling Array Of Struct AsSafeArray ByRef");
        try
        {
            if (!MarshalArrayOfStructAsParam_AsSafeArrayByRef(ref sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsParam_AsSafeArrayByRef did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByRef did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("sourceArrS2", sourceArrS2);
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
        #region MarshalArrayOfStructAsParam_AsSafeArrayByValIn
        Console.WriteLine("\tMarshaling Array Of Struct AsSafeArray ByValInIn");
        sourceArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        try
        {
            if (!MarshalArrayOfStructAsParam_AsSafeArrayByValIn(sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsParam_AsSafeArrayByValIn did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(sourceArrS2, cloneArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByValInIn did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("sourceArrS2", sourceArrS2);
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
        #region MarshalArrayOfStructAsParam_AsSafeArrayByRefIn
        Console.WriteLine("\tMarshaling Array Of Struct AsSafeArray ByRefIn");
        try
        {
            if (!MarshalArrayOfStructAsParam_AsSafeArrayByRefIn(ref sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsParam_AsSafeArrayByRefIn did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(sourceArrS2, cloneArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByRefIn did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("sourceArrS2", sourceArrS2);
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
        #region MarshalArrayOfStructAsParam_AsSafeArrayByValOut
        Console.WriteLine("\tMarshaling Array Of Struct AsSafeArray ByValOut");
        try
        {
            if (!MarshalArrayOfStructAsParam_AsSafeArrayByValOut(sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsParam_AsSafeArrayByValOut did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByValOut did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("sourceArrS2", sourceArrS2);
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
        #region MarshalArrayOfStructAsParam_AsSafeArrayByRefOut
        Console.WriteLine("\tMarshaling Array Of Struct AsSafeArray ByRefOut");
        sourceArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        try
        {
            if (!MarshalArrayOfStructAsParam_AsSafeArrayByRefOut(out sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsParam_AsSafeArrayByRefOut did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByRefOut did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("sourceArrS2", sourceArrS2);
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
        #region MarshalArrayOfStructAsParam_AsSafeArrayByValInOut
        Console.WriteLine("\tMarshaling Array Of Struct AsSafeArray ByValInOut");
        sourceArrS2 = NewS2arr(NumArrOfStructElements1, Int32.MinValue, UInt32.MaxValue, short.MinValue, ushort.MaxValue, byte.MinValue, sbyte.MaxValue, Int16.MinValue, UInt16.MaxValue, Int64.MinValue, UInt64.MaxValue, 32.0F, 3.2);
        try
        {
            if (!MarshalArrayOfStructAsParam_AsSafeArrayByValInOut(sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsParam_AsSafeArrayByValInOut did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByValInOut did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("sourceArrS2", sourceArrS2);
                Console.WriteLine("\tThe Expected is...");
                PrintS2arr("cloneArrS2", changeArrS2);
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
        #region MarshalArrayOfStructAsParam_AsSafeArrayByRefInOut
        Console.WriteLine("\tMarshaling Array Of Struct AsSafeArray ByRefInOut");
        try
        {
            if (!MarshalArrayOfStructAsParam_AsSafeArrayByRefInOut(ref sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tMarshalArrayOfStructAsParam_AsSafeArrayByRefInOut did not return expected Value!");
                result = false;
            }
            else if (!IsCorrect(sourceArrS2, changeArrS2))
            {
                Console.WriteLine("\tFAILED! Marshaling Array of S2 ByRefInOut did not receive param as expected.");
                Console.WriteLine("\tThe Actual is...");
                PrintS2arr("sourceArrS2", sourceArrS2);
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
        LogResult(result);
        return result;
    }
    #endregion
}
