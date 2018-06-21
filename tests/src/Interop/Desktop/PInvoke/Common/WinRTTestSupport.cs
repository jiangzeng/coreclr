using System;
using System.Collections.Generic;
using System.Text;

#if PlatformCode
using System.Security;
#endif
// When compiled into the same project as ExpectedType.cs we need to put this into a namespace
// because ExpectedTypes unavoidably has a namespace called 'Test' (which we get from the WinMD
// unit tests).  When we integrate this back with the other unit tests we'll have to decide how
// to merge this.
#if TEST_NAMESPACE_HACK
namespace WinRTUnitTests
{
#endif

public static class Helpers
{
    public static int S_OK = 1;
    public static int E_NOINTERFACE = unchecked((int)0x80004002);
    public static int COR_E_INVALIDOPERATION = unchecked((int)0x80131509);
    public static int COR_E_GENERICMETHOD = unchecked((int)0x80131535);
}

public static class TestHelper
{
    static bool s_pass = true;
    static bool s_debugWriteLine = false;

    // Used to synchronize when logging errors that may otherwise
    // be garbled if multiple threads attempt to log in parallel.
    static object s_errorLogLock = new object();

    static TestHelper()
    {


#if !WinCoreSys
        InformationWriteLine("NOTE: Set TEST_DEBUG_OUTPUT=1 for additional output");
#endif
    }

    public static void BeginScenario(string scenarioDescription)
    {
        InformationWriteLine();
        InformationWriteLine("--Scenario: {0}", scenarioDescription);
    }

    public static void BeginSubScenario(string message)
    {
        InformationWriteLine("----Sub Scenario: {0}", message);
    }

    public static void BeginSubScenario(string message, params Object[] args)
    {
        BeginSubScenario(String.Format(message, args));
    }

    public static bool Pass
    {
        get
        {
            return s_pass;
        }
    }

    public static void InformationWriteLine()
    {
        Console.WriteLine();
    }

    public static void InformationWriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public static void InformationWriteLine(string message, params Object[] args)
    {
        InformationWriteLine(String.Format(message, args));
    }

    public static void DebugWriteLine(string message)
    {
        if (s_debugWriteLine)
        {
            Console.WriteLine(message);
        }
    }

    public static void DebugWriteLine(string message, params Object[] args)
    {
        DebugWriteLine(String.Format(message, args));
    }

    public static void WarningWriteLine(string message)
    {
        Console.WriteLine("****Warning: " + message);
    }

    public static void WarningWriteLine(string message, params Object[] args)
    {
        WarningWriteLine(String.Format(message, args));
    }

    private static void InternalErrorWriteLine(string message)
    {
        lock (s_errorLogLock) {
            Console.WriteLine("****Error: " + message);
        }
    }

    private static void InternalErrorWriteLine(string message, params Object[] args)
    {
        InternalErrorWriteLine(String.Format(message, args));
    }

    public static void ErrorWriteLine(string message)
    {
        InternalErrorWriteLine(message);
        Assert(false);
    }

    public static void ErrorWriteLine(string message, params Object[] args)
    {
        InternalErrorWriteLine(String.Format(message, args));
        Assert(false);
    }

    public static bool Assert(bool condition)
    {
        if (!condition)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                System.Diagnostics.Debugger.Break();
            }

            s_pass = false;
            return false;
        }

        return true;
    }

    public static bool Assert<T>(T expected, T actual, string message)
    {
        if (!Equals(expected, actual))
        {
            InternalErrorWriteLine("{0} Expected: {1} Actual: {2}", message, expected, actual);
            return Assert(false);
        }

        return Assert(true);
    }

    public static bool Assert(bool condition, string message)
    {
        if (!condition)
        {
            InternalErrorWriteLine(message);
        }

        return Assert(condition);
    }

    public static bool Assert(bool condition, string message, params Object[] args)
    {
        if (!condition)
        {
            InternalErrorWriteLine(String.Format(message, args));
        }

        return Assert(condition);
    }

    public static bool AssertException(
        Type expectedExceptionType,
        Action exceptionGenerator,
        string message,
        params Object[] args)
    {
        if (null == expectedExceptionType)
        {
            throw new ArgumentNullException("expectedExceptionType");
        }

        if (null == exceptionGenerator)
        {
            throw new ArgumentNullException("exceptionGenerator");
        }

        try
        {
            exceptionGenerator();
            return Assert(false, "Expected exception {0} to be thrown and nothing was thrown. {1}", expectedExceptionType, String.Format(message, args));
        }
        catch (Exception e)
        {
            if (expectedExceptionType != e.GetType())
            {
                return Assert(false, "Expected exception {0} to be thrown and {1} was thrown. {2}", expectedExceptionType, e.ToString(), String.Format(message, args));
            }

            DebugWriteLine("{0} threw {1}: {2}", String.Format(message, args), e.GetType(), e.Message);
            return true;
        }
    }

    public static bool AssertException(
        Type expectedExceptionType,
        string expectedExceptionString,
        Action exceptionGenerator,
        string message,
        params Object[] args)
    {
        if (null == expectedExceptionType)
        {
            throw new ArgumentNullException("expectedExceptionType");
        }

        if (null == exceptionGenerator)
        {
            throw new ArgumentNullException("exceptionGenerator");
        }

        try
        {
            exceptionGenerator();
            return Assert(false, "Expected exception {0} to be thrown and nothing was thrown. {1}", expectedExceptionType, String.Format(message, args));
        }
        catch (Exception e)
        {
            if (expectedExceptionType != e.GetType())
            {
                return Assert(false, "Expected exception {0} to be thrown and {1} was thrown. {2}", expectedExceptionType, e.GetType(), String.Format(message, args));
            }

            if (!e.Message.Equals(expectedExceptionString, StringComparison.CurrentCulture))
            {
                return Assert(false, "Expected exception string:{0} \n Actual thrown:{1}", expectedExceptionString, e.Message);
            }

            DebugWriteLine("{0} threw {1}: {2}", String.Format(message, args), e.GetType(), e.Message);
            return true;
        }
    }

    public static bool Assert<T>(T[] expectedArray, T[] actualArray, string message)
    {
        return Assert(expectedArray, actualArray, actualArray.Length, message);
    }


    public static bool Assert<T>(T[] expectedArray, T[] actualArray, int actualArrayLength, string message)
    {
        bool result = true;
        int minArrayLengths = Math.Min(expectedArray.Length, actualArrayLength);

        result &= Assert(expectedArray.Length, actualArrayLength, String.Format("{0} array.Length", message));

        for (int i = 0; i < minArrayLengths; ++i)
        {
            result &= Assert(expectedArray[i], actualArray[i], String.Format("{0} array item(index: {1})", message, i));
        }

        return result;
    }

    public static bool Run(ITestcase testcase)
    {
        bool result = true;

        if (null == testcase)
        {
            throw new ArgumentNullException("testcase");
        }

        try
        {
            if (testcase.Initialize())
            {
                // Only call RunTests if Initialize is successfull
                result = testcase.RunTests();
            }
            else
            {
                result = false;
            }
        }
        finally
        {
            // We always call Cleanup even if Initialize failed.
            // It is up to testcase to gracefully handle this.
            result &= testcase.Cleanup();
        }

        if (result)
        {
            InformationWriteLine();
            InformationWriteLine("TEST PASSED");
        }
        else
        {
            InformationWriteLine();
            InformationWriteLine("TEST FAILED");
        }

        return result;
    }

    public static T CreateWinRTInstance<T>(params Object[] args)
    {
        return (T)Activator.CreateInstance(typeof(T), args);
    }

    public static void CleanupWinRTInstance<T>(T winRTInstance)
    {
        return;
    }

    private static bool Equals<T>(T x, T y)
    {
        if (null == x)
        {
            return null == y;
        }
        else if (null == y)
        {
            return false;
        }
        else
        {
            return x.Equals(y);
        }
    }
}

public interface ITestcase
{
    bool Initialize();

    bool Cleanup();

    bool RunTests();
}

abstract public class Testcase : ITestcase
{
#if PlatformCode
[SecuritySafeCritical]
#endif
    public virtual bool Initialize()
    {
        TestHelper.BeginScenario("Initialize");
        return true;
    }

    public virtual bool Cleanup()
    {
        TestHelper.BeginScenario("Cleanup");
        return true;
    }

    abstract public bool RunTests();
}

#if TEST_NAMESPACE_HACK
}
#endif

