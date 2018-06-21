using System;
using System.Runtime.InteropServices;

#region Struct Definition
[StructLayout(LayoutKind.Sequential)]
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

[StructLayout(LayoutKind.Sequential)]
public struct Struct_Sequential
{
    [MarshalAs(UnmanagedType.SafeArray)]
    public int[] longArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public uint[] ulongArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public short[] shortArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public ushort[] ushortArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public long[] long64Arr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public ulong[] ulong64Arr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public double[] doubleArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public float[] floatArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public byte[] byteArr;

    [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public string[] bstrArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public bool[] boolArr;
}

[StructLayout(LayoutKind.Explicit)]
public struct Struct_Explicit
{
    [FieldOffset(0 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public int[] longArr;

    [FieldOffset(1 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public uint[] ulongArr;

    [FieldOffset(2 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public short[] shortArr;

    [FieldOffset(3 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public ushort[] ushortArr;

    [FieldOffset(4 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public long[] long64Arr;

    [FieldOffset(5 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public ulong[] ulong64Arr;

    [FieldOffset(6 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public double[] doubleArr;

    [FieldOffset(7 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public float[] floatArr;

    [FieldOffset(8 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public byte[] byteArr;

    [FieldOffset(9 * 8)]
    [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public string[] bstrArr;

    [FieldOffset(10 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public bool[] boolArr;
}

[StructLayout(LayoutKind.Sequential)]
public struct Struct_SeqWithArrOfStr
{
    [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_RECORD)]
    public S2[] arrS2;
}

[StructLayout(LayoutKind.Explicit)]
public struct Struct_ExpWithArrOfStr
{
    [FieldOffset(0)]
    [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_RECORD)]
    public S2[] arrS2;
}
#endregion

#region Class Definition
[StructLayout(LayoutKind.Sequential)]
public class Class_Sequential
{
    [MarshalAs(UnmanagedType.SafeArray)]
    public int[] longArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public uint[] ulongArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public short[] shortArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public ushort[] ushortArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public long[] long64Arr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public ulong[] ulong64Arr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public double[] doubleArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public float[] floatArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public byte[] byteArr;

    [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public string[] bstrArr;

    [MarshalAs(UnmanagedType.SafeArray)]
    public bool[] boolArr;
}

[StructLayout(LayoutKind.Explicit)]
public class Class_Explicit
{
    [FieldOffset(0 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public int[] longArr;

    [FieldOffset(1 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public uint[] ulongArr;

    [FieldOffset(2 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public short[] shortArr;

    [FieldOffset(3 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public ushort[] ushortArr;

    [FieldOffset(4 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public long[] long64Arr;

    [FieldOffset(5 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public ulong[] ulong64Arr;

    [FieldOffset(6 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public double[] doubleArr;

    [FieldOffset(7 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public float[] floatArr;

    [FieldOffset(8 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public byte[] byteArr;

    [FieldOffset(9 * 8)]
    [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public string[] bstrArr;

    [FieldOffset(10 * 8)]
    [MarshalAs(UnmanagedType.SafeArray)]
    public bool[] boolArr;
}

[StructLayout(LayoutKind.Sequential)]
public class Class_SeqWithArrOfStr
{
    [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_RECORD)]
    public S2[] arrS2;
}

[StructLayout(LayoutKind.Explicit)]
public class Class_ExpWithArrOfStr
{
    [FieldOffset(0)]
    [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_RECORD)]
    public S2[] arrS2;
}
#endregion