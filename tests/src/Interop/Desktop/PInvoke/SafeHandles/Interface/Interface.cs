using System;
using System.Runtime.InteropServices;
using System.Threading;

[StructLayout(LayoutKind.Sequential)]
public struct StructMAIntf
{
    [MarshalAs(UnmanagedType.Interface)]
    public SafeFileHandle hnd;
}

public class SHtoIntfTester
{
    public static int Main()
    {
        int retVal = 100;

        ///////////////////////////////////Tests/////////////////////////////////////

        if (!RunTests())
            retVal = 0;

        /////////////////////////////////////////////////////////////////////////////

        Console.WriteLine((retVal == 0) ? "\nTEST FAILED!" : "\nTEST PASSED!");
        return retVal;

    } //end of Main

    [DllImport("PInvoke_SafeHandle_MarshalAs_Interface")]
    public static extern bool SH_MAIntf([MarshalAs(UnmanagedType.Interface)]SafeFileHandle sh, Int32 shVal, Int32 shfld1Val, Int32 shfld2Val);

    [DllImport("PInvoke_SafeHandle_MarshalAs_Interface")]
    public static extern bool SH_MAIntf_Ref([MarshalAs(UnmanagedType.Interface)]ref SafeFileHandle sh, Int32 shVal, Int32 shfld1Val, Int32 shfld2Val);

    [DllImport("PInvoke_SafeHandle_MarshalAs_Interface")]
    public static extern bool SHFld_MAIntf(StructMAIntf s, Int32 shndVal, Int32 shfld1Val, Int32 shfld2Val);

    public static bool RunTests()
    {
        Console.WriteLine("\nRunTests():");

        ////////////////////////////////////////////////////////
        SafeFileHandle sh = Helper.NewSFH();
        Int32 shVal = Helper.SHInt32(sh);
        sh.shfld1 = Helper.NewSFH(); //SH field of SFH class
        Int32 shfld1Val = Helper.SHInt32(sh.shfld1);
        sh.shfld2 = Helper.NewSFH(); //SFH field of SFH class
        Int32 shfld2Val = Helper.SHInt32(sh.shfld2);

        //NOTE: SafeHandle is now ComVisible(false)...QIs for IDispatch or the class interface on a 
        //    type with a ComVisible(false) type in its hierarchy are no longer allowed; so calling 
        //    the DW ctor with a SH subclass causes an invalidoperationexception to be thrown since
        //    the ctor QIs for IDispatch
        try
        {
            Console.WriteLine("Testing SH_MAIntf...");
            /*
            if( !SH_MAIntf(sh, shVal, shfld1Val, shfld2Val) )
                return false;
            else if( !IsCertified(sh, shVal) )
            {
                Console.WriteLine("Changes to sh could not be certified---method did not return sh as expected!");
                return false;
            }
            else
                Console.WriteLine("Call completed successfully.");
            */
            SH_MAIntf(sh, shVal, shfld1Val, shfld2Val);
            Console.WriteLine("Did NOT THROW InvalidOperationException! FAILED!");
            return false;
        }
        catch (InvalidOperationException ioe)
        {
            string expectedMsg = "This type has a ComVisible(false) parent in its hierarchy, therefore QueryInterface calls for IDispatch or class interfaces are disallowed.";
            if (System.Globalization.CultureInfo.CurrentCulture.Name == "en-US")
            {
                if (ioe.Message != expectedMsg)
                {
                    Console.WriteLine("Exception message not as expected! FAILED!");
                    Console.WriteLine("Expected message = " + expectedMsg);
                    Console.WriteLine("Actual message = " + ioe.Message);
                }
            }
        }

        ////////////////////////////////////////////////////////
        sh = Helper.NewSFH();
        shVal = Helper.SHInt32(sh);
        sh.shfld1 = Helper.NewSFH(); //SH field of SFH class
        shfld1Val = Helper.SHInt32(sh.shfld1);
        sh.shfld2 = Helper.NewSFH(); //SFH field of SFH class
        shfld2Val = Helper.SHInt32(sh.shfld2);

        //NOTE: SafeHandle is now ComVisible(false)...QIs for IDispatch or the class interface on a 
        //    type with a ComVisible(false) type in its hierarchy are no longer allowed; so calling 
        //    the DW ctor with a SH subclass causes an invalidoperationexception to be thrown since
        //    the ctor QIs for IDispatch
        try
        {
            Console.WriteLine("Testing SH_MAIntf_Ref...");
            /*
            if( !SH_MAIntf_Ref(ref sh, shVal, shfld1Val, shfld2Val) )
                return false;
            else if( !IsCertified(sh, shVal) )
            {
                Console.WriteLine("Changes to sh could not be certified---method did not return sh as expected!");
                return false;
            }
            else
                Console.WriteLine("Call completed successfully.");
            */
            SH_MAIntf_Ref(ref sh, shVal, shfld1Val, shfld2Val);
            Console.WriteLine("Did NOT THROW InvalidOperationException! FAILED!");
            return false;
        }
        catch (InvalidOperationException ioe)
        {
            string expectedMsg = "This type has a ComVisible(false) parent in its hierarchy, therefore QueryInterface calls for IDispatch or class interfaces are disallowed.";
            if (System.Globalization.CultureInfo.CurrentCulture.Name == "en-US")
            {
                if (ioe.Message != expectedMsg)
                {
                    Console.WriteLine("Exception message not as expected! FAILED!");
                    Console.WriteLine("Expected message = " + expectedMsg);
                    Console.WriteLine("Actual message = " + ioe.Message);
                }
            }
        }

        ////////////////////////////////////////////////////////
        StructMAIntf s = new StructMAIntf();
        s.hnd = Helper.NewSFH();
        Int32 shndVal = Helper.SHInt32(s.hnd);
        s.hnd.shfld1 = Helper.NewSFH(); //SH field of SFH field of struct
        shfld1Val = Helper.SHInt32(s.hnd.shfld1);
        s.hnd.shfld2 = Helper.NewSFH(); //SFH field of SFH field of struct
        shfld2Val = Helper.SHInt32(s.hnd.shfld2);

        //NOTE: SafeHandle is now ComVisible(false)...QIs for IDispatch or the class interface on a 
        //    type with a ComVisible(false) type in its hierarchy are no longer allowed; so calling 
        //    the DW ctor with a SH subclass causes an invalidoperationexception to be thrown since
        //    the ctor QIs for IDispatch
        try
        {
            Console.WriteLine("Testing SHFld_MAIntf...");
            /*
            if( !SHFld_MAIntf(s, shndVal, shfld1Val, shfld2Val) )
                return false;
            else if( !IsCertified(s.hnd, shndVal) )
            {
                Console.WriteLine("Changes to s.hnd could not be certified---method did not return struct as expected!");
                return false;
            }
            else
                Console.WriteLine("Call completed successfully.");
            */
            SHFld_MAIntf(s, shndVal, shfld1Val, shfld2Val);
            Console.WriteLine("Did NOT THROW InvalidOperationException! FAILED!");
            return false;
        }
        catch (InvalidOperationException ioe)
        {
            string expectedMsg = "This type has a ComVisible(false) parent in its hierarchy, therefore QueryInterface calls for IDispatch or class interfaces are disallowed.";
            if (System.Globalization.CultureInfo.CurrentCulture.Name == "en-US")
            {
                if (ioe.Message != expectedMsg)
                {
                    Console.WriteLine("Exception message not as expected! FAILED!");
                    Console.WriteLine("Expected message = " + expectedMsg);
                    Console.WriteLine("Actual message = " + ioe.Message);
                }
            }
        }

        return true;
    } //end of RunSHFldInvalidMATests

    public static bool IsCertified(SafeFileHandle sh, Int32 shVal)
    {
        //sh should be closed
        if (!sh.IsClosed)
        {
            Console.WriteLine("The SafeFileHandle is still open.");
            return false;
        }
        //  NOTE: DangerousGetHandle (which is called by Helper.SHInt32) now (as of a 3/4/03 System\Runtime\InteropServices\SafeHandle.cs checkin) 
        //      does NOT throw if the handle is closed; there was a time when it did and this try/catch was to test that code path
        /*  else {
                try
                {
                    Helper.SHInt32(sh);
                    Console.WriteLine("Did NOT throw exception!");
                    return false;
                }
                catch( InvalidOperationException ie )
                {
                    Console.WriteLine("Caught expected exception: \n\t" + ie.ToString());
                }
                catch( Exception e )
                {
                    Console.WriteLine("Caught UNexpected exception: \n\t" + e.ToString());
                    return false;
                }
            }
          */
        else
        {
            if (Helper.SHInt32(sh) != shVal)
            {
                Console.WriteLine("Helper.SHInt32(sh) != shVal");
                Console.WriteLine("Helper.SHInt32(sh) = " + Helper.SHInt32(sh));
                return false;
            }
        }

        return true;
    }
}