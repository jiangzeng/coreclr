using System;
using CoreFXTestLibrary;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

internal class MyCriticalHandle : CriticalHandle
{
    static int s_uniqueHandleValue;
    static HashSet<int> s_closedHandles = new HashSet<int>();

    public MyCriticalHandle() : base(new IntPtr(-1))
    {

    }

    public override bool IsInvalid
    {
        get { return false; }
    }

    protected override bool ReleaseHandle()
    {
        if (!s_closedHandles.Contains(handle.ToInt32()))
        {
            s_closedHandles.Add(handle.ToInt32());
            return true;
        }

        return false;
    }

    internal IntPtr Handle
    {
        get
        {
            return handle;
        }
        set 
        {
            handle = value;
        }
    }
    
    internal static IntPtr GetUniqueHandle()
    {
        return new IntPtr(s_uniqueHandleValue++);
    }
    
    internal static bool IsHandleClosed(IntPtr handle)
    {
        return s_closedHandles.Contains(handle.ToInt32());
    }
}

internal class Native
{
    [UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.Bool)]internal delegate bool IsHandleClosed(IntPtr handle);

    [DllImport("CPPComponent.dll", CallingConvention = CallingConvention.StdCall)]
    internal static extern IntPtr In([MarshalAs(UnmanagedType.LPArray)]MyCriticalHandle[] handle);

    [DllImport("CPPComponent.dll", CallingConvention = CallingConvention.StdCall)]
    internal static extern void Out(IntPtr handleValue, [MarshalAs(UnmanagedType.LPArray)]out MyCriticalHandle[] handle);

    [DllImport("CPPComponent.dll", EntryPoint = "Ref", CallingConvention = CallingConvention.StdCall)]
    internal static extern IntPtr InRef([In, MarshalAs(UnmanagedType.LPArray)]ref MyCriticalHandle[] handle);

    [DllImport("CPPComponent.dll", CallingConvention = CallingConvention.StdCall)]
    internal static extern IntPtr Ref([MarshalAs(UnmanagedType.LPArray)]ref MyCriticalHandle[] handle);

    [DllImport("CPPComponent.dll", CallingConvention = CallingConvention.StdCall)]
    internal static extern IntPtr RefModify(IntPtr handleValue, [MarshalAs(UnmanagedType.LPArray)]ref MyCriticalHandle[] handle);
    
    [DllImport("CPPComponent.dll", CallingConvention = CallingConvention.StdCall)]
    internal static extern MyCriticalHandle[] Ret(IntPtr handleValue);

    [DllImport("CPPComponent.dll", CallingConvention = CallingConvention.StdCall)]
    internal static extern IntPtr SetIsHandleClosedCallback([MarshalAs(UnmanagedType.FunctionPtr)]IsHandleClosed isHandleClosed);
}

public class CriticalHandleArrayTest
{
    private static Native.IsHandleClosed s_isHandleClose = (handleValue) => 
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        return MyCriticalHandle.IsHandleClosed(handleValue);
    };

    [TestMethod]
    public static void In()
    {
        IntPtr handleValue = MyCriticalHandle.GetUniqueHandle();
        MyCriticalHandle[] myCriticalHandleArray = new MyCriticalHandle[] { new MyCriticalHandle() { Handle = handleValue } };

        Assert.Throws<MarshalDirectiveException>(() => Native.In(myCriticalHandleArray));
    }

    [TestMethod]
    public static void Ret()
    {
        IntPtr handleValue = MyCriticalHandle.GetUniqueHandle();

        Assert.Throws<MarshalDirectiveException>(() => Native.Ret(handleValue));
    }

    [TestMethod]
    public static void Out()
    {
        IntPtr handleValue = MyCriticalHandle.GetUniqueHandle();
        MyCriticalHandle[] myCriticalHandleArray;

        Assert.Throws<MarshalDirectiveException>(() => Native.Out(handleValue, out myCriticalHandleArray));
    }

    [TestMethod]
    public static void InRef()
    {
        IntPtr handleValue = MyCriticalHandle.GetUniqueHandle();
        MyCriticalHandle[] myCriticalHandleArray = new MyCriticalHandle[] { new MyCriticalHandle() { Handle = handleValue } };

        Assert.Throws<MarshalDirectiveException>(() => Native.InRef(ref myCriticalHandleArray));
    }

    [TestMethod]
    public static void Ref()
    {
        IntPtr handleValue = MyCriticalHandle.GetUniqueHandle();
        MyCriticalHandle[] myCriticalHandleArray = new MyCriticalHandle[] { new MyCriticalHandle() { Handle = handleValue } };

        Assert.Throws<MarshalDirectiveException>(() => Native.Ref(ref myCriticalHandleArray));
    }

    [TestMethod]
    public static void RefModify()
    {
        IntPtr handleValue1 = MyCriticalHandle.GetUniqueHandle();
        IntPtr handleValue2 = MyCriticalHandle.GetUniqueHandle();
        MyCriticalHandle[] myCriticalHandleArray = new MyCriticalHandle[] { new MyCriticalHandle() { Handle = handleValue1 } };

        Assert.Throws<MarshalDirectiveException>(() => Native.RefModify(handleValue2, ref myCriticalHandleArray));
    }
}
