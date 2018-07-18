﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text;
using System.Runtime.InteropServices;

[assembly: BestFitMapping(true, ThrowOnUnmappableChar = false)]

public class BFM_CharMarshaler
{
    static int iCountErrors = 0;
    static int iCountTestCases = 0;

    [DllImport("Char_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = false)]
    public static extern bool Char_In([In]char c);

    [DllImport("Char_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = false)]
    public static extern bool Char_InByRef([In]ref char c);

    [DllImport("Char_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = false)]
    public static extern bool Char_InOutByRef([In, Out]ref char c);

    [DllImport("Char_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = false)]
    public static extern bool CharBuffer_In_String([In]String s);

    [DllImport("Char_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = false)]
    public static extern bool CharBuffer_InByRef_String([In]ref String s);

    [DllImport("Char_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = false)]
    public static extern bool CharBuffer_InOutByRef_String([In, Out]ref String s);

    [DllImport("Char_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = false)]
    public static extern bool CharBuffer_In_StringBuilder([In]StringBuilder s);

    [DllImport("Char_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = false)]
    public static extern bool CharBuffer_InByRef_StringBuilder([In]ref StringBuilder s);

    [DllImport("Char_BestFitMappingNative", BestFitMapping = true, ThrowOnUnmappableChar = false)]
    public static extern bool CharBuffer_InOutByRef_StringBuilder([In, Out]ref StringBuilder s);

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
        sbl.Append('乀');
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
        sbl.Append('乀');
        return sbl;
    }

    char GetInvalidChar()
    {
        return (char)0x2216;
    }

    char GetValidChar()
    {
        return 'c';
    }

    void testChar()
    {
        iCountTestCases++;
        if (!Char_In(GetInvalidChar()))
        {
            Console.WriteLine("[Error] Location tc11");
            iCountErrors++;
        }

        iCountTestCases++;
        if (!Char_In(GetValidChar()))
        {
            Console.WriteLine("[Error] Location tc22");
            iCountErrors++;
        }

        iCountTestCases++;
        char cTemp = GetInvalidChar();
        char cTempClone = cTemp;
        if (!Char_InByRef(ref cTemp))
        {
            Console.WriteLine("[Error] Location tc33");
            iCountErrors++;
        }
        if (cTemp != cTempClone)
        {
            Console.WriteLine("[Error] Location tc44");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetValidChar();
        cTempClone = cTemp;
        if (!Char_InByRef(ref cTemp))
        {
            Console.WriteLine("[Error] Location tc55");
            iCountErrors++;
        }
        if (cTemp != cTempClone)
        {
            Console.WriteLine("[Error] Location tc66");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetInvalidChar();
        cTempClone = cTemp;
        if (!Char_InOutByRef(ref cTemp))
        {
            Console.WriteLine("[Error] Location tc77");
            iCountErrors++;
        }
        if (cTemp == cTempClone)
        {
            Console.WriteLine("[Error] Location tc88");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetValidChar();
        cTempClone = cTemp;
        if (!Char_InOutByRef(ref cTemp))
        {
            Console.WriteLine("[Error] Location tc99");
            iCountErrors++;
        }
        if (cTemp != cTempClone)
        {
            Console.WriteLine("[Error] Location tc1100");
            iCountErrors++;
        }
    }

    void testCharBufferString()
    {
        iCountTestCases++;
        if (!CharBuffer_In_String(GetInvalidString()))
        {
            Console.WriteLine("Error location b111");
            iCountErrors++;
        }

        iCountTestCases++;
        if (!CharBuffer_In_String(GetValidString()))
        {
            Console.WriteLine("Error location b222");
            iCountErrors++;
        }

        iCountTestCases++;
        String cTemp = GetInvalidString();
        String cTempClone = cTemp;
        if (!CharBuffer_InByRef_String(ref cTemp))
        {
            Console.WriteLine("Error location b333");
            iCountErrors++;
        }
        if (cTemp != cTempClone)
        {
            Console.WriteLine("Error location b444");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetValidString();
        cTempClone = cTemp;
        if (!CharBuffer_InByRef_String(ref cTemp))
        {
            Console.WriteLine("Error location b555");
            iCountErrors++;
        }
        if (cTemp != cTempClone)
        {
            Console.WriteLine("Error location b666");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetInvalidString();
        cTempClone = cTemp;
        if (!CharBuffer_InOutByRef_String(ref cTemp))
        {
            Console.WriteLine("Error location b777");
            iCountErrors++;
        }
        if (cTemp == cTempClone)
        {
            Console.WriteLine("Error location b888");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetValidString();
        cTempClone = cTemp;
        if (!CharBuffer_InOutByRef_String(ref cTemp))
        {
            Console.WriteLine("Error location b999");
            iCountErrors++;
        }
        if (cTemp != cTempClone)
        {
            Console.WriteLine("Error location b123");
            iCountErrors++;
        }
    }

    void testCharBufferStringBuilder()
    {
        iCountTestCases++;
        if (!CharBuffer_In_StringBuilder(GetInvalidStringBuilder()))
        {
            Console.WriteLine("Error location c111");
            iCountErrors++;
        }

        iCountTestCases++;
        if (!CharBuffer_In_StringBuilder(GetValidStringBuilder()))
        {
            Console.WriteLine("Error location c222");
            iCountErrors++;
        }

        iCountTestCases++;
        StringBuilder cTemp = GetInvalidStringBuilder();
        StringBuilder cTempClone = cTemp;
        if (!CharBuffer_InByRef_StringBuilder(ref cTemp))
        {
            Console.WriteLine("Error location c333");
            iCountErrors++;
        }
        if (cTemp.ToString() != cTempClone.ToString())
        {
            Console.WriteLine("Error location c444");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetValidStringBuilder();
        cTempClone = cTemp;
        if (!CharBuffer_InByRef_StringBuilder(ref cTemp))
        {
            Console.WriteLine("Error location c555");
            iCountErrors++;
        }
        if (cTemp.ToString() != cTempClone.ToString())
        {
            Console.WriteLine("Error location c666");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetInvalidStringBuilder();
        cTempClone = cTemp;
        if (!CharBuffer_InOutByRef_StringBuilder(ref cTemp))
        {
            Console.WriteLine("Error location c777");
            iCountErrors++;
        }
        if (cTemp.ToString() == cTempClone.ToString())
        {
            Console.WriteLine("Error location c888");
            iCountErrors++;
        }

        iCountTestCases++;
        cTemp = GetValidStringBuilder();
        cTempClone = cTemp;
        if (!CharBuffer_InOutByRef_StringBuilder(ref cTemp))
        {
            Console.WriteLine("Error location c999");
            iCountErrors++;
        }
        if (cTemp.ToString() != cTempClone.ToString())
        {
            Console.WriteLine("Error location c123");
            iCountErrors++;
        }
    }

    Boolean runTest()
    {
        testChar();

        testCharBufferString();

        testCharBufferStringBuilder();

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
        BFM_CharMarshaler v = new BFM_CharMarshaler();

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