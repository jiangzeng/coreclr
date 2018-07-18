﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text;
using System.Runtime.InteropServices;

[assembly: BestFitMapping(false, ThrowOnUnmappableChar = true)]

[StructLayout(LayoutKind.Sequential)]
[BestFitMapping(true)]
public struct LPStrTestStruct_nothrow
{
    [MarshalAs(UnmanagedType.LPStr)]
    public String str;
}

[StructLayout(LayoutKind.Sequential)]
[BestFitMapping(true, ThrowOnUnmappableChar = true)]
public struct LPStrTestStruct
{
    [MarshalAs(UnmanagedType.LPStr)]
    public String str;
}

[StructLayout(LayoutKind.Sequential)]
[BestFitMapping(true, ThrowOnUnmappableChar = true)]
public class LPStrTestClass
{
    [MarshalAs(UnmanagedType.LPStr)]
    public String str;
}

public class BFM_LPStrMarshaler
{
    static int iCountErrors = 0;
    static int iCountTestCases = 0;

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_In_String([In][MarshalAs(UnmanagedType.LPStr)]String s);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_InByRef_String([In][MarshalAs(UnmanagedType.LPStr)]ref String s);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_InOutByRef_String([In, Out][MarshalAs(UnmanagedType.LPStr)]ref String s);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_In_StringBuilder([In][MarshalAs(UnmanagedType.LPStr)]StringBuilder s);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_InByRef_StringBuilder([In][MarshalAs(UnmanagedType.LPStr)]ref StringBuilder s);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_InOutByRef_StringBuilder([In, Out][MarshalAs(UnmanagedType.LPStr)]ref StringBuilder s);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_In_Struct_String_nothrow([In][MarshalAs(UnmanagedType.Struct)]LPStrTestStruct_nothrow strStruct);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_In_Struct_String([In][MarshalAs(UnmanagedType.Struct)]LPStrTestStruct strStruct);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_InByRef_Struct_String([In][MarshalAs(UnmanagedType.Struct)]ref LPStrTestStruct strStruct);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_InOutByRef_Struct_String([In, Out][MarshalAs(UnmanagedType.Struct)]ref LPStrTestStruct strStruct);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_In_Array_String([In][MarshalAs(UnmanagedType.LPArray)]String[] strArray);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_InByRef_Array_String([In][MarshalAs(UnmanagedType.LPArray)]ref String[] strArray);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_InOutByRef_Array_String([In, Out][MarshalAs(UnmanagedType.LPArray)]ref String[] Array);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_In_Class_String([In][MarshalAs(UnmanagedType.LPStruct)]LPStrTestClass strClass);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_InByRef_Class_String([In][MarshalAs(UnmanagedType.LPStruct)]ref LPStrTestClass strClass);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern bool LPStrBuffer_InOutByRef_Class_String([In, Out][MarshalAs(UnmanagedType.LPStruct)]ref LPStrTestClass strClass);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = false, ThrowOnUnmappableChar = false)]
    public static extern bool LPStrBuffer_In_Array_Struct([In][MarshalAs(UnmanagedType.LPArray)]LPStrTestStruct[] structArray);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = false, ThrowOnUnmappableChar = false)]
    public static extern bool LPStrBuffer_InByRef_Array_Struct([In][MarshalAs(UnmanagedType.LPArray)]ref LPStrTestStruct[] structArray);

    [DllImport("LPStr_BestFitMappingNative", BestFitMapping = false, ThrowOnUnmappableChar = false)]
    public static extern bool LPStrBuffer_InOutByRef_Array_Struct([In, Out][MarshalAs(UnmanagedType.LPArray)]ref LPStrTestStruct[] structArray);

    String GetValidString()
    {
        return "This is the initial test string.";
    }

    String GetInvalidString()
    {
        StringBuilder sbl = new StringBuilder();
        sbl.Append((char)0x2216);
        sbl.Append((char)0x2044);
        sbl.Append((char)0x2215);
        sbl.Append((char)0x0589);
        sbl.Append((char)0x2236);
        //sbl.Append ('乀');
        return sbl.ToString();
    }

    StringBuilder GetValidStringBuilder()
    {
        StringBuilder sb = new StringBuilder("test string.");
        return sb;
    }

    StringBuilder GetInvalidStringBuilder()
    {
        StringBuilder sbl = new StringBuilder();
        sbl.Append((char)0x2216);
        sbl.Append((char)0x2044);
        sbl.Append((char)0x2215);
        sbl.Append((char)0x0589);
        sbl.Append((char)0x2236);
        //sbl.Append ('乀');
        return sbl;
    }

    void testLPStrBufferString()
    {
        iCountTestCases++;
        if (!LPStrBuffer_In_String(GetInvalidString()))
        {
            Console.WriteLine("[Error] Location tcbs11");
            iCountErrors++;
        }

        iCountTestCases++;
        if (!LPStrBuffer_In_String(GetValidString()))
        {
            Console.WriteLine("[Error] Location tcbs22");
            iCountErrors++;
        }

        iCountTestCases++;
        String cTemp = GetInvalidString();
        String cTempClone = GetInvalidString();
        if (!LPStrBuffer_InByRef_String(ref cTemp))
        {
            Console.WriteLine("[Error] Location tcbs33");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetValidString();
        cTempClone = cTemp;
        if (!LPStrBuffer_InByRef_String(ref cTemp))
        {
            Console.WriteLine("[Error] Location tcbs44");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetInvalidString();
        cTempClone = cTemp;
        if (!LPStrBuffer_InOutByRef_String(ref cTemp))
        {
            Console.WriteLine("[Error] Location tcbs55");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetValidString();
        cTempClone = cTemp;
        if (!LPStrBuffer_InOutByRef_String(ref cTemp))
        {
            Console.WriteLine("[Error] Location tcbs66");
            iCountErrors++;
        }
    }

    void testLPStrBufferStringBuilder()
    {
        iCountTestCases++;
        if (!LPStrBuffer_In_StringBuilder(GetInvalidStringBuilder()))
        {
            Console.WriteLine("[Error] Location tcbsb11");
            iCountErrors++;
        }

        iCountTestCases++;
        if (!LPStrBuffer_In_StringBuilder(GetValidStringBuilder()))
        {
            Console.WriteLine("[Error] Location tcbsb22");
            iCountErrors++;
        }

        iCountTestCases++;
        StringBuilder cTemp = GetInvalidStringBuilder();
        StringBuilder cTempClone = cTemp;
        if (!LPStrBuffer_InByRef_StringBuilder(ref cTemp))
        {
            Console.WriteLine("[Error] Location tcbsb33");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetValidStringBuilder();
        cTempClone = cTemp;
        if (!LPStrBuffer_InByRef_StringBuilder(ref cTemp))
        {
            Console.WriteLine("[Error] Location tcbsb44");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetInvalidStringBuilder();
        cTempClone = cTemp;
        if (!LPStrBuffer_InOutByRef_StringBuilder(ref cTemp))
        {
            Console.WriteLine("[Error] Location tcbsb55");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetValidStringBuilder();
        cTempClone = cTemp;
        if (!LPStrBuffer_InOutByRef_StringBuilder(ref cTemp))
        {
            Console.WriteLine("[Error] Location tcbsb66");
            iCountErrors++;
        }
    }

    LPStrTestStruct GetInvalidStruct()
    {
        LPStrTestStruct inValidStruct = new LPStrTestStruct();
        inValidStruct.str = GetInvalidString();

        return inValidStruct;
    }


    LPStrTestStruct GetValidStruct()
    {
        LPStrTestStruct validStruct = new LPStrTestStruct();
        validStruct.str = GetValidString();

        return validStruct;
    }

    LPStrTestStruct_nothrow GetInvalidStruct_nothrow()
    {
        LPStrTestStruct_nothrow inValidStruct = new LPStrTestStruct_nothrow();
        inValidStruct.str = GetInvalidString();

        return inValidStruct;
    }


    LPStrTestStruct_nothrow GetValidStruct_nothrow()
    {
        LPStrTestStruct_nothrow validStruct = new LPStrTestStruct_nothrow();
        validStruct.str = GetValidString();

        return validStruct;
    }

    void testLPStrBufferStruct()
    {
        /// bug 127702
        iCountTestCases++;
        LPStrTestStruct_nothrow lpss_nt = GetInvalidStruct_nothrow();
        if (!LPStrBuffer_In_Struct_String_nothrow(lpss_nt))
        {
            Console.WriteLine("Error location ctlps11bb");
            iCountErrors++;
        }

        iCountTestCases++;
        lpss_nt = GetValidStruct_nothrow();
        if (!LPStrBuffer_In_Struct_String_nothrow(lpss_nt))
        {
            Console.WriteLine("Error location ctlps22bb");
            iCountErrors++;
        }

        ////
        iCountTestCases++;
        LPStrTestStruct lpss = GetInvalidStruct();
        if (!LPStrBuffer_In_Struct_String(lpss))
        {
            Console.WriteLine("Error location ctlps11");
            iCountErrors++;
        }

        iCountTestCases++;
        if (!LPStrBuffer_In_Struct_String(GetValidStruct()))
        {
            Console.WriteLine("Error location ctlps22");
            iCountErrors++;
        }

        iCountTestCases++;
        lpss = GetInvalidStruct();
        if (!LPStrBuffer_InByRef_Struct_String(ref lpss))
        {
            Console.WriteLine("Error location ctlps33");
            iCountErrors++;
        }

        iCountTestCases++;
        lpss = GetValidStruct();
        if (!LPStrBuffer_InByRef_Struct_String(ref lpss))
        {
            Console.WriteLine("Error location ctlps44");
            iCountErrors++;
        }

        iCountTestCases++;
        lpss = GetInvalidStruct();
        if (!LPStrBuffer_InOutByRef_Struct_String(ref lpss))
        {
            Console.WriteLine("Error location ctlps55");
            iCountErrors++;
        }

        iCountTestCases++;
        lpss = GetValidStruct();
        if (!LPStrBuffer_InOutByRef_Struct_String(ref lpss))
        {
            Console.WriteLine("Error location ctlps66");
            iCountErrors++;
        }
    }

    String[] GetValidArray()
    {
        String[] s = new String[3];

        s[0] = GetValidString();
        s[1] = GetValidString();
        s[2] = GetValidString();

        return s;
    }

    String[] GetInvalidArray()
    {
        String[] s = new String[3];

        s[0] = GetInvalidString();
        s[1] = GetInvalidString();
        s[2] = GetInvalidString();

        return s;
    }

    void testLPStrBufferArray()
    {
        iCountTestCases++;
        String[] s = GetInvalidArray();
        if (!LPStrBuffer_In_Array_String(s))
        {
            Console.WriteLine("Error location ctlpsa11");
            iCountErrors++;
        }

        iCountTestCases++;
        s = GetValidArray();
        if (!LPStrBuffer_In_Array_String(s))
        {
            Console.WriteLine("Error location ctlpsa22");
            iCountErrors++;
        }

        iCountTestCases++;
        s = GetInvalidArray();
        if (!LPStrBuffer_InByRef_Array_String(ref s))
        {
            Console.WriteLine("Error location ctlpsa33");
            iCountErrors++;
        }

        iCountTestCases++;
        s = GetValidArray();
        if (!LPStrBuffer_InByRef_Array_String(ref s))
        {
            Console.WriteLine("Error location ctlpsa44");
            iCountErrors++;
        }

        iCountTestCases++;
        s = GetInvalidArray();
        if (!LPStrBuffer_InOutByRef_Array_String(ref s))
        {
            Console.WriteLine("Error location ctlpsa55");
            iCountErrors++;
        }

        iCountTestCases++;
        s = GetValidArray();
        if (!LPStrBuffer_InOutByRef_Array_String(ref s))
        {
            Console.WriteLine("Error location ctlpsa66");
            iCountErrors++;
        }
    }

    void testLPStrBufferClass()
    {
        iCountTestCases++;
        LPStrTestClass sClass = new LPStrTestClass();
        sClass.str = GetInvalidString();
        if (!LPStrBuffer_In_Class_String(sClass))
        {
            Console.WriteLine("Error location tlpbc11");
            iCountErrors++;
        }

        iCountTestCases++;
        sClass.str = GetValidString();
        if (!LPStrBuffer_In_Class_String(sClass))
        {
            Console.WriteLine("Error location tlpbc22");
            iCountErrors++;
        }

        iCountTestCases++;
        sClass.str = GetInvalidString();
        if (!LPStrBuffer_InByRef_Class_String(ref sClass))
        {
            Console.WriteLine("Error location tlpbc33");
            iCountErrors++;
        }

        iCountTestCases++;
        sClass.str = GetValidString();
        if (!LPStrBuffer_InByRef_Class_String(ref sClass))
        {
            Console.WriteLine("Error location tlpbc44");
            iCountErrors++;
        }

        iCountTestCases++;
        sClass.str = GetInvalidString();
        if (!LPStrBuffer_InOutByRef_Class_String(ref sClass))
        {
            Console.WriteLine("Error location tlpbc55");
            iCountErrors++;
        }

        iCountTestCases++;
        sClass.str = GetValidString();
        if (!LPStrBuffer_InOutByRef_Class_String(ref sClass))
        {
            Console.WriteLine("Error location tlpbc66");
            iCountErrors++;
        }
    }

    void testLPStrBufferArrayOfStructs()
    {
        iCountTestCases++;
        LPStrTestStruct[] lpss = new LPStrTestStruct[2];
        lpss[0] = GetInvalidStruct();
        lpss[1] = GetInvalidStruct();

        if (!LPStrBuffer_In_Array_Struct(lpss))
        {
            Console.WriteLine("Error location ctlpsa11");
            iCountErrors++;
        }

        iCountTestCases++;
        lpss = new LPStrTestStruct[2];
        lpss[0] = GetValidStruct();
        lpss[1] = GetValidStruct();

        if (!LPStrBuffer_In_Array_Struct(lpss))
        {
            Console.WriteLine("Error location ctlpsa22");
            iCountErrors++;
        }

        iCountTestCases++;
        lpss = new LPStrTestStruct[2];
        lpss[0] = GetInvalidStruct();
        lpss[1] = GetInvalidStruct();
        if (!LPStrBuffer_InByRef_Array_Struct(ref lpss))
        {
            Console.WriteLine("Error location ctlpsa33");
            iCountErrors++;
        }

        iCountTestCases++;
        lpss = new LPStrTestStruct[2];
        lpss[0] = GetValidStruct();
        lpss[1] = GetValidStruct();

        if (!LPStrBuffer_InByRef_Array_Struct(ref lpss))
        {
            Console.WriteLine("Error location ctlpsa44");
            iCountErrors++;
        }

        iCountTestCases++;
        lpss = new LPStrTestStruct[2];
        lpss[0] = GetInvalidStruct();
        lpss[1] = GetInvalidStruct();

        if (!LPStrBuffer_InOutByRef_Array_Struct(ref lpss))
        {
            Console.WriteLine("Error location ctlpsa55");
            iCountErrors++;
        }

        iCountTestCases++;
        lpss = new LPStrTestStruct[2];
        lpss[0] = GetValidStruct();
        lpss[1] = GetValidStruct();

        if (!LPStrBuffer_InOutByRef_Array_Struct(ref lpss))
        {
            Console.WriteLine("Error location ctlpsa66");
            iCountErrors++;
        }
    }

    Boolean runTest()
    {
        testLPStrBufferString();

        testLPStrBufferStringBuilder();

        testLPStrBufferStruct();

        testLPStrBufferArray();

        testLPStrBufferClass();

        testLPStrBufferArrayOfStructs();

        if (iCountErrors > 0)
            return false;

        return true;
    }

    public static int Main()
    {
        if (System.Globalization.CultureInfo.CurrentCulture.Name != "en-US")
        {
            Console.WriteLine("Non english platforms are not supported");
            Console.WriteLine("passing without running tests");

            Console.WriteLine("--- Sucess");
            return 100;
        }

        Boolean bResult = false;
        BFM_LPStrMarshaler v = new BFM_LPStrMarshaler();

        try
        {
            bResult = v.runTest();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            bResult = false;
        }

        // ---------- Final Result --------------

        Console.WriteLine("iCountTestCases : " + iCountTestCases);
        Console.WriteLine("iCountErrors    : " + iCountErrors);

        if (iCountErrors > 0)
            bResult = false;

        if (bResult == true)
        {
            Console.WriteLine("--- Sucess");
            return 100;
        }
        else
        {
            Console.WriteLine("--- FAIL!!");
            return 11;
        }
    }
}