using System;
using System.Runtime.InteropServices;


public class SHTester
{
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


    static int failed = 0;
    public static int Main()
    {
        if (RunSHParamTests() == false)
        {
            Console.WriteLine("Test FAILED!");
            return 0;
        }

        if (RunSHStructParamTests() == false)
        {
            Console.WriteLine("Test FAILED!");
            return 0;
        }

        Console.WriteLine("Test PASSED!");
        return 100;
    }

    /// <summary>
    ///passing SH subclass parameters to unmanaged code in various combinations and forms;
    ///it uses the PInvoke signatures defined above it 
    ///1- passing SH subclass parameters individually in separate methods (In, out, ref)
    ///2- passing SH subclass parameters in combination in the same method
    /// </summary>
    public static bool RunSHParamTests()
    {
        Console.WriteLine("\nRunSHParamTests():");
        failed = 0;
        ///1- passing SH subclass parameters individually in separate methods (In, out, ref)
        //get a new SH
        SafeFileHandle hnd = Helper.NewSFH();
        Int32 hndInt32 = Helper.SHInt32(hnd); //get the 32-bit value associated with hnd

        Console.WriteLine("Testing SHParam_In...");
        SHParam_In(hnd, hndInt32);
        CheckCleanUp(hnd);

        SFH_NoCloseHandle hndout = Helper.NewSFH_NoCloseHandle(); //get a new value
        SafeHandle hnd_ref_backup = hndout;
        hndInt32 = Helper.SHInt32(hndout);
        Console.WriteLine("Testing SHParam_Ref...");
        SHParam_Ref(ref hndout, hndInt32);
        CheckCleanUp(hnd_ref_backup);

        ///2- passing SH subclass parameters in combination in the same method
        //initialize parameters
        SafeFileHandle hnd1 = Helper.NewSFH();
        Int32 hnd1Int32 = Helper.SHInt32(hnd1); //get the 32-bit value associated with hnd1

        SFH_NoCloseHandle hnd2 = null; //out parameter

        SFH_NoCloseHandle hnd3 = Helper.NewSFH_NoCloseHandle();
        SafeHandle hnd3_ref_backup = hnd3;
        Int32 hnd3Int32 = Helper.SHInt32(hnd3); //get the 32-bit value associated with hnd3

        Console.WriteLine("Testing SHParam_Multiple...");
        SHParam_Multiple(hnd1, out hnd2, ref hnd3, hnd1Int32, hnd3Int32);
        CheckCleanUp(hnd1);
        CheckCleanUp(hnd2);
        CheckCleanUp(hnd3_ref_backup);

        if (failed > 0)
        {
            Console.WriteLine(failed + " test cases are failed when pass as SafeFileHandle param");
            return false;
        }
        return true;
    }

    /// <summary>
    ///passing structures (with SH subclass fields) as parameters in various combinations and forms;
    ///it uses the PInvoke signatures defined above it
    ///1- passing structures (In, out, ref) (with SH subclass fields) individually in separate methods
    ///2- passing structures (In, out, ref) (with SH subclass fields) in combination in the same method
    /// </summary>
    public static bool RunSHStructParamTests()
    {
        Console.WriteLine("\nRunSHStructParamTests():");
        failed = 0;
        ///1- passing structures (In, out, ref) (with SH subclass fields) individually in separate methods
        ///
        ///

        //initialize a new StructWithSHFld
        StructWithSHFld s = new StructWithSHFld();
        s.hnd = Helper.NewSFH(); //get a new SH
        Int32 hndInt32 = Helper.SHInt32(s.hnd); //get the 32-bit value associated with s.hnd

        Console.WriteLine("Testing SHStructParam_In...");
        SHStructParam_In(s, hndInt32);
        CheckCleanUp(s.hnd);

        s.hnd = Helper.NewSFH(); //get a new SH
        SafeHandle hnd_ref_backup = s.hnd;
        hndInt32 = Helper.SHInt32(s.hnd); //get the 32-bit value associated with s.hnd
        Console.WriteLine("Testing SHStructParam_Ref1 (does not change value of handle field)...");
        SHStructParam_Ref1(ref s, hndInt32);
        CheckCleanUp(hnd_ref_backup);

        ///2- passing structures (In, out, ref) (with SH subclass fields) in combination in the same method
        ///
        ///
        //initialize parameters
        StructWithSHFld s1 = new StructWithSHFld();
        s1.hnd = Helper.NewSFH();
        Int32 hnd1Int32 = Helper.SHInt32(s1.hnd); //get the 32-bit value associated with s1.hnd

        StructWithSHFld s3 = new StructWithSHFld();
        s3.hnd = Helper.NewSFH();
        Int32 hnd3Int32 = Helper.SHInt32(s3.hnd); //get the 32-bit value associated with s3.hnd
        SafeHandle hnd3_ref_backup = s3.hnd;
        Console.WriteLine("Testing SHStructParam_Multiple2 (takes a ref struct as one of the params)...");
        SHStructParam_Multiple2(s1, ref s3, hnd1Int32, hnd3Int32);
        CheckCleanUp(s1.hnd);
        CheckCleanUp(hnd3_ref_backup);

        if (failed > 0)
        {
            Console.WriteLine(failed + " test cases are failed when pass as SafeFileHandle param");
            return false;
        }
        return true;
    }

    static void CheckCleanUp(SafeHandle hnd)
    {
        if (hnd.IsClosed)
        {
            Console.WriteLine("Failed: SafeFileHandle Closed before calling close");
            failed++;
        }
    }
}