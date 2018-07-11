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
            Console.WriteLine("ArgumentNullException thrown by ReleaseComObject for null as expected.");
        }
        catch (NullReferenceException)
        {
            // Desktop CLR behavior (test must pass both ProjectN and Desktop CLR behaviors)
            Console.WriteLine("NullReferenceException thrown by ReleaseComObject for null as expected.");
        }
        catch (Exception ex)
        {
            Assert.Fail("Failed ReleaseComObject test. Unexpected Exception occurred from ReleaseComObject when passed null as parameter: {0}", ex);
        }

        try //Test for non-COM object
        {
            Marshal.ReleaseComObject(new object());

            Assert.Fail("Failed ReleaseComObject test. No exception from ReleaseComObject when passed non-COM object as parameter.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ArgumentException thrown by ReleaseComObject for non-COM object as expected.");
        }
        catch (Exception ex)
        {
            Assert.Fail("Failed ReleaseComObject test. Unexpected Exception occurred from ReleaseComObject when passed non-COM object as parameter: {0}", ex);
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
            Console.WriteLine("ArgumentNullException thrown by FinalReleaseComObject for null as expected.");
        }
        catch (Exception ex)
        {
            Assert.Fail("Failed ReleaseComObject test. Unexpected Exception occurred from FinalReleaseComObject when passed null as parameter: {0}", ex);
        }

        try //Test for non-COM object
        {
            Marshal.FinalReleaseComObject(new object());
            Assert.Fail("Failed ReleaseComObject test. No exception from FinalReleaseComObject when passed non-COM object as parameter.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ArgumentException thrown by FinalReleaseComObject for non-COM object as expected.");
        }
        catch (Exception ex)
        {
            Assert.Fail("Failed ReleaseComObject test. Unexpected Exception occurred from FinalReleaseComObject when passed non-COM object as parameter: {0}", ex);
        }
    }
    
    public void RunTests()
    {
        Console.WriteLine("ReleaseComObject Tests");
        ReleaseComObjectTests();

        Console.WriteLine("FinalReleaseComObject Tests");
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
