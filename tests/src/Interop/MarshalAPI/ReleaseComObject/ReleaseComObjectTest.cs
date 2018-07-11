using System;
using System.IO;
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using CoreFXTestLibrary;

public class ReleaseComObjectTest
{
    private void ReleaseComObjectTests()
    {
        try //Test for null
        {
            Marshal.ReleaseComObject(null);
            Assert.Fail("Failed ReleaseComObject test. No exception from ReleaseComObject when passed null as parameter.");
        }
        catch (ArgumentNullException)
        {
            // ProjectN
        }
        catch (NullReferenceException)
        {
            // Desktop CLR behavior (test must pass both ProjectN and Desktop CLR behaviors)
        }

        try //Test for non-COM object
        {
            Marshal.ReleaseComObject(new object());
            Assert.Fail("Failed ReleaseComObject test. No exception from ReleaseComObject when passed non-COM object as parameter.");
        }
        catch (ArgumentException)
        {

        }
    }

    private void FinalReleaseComObjectTests()
    {
        try //Test for null
        {
            Marshal.FinalReleaseComObject(null);
            Assert.Fail("Failed ReleaseComObject test. No exception from FinalReleaseComObject when passed null as parameter.");
        }
        catch (ArgumentNullException)
        {

        }

        try //Test for non-COM object
        {
            Marshal.FinalReleaseComObject(new object());
            Assert.Fail("Failed ReleaseComObject test. No exception from FinalReleaseComObject when passed non-COM object as parameter.");
        }
        catch (ArgumentException)
        {

        }
    }
    
    public void RunTests()
    {
        ReleaseComObjectTests();
        FinalReleaseComObjectTests();
    }

    public static int Main(String[] unusedArgs)
    {
        try
        {
            new ReleaseComObjectTest().RunTests();
        }
        catch (Exception e)
        {
            Console.WriteLine("Test failure: " + e.Message);
            return 101;
        }

        return 100;
    }

}
