using System;
using System.IO;
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Windows.Foundation.Collections;
using TestTools = Test;

public class ReleaseComObjectTest : Testcase
{
    private void ReleaseComObjectTests()
    {
        try //Test for null
        {
            Marshal.ReleaseComObject(null);

            TestTools.ErrorWriteLine("Failed ReleaseComObject test.");
            TestTools.ErrorWriteLine("No exception from ReleaseComObject when passed null as parameter.");
        }
        catch (ArgumentNullException)
        {
            // ProjectN
            TestTools.InformationWriteLine("ArgumentNullException thrown by ReleaseComObject for null as expected.");
        }
        catch (NullReferenceException)
        {
            // Desktop CLR behavior (test must pass both ProjectN and Desktop CLR behaviors)
            TestTools.InformationWriteLine("NullReferenceException thrown by ReleaseComObject for null as expected.");
        }
        catch (Exception ex)
        {
            TestTools.ErrorWriteLine("Failed ReleaseComObject test.");
            TestTools.ErrorWriteLine("Exception occurred: {0}", ex);
        }

        try //Test for non-COM object
        {
            Marshal.ReleaseComObject(new object());

            TestTools.ErrorWriteLine("Failed ReleaseComObject test.");
            TestTools.ErrorWriteLine("No exception from ReleaseComObject when passed non-COM object as parameter.");
        }
        catch (ArgumentException)
        {
            TestTools.InformationWriteLine("ArgumentException thrown by ReleaseComObject for non-COM object as expected.");
        }
        catch (Exception ex)
        {
            TestTools.ErrorWriteLine("Failed ReleaseComObject test.");
            TestTools.ErrorWriteLine("Unexpected Exception occurred: {0}", ex);
        }

        int retValue;

        try
        {
            PropertySet propertySet = new PropertySet(); //Create an RCW associated with COM object

            retValue = Marshal.ReleaseComObject(propertySet);

            //Since we typyically only keep one RCW for one object
            //Marshal.ReleaseComObject should have returned 0
            if (retValue != 0)
            {
                TestTools.ErrorWriteLine("Failed ReleaseComObject test.");
                TestTools.ErrorWriteLine("Ref count returned from ReleaseComObject is not zero. RefCount: " + retValue);
            }

            //This should result in an Exception
            int count = propertySet.Count;

            TestTools.ErrorWriteLine("Failed ReleaseComObject test.");
            TestTools.ErrorWriteLine("No exception when accessing an object already released by ReleaseComObject.");
        }
        catch (InvalidComObjectException)
        {
            TestTools.InformationWriteLine("InvalidComObjectException thrown for accessing an object already released by ReleaseComObject as expected.");
        }
        catch (Exception ex)
        {
            TestTools.ErrorWriteLine("Failed ReleaseComObject test.");
            TestTools.ErrorWriteLine("Exception occurred: {0}", ex);
        }
    }

    private void FinalReleaseComObjectTests()
    {
        try //Test for null
        {
            Marshal.FinalReleaseComObject(null);

            TestTools.ErrorWriteLine("Failed FinalReleaseComObject test.");
            TestTools.ErrorWriteLine("No exception from FinalReleaseComObject when passed null as parameter.");
        }
        catch (ArgumentNullException)
        {
            TestTools.InformationWriteLine("ArgumentNullException thrown by FinalReleaseComObject for null as expected.");
        }
        catch (Exception ex)
        {
            TestTools.ErrorWriteLine("Failed FinalReleaseComObject test.");
            TestTools.ErrorWriteLine("Exception occurred: {0}", ex);
        }

        try //Test for non-COM object
        {
            Marshal.FinalReleaseComObject(new object());

            TestTools.ErrorWriteLine("Failed FinalReleaseComObject test.");
            TestTools.ErrorWriteLine("No exception from FinalReleaseComObject when passed non-COM object as parameter.");
        }
        catch (ArgumentException)
        {
            TestTools.InformationWriteLine("ArgumentException thrown by FinalReleaseComObject for non-COM object as expected.");
        }
        catch (Exception ex)
        {
            TestTools.ErrorWriteLine("Failed FinalReleaseComObject test.");
            TestTools.ErrorWriteLine("Unexpected Exception occurred: {0}", ex);
        }

        int retValue;

        //TODO: Add a scenario where RCW count is more than 1

        try
        {
            PropertySet propertySet = new PropertySet(); //Create an RCW associated with COM object

            retValue = Marshal.FinalReleaseComObject(propertySet);

            //Marshal.FinalReleaseComObject always returns 0 if it succeeds
            if (retValue != 0)
            {
                TestTools.ErrorWriteLine("Failed FinalReleaseComObject test.");
                TestTools.ErrorWriteLine("Ref count returned from FinalReleaseComObject is not zero. RefCount: " + retValue);
            }

            //This should result in an Exception
            int count = propertySet.Count;

            TestTools.ErrorWriteLine("Failed FinalReleaseComObject test.");
            TestTools.ErrorWriteLine("No exception when accessing an object already released by FinalReleaseComObject.");
        }
        catch (InvalidComObjectException)
        {
            TestTools.InformationWriteLine("InvalidComObjectException thrown for accessing an object already released by FinalReleaseComObject as expected.");
        }
        catch (Exception ex)
        {
            TestTools.ErrorWriteLine("Failed FinalReleaseComObject test.");
            TestTools.ErrorWriteLine("Exception occurred: {0}", ex);
        }
    }
    
    public override bool RunTests()
    {
        TestTools.BeginScenario("ReleaseComObject Tests");
        ReleaseComObjectTests();

        TestTools.InformationWriteLine("Success so far: {0}", TestTools.Pass);

        TestTools.BeginScenario("FinalReleaseComObject Tests");
        FinalReleaseComObjectTests();

        TestTools.InformationWriteLine("Success so far: {0}", TestTools.Pass);

        return TestTools.Pass;
    }

    public static int Main(String[] unusedArgs)
    {
        if (TestTools.Run(new ReleaseComObjectTest()))
            return 100;

        return 99;
    }

}
