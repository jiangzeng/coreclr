using System.Runtime.InteropServices;
using System;
using System.Reflection;
using System.Text;

class BoxedInt
{
    public int MyInt;
}

class Test
{
    [DllImport(@"PInvoke_HandleRef", CallingConvention = CallingConvention.Winapi)]
    private static extern int MarshalPointer_In(HandleRef pintValue, int stackGuard);

    [DllImport(@"PInvoke_HandleRef", CallingConvention = CallingConvention.Winapi)]
    private static extern int MarshalPointer_InOut(HandleRef pintValue, int stackGuard);

    [DllImport(@"PInvoke_HandleRef", CallingConvention = CallingConvention.Winapi)]
    private static extern int MarshalPointer_Out(HandleRef pintValue, int stackGuard);

    [DllImport(@"PInvoke_HandleRef", CallingConvention = CallingConvention.Winapi)]
    private static extern int TestNoGC(HandleRef pintValue, Action gcCallback);

    public unsafe static int Main(string[] args)
    {
        const int intManaged = 1000;
        const int intNative = 2000;
        const int intReturn = 3000;
        const int stackGuard = 5000;

        TestHelper.BeginSubScenario("MarshalPointer_In");
        int int1 = intManaged;
        int* int1Ptr = &int1;
        HandleRef hr1 = new HandleRef(new Object(), (IntPtr)int1Ptr);
        TestHelper.Assert(intReturn, MarshalPointer_In(hr1, stackGuard), "The return value is wrong");
        TestHelper.Assert(intManaged, int1, "The parameter value is changed");
        
        TestHelper.BeginSubScenario("MarshalPointer_InOut");
        int int2 = intManaged;
        int* int2Ptr = &int2;
        HandleRef hr2 = new HandleRef(new Object(), (IntPtr)int2Ptr);
        TestHelper.Assert(intReturn, MarshalPointer_InOut(hr2, stackGuard), "The return value is wrong");
        TestHelper.Assert(intNative, int2, "The passed value is wrong");
        
        TestHelper.BeginSubScenario("MarshalPointer_Out");
        int int3 = intManaged;
        int* int3Ptr = &int3;
        HandleRef hr3 = new HandleRef(new Object(), (IntPtr)int3Ptr);
        TestHelper.Assert(intReturn, MarshalPointer_Out(hr3, stackGuard), "The return value is wrong");
        TestHelper.Assert(intNative, int3, "The passed value is wrong");

        // Note that this scenario will always pass in a debug build because all values 
        // stay rooted until the end of the method. 
        TestHelper.BeginSubScenario("TestNoGC");

        // Keep the int boxed and pinned to prevent it from getting collected.
        // That way, we can safely reference it from finalizers that run on shutdown.
        BoxedInt boxedInt = new BoxedInt();
        GCHandle.Alloc(boxedInt, GCHandleType.Pinned);

        int* int4Ptr;
        fixed (int* tempIntPtr = &boxedInt.MyInt)
        {
            // Smuggle the pointer out of the fixed scope
            int4Ptr = tempIntPtr;
        }
        *int4Ptr = intManaged;
        CollectableClass collectableClass = new CollectableClass(int4Ptr);
        HandleRef hr4 = new HandleRef(collectableClass, (IntPtr)int4Ptr);
        Action gcCallback = () => { Console.WriteLine("GC callback now"); GC.Collect(2, GCCollectionMode.Forced); GC.WaitForPendingFinalizers(); GC.Collect(2, GCCollectionMode.Forced); };
        TestHelper.Assert(intReturn, TestNoGC(hr4, gcCallback), "The return value is wrong");
        Console.WriteLine("Native code finished");

        if (TestHelper.Pass)
        {
            Console.WriteLine("Passed!");
            return 100;
        }
        else
        {
            Console.WriteLine("Failed");
            return 101;
        }
    }

    /// <summary>
    /// Class that will change a pointer passed to native code when this class gets finalized.
    /// Native code can check whether the pointer changed during a P/Invoke
    /// </summary>
    unsafe class CollectableClass
    {
        int* PtrToChange;
        public CollectableClass(int* ptrToChange)
        {
            PtrToChange = ptrToChange;
        }

        ~CollectableClass()
        {
            Console.WriteLine("CollectableClass collected");
            *PtrToChange = Int32.MaxValue;
        }
    }
}

namespace System.Runtime.InteropServices
{
    // HandleRef isn't in the public surface area and this is a quirk for apps that define their own.
    // Copied from HandleRef.cs on desktop
    public struct HandleRef
    {
        internal Object m_wrapper;
        internal IntPtr m_handle;

        public HandleRef(Object wrapper, IntPtr handle)
        {
            m_wrapper = wrapper;
            m_handle = handle;
        }

        public Object Wrapper
        {
            get
            {
                return m_wrapper;
            }
        }

        public IntPtr Handle
        {
            get
            {
                return m_handle;
            }
        }


        public static explicit operator IntPtr(HandleRef value)
        {
            return value.m_handle;
        }

        public static IntPtr ToIntPtr(HandleRef value)
        {
            return value.m_handle;
        }

    }
}