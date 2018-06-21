using System;
using System.Runtime.InteropServices;

public class SHTester_Misc
{
    public static int Main()
    {
        int retVal = 100;

        if (!RunSHMiscTests() || !RunChildSHParamTests() || !RunChildSHStructParamTests())
            retVal = 0;

        Console.WriteLine((retVal == 0) ? "FAILED!" : "PASSED!");
        return retVal;

    } //end of Main

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructArrayParam(StructWithSHFld[] arr, Int32[] arrInt32s, int length);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern SFH_NoCloseHandle SHReturn();

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructNestedParam(StructNestedParent sn, Int32 arrInt32s);

    [DllImport("PInvoke_SafeHandle")]
    public static extern bool SHMixedParam1(SafeHandle sh1, out SFH_NoCloseHandle sh2, ref ChildSFH_NoCloseHandle sh3, StructWithBaseSHFld s1,
        StructWithSHFld s2, ref StructWithChildSHFld s3, Int32 sh1Value, Int32 sh3Value, Int32 s1fldValue, Int32 s2fldValue, Int32 s3fldValue);

    [DllImport("PInvoke_SafeHandle")]
    public static extern bool SHStructWithManySHFldsParam_In(StructWithManySHFlds s, Int32[] arrInt32s);

    [DllImport("PInvoke_SafeHandle")]
    public static extern bool SHStructWithManySHFldsParam_Ref1(ref StructWithManySHFlds s, Int32[] arrInt32s);

    [DllImport("PInvoke_SafeHandle")]
    public static extern bool SHStructWithManySHFldsParam_Ref2(ref StructWithManySHFlds s, Int32[] arrInt32s);

    [DllImport(@"Interface\PInvoke_SafeHandle_MarshalAs_Interface.dll", CharSet = CharSet.Ansi)] //the MA attribute indicates that obj is to be marshaled as a VARIANT
    public static extern bool SHObjectParam([MarshalAs(UnmanagedType.Struct)]Object obj, Int32 shValue, Int32 shfld1Value, Int32 shfld2Value, String wrapper);

    [DllImport(@"Interface\PInvoke_SafeHandle_MarshalAs_Interface.dll", CharSet = CharSet.Ansi)]
    public static extern bool SHStructWithObjectFldParam(StructWithObjFld s, Int32 shValue, Int32 shfld1Value, Int32 shfld2Value, String objtype);

    /// <summary>
    ///runs all other miscellaneous tests;
    ///it uses the PInvoke signatures defined above it 
    ///1-passing arrays of SHs as parameters
    ///2-passing arrays of structures (with SH subclass fields) as parameters
    ///3-returning SHs from unmanaged code as pure return values
    ///4-returning structures (with SH subclass fields) from unmanaged code as pure return values
    ///5-passing nested structures (with the nested structure having a SH subclass field)
    ///6-passing structures with SH Array fields
    ///7-passing mixed params (SH, SH subclass, subclass of SH subclass)
    ///8-passing struct params that have many handle fields [in, ref (with and without changes to flds)]
    ///9-passing SH subclass in Dispatch\UnknownWrapper, expecting a VARIANT (of type VT_DISPATCH or
    ///VT_UNKNOWN) on the managed side; as params and as fields
    /// </summary>
    public static bool RunSHMiscTests()
    {
        Console.WriteLine("\nRunSHMiscTests():");

        SafeFileHandle[] hndArray = new SafeFileHandle[Helper.N];
        //the following array will contain the 32-bit values corresponding to hndArray's elements
        Int32[] hndArrayInt32s = new Int32[Helper.N];

        ///2-passing arrays of structures (with SH subclass fields) as parameters
        StructWithSHFld[] structArray = new StructWithSHFld[Helper.N];
        //the following array will contain the 32-bit values corresponding to structArray's elements
        Int32[] structArrayInt32s = new Int32[Helper.N];
        for (int i = 0; i < Helper.N; i++)
        {
            structArray[i] = new StructWithSHFld();
            structArray[i].hnd = Helper.NewSFH();
            structArrayInt32s[i] = Helper.SHInt32(structArray[i].hnd);
        }

        Console.WriteLine("Testing SHStructArrayParam...");
        SHStructArrayParam(structArray, structArrayInt32s, Helper.N);
        try
        {
            SHStructArrayParam(structArray, structArrayInt32s, Helper.N);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("\tCaught expected InvalidOperationException:\n\t\t " + e.ToString() + "\n");
        }

        ///3-returning SHs from unmanaged code as pure return values
        SFH_NoCloseHandle hnd;
        Console.WriteLine("Testing SHReturn...");
        hnd = SHReturn();
        if (!Helper.IsChanged(hnd))
        {
            Console.WriteLine("\tFAILED! SHReturn did not return hnd as expected.");
            return false;
        }

        ///5-passing nested structures (with the nested structure having a SH subclass field)
        StructNestedParent sn = new StructNestedParent();
        sn.snOneDeep = new StructNestedOneDeep();
        sn.snOneDeep.s = new StructWithSHFld();
        sn.snOneDeep.s.hnd = Helper.NewSFH();
        Int32 hndInt32 = Helper.SHInt32(sn.snOneDeep.s.hnd);
        Console.WriteLine("Testing SHStructNestedParam...");
        if (!SHStructNestedParam(sn, hndInt32))
        {
            Console.WriteLine("\tFAILED! SHStructNestedParam did not receive param as expected.");
            return false;
        }
        //check that the value of the HANDLE field did not change
        else if (Helper.IsChanged(sn.snOneDeep.s.hnd))
        {
            Console.WriteLine("\tFAILED! SHStructNestedParam did not return param as expected.");
            return false;
        }

        ///7-passing mixed params (SH, SH subclass, subclass of SH subclass)
        SafeHandle sh1 = Helper.NewSFH();
        SFH_NoCloseHandle sh2;
        ChildSFH_NoCloseHandle sh3 = Helper.NewChildSFH_NoCloseHandle();
        StructWithBaseSHFld s1 = new StructWithBaseSHFld(); s1.hnd = Helper.NewSFH();
        StructWithSHFld s2 = new StructWithSHFld(); s2.hnd = Helper.NewSFH();
        StructWithChildSHFld s3 = new StructWithChildSHFld(); s3.hnd = Helper.NewChildSFH();
        Int32 sh1Value = Helper.SHInt32(sh1);
        Int32 sh3Value = Helper.SHInt32(sh3);
        Int32 s1fldValue = Helper.SHInt32(s1.hnd);
        Int32 s2fldValue = Helper.SHInt32(s2.hnd);
        Int32 s3fldValue = Helper.SHInt32(s3.hnd);

        Console.WriteLine("Testing SHMixedParam1...");
        if (!SHMixedParam1(sh1, out sh2, ref sh3, s1, s2, ref s3, sh1Value, sh3Value, s1fldValue, s2fldValue, s3fldValue))
        {
            Console.WriteLine("\tFAILED! SHMixedParam1 did not receive params as expected.");
            return false;
        }
        //check the values after the call
        else if (Helper.IsChanged(sh1) || !Helper.IsChanged(sh2) || Helper.IsChanged(sh3) || Helper.IsChanged(s1.hnd) ||
                 Helper.IsChanged(s2.hnd) || Helper.IsChanged(s3.hnd))
        {
            Console.WriteLine("\tFAILED! SHMixedParam1 did not return params as expected.");
            return false;
        }

        ///8-passing struct params that have many handle fields [in, ref (with and without changes to flds)]

        //initialize a new StructWithManySHFlds
        Int32[] arrInt32s = null;
        StructWithManySHFlds s = Helper.NewStructWithManySHFlds(ref arrInt32s);

        Console.WriteLine("Testing SHStructWithManySHFldsParam_In...");
        if (!SHStructWithManySHFldsParam_In(s, arrInt32s))
        {
            Console.WriteLine("\tFAILED! SHStructWithManySHFldsaram_In did not receive param as expected.");
            return false;
        }
        //check that the value of the HANDLE fields did not change
        else if (Helper.IsChangedStructWithManySHFlds(s, arrInt32s))
        {
            Console.WriteLine("\tFAILED! SHStructWithManySHFldsParam_In did not return param as expected.");
            return false;
        }

        Console.WriteLine("Testing SHStructWithManySHFldsParam_Ref1...");
        if (!SHStructWithManySHFldsParam_Ref1(ref s, arrInt32s))
        {
            Console.WriteLine("\tFAILED! SHStructWithManySHFldsaram_Ref1 did not receive param as expected.");
            return false;
        }
        //check that the value of the HANDLE fields did not change
        else if (Helper.IsChangedStructWithManySHFlds(s, arrInt32s))
        {
            Console.WriteLine("\tFAILED! SHStructWithManySHFldsParam_Ref1 did not return param as expected.");
            return false;
        }


        Console.WriteLine("Testing SHStructWithManySHFldsParam_Ref2...");
        try
        {
            SHStructWithManySHFldsParam_Ref2(ref s, arrInt32s);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (System.NotSupportedException e)
        {
            Console.WriteLine("\tCaught expected NotSupportedException:\n\t\t " + e.ToString() + "\n");
        }

        ///9-passing SH subclass in Dispatch\UnknownWrapper, expecting a VARIANT (of type VT_DISPATCH or
        ///VT_UNKNOWN) on the managed side
        SafeFileHandle sfh = Helper.NewSFH(); //SafeFileHandle
        sfh.shfld1 = Helper.NewSFH();
        sfh.shfld2 = Helper.NewSFH();
        Int32 shValue = Helper.SHInt32(sfh);
        Int32 shfld1Value = Helper.SHInt32(sfh.shfld1);
        Int32 shfld2Value = Helper.SHInt32(sfh.shfld2);

        SafeFileHandle sfh2 = Helper.NewSFH(); //SafeFileHandle
        sfh2.shfld1 = Helper.NewSFH();
        sfh2.shfld2 = Helper.NewSFH();
        Int32 sh2Value = Helper.SHInt32(sfh2);
        Int32 sh2fld1Value = Helper.SHInt32(sfh2.shfld1);
        Int32 sh2fld2Value = Helper.SHInt32(sfh2.shfld2);

        //re-initialize
        sfh = Helper.NewSFH(); //SafeFileHandle
        sfh.shfld1 = Helper.NewSFH();
        sfh.shfld2 = Helper.NewSFH();
        shValue = Helper.SHInt32(sfh);
        shfld1Value = Helper.SHInt32(sfh.shfld1);
        shfld2Value = Helper.SHInt32(sfh.shfld2);
        String sfhstr = "SafeFileHandle";

        Console.WriteLine("Testing SHObjectParam with SFH...");
        try
        {
            SHObjectParam(sfh, shValue, shfld1Value, shfld2Value, sfhstr);
            Console.WriteLine("\tNo Exception Thrown! FAILED!");
            return false;
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine("\tCaught Expected ArgumentException:\n\t\t" + ae.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("\tCaught UNEXPECTED Exception:\n\t\t" + e.ToString());
            return false;
        }

        //re-initialize SH's that will be wrapped for the structure fields
        sfh = Helper.NewSFH(); //SafeFileHandle
        sfh.shfld1 = Helper.NewSFH();
        sfh.shfld2 = Helper.NewSFH();
        shValue = Helper.SHInt32(sfh);
        shfld1Value = Helper.SHInt32(sfh.shfld1);
        shfld2Value = Helper.SHInt32(sfh.shfld2);

        sfh2 = Helper.NewSFH(); //SafeFileHandle
        sfh2.shfld1 = Helper.NewSFH();
        sfh2.shfld2 = Helper.NewSFH();
        sh2Value = Helper.SHInt32(sfh2);
        sh2fld1Value = Helper.SHInt32(sfh2.shfld1);
        sh2fld2Value = Helper.SHInt32(sfh2.shfld2);

        //re-initialize
        sfh = Helper.NewSFH(); //SafeFileHandle
        sfh.shfld1 = Helper.NewSFH();
        sfh.shfld2 = Helper.NewSFH();
        shValue = Helper.SHInt32(sfh);
        shfld1Value = Helper.SHInt32(sfh.shfld1);
        shfld2Value = Helper.SHInt32(sfh.shfld2);

        StructWithObjFld sWithSFHFld = new StructWithObjFld();
        sWithSFHFld.obj = sfh;

        Console.WriteLine("Testing SHStructWithObjectFldParam with sWithSFHFld...");
        try
        {
            SHStructWithObjectFldParam(sWithSFHFld, shValue, shfld1Value, shfld2Value, sfhstr);
            Console.WriteLine("\tNo Exception Thrown! FAILED!");
            return false;
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine("\tCaught Expected ArgumentException:\n\t\t" + ae.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("\tCaught UNEXPECTED Exception:\n\t\t" + e.ToString());
            return false;
        }

        return true;
    } //end of RunSHMiscTests

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHParam_In([In]ChildSafeFileHandle sh1, Int32 sh1Value);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHParam_Out(out ChildSFH_NoCloseHandle sh1);

    [DllImport("PInvoke_SafeHandle", PreserveSig = false, SetLastError = true)]
    public static extern ChildSFH_NoCloseHandle SHParam_OutRetVal();

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHParam_Ref(ref ChildSFH_NoCloseHandle sh1, Int32 sh1Value);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHParam_Multiple([In]ChildSafeFileHandle sh1, out ChildSFH_NoCloseHandle sh2, ref ChildSFH_NoCloseHandle sh3, Int32 sh1Value, Int32 sh3Value);

    /// <summary>
    ///passing SafeFileHandle subclass parameters to unmanaged code in various combinations and forms;
    ///it uses the PInvoke signatures defined above it 
    ///1-passing SafeFileHandle subclass parameters individually in separate methods (In, out, ref)
    ///2-passing SafeFileHandle subclass parameters in combination in the same method
    /// </summary>
    public static bool RunChildSHParamTests()
    {
        Console.WriteLine("\nRunChildSHParamTests():");

        ///1-passing SafeFileHandle subclass parameters individually in separate methods (In, out, ref)
        ///
        ///

        //get a new SH
        ChildSafeFileHandle hnd = Helper.NewChildSFH();
        Int32 hndInt32 = Helper.SHInt32(hnd); //get the 32-bit value associated with hnd

        Console.WriteLine("Testing SHParam_In...");
        if (!SHParam_In(hnd, hndInt32))
        {
            Console.WriteLine("\tFAILED! SHParam_In did not receive hnd as expected.");
            return false;
        }
        //check that the value of the HANDLE did not change
        else if (Helper.IsChanged(hnd))
        {
            Console.WriteLine("\tFAILED! SHParam_In did not return hnd as expected.");
            return false;
        }

        Console.WriteLine("Testing SHParam_Out...");
        ChildSFH_NoCloseHandle hndout;
        SHParam_Out(out hndout);
        //check that the value of the HANDLE changed
        if (!Helper.IsChanged(hndout))
        {
            Console.WriteLine("\tFAILED! SHParam_Out did not return hndout as expected.");
            Console.WriteLine("\thndout = " + Helper.SHInt32(hndout));
            return false;
        }

        Console.WriteLine("Testing SHParam_OutRetVal...");
        hndout = null;
        hndout = SHParam_OutRetVal();
        //check that the value of the HANDLE changed
        if (!Helper.IsChanged(hndout))
        {
            Console.WriteLine("\tFAILED! SHParam_OutRetVal did not return hndout as expected.");
            return false;
        }

        hndout = Helper.NewChildSFH_NoCloseHandle(); //get a new value
        hndInt32 = Helper.SHInt32(hndout);
        Console.WriteLine("Testing SHParam_Ref...");
        if (!SHParam_Ref(ref hndout, hndInt32))
        {
            Console.WriteLine("\tFAILED! SHParam_Ref did not receive hndout as expected.");
            return false;
        }
        //check that the value of the HANDLE changed
        else if (!Helper.IsChanged(hndout))
        {
            Console.WriteLine("\tFAILED! SHParam_Ref did not return hndout as expected.");
            return false;
        }

        ///2-passing SafeFileHandle subclass parameters in combination in the same method
        ///
        ///
        //initialize parameters
        ChildSafeFileHandle hnd1 = Helper.NewChildSFH();
        Int32 hnd1Int32 = Helper.SHInt32(hnd1); //get the 32-bit value associated with hnd1

        ChildSFH_NoCloseHandle hnd2 = null; //out parameter

        ChildSFH_NoCloseHandle hnd3 = Helper.NewChildSFH_NoCloseHandle();
        Int32 hnd3Int32 = Helper.SHInt32(hnd3); //get the 32-bit value associated with hnd3

        Console.WriteLine("Testing SHParam_Multiple...");
        if (!SHParam_Multiple(hnd1, out hnd2, ref hnd3, hnd1Int32, hnd3Int32))
        {
            Console.WriteLine("\tFAILED! SHParam_Multiple did not receive parameter(s) as expected.");
            return false;
        }
        //check that the value of the HANDLES are as expected
        else if (Helper.IsChanged(hnd1) || !Helper.IsChanged(hnd2) || !Helper.IsChanged(hnd3))
        {
            Console.WriteLine("\tFAILED! SHParam_Multiple did not return handles as expected.");
            return false;
        }

        return true;
    } //end of static method RunChildSHParamTests

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_In([In]StructWithChildSHFld s, Int32 shfldValue);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Out(out StructWithChildSHFld s);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Ref1(ref StructWithChildSHFld s, Int32 shfldValue);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Ref2(ref StructWithChildSHFld s, Int32 shfldValue);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Multiple1([In]StructWithChildSHFld sh1, out StructWithChildSHFld sh2,
        ref StructWithChildSHFld sh3, Int32 sh1fldValue, Int32 sh2fldValue);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Multiple2([In]StructWithChildSHFld sh1, ref StructWithChildSHFld sh2, Int32 sh1fldValue, Int32 sh2fldValue);

    [DllImport("PInvoke_SafeHandle", SetLastError = true)]
    public static extern bool SHStructParam_Multiple3([In]StructWithChildSHFld sh1, ref StructWithChildSHFld sh2, Int32 sh1fldValue, Int32 sh2fldValue);

    /// <summary>
    ///passing structures (with SafeFileHandle subclass fields) as parameters in various combinations and forms;
    ///it uses the PInvoke signatures defined above it
    ///1-passing structures (In, out, ref) (with SafeFileHandle subclass fields) individually in separate methods
    ///2-passing structures (In, out, ref) (with SafeFileHandle subclass fields) in combination in the same method
    /// </summary>
    public static bool RunChildSHStructParamTests()
    {
        Console.WriteLine("\nRunChildSHStructParamTests():");

        ///1-passing structures (In, out, ref) (with SafeFileHandle subclass fields) individually in separate methods
        ///
        ///

        //initialize a new StructWithChildSHFld
        StructWithChildSHFld s = new StructWithChildSHFld();
        s.hnd = Helper.NewChildSFH(); //get a new SH
        Int32 hndInt32 = Helper.SHInt32(s.hnd); //get the 32-bit value associated with s.hnd

        Console.WriteLine("Testing SHStructParam_In...");
        if (!SHStructParam_In(s, hndInt32))
        {
            Console.WriteLine("\tFAILED! SHStructParam_In did not receive param as expected.");
            return false;
        }
        //check that the value of the HANDLE field did not change
        else if (Helper.IsChanged(s.hnd))
        {
            Console.WriteLine("\tFAILED! SHStructParam_In did not return param as expected.");
            return false;
        }

        Console.WriteLine("Testing SHStructParam_Out...");
        try
        {
            SHStructParam_Out(out s);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (System.NotSupportedException e)
        {
            Console.WriteLine("\tCaught expected NotSupportedException:\n\t\t " + e.ToString() + "\n");
        }

        s.hnd = Helper.NewChildSFH(); //get a new SH
        hndInt32 = Helper.SHInt32(s.hnd); //get the 32-bit value associated with s.hnd
        Console.WriteLine("Testing SHStructParam_Ref1 (does not change value of handle field)...");
        if (!SHStructParam_Ref1(ref s, hndInt32))
        {
            Console.WriteLine("\tFAILED! SHStructParam_Ref1 did not receive param as expected.");
            return false;
        }
        //check that the value of the HANDLE field is not changed
        else if (Helper.IsChanged(s.hnd))
        {
            Console.WriteLine("\tFAILED! SHStructParam_Ref1 did not return param as expected.");
            return false;
        }

        Console.WriteLine("Testing SHStructParam_Ref2 (does change value of handle field)...");
        try
        {
            SHStructParam_Ref2(ref s, hndInt32);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (System.NotSupportedException e)
        {
            Console.WriteLine("\tCaught expected NotSupportedException:\n\t\t " + e.ToString() + "\n");
        }

        ///2-passing structures (In, out, ref) (with SafeFileHandle subclass fields) in combination in the same method
        ///
        ///
        //initialize parameters
        StructWithChildSHFld s1 = new StructWithChildSHFld();
        s1.hnd = Helper.NewChildSFH();
        Int32 hnd1Int32 = Helper.SHInt32(s1.hnd); //get the 32-bit value associated with s1.hnd

        StructWithChildSHFld s2; //out parameter

        StructWithChildSHFld s3 = new StructWithChildSHFld();
        s3.hnd = Helper.NewChildSFH();
        Int32 hnd3Int32 = Helper.SHInt32(s3.hnd); //get the 32-bit value associated with s3.hnd

        Console.WriteLine("Testing SHStructParam_Multiple1 (takes an out struct as one of the params and so is expected to result in an exception)...");
        try
        {
            SHStructParam_Multiple1(s1, out s2, ref s3, hnd1Int32, hnd3Int32);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (System.NotSupportedException e)
        {
            Console.WriteLine("\tCaught expected NotSupportedException:\n\t\t " + e.ToString() + "\n");
        }

        s3.hnd = Helper.NewChildSFH();
        hnd3Int32 = Helper.SHInt32(s3.hnd); //get the 32-bit value associated with s3.hnd
        Console.WriteLine("Testing SHStructParam_Multiple2 (takes a ref struct as one of the params)...");
        if (!SHStructParam_Multiple2(s1, ref s3, hnd1Int32, hnd3Int32))
        {
            Console.WriteLine("\tFAILED! SHStructParam_Multiple2 did not receive parameter(s) as expected.");
            return false;
        }
        //check that the value of the HANDLES are as expected
        else if (Helper.IsChanged(s1.hnd) || Helper.IsChanged(s3.hnd))
        {
            Console.WriteLine("\tFAILED! SHStructParam_Multiple2 did not return handles as expected.");
            return false;
        }

        Console.WriteLine("Testing SHStructParam_Multiple3 (takes a ref struct as one of the params and changes it and so is expected to result in an exception)...");
        try
        {
            SHStructParam_Multiple3(s1, ref s3, hnd1Int32, hnd3Int32);
            Console.WriteLine("\tFAILED!  Exception not thrown.");
            return false;
        }
        catch (System.NotSupportedException e)
        {
            Console.WriteLine("\tCaught expected NotSupportedException:\n\t\t " + e.ToString() + "\n");
        }

        return true;
    }
}