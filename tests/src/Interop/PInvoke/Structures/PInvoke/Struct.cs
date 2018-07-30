// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text;
using System.Runtime.InteropServices;

public class Common
{
    public const int NumArrElements = 2;
}

//////////////////////////////struct definition///////////////////////////
[StructLayout(LayoutKind.Sequential)]
public struct InnerSequential
{
    public int f1;
    public float f2;
    [MarshalAs(UnmanagedType.BStr)]
    public String f3;
}

[StructLayout(LayoutKind.Explicit)]
public struct InnerExplicit1
{
    [FieldOffset(0)]
    public int f1;
    [FieldOffset(4)]
    public float f2;
    [FieldOffset(8)]
    [MarshalAs(UnmanagedType.BStr)]
    public String f3;
}

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
public struct StringExplicit
{
    [FieldOffset(0)]
    [MarshalAs(UnmanagedType.LPStr)]
    public String str1;

    [FieldOffset(8)]
    [MarshalAs(UnmanagedType.LPTStr)]
    public String str2;

    [FieldOffset(16)]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public String charr;
}

[StructLayout(LayoutKind.Explicit)]
public struct InnerExplicit2
{
    [FieldOffset(0)]
    public int f1;
    [FieldOffset(4)]
    public float f2;
    [FieldOffset(8)]
    [MarshalAs(UnmanagedType.BStr)]
    public String f3;
}

[StructLayout(LayoutKind.Sequential)]//struct containing one field of array type
public struct InnerArraySequential
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Common.NumArrElements)]
    public InnerSequential[] arr;
}

[StructLayout(LayoutKind.Explicit, Pack = 8)]
public struct InnerArrayExplicit1
{
    [FieldOffset(0)]
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Common.NumArrElements)]
    public InnerSequential[] arr;

    [FieldOffset(32)]
    [MarshalAs(UnmanagedType.BStr)]
    public string f4;
}

[StructLayout(LayoutKind.Explicit)]
public struct InnerArrayExplicit2
{
    [FieldOffset(0)]
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Common.NumArrElements)]
    public InnerSequential[] arr;

    [FieldOffset(32)]
    [MarshalAs(UnmanagedType.BStr)]
    public string f4;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct CharSetAnsiSequential
{
    public string f1;
    public char f2;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct CharSetUnicodeSequential
{
    public string f1;
    public char f2;
}

[StructLayout(LayoutKind.Sequential)]
public struct NumberSequential
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
public struct StructSeqWithArrayField
{
    public bool flag;
    public string str;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    public int[] vals;
}

[StructLayout(LayoutKind.Sequential)]
public struct S4
{
    public int age;
    public string name;
}

public enum Enum1 { e1 = 1, e2 = 3 };

[StructLayout(LayoutKind.Sequential)]
public struct StructSeqWithEnumField
{
    public S4 s4;
    public Enum1 ef;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct StringStructSequentialAnsi
{
    [MarshalAs(UnmanagedType.BStr)]
    public string first;
    public string last;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct StringStructSequentialUnicode
{
    [MarshalAs(UnmanagedType.BStr)]
    public string first;
    public string last;
}

[StructLayout(LayoutKind.Sequential)]
public struct PritypeStructSeqWithUnmanagedType
{
    [MarshalAs(UnmanagedType.BStr)]
    public string name;
    [MarshalAs(UnmanagedType.VariantBool)]
    public bool gender;
    //[MarshalAs(UnmanagedType.Currency)] //In ProjectN V1, we dont support Marshal Decimal as Currency
    //public decimal wage;
    [MarshalAs(UnmanagedType.U2)]
    public UInt16 jobNum;
    //[MarshalAs(UnmanagedType.Error)] //In ProjectN V1, we dont support MarshalAs Error 
    //public int i32;
    //[MarshalAs(UnmanagedType.Error)]
    //public uint ui32;
    [MarshalAs(UnmanagedType.I1)]
    public sbyte mySByte;
}

public struct StructSequentialWithDelegateField
{
    //[MarshalAs(UnmanagedType.Error)] //In ProjectN V1, we dont support MarshalAs Error 
    //public int i32;
    public TestDelegate1 myDelegate1;
}

public delegate void TestDelegate1(StructSequentialWithDelegateField myStruct);

[StructLayout(LayoutKind.Sequential)]
public struct IntergerStructSequential
{
    public int i;
}

[StructLayout(LayoutKind.Sequential)]
public struct OuterIntergerStructSequential
{
    public int i;
    public IntergerStructSequential s_int;
}

[StructLayout(LayoutKind.Sequential)]
public struct IncludeOuterIntergerStructSequential
{
    public OuterIntergerStructSequential s;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct StructSequentialWithPointerField
{
    public int* i32;
    public int i;
}

[StructLayout(LayoutKind.Explicit)]
public struct NumberExplicit
{
    [FieldOffset(0)]
    public int i32;
    [FieldOffset(0)]
    public uint ui32;
    [FieldOffset(0)]
    public IntPtr iPtr;
    [FieldOffset(0)]
    public UIntPtr uiPtr;
    [FieldOffset(0)]
    public short s;
    [FieldOffset(0)]
    public ushort us;
    [FieldOffset(0)]
    public Byte b;
    [FieldOffset(0)]
    public SByte sb;
    [FieldOffset(0)]
    public long l;
    [FieldOffset(0)]
    public ulong ul;
    [FieldOffset(0)]
    public float f;
    [FieldOffset(0)]
    public Double d;
}

[StructLayout(LayoutKind.Explicit, Size = 2)]
public struct ByteStructPack2Explicit
{
    [FieldOffset(0)]
    public byte b1;
    [FieldOffset(1)]
    public byte b2;
}

[StructLayout(LayoutKind.Explicit, Size = 4)]
public struct ShortStructPack4Explicit
{
    [FieldOffset(0)]
    public short s1;
    [FieldOffset(2)]
    public short s2;
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct IntStructPack8Explicit
{
    [FieldOffset(0)]
    public int i1;
    [FieldOffset(4)]
    public int i2;
}

[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct LongStructPack16Explicit
{
    [FieldOffset(0)]
    public long l1;
    [FieldOffset(8)]
    public long l2;
}
