using System;
using System.IO;
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using CoreFXTestLibrary;

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

public class AddReleaseRefTest
{
    private object[] TestObjects;

    private void AddReleaseRefTests()
    {
        try //Test for IntPtr.Zero
        {
            Marshal.AddRef(IntPtr.Zero);
            Assert.Fail("Failed AddReleaseRef test. No exception from AddRef when passed IntPtr.Zero as parameter.");
        }
        catch (ArgumentNullException)
        {
            
        }

        try //Test for IntPtr.Zero
        {
            Marshal.Release(IntPtr.Zero);
            Assert.Fail("Failed AddReleaseRef test. No exception from Release when passed IntPtr.Zero as parameter.");
        }
        catch (ArgumentNullException)
        {
            
        }

        Initialize(ref TestObjects);
        foreach (object obj in TestObjects)
        {
            IntPtr ptr = IntPtr.Zero;
            int refCount = 0; //This should keep a running tally of the current ref count
            int retValue = 0;

            ptr = Marshal.GetIUnknownForObject(obj);
            refCount = Marshal.AddRef(ptr); //Inintialize the refCount

            for (int i = 0; i < 10; i++)  //By the end of this loop we should have no additional refCount
            {
                retValue = Marshal.AddRef(ptr);
                if (++refCount != retValue)
                {
                    Assert.Fail("Failed AddReleaseRef test. Unexpected ref count. Expected: " + refCount + ", Actual: " + retValue);
                }

                retValue = Marshal.Release(ptr);
                if (--refCount != retValue)
                {
                    Assert.Fail("Failed AddReleaseRef test. Unexpected ref count. Expected: " + refCount + ", Actual: " + retValue);
                }
            }

            retValue = Marshal.Release(ptr); //This should negate the first AddRedf call before the loops
            if (--refCount != retValue)
            {
                Assert.Fail("Failed AddReleaseRef test. Unexpected ref count. Expected: " + refCount + ", Actual: " + retValue);
            }

            retValue = Marshal.Release(ptr); //This should negate the GetIUnknownForObject call before the loops
            if (--refCount != retValue)
            {
                Assert.Fail("Failed AddReleaseRef test. Unexpected ref count. Expected: " + refCount + ", Actual: " + retValue);
            }
        }
    }

    public void RunTests()
    {
        AddReleaseRefTests();
    }

    public void Initialize(ref object[] TestObjects)
    {
        TestObjects = new object[7];

        TestObjects[0] = 1;                             //int
        TestObjects[1] = 'a';                           //char
        TestObjects[2] = false;                         //bool
        TestObjects[3] = "string";                      //string
        TestObjects[4] = new TestClass();               //Object of type TestClass 
        TestObjects[5] = new List<int>();               //Projected Type
        TestObjects[6] = new Nullable<int>(2);          //Nullable Type
    }

    public static int Main(String[] unusedArgs)
    {
        try
        {
            new AddReleaseRefTest().RunTests();
        }
        catch (Exception e)
        {
            Console.WriteLine("Test failure: " + e.Message);
            return 101;
        }

        return 100;
    }

}
