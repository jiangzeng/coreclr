using System;
using System.Runtime.InteropServices;


public class SHTester
{
    public static int Main()
    {
        RunSHParamTests();
        RunSHStructParamTests();

        if (TestHelper.Pass)
        {
            Console.WriteLine("Passed!");
            return 100;
        }
        else
        {
            Console.WriteLine("Failed");
            return 101;
        }
    }

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHParam_In([In]SafeFileHandle sh1, Int32 sh1Value);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHParam_Out(out SFH_NoCloseHandle sh1);

    [DllImport("PInvoke_SafeHandle", PreserveSig = false, SetLastError = true)]
    public static extern SFH_NoCloseHandle SHParam_OutRetVal();

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHParam_Ref(ref SFH_NoCloseHandle sh1, Int32 sh1Value);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHParam_Multiple([In]SafeFileHandle sh1, out SFH_NoCloseHandle sh2, ref SFH_NoCloseHandle sh3, Int32 sh1Value, Int32 sh3Value);

    /// <summary>
    ///passing SH subclass parameters to unmanaged code in various combinations and forms;
    ///it uses the PInvoke signatures defined above it 
    ///1-	passing SH subclass parameters individually in separate methods (In, out, ref)
    ///2-	passing SH subclass parameters in combination in the same method
    /// </summary>
    public static void RunSHParamTests()
    {
        TestHelper.BeginSubScenario("SHParam_In");
        SafeFileHandle hnd = Helper.NewSFH();    //get a new SH
        Int32 hndInt32 = Helper.SHInt32(hnd); //get the 32-bit value associated with hnd
        TestHelper.Assert(SHParam_In(hnd, hndInt32), "SHParam_In did not receive hnd as expected");
        TestHelper.Assert(!Helper.IsChanged(hnd), "SHParam_In did not return hnd as expected.");

        TestHelper.BeginSubScenario("SHParam_Out");
        SFH_NoCloseHandle hndout;
        SHParam_Out(out hndout);
        TestHelper.Assert(Helper.IsChanged(hndout), "SHParam_Out did not return hndout as expected. hndout = " + Helper.SHInt32(hndout));

        TestHelper.BeginSubScenario("SHParam_OutRetVal");
        hndout = null;
        hndout = SHParam_OutRetVal();
        TestHelper.Assert(Helper.IsChanged(hndout), "SHParam_OutRetVal did not return hndout as expected.");

        TestHelper.BeginSubScenario("SHParam_Ref");
        hndout = Helper.NewSFH_NoCloseHandle(); //get a new value
        hndInt32 = Helper.SHInt32(hndout);
        TestHelper.Assert(SHParam_Ref(ref hndout, hndInt32), "SHParam_Ref did not receive hndout as expected");
        TestHelper.Assert(Helper.IsChanged(hndout), "SHParam_Ref did not return hndout as expected.");

        TestHelper.BeginSubScenario("SHParam_Multiple");
        SafeFileHandle hnd1 = Helper.NewSFH();
        Int32 hnd1Int32 = Helper.SHInt32(hnd1); //get the 32-bit value associated with hnd1
        SFH_NoCloseHandle hnd2 = null; //out parameter
        SFH_NoCloseHandle hnd3 = Helper.NewSFH_NoCloseHandle();
        Int32 hnd3Int32 = Helper.SHInt32(hnd3); //get the 32-bit value associated with hnd3

        TestHelper.Assert(SHParam_Multiple(hnd1, out hnd2, ref hnd3, hnd1Int32, hnd3Int32), "SHParam_Multiple did not receive parameter(s) as expected.");

        TestHelper.Assert(Helper.IsChanged(hnd2), "HParam_Multiple did not return hnd2 as expected.");
        TestHelper.Assert(Helper.IsChanged(hnd3), "HParam_Multiple did not return hnd3 as expected.");
    }


    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_In([In]StructWithSHFld s, Int32 shfldValue);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Out(out StructWithSHFld s);

    [DllImport("PInvoke_SafeHandle", PreserveSig = false, SetLastError = true)]
    public static extern StructWithSHFld SHStructParam_OutRetVal();

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Ref1(ref StructWithSHFld s, Int32 shfldValue);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Ref2(ref StructWithSHFld s, Int32 shfldValue);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Multiple1([In]StructWithSHFld sh1, out StructWithSHFld sh2, ref StructWithSHFld sh3, Int32 sh1fldValue, Int32 sh2fldValue);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Multiple2([In]StructWithSHFld sh1, ref StructWithSHFld sh2, Int32 sh1fldValue, Int32 sh2fldValue);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Multiple3([In]StructWithSHFld sh1, ref StructWithSHFld sh2, Int32 sh1fldValue, Int32 sh2fldValue);

    /// <summary>
    ///passing structures (with SH subclass fields) as parameters in various combinations and forms;
    ///it uses the PInvoke signatures defined above it
    ///1-	passing structures (In, out, ref) (with SH subclass fields) individually in separate methods
    ///2-	passing structures (In, out, ref) (with SH subclass fields) in combination in the same method
    /// </summary>
    public static void RunSHStructParamTests()
    {
        Console.WriteLine("\nRunSHStructParamTests():");

        TestHelper.BeginSubScenario("SHStructParam_In");
        StructWithSHFld s = new StructWithSHFld();//initialize a new StructWithSHFld
        s.hnd = Helper.NewSFH(); //get a new SH
        Int32 hndInt32 = Helper.SHInt32(s.hnd); //get the 32-bit value associated with s.hnd
        TestHelper.Assert(SHStructParam_In(s, hndInt32), "SHStructParam_In did not receive param as expected.");
        TestHelper.Assert(!Helper.IsChanged(s.hnd), "SHStructParam_In did not return param as expected.");//check that the value of the HANDLE field did not change

        TestHelper.BeginSubScenario("SHStructParam_Out");
        TestHelper.AssertException(typeof(System.NotSupportedException), () => { SHStructParam_Out(out s); }, "SHStructParam_Out");

        TestHelper.BeginSubScenario("SHStructParam_OutRetVal");
        //mangling the unmanaged signature and returning the structure should cause this exception since PInvoke does not support returning
        //non-blittable value classes
        TestHelper.AssertException(typeof(MarshalDirectiveException), () => { SHStructParam_OutRetVal(); }, "SHStructParam_OutRetVal");

        TestHelper.BeginSubScenario("SHStructParam_Ref1"); //Testing SHStructParam_Ref1 (does not change value of handle field)
        s.hnd = Helper.NewSFH(); //get a new SH
        hndInt32 = Helper.SHInt32(s.hnd); //get the 32-bit value associated with s.hnd
        TestHelper.Assert(SHStructParam_Ref1(ref s, hndInt32), "SHStructParam_Ref1 did not receive param as expected.");
        TestHelper.Assert(!Helper.IsChanged(s.hnd), "SHStructParam_Ref1 did not return param as expected."); //check that the value of the HANDLE field is not changed

        TestHelper.BeginSubScenario("SHStructParam_Ref2");
        TestHelper.AssertException(typeof(System.NotSupportedException), () => { SHStructParam_Ref2(ref s, hndInt32); }, "SHStructParam_Ref2");
        ///
        ///2-   passing structures (In, out, ref) (with SH subclass fields) in combination in the same method
        ///

        StructWithSHFld s1 = new StructWithSHFld();//initialize parameters
        s1.hnd = Helper.NewSFH();
        Int32 hnd1Int32 = Helper.SHInt32(s1.hnd); //get the 32-bit value associated with s1.hnd

        StructWithSHFld s2; //out parameter

        StructWithSHFld s3 = new StructWithSHFld();
        s3.hnd = Helper.NewSFH();
        Int32 hnd3Int32 = Helper.SHInt32(s3.hnd); //get the 32-bit value associated with s3.hnd

        TestHelper.BeginSubScenario("SHStructParam_Multiple1: takes an out struct as one of the params and so is expected to result in an exception");
        TestHelper.AssertException(typeof(System.NotSupportedException),
            () => { SHStructParam_Multiple1(s1, out s2, ref s3, hnd1Int32, hnd3Int32); }, "SHStructParam_Multiple1");

        TestHelper.BeginSubScenario("SHStructParam_Multiple2:takes a ref struct as one of the params");
        s3.hnd = Helper.NewSFH();
        hnd3Int32 = Helper.SHInt32(s3.hnd); //get the 32-bit value associated with s3.hnd
        TestHelper.Assert(SHStructParam_Multiple2(s1, ref s3, hnd1Int32, hnd3Int32), "SHStructParam_Multiple2 did not receive parameter(s) as expected.");
        TestHelper.Assert(!Helper.IsChanged(s1.hnd), "SHStructParam_Multiple2 did not return s1.hnd as expected.");
        TestHelper.Assert(!Helper.IsChanged(s3.hnd), "SHStructParam_Multiple2 did not return s3.hnd as expected.");

        TestHelper.BeginSubScenario("SHStructParam_Multiple3:takes a ref struct as one of the params aand changes its handle field and so is expected to result in an exception");
        TestHelper.AssertException(typeof(System.NotSupportedException), () => { SHStructParam_Multiple3(s1, ref s3, hnd1Int32, hnd3Int32); }, "SHStructParam_Multiple3");
    }
}