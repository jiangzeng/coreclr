using System;
using System.Text;
using System.Runtime.InteropServices;


[StructLayout(LayoutKind.Sequential)]
public struct Stru_Seq_DateAsStructAsFld
{
    [MarshalAs(UnmanagedType.Struct)]
    public DateTime dt;

    public int iInt;

    [MarshalAs(UnmanagedType.BStr)]
    public string bstr;
}

[StructLayout(LayoutKind.Explicit)]
public struct Stru_Exp_DateAsStructAsFld
{

    [FieldOffset(0)]
    public int iInt;

    [FieldOffset(8)]
    [MarshalAs(UnmanagedType.Struct)]
    public DateTime dt;
}

class DatetimeTest
{
    private static DateTime ExpectedRetdate;

    #region Helper

    static int fails = 0;
    static int ReportFailure(string s)
    {
        Console.WriteLine(" === Fail:" + s);
        return (++fails);
    }

    #endregion

    #region PInvoke
    [DllImport("PInvoke_DateTime_NativeServer.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern bool Marshal_In_stdcall([In][MarshalAs(UnmanagedType.Struct)] DateTime t);

    [DllImport("PInvoke_DateTime_NativeServer.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool Marshal_InOut_cdecl([In, Out][MarshalAs(UnmanagedType.Struct)] ref DateTime t);

    [DllImport("PInvoke_DateTime_NativeServer.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern bool Marshal_Out_stdcall([Out][MarshalAs(UnmanagedType.Struct)] out DateTime t);

    [DllImport("PInvoke_DateTime_NativeServer.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool MarshalSeqStruct_InOut_cdecl([In, Out][MarshalAs(UnmanagedType.Struct)] ref Stru_Seq_DateAsStructAsFld t);

    [DllImport("PInvoke_DateTime_NativeServer.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool MarshalExpStruct_InOut_cdecl([In, Out][MarshalAs(UnmanagedType.Struct)] ref Stru_Exp_DateAsStructAsFld t);
    #endregion

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate bool Del_Marshal_InOut_cdecl([In, Out][MarshalAs(UnmanagedType.Struct)] ref DateTime t);

#if NOTSUPPORTED 
    //BUG 735119
    #region delegatePinvoke

    [DllImport("PInvoke_DateTime_NativeServer.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.FunctionPtr)]
    private static extern Del_Marshal_InOut_cdecl GetDel_Marshal_InOut_cdecl();

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    delegate bool Del_Marshal_Out_stdcall([Out][MarshalAs(UnmanagedType.Struct)] out DateTime t);

    [DllImport("PInvoke_DateTime_NativeServer.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern Del_Marshal_Out_stdcall GetDel_Marshal_Out_stdcall();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate bool Del_MarshalSeqStruct_InOut_cdecl([In, Out][MarshalAs(UnmanagedType.Struct)] ref Stru_Seq_DateAsStructAsFld t);

    [DllImport("PInvoke_DateTime_NativeServer.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern Del_MarshalSeqStruct_InOut_cdecl GetDel_Del_MarshalSeqStruct_InOut_cdecl();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate bool Del_MarshalExpStruct_InOut_cdecl([In, Out][MarshalAs(UnmanagedType.Struct)] ref Stru_Exp_DateAsStructAsFld t);

    [DllImport("PInvoke_DateTime_NativeServer.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern Del_MarshalExpStruct_InOut_cdecl GetDel_Del_MarshalExpStruct_InOut_cdecl();

    #endregion
#endif

    #region ReversePInvoke

    [DllImport("PInvoke_DateTime_NativeServer.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool RevP_Marshal_InOut_cdecl(Del_Marshal_InOut_cdecl d);


    public static bool RevPMethod_Marshal_InOut_cdecl(ref DateTime d)
    {
        ExpectedRetdate = new DateTime(1947, 8, 15);
        if (!d.Equals(ExpectedRetdate))
        {
            ReportFailure("RevPMethod_Marshal_InOut_cdecl : Date didn't match to expected date\n");
            return false;
        }
        d = d.AddDays(-1);
        return true;
    }

    #endregion

    static int Main(string[] args)
    {
        ExpectedRetdate = new DateTime(1947, 8, 15);

        #region Pinvoke

        DateTime Date1 = new DateTime(2008, 7, 4);
        if (!Marshal_In_stdcall(Date1))
        {
            ReportFailure("Marshal_In_stdcall : Returned false\n");
        }

        if (!Marshal_InOut_cdecl(ref Date1))
        {
            ReportFailure("Marshal_InOut_cdecl : Returned false\n");
        }
        if (!Date1.Equals(ExpectedRetdate))
        {
            ReportFailure("Marshal_InOut_cdecl : Returned date is wrong\n");
        }

        DateTime Date2;
        if (!Marshal_Out_stdcall(out Date2))
        {
            ReportFailure("Marshal_In_stdcall : Returned false\n");
        }
        if (!Date2.Equals(ExpectedRetdate))
        {
            ReportFailure("Marshal_InOut_cdecl : Returned date is wrong\n");
        }

        Stru_Seq_DateAsStructAsFld StDate1;
        StDate1.dt = new DateTime(2008, 7, 4);
        StDate1.iInt = 100;
        StDate1.bstr = "Managed";

        if (!MarshalSeqStruct_InOut_cdecl(ref StDate1))
        {
            ReportFailure("MarshalSeqStruct_InOut_cdecl : Native side check failed\n");
        }

        //Veify the changes
        if (!(StDate1.dt).Equals(ExpectedRetdate))
        {
            ReportFailure("MarshalSeqStruct_InOut_cdecl : Returned date is wrong\n");
        }

        Stru_Exp_DateAsStructAsFld StDate2;
        StDate2.dt = new DateTime(2008, 7, 4);
        StDate2.iInt = 100;

        if (!MarshalExpStruct_InOut_cdecl(ref StDate2))
        {
            ReportFailure("MarshalExpStruct_InOut_cdecl : Native side check failed\n");
        }

        //Veify the changes
        if (!(StDate2.dt).Equals(ExpectedRetdate))
        {
            ReportFailure("MarshalExpStruct_InOut_cdecl : Returned date is wrong\n");
        }
        #endregion

        #region DelegatePInvoke
#if NOTSUPPORTED
        //BUG 735119
        Del_Marshal_InOut_cdecl del1 = GetDel_Marshal_InOut_cdecl();

        DateTime Date4 = new DateTime(2008, 7, 4);
        if (!del1(ref Date4))
        {
            ReportFailure("GetDel_Marshal_InOut_cdecl : Returned false\n");
        }
        if (!Date4.Equals(ExpectedRetdate))
        {
            ReportFailure("GetDel_Marshal_InOut_cdecl : Returned date is wrong\n");
        }

        Del_Marshal_Out_stdcall del3 = GetDel_Marshal_Out_stdcall();

        DateTime Date6;
        if (!del3(out Date6))
        {
            ReportFailure("GetDel_Marshal_Out_stdcall : Returned false\n");
        }
        if (!Date6.Equals(ExpectedRetdate))
        {
            ReportFailure("GetDel_Marshal_Out_stdcall : Returned date is wrong\n");
        }
        Stru_Seq_DateAsStructAsFld StDate3;
        StDate3.dt = new DateTime(2008, 7, 4);
        StDate3.iInt = 100;
        StDate3.bstr = "Managed";

        Del_MarshalSeqStruct_InOut_cdecl del4 = GetDel_Del_MarshalSeqStruct_InOut_cdecl();

        if (!del4(ref StDate3))
        {
            ReportFailure("MarshalSeqStruct_InOut_cdecl : Native side check failed\n");
        }

        //Veify the changes
        if (!(StDate3.dt).Equals(ExpectedRetdate))
        {
            ReportFailure("MarshalSeqStruct_InOut_cdecl : Returned date is wrong\n");
        }

        Stru_Exp_DateAsStructAsFld StDate4;
        StDate4.dt = new DateTime(2008, 7, 4);
        StDate4.iInt = 100;

        Del_MarshalExpStruct_InOut_cdecl del5 = GetDel_Del_MarshalExpStruct_InOut_cdecl();

        if (!del5(ref StDate4))
        {
            ReportFailure("MarshalExpStruct_InOut_cdecl : Native side check failed\n");
        }

        //Veify the changes
        if (!(StDate4.dt).Equals(ExpectedRetdate))
        {
            ReportFailure("MarshalExpStruct_InOut_cdecl : Returned date is wrong\n");
        }
#endif
        #endregion

        #region ReversePInvoke
        if (!RevP_Marshal_InOut_cdecl(new Del_Marshal_InOut_cdecl(RevPMethod_Marshal_InOut_cdecl)))
        {
            ReportFailure("RevP_Marshal_InOut_cdecl : Returned false\n");
        }
        #endregion


        if (fails > 0)
        {
            Console.WriteLine("Test Failed \n");
            return 101;
        }
        else
        {
            Console.WriteLine("Test Passed \n");
            return 100;
        }

    }
}

