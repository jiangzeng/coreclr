﻿//The testcase focus test the BStr with embed null string

#define WIN8P //Disable LCIDConversionAttribute not supported in Win8P, we are still getting PreserveSig and SetLastError coverage

using System.Runtime.InteropServices;
using System;
using System.Reflection;
using System.Text;
using CoreFXTestLibrary;

class LCIDTest
{
#if !WIN8P

    [DllImport(@"LCIDNative.dll", EntryPoint = "Marshal_InOut1")]
    [LCIDConversionAttribute(0)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    private static extern StringBuilder MarshalStrB_InOut1([In, Out][MarshalAs(UnmanagedType.LPStr)]StringBuilder s);

    [DllImport(@"LCIDNative.dll", EntryPoint = "Marshal_InOut2")]
    [LCIDConversionAttribute(1)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    private static extern StringBuilder MarshalStrB_InOut2([In, Out][MarshalAs(UnmanagedType.LPStr)]StringBuilder s);

    [DllImport(@"LCIDNative.dll", EntryPoint = "Marshal_InOut2", SetLastError = true)]
    [LCIDConversionAttribute(1)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    private static extern StringBuilder MarshalStrB_InOut3([In, Out][MarshalAs(UnmanagedType.LPStr)]StringBuilder s);

    [DllImport(@"LCIDNative.dll", EntryPoint = "Marshal_InOut4", PreserveSig = false, SetLastError = true)]
    [LCIDConversionAttribute(1)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    private static extern StringBuilder MarshalStrB_InOut4([In, Out][MarshalAs(UnmanagedType.LPStr)]StringBuilder s);

#else

    [DllImport(@"LCIDNative.dll", EntryPoint = "Marshal_InOut1")]
    [return: MarshalAs(UnmanagedType.LPStr)]
    private static extern StringBuilder MarshalStrB_InOut1([In][MarshalAs(UnmanagedType.I4)]int lcid, [In, Out][MarshalAs(UnmanagedType.LPStr)]StringBuilder s);

    [DllImport(@"LCIDNative.dll", EntryPoint = "Marshal_InOut2")]
    [return: MarshalAs(UnmanagedType.LPStr)]
    private static extern StringBuilder MarshalStrB_InOut2([In, Out][MarshalAs(UnmanagedType.LPStr)]StringBuilder s, [In][MarshalAs(UnmanagedType.I4)]int lcid);

    [DllImport(@"LCIDNative.dll", EntryPoint = "Marshal_InOut2", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    private static extern StringBuilder MarshalStrB_InOut3([In, Out][MarshalAs(UnmanagedType.LPStr)]StringBuilder s, [In][MarshalAs(UnmanagedType.I4)]int lcid);

    [DllImport(@"LCIDNative.dll", EntryPoint = "Marshal_InOut4", PreserveSig = false, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    private static extern StringBuilder MarshalStrB_InOut4([In, Out][MarshalAs(UnmanagedType.LPStr)]StringBuilder s, [In][MarshalAs(UnmanagedType.I4)]int lcid);

#endif

    //LCID as first argument
    static void Scenario1()
    {
        string strManaged = "Managed";
        string strRet = "a";
        StringBuilder expectedStrRet = new StringBuilder("a", 1);
        string strNative = " Native";
        StringBuilder strBNative = new StringBuilder(" Native", 7);

        StringBuilder strPara1 = new StringBuilder(strManaged, strManaged.Length);
#if !WIN8P
        StringBuilder strRet1 = MarshalStrB_InOut1(strPara1);
#else
        StringBuilder strRet1 = MarshalStrB_InOut1(0, strPara1);
#endif

        Assert.AreEqual(expectedStrRet.ToString(), strRet1.ToString(), "Method MarshalStrB_InOut1[Managed Side],The Return string is wrong");
        Assert.AreEqual(strBNative.ToString(), strPara1.ToString(), "Method MarshalStrB_InOut1[Managed Side],The Passed string is wrong");
    }

    //LCID as last argument
    static void Scenario2()
    {
        string strManaged = "Managed";
        string strRet = "a";
        StringBuilder expectedStrRet = new StringBuilder("a", 1);
        string strNative = " Native";
        StringBuilder strBNative = new StringBuilder(" Native", 7);

        StringBuilder strPara2 = new StringBuilder(strManaged, strManaged.Length);
#if !WIN8P
        StringBuilder strRet2 = MarshalStrB_InOut2(strPara2);
#else
        StringBuilder strRet2 = MarshalStrB_InOut2(strPara2, 0);
#endif

        Assert.AreEqual(expectedStrRet.ToString(), strRet2.ToString(), "Method MarshalStrB_InOut2[Managed Side],The Return string is wrong");
        Assert.AreEqual(strBNative.ToString(), strPara2.ToString(), "Method MarshalStrB_InOut2[Managed Side],The Passed string is wrong");

        //Verify that error value is set.
        int result = Marshal.GetLastWin32Error();
        Assert.AreEqual(0, result, "MarshalStrB_InOut2: GetLasterror returned wrong error code");
    }

    //SetLastError =true
    static void Scearnio3()
    {
        string strManaged = "Managed";
        string strRet = "a";
        StringBuilder expectedStrRet = new StringBuilder("a", 1);
        string strNative = " Native";
        StringBuilder strBNative = new StringBuilder(" Native", 7);

        StringBuilder strPara3 = new StringBuilder(strManaged, strManaged.Length);
#if !WIN8P
        StringBuilder strRet3 = MarshalStrB_InOut3(strPara3);
#else
        StringBuilder strRet3 = MarshalStrB_InOut3(strPara3, 0);
#endif

        Assert.AreEqual(expectedStrRet.ToString(), strRet3.ToString(), "Method MarshalStrB_InOut3[Managed Side],The Return string is wrong");
        Assert.AreEqual(strBNative.ToString(), strPara3.ToString(), "Method MarshalStrB_InOut3[Managed Side],The Passed string is wrong");

        //Verify that error value is set
        int result = Marshal.GetLastWin32Error();
        Assert.AreEqual(1090, result, "MarshalStrB_InOut3 : GetLasterror returned wrong error code");

    }

    //PreserveSig = false, SetLastError = true
    static void Scenario4()
    {
        string strManaged = "Managed";
        string strRet = "a";
        StringBuilder expectedStrRet = new StringBuilder("a", 1);
        string strNative = " Native";
        StringBuilder strBNative = new StringBuilder(" Native", 7);

        StringBuilder strPara4 = new StringBuilder(strManaged, strManaged.Length);
#if !WIN8P
        StringBuilder strRet4 = MarshalStrB_InOut4(strPara4);
#else
        StringBuilder strRet4 = MarshalStrB_InOut4(strPara4, 0);
#endif

        Assert.AreEqual(expectedStrRet.ToString(), strRet4.ToString(), "Method MarshalStrB_InOut4[Managed Side],The Return string is wrong");
        Assert.AreEqual(strBNative.ToString(), strPara4.ToString(), "Method MarshalStrB_InOut4[Managed Side],The Passed string is wrong");

        //Verify that error value is set
        int result = Marshal.GetLastWin32Error();
        Assert.AreEqual(1090, result, "MarshalStrB_InOut4 : GetLasterror returned wrong error code");
    }

    public static int Main(string[] args)
    {
        try
        {
            //LCID as first argument
            Scenario1();
            //LCID as last argument
            Scenario2();
            //SetLastError =true
            Scearnio3();
            //PreserveSig = false, SetLastError = true
            Scenario4();

            return 100;
        }
        catch (Exception e)
        {
            Console.WriteLine("Test failure: " + e.Message);
            return 101;
        }
    }
}
