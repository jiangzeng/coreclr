using System;
using System.IO;
using System.Runtime.InteropServices;

public abstract class AllMySafeHandles : SafeHandle
{
    private static readonly IntPtr _invalidHandleValue = new IntPtr(-1);

    //0 or -1 considered invalid
    public override bool IsInvalid
    {
        get { return handle == IntPtr.Zero || handle == _invalidHandleValue; }
    }

    protected AllMySafeHandles(bool ownsHandle) : base(IntPtr.Zero, ownsHandle) { }
}

public sealed class MySafeEventHandle : AllMySafeHandles
{
    private MySafeEventHandle() : base(true) { }

    [DllImport("api-ms-win-core-synch-l1-2-0", SetLastError = true, EntryPoint = "CreateEventW")]
    internal static extern MySafeEventHandle CreateEvent(IntPtr mustBeZero, bool isManualReset, bool initialState, String name);

    [DllImport("api-ms-win-core-synch-l1-2-0", SetLastError = true)]
    internal static extern bool SetEvent(MySafeEventHandle handle);

    [DllImport("api-ms-win-core-handle-l1-1-0")]
    private static extern bool CloseHandle(IntPtr handle);

    override protected bool ReleaseHandle()
    {
        return CloseHandle(handle);
    }
}

public class AbstractDerivedSHTester
{
    private static int ClassHierarchyTest()
    {
        Console.WriteLine("Class hierarchy test...");

        //create an event
        Console.WriteLine("\tCreate new event");
        MySafeEventHandle sh = MySafeEventHandle.CreateEvent(IntPtr.Zero, true, false, null);
        if (sh.IsInvalid)
        {
            Console.WriteLine("\t\tCreateEvent returned an invalid SafeHandle!");
            return 0;
        }
        else if (!MySafeEventHandle.SetEvent(sh))
        {
            Console.WriteLine("\t\tSetEvent failed on a SafeHandle!");
            return 0;
        }

        Console.WriteLine("\tFirst test: Call dispose on sh");
        sh.Dispose();
        Console.WriteLine("\tCall succeeded.\n");

        // Now create another event and force the critical finalizer to run.
        Console.WriteLine("\tCreate new event");
        sh = MySafeEventHandle.CreateEvent(IntPtr.Zero, false, true, null);
        if (sh.IsInvalid)
        {
            Console.WriteLine("\t\tCreateEvent returned an invalid SafeHandle!");
            return 0;
        }

        Console.WriteLine("\tSecond test: Force critical finalizer to run");
        sh = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("\tSucceeded.\n");

        return 100;
    }

    private static int Main()
    {
        int retVal = ClassHierarchyTest();
        Console.WriteLine((retVal == 0) ? "Test FAILED!" : "Test PASSED!");
        return retVal;
    }
}