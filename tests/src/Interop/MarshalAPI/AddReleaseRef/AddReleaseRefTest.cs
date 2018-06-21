using System;
using System.IO;
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using Windows.Foundation.Collections;
using TestTools = Test;

public class TestClass
{
    public int value;
    public string str;

    public TestClass()
    {
        value = int.MaxValue;
        str = "Test String";
    }

    public override string ToString()
    {
        return str + value;
    }
}

public class AddReleaseRefTest : Testcase
{
    private object[] TestObjects;

    private void AddReleaseRefTests()
    {
        try //Test for IntPtr.Zero
        {
            Marshal.AddRef(IntPtr.Zero);

            TestTools.ErrorWriteLine("Failed AddReleaseRef test.");
            TestTools.ErrorWriteLine("No exception from AddRef when passed IntPtr.Zero as parameter.");
        }
        catch (ArgumentNullException)
        {
            TestTools.InformationWriteLine("ArgumentNullException thrown by AddRef for IntPtr.Zero as expected.");
        }
        catch (Exception ex)
        {
            TestTools.ErrorWriteLine("Failed AddReleaseRef test.");
            TestTools.ErrorWriteLine("Exception occurred: {0}", ex);
        }

        try //Test for IntPtr.Zero
        {
            Marshal.Release(IntPtr.Zero);

            TestTools.ErrorWriteLine("Failed AddReleaseRef test.");
            TestTools.ErrorWriteLine("No exception from Release when passed IntPtr.Zero as parameter.");
        }
        catch (ArgumentNullException)
        {
            TestTools.InformationWriteLine("ArgumentNullException thrown by Release for IntPtr.Zero as expected.");
        }
        catch (Exception ex)
        {
            TestTools.ErrorWriteLine("Failed AddReleaseRef test.");
            TestTools.ErrorWriteLine("Unexpected Exception occurred: {0}", ex);
        }

        foreach (object obj in TestObjects)
        {
            IntPtr ptr = IntPtr.Zero;
            int refCount = 0; //This should keep a running tally of the current ref count
            int retValue = 0;

            try
            {
                ptr = Marshal.GetIUnknownForObject(obj);
                refCount = Marshal.AddRef(ptr); //Inintialize the refCount

                for (int i = 0; i < 10; i++)  //By the end of this loop we should have no additional refCount
                {
                    retValue = Marshal.AddRef(ptr);
                    if (++refCount != retValue)
                    {
                        TestTools.ErrorWriteLine("Failed AddReleaseRef test.");
                        TestTools.ErrorWriteLine("Unexpected ref count. Expected: " + refCount + ", Actual: " + retValue);
                    }

                    retValue = Marshal.Release(ptr);
                    if (--refCount != retValue)
                    {
                        TestTools.ErrorWriteLine("Failed AddReleaseRef test.");
                        TestTools.ErrorWriteLine("Unexpected ref count. Expected: " + refCount + ", Actual: " + retValue);
                    }
                }

                retValue = Marshal.Release(ptr); //This should negate the first AddRedf call before the loops
                if (--refCount != retValue)
                {
                    TestTools.ErrorWriteLine("Failed AddReleaseRef test.");
                    TestTools.ErrorWriteLine("Unexpected ref count. Expected: " + refCount + ", Actual: " + retValue);
                }

                retValue = Marshal.Release(ptr); //This should negate the GetIUnknownForObject call before the loops
                if (--refCount != retValue)
                {
                    TestTools.ErrorWriteLine("Failed AddReleaseRef test.");
                    TestTools.ErrorWriteLine("Unexpected ref count. Expected: " + refCount + ", Actual: " + retValue);
                }
            }
            catch (Exception ex)
            {
                TestTools.ErrorWriteLine("Failed AddReleaseRef test.");
                TestTools.ErrorWriteLine("Exception occurred: {0}", ex);
            }
        }
    }

    public override bool RunTests()
    {
        TestTools.BeginScenario("AddReleaseRef Tests");
        AddReleaseRefTests();

        TestTools.InformationWriteLine("Success so far: {0}", TestTools.Pass);

        return TestTools.Pass;
    }

    public override bool Initialize()
    {
        base.Initialize();

        TestObjects = new object[8];

        TestObjects[0] = 1;                             //int
        TestObjects[1] = 'a';                           //char
        TestObjects[2] = false;                         //bool
        TestObjects[3] = "string";                      //string
        TestObjects[4] = new TestClass();               //Object of type TestClass 
        TestObjects[5] = new List<int>();               //Projected Type
        TestObjects[6] = new Nullable<int>(2);          //Nullable Type
        TestObjects[7] = new PropertySet();             //RCW Type

        return Test.Pass;
    }

    public static int Main(String[] unusedArgs)
    {
        if (TestTools.Run(new AddReleaseRefTest()))
            return 100;

        return 99;
    }

}
