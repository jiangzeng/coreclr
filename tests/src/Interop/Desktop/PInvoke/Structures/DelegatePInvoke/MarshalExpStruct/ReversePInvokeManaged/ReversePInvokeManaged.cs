using System;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

public class Test
{
    const int iNative = 11;//the value passed from Native side to Managed side
    const int iManaged = 10;//The value passed from Managed side to Native sid

    enum StructID
    {
        INNER2Id,
        InnerExplicitId,
        InnerArrayExplicitId,
        OUTER3Id,
        UId,
        ByteStructPack2ExplicitId,
        ShortStructPack4ExplicitId,
        IntStructPack8ExplicitId,
        LongStructPack16ExplicitId
    }



    #region Methods implementation

    #region ReversePinvoke, ByRef, Cdel  
    
    //ReversePinvoke,Cdel
    // 1.1
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByRefCdeclcaller_INNER2([In, Out]ref INNER2 inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByRefStruct_Cdecl_INNER2(ByRefCdeclcaller_INNER2 caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_INNER2_Cdecl(ref INNER2 inner2)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Cdecl");
        try
        {
            INNER2 sourceINNER2 = Helper.NewINNER2(77, 77.0F, "Native");
            if (!Helper.ValidateINNER2(sourceINNER2, inner2, "TestMethod_DoCallBack_MarshalStructByRef_INNER2_Cdecl"))
            {
                breturn = false;
                Console.WriteLine(inner2.f1);
                Console.WriteLine(inner2.f2);
                Console.WriteLine(inner2.f3);
                TestFramework.LogError("001.01.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_INNER2_Cdecl.Expected:True;Actual:False");
            }
            //changed the value
            inner2.f1 = 1;
            inner2.f2 = 1.0F;
            inner2.f3 = "some string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("001.01.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 1.2
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByRefCdeclcaller_InnerExplicit([In, Out]ref InnerExplicit inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByRefStruct_Cdecl_InnerExplicit(ByRefCdeclcaller_InnerExplicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_InnerExplicit_Cdecl(ref InnerExplicit inner2)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Cdecl");
        try
        {
            InnerExplicit source_ie = new InnerExplicit();
            source_ie.f1 = 77;
            source_ie.f3 = "Native";

            if (!Helper.ValidateInnerExplicit(source_ie, inner2, "TestMethod_DoCallBack_MarshalStructByRef_InnerExplicit_Cdecl"))
            {
                breturn = false;
                Console.WriteLine(inner2.f1);
                Console.WriteLine(inner2.f3);
                TestFramework.LogError("001.02.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_InnerExplicit_Cdecl.Expected:True;Actual:False");
            }
            //changed the value
            inner2.f1 = 1;
            inner2.f3 = "some string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("001.02.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 1.3
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByRefCdeclcaller_InnerArrayExplicit([In, Out]ref InnerArrayExplicit inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByRefStruct_Cdecl_InnerArrayExplicit(ByRefCdeclcaller_InnerArrayExplicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_InnerArrayExplicit_Cdecl(ref InnerArrayExplicit iae)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Cdecl");
        try
        {
            InnerArrayExplicit source_iae = Helper.NewInnerArrayExplicit(77, 77.0F, "Native", "Native");

            if (!Helper.ValidateInnerArrayExplicit(source_iae, iae, "TestMethod_DoCallBack_MarshalStructByRef_InnerArrayExplicit_Cdecl"))
            {
                breturn = false;
                Console.WriteLine(iae.arr[0].f1);
                Console.WriteLine(iae.arr[0].f3);
                Console.WriteLine(iae.f4);
                TestFramework.LogError("001.03.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_InnerArrayExplicit_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            for (int i = 0; i < Common.NumArrElements; i++)
            {
                iae.arr[i].f1 = 1;
                iae.arr[i].f3 = "some string";
            }

            iae.f4 = "some string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("001.03.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 1.4
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByRefCdeclcaller_OUTER3([In, Out]ref OUTER3 outer3);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByRefStruct_Cdecl_OUTER3(ByRefCdeclcaller_OUTER3 caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_OUTER3_Cdecl(ref OUTER3 outer3)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Cdecl");
        try
        {
            OUTER3 sourceOUTER3 = Helper.NewOUTER3(77, 77.0F, "Native", "Native");

            if (!Helper.ValidateOUTER3(sourceOUTER3, outer3, "TestMethod_DoCallBack_MarshalStructByRef_OUTER3_Cdecl"))
            {
                breturn = false;
                Console.WriteLine(outer3.arr[0].f1);
                Console.WriteLine(outer3.arr[0].f2);
                Console.WriteLine(outer3.arr[0].f3);
                Console.WriteLine(outer3.f4);
                TestFramework.LogError("001.04.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_OUTER3_Cdecl.Expected:True;Actual:False");
            }
            //changed the value
            for (int i = 0; i < Common.NumArrElements; i++)
            {
                outer3.arr[i].f1 = 1;
                outer3.arr[i].f2 = 1.0F;
                outer3.arr[i].f3 = "some string";
            }

            outer3.f4 = "some string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("001.04.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 1.5
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByRefCdeclcaller_U([In, Out]ref U u);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByRefStruct_Cdecl_U(ByRefCdeclcaller_U caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_U_Cdecl(ref U u)
    {

        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Cdecl");
        try
        {
            U changeU = Helper.NewU(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, 
                sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 1.23);

            if (!Helper.ValidateU(changeU, u, "TestMethod_DoCallBack_MarshalStructByRef_U_Cdecl"))
            {
                breturn = false;
                TestFramework.LogError("001.05.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_U_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            u.d = 3.2;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("001.05.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 1.6
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByRefCdeclcaller_ByteStructPack2Explicit([In, Out]ref ByteStructPack2Explicit bspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByRefStruct_Cdecl_ByteStructPack2Explicit(ByRefCdeclcaller_ByteStructPack2Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_ByteStructPack2Explicit_Cdecl(ref ByteStructPack2Explicit bspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Cdecl");
        try
        {
            ByteStructPack2Explicit change_bspe = Helper.NewByteStructPack2Explicit(64, 64);

            if (!Helper.ValidateByteStructPack2Explicit(change_bspe, bspe, "TestMethod_DoCallBack_MarshalStructByRef_ByteStructPack2Explicit_Cdecl"))
            {
                breturn = false;
                TestFramework.LogError("001.06.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_ByteStructPack2Explicit_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            bspe.b1 = 32;
            bspe.b2 = 32;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("001.06.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 1.7
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByRefCdeclcaller_ShortStructPack4Explicit([In, Out]ref ShortStructPack4Explicit sspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByRefStruct_Cdecl_ShortStructPack4Explicit(ByRefCdeclcaller_ShortStructPack4Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_ShortStructPack4Explicit_Cdecl(ref ShortStructPack4Explicit sspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Cdecl");
        try
        {
            ShortStructPack4Explicit change_sspe = Helper.NewShortStructPack4Explicit(64, 64);

            if (!Helper.ValidateShortStructPack4Explicit(change_sspe, sspe, "TestMethod_DoCallBack_MarshalStructByRef_ShortStructPack4Explicit_Cdecl"))
            {
                breturn = false;
                TestFramework.LogError("001.07.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_ShortStructPack4Explicit_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            sspe.s1 = 32;
            sspe.s2 = 32;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("001.07.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 1.8
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByRefCdeclcaller_IntStructPack8Explicit([In, Out]ref IntStructPack8Explicit ispe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByRefStruct_Cdecl_IntStructPack8Explicit(ByRefCdeclcaller_IntStructPack8Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_IntStructPack8Explicit_Cdecl(ref IntStructPack8Explicit ispe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Cdecl");
        try
        {
            IntStructPack8Explicit change_ispe = Helper.NewIntStructPack8Explicit(64, 64);

            if (!Helper.ValidateIntStructPack8Explicit(change_ispe, ispe, "TestMethod_DoCallBack_MarshalStructByRef_IntStructPack8Explicit_Cdecl"))
            {
                breturn = false;
                TestFramework.LogError("001.08.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_IntStructPack8Explicit_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            ispe.i1 = 32;
            ispe.i2 = 32;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("001.08.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 1.9
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByRefCdeclcaller_LongStructPack16Explicit([In, Out]ref LongStructPack16Explicit lspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByRefStruct_Cdecl_LongStructPack16Explicit(ByRefCdeclcaller_LongStructPack16Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_LongStructPack16Explicit_Cdecl(ref LongStructPack16Explicit lspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Cdecl");
        try
        {
            LongStructPack16Explicit change_lspe = Helper.NewLongStructPack16Explicit(64, 64);

            if (!Helper.ValidateLongStructPack16Explicit(change_lspe, lspe, "TestMethod_DoCallBack_MarshalStructByRef_LongStructPack16Explicit_Cdecl"))
            {
                breturn = false;
                TestFramework.LogError("001.09.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_LongStructPack16Explicit_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            lspe.l1 = 32;
            lspe.l2 = 32;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("001.09.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    #endregion
    
    #region ReversePinvoke, ByRef, Stdcall

    //ReversePinvoke,Stdcall
    // 2.1
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByRefStdcallcaller_INNER2([In, Out]ref INNER2 inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByRefStruct_Stdcall_INNER2(ByRefStdcallcaller_INNER2 caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_INNER2_Stdcall(ref INNER2 inner2)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Stdcall");
        try
        {
            INNER2 sourceINNER2 = Helper.NewINNER2(77, 77.0F, "Native");
            if (!Helper.ValidateINNER2(sourceINNER2, inner2, "TestMethod_DoCallBack_MarshalStructByRef_INNER2_Stdcall"))
            {
                breturn = false;
                Console.WriteLine(inner2.f1);
                Console.WriteLine(inner2.f2);
                Console.WriteLine(inner2.f3);
                TestFramework.LogError("002.01.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_INNER2_Stdcall.Expected:True;Actual:False");
            }
            //changed the value
            inner2.f1 = 1;
            inner2.f2 = 1.0F;
            inner2.f3 = "some string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("002.01.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 2.2
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByRefStdcallcaller_InnerExplicit([In, Out]ref InnerExplicit inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByRefStruct_Stdcall_InnerExplicit(ByRefStdcallcaller_InnerExplicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_InnerExplicit_Stdcall(ref InnerExplicit inner2)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Stdcall");
        try
        {
            InnerExplicit source_ie = new InnerExplicit();
            source_ie.f1 = 77;
            source_ie.f3 = "Native";

            if (!Helper.ValidateInnerExplicit(inner2,source_ie, "TestMethod_DoCallBack_MarshalStructByRef_InnerExplicit_Stdcall"))
            {
                breturn = false;
                Console.WriteLine(inner2.f1);
                Console.WriteLine(inner2.f3);
                TestFramework.LogError("002.02.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_InnerExplicit_Stdcall.Expected:True;Actual:False");
            }
            //changed the value
            inner2.f1 = 1;
            inner2.f3 = "some string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("002.02.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 2.3
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByRefStdcallcaller_InnerArrayExplicit([In, Out]ref InnerArrayExplicit inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByRefStruct_Stdcall_InnerArrayExplicit(ByRefStdcallcaller_InnerArrayExplicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_InnerArrayExplicit_Stdcall(ref InnerArrayExplicit iae)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Stdcall");
        try
        {
            InnerArrayExplicit source_iae = Helper.NewInnerArrayExplicit(77, 77.0F, "Native", "Native");

            if (!Helper.ValidateInnerArrayExplicit(source_iae, iae, "TestMethod_DoCallBack_MarshalStructByRef_InnerArrayExplicit_Stdcall"))
            {
                breturn = false;
                Console.WriteLine(iae.arr[0].f1);
                Console.WriteLine(iae.arr[0].f3);
                Console.WriteLine(iae.f4);
                TestFramework.LogError("002.03.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_InnerArrayExplicit_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            for (int i = 0; i < Common.NumArrElements; i++)
            {
                iae.arr[i].f1 = 1;
                iae.arr[i].f3 = "some string";
            }

            iae.f4 = "some string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("002.03.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 2.4
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByRefStdcallcaller_OUTER3([In, Out]ref OUTER3 outer3);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByRefStruct_Stdcall_OUTER3(ByRefStdcallcaller_OUTER3 caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_OUTER3_Stdcall(ref OUTER3 outer3)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Stdcall");
        try
        {
            OUTER3 sourceOUTER3 = Helper.NewOUTER3(77, 77.0F, "Native", "Native");

            if (!Helper.ValidateOUTER3(sourceOUTER3, outer3, "TestMethod_DoCallBack_MarshalStructByRef_OUTER3_Stdcall"))
            {
                breturn = false;
                Console.WriteLine(outer3.arr[0].f1);
                Console.WriteLine(outer3.arr[0].f2);
                Console.WriteLine(outer3.arr[0].f3);
                Console.WriteLine(outer3.f4);
                TestFramework.LogError("002.04.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_OUTER3_Stdcall.Expected:True;Actual:False");
            }
            //changed the value
            for (int i = 0; i < Common.NumArrElements; i++)
            {
                outer3.arr[i].f1 = 1;
                outer3.arr[i].f2 = 1.0F;
                outer3.arr[i].f3 = "some string";
            }

            outer3.f4 = "some string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("002.04.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 2.5
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByRefStdcallcaller_U([In, Out]ref U u);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByRefStruct_Stdcall_U(ByRefStdcallcaller_U caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_U_Stdcall(ref U u)
    {

        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Stdcall");
        try
        {
            U changeU = Helper.NewU(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, 
                sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 1.23);

            if (!Helper.ValidateU(changeU, u, "TestMethod_DoCallBack_MarshalStructByRef_U_Stdcall"))
            {
                breturn = false;
                TestFramework.LogError("002.05.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_U_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            u.d = 3.2;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("002.05.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 2.6
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByRefStdcallcaller_ByteStructPack2Explicit([In, Out]ref ByteStructPack2Explicit bspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByRefStruct_Stdcall_ByteStructPack2Explicit(ByRefStdcallcaller_ByteStructPack2Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_ByteStructPack2Explicit_Stdcall(ref ByteStructPack2Explicit bspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Stdcall");
        try
        {
            ByteStructPack2Explicit change_bspe = Helper.NewByteStructPack2Explicit(64, 64);

            if (!Helper.ValidateByteStructPack2Explicit(change_bspe, bspe, "TestMethod_DoCallBack_MarshalStructByRef_ByteStructPack2Explicit_Stdcall"))
            {
                breturn = false;
                TestFramework.LogError("002.06.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_ByteStructPack2Explicit_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            bspe.b1 = 32;
            bspe.b2 = 32;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("002.06.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 2.7
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByRefStdcallcaller_ShortStructPack4Explicit([In, Out]ref ShortStructPack4Explicit sspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByRefStruct_Stdcall_ShortStructPack4Explicit(ByRefStdcallcaller_ShortStructPack4Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_ShortStructPack4Explicit_Stdcall(ref ShortStructPack4Explicit sspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Stdcall");
        try
        {
            ShortStructPack4Explicit change_sspe = Helper.NewShortStructPack4Explicit(64, 64);

            if (!Helper.ValidateShortStructPack4Explicit(change_sspe, sspe, "TestMethod_DoCallBack_MarshalStructByRef_ShortStructPack4Explicit_Stdcall"))
            {
                breturn = false;
                TestFramework.LogError("002.07.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_ShortStructPack4Explicit_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            sspe.s1 = 32;
            sspe.s2 = 32;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("002.07.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 2.8
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByRefStdcallcaller_IntStructPack8Explicit([In, Out]ref IntStructPack8Explicit ispe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByRefStruct_Stdcall_IntStructPack8Explicit(ByRefStdcallcaller_IntStructPack8Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_IntStructPack8Explicit_Stdcall(ref IntStructPack8Explicit ispe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Stdcall");
        try
        {
            IntStructPack8Explicit change_ispe = Helper.NewIntStructPack8Explicit(64, 64);

            if (!Helper.ValidateIntStructPack8Explicit(change_ispe, ispe, "TestMethod_DoCallBack_MarshalStructByRef_IntStructPack8Explicit_Stdcall"))
            {
                breturn = false;
                TestFramework.LogError("002.08.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_IntStructPack8Explicit_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            ispe.i1 = 32;
            ispe.i2 = 32;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("002.08.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 2.9
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByRefStdcallcaller_LongStructPack16Explicit([In, Out]ref LongStructPack16Explicit lspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByRefStruct_Stdcall_LongStructPack16Explicit(ByRefStdcallcaller_LongStructPack16Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByRef_LongStructPack16Explicit_Stdcall(ref LongStructPack16Explicit lspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Stdcall");
        try
        {
            LongStructPack16Explicit change_lspe = Helper.NewLongStructPack16Explicit(64, 64);

            if (!Helper.ValidateLongStructPack16Explicit(change_lspe, lspe, "TestMethod_DoCallBack_MarshalStructByRef_LongStructPack16Explicit_Stdcall"))
            {
                breturn = false;
                TestFramework.LogError("002.09.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByRef_LongStructPack16Explicit_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            lspe.l1 = 32;
            lspe.l2 = 32;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("002.09.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    #endregion
    
    #region ReversePinvoke, ByVal, Cdel

    // 3.1
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByValCdeclcaller_INNER2([In, Out] INNER2 inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByValStruct_Cdecl_INNER2(ByValCdeclcaller_INNER2 caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_INNER2_Cdecl( INNER2 inner2)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Ref,Cdecl");
        try
        {
            INNER2 sourceINNER2 = Helper.NewINNER2(1, 1.0F, "some string");
            if (!Helper.ValidateINNER2(sourceINNER2, inner2, "TestMethod_DoCallBack_MarshalStructByVal_INNER2_Cdecl"))
            {
                breturn = false;
                Console.WriteLine(inner2.f1);
                Console.WriteLine(inner2.f2);
                Console.WriteLine(inner2.f3);
                TestFramework.LogError("003.01.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_INNER2_Cdecl.Expected:True;Actual:False");
            }
            //changed the value
            inner2.f1 = 77;
            inner2.f2 = 77.0F;
            inner2.f3 = "changed string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("003.01.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 3.2
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByValCdeclcaller_InnerExplicit([In, Out] InnerExplicit inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByValStruct_Cdecl_InnerExplicit(ByValCdeclcaller_InnerExplicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_InnerExplicit_Cdecl( InnerExplicit inner2)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Cdecl");
        try
        {
            InnerExplicit source_ie = new InnerExplicit();
            source_ie.f1 = 1;
            source_ie.f3 = "Native";

            if (!Helper.ValidateInnerExplicit(source_ie, inner2, "TestMethod_DoCallBack_MarshalStructByVal_InnerExplicit_Cdecl"))
            {
                breturn = false;
                Console.WriteLine(inner2.f1);
                Console.WriteLine(inner2.f3);
                TestFramework.LogError("003.02.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_InnerExplicit_Cdecl.Expected:True;Actual:False");
            }
            //changed the value
            inner2.f1 = 1;
            inner2.f3 = "changed string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("003.02.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 3.3
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByValCdeclcaller_InnerArrayExplicit([In, Out] InnerArrayExplicit inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByValStruct_Cdecl_InnerArrayExplicit(ByValCdeclcaller_InnerArrayExplicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_InnerArrayExplicit_Cdecl( InnerArrayExplicit iae)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Cdecl");
        try
        {
            InnerArrayExplicit source_iae = Helper.NewInnerArrayExplicit(1, 1.0F, "some string", "some string");

            if (!Helper.ValidateInnerArrayExplicit(source_iae, iae, "TestMethod_DoCallBack_MarshalStructByVal_InnerArrayExplicit_Cdecl"))
            {
                breturn = false;
                Console.WriteLine(iae.arr[0].f1);
                Console.WriteLine(iae.arr[0].f3);
                Console.WriteLine(iae.f4);
                TestFramework.LogError("003.03.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_InnerArrayExplicit_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            for (int i = 0; i < Common.NumArrElements; i++)
            {
                iae.arr[i].f1 = 1;
                iae.arr[i].f3 = "changed string";
            }

            iae.f4 = "changed string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("003.03.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 3.4
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByValCdeclcaller_OUTER3([In, Out] OUTER3 outer3);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByValStruct_Cdecl_OUTER3(ByValCdeclcaller_OUTER3 caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_OUTER3_Cdecl( OUTER3 outer3)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Cdecl");
        try
        {
            OUTER3 sourceOUTER3 = Helper.NewOUTER3(1, 1.0F, "some string", "some string");

            if (!Helper.ValidateOUTER3(sourceOUTER3, outer3, "TestMethod_DoCallBack_MarshalStructByVal_OUTER3_Cdecl"))
            {
                breturn = false;
                Console.WriteLine(outer3.arr[0].f1);
                Console.WriteLine(outer3.arr[0].f2);
                Console.WriteLine(outer3.arr[0].f3);
                Console.WriteLine(outer3.f4);
                TestFramework.LogError("003.04.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_OUTER3_Cdecl.Expected:True;Actual:False");
            }
            //changed the value
            for (int i = 0; i < Common.NumArrElements; i++)
            {
                outer3.arr[i].f1 = 1;
                outer3.arr[i].f2 = 1.0F;
                outer3.arr[i].f3 = "changed string";
            }

            outer3.f4 = "changed string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("003.04.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 3.5
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByValCdeclcaller_U([In, Out] U u);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByValStruct_Cdecl_U(ByValCdeclcaller_U caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_U_Cdecl( U u)
    {

        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Cdecl");
        try
        {
            U changeU = Helper.NewU(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, 
                sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);

            if (!Helper.ValidateU(changeU, u, "TestMethod_DoCallBack_MarshalStructByVal_U_Cdecl"))
            {
                breturn = false;
                TestFramework.LogError("003.05.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_U_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            u.d = 1.23;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("003.05.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 3.6
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByValCdeclcaller_ByteStructPack2Explicit([In, Out] ByteStructPack2Explicit bspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByValStruct_Cdecl_ByteStructPack2Explicit(ByValCdeclcaller_ByteStructPack2Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_ByteStructPack2Explicit_Cdecl( ByteStructPack2Explicit bspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Cdecl");
        try
        {
            ByteStructPack2Explicit change_bspe = Helper.NewByteStructPack2Explicit(32, 32);

            if (!Helper.ValidateByteStructPack2Explicit(change_bspe, bspe, "TestMethod_DoCallBack_MarshalStructByVal_ByteStructPack2Explicit_Cdecl"))
            {
                breturn = false;
                TestFramework.LogError("003.06.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_ByteStructPack2Explicit_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            bspe.b1 = 64;
            bspe.b2 = 64;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("003.06.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 3.7
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByValCdeclcaller_ShortStructPack4Explicit([In, Out] ShortStructPack4Explicit sspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByValStruct_Cdecl_ShortStructPack4Explicit(ByValCdeclcaller_ShortStructPack4Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_ShortStructPack4Explicit_Cdecl( ShortStructPack4Explicit sspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Cdecl");
        try
        {
            ShortStructPack4Explicit change_sspe = Helper.NewShortStructPack4Explicit(32, 32);

            if (!Helper.ValidateShortStructPack4Explicit(change_sspe, sspe, "TestMethod_DoCallBack_MarshalStructByVal_ShortStructPack4Explicit_Cdecl"))
            {
                breturn = false;
                TestFramework.LogError("003.07.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_ShortStructPack4Explicit_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            sspe.s1 = 64;
            sspe.s2 = 64;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("003.07.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 3.8
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByValCdeclcaller_IntStructPack8Explicit([In, Out] IntStructPack8Explicit ispe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByValStruct_Cdecl_IntStructPack8Explicit(ByValCdeclcaller_IntStructPack8Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_IntStructPack8Explicit_Cdecl( IntStructPack8Explicit ispe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Cdecl");
        try
        {
            IntStructPack8Explicit change_ispe = Helper.NewIntStructPack8Explicit(32, 32);

            if (!Helper.ValidateIntStructPack8Explicit(change_ispe, ispe, "TestMethod_DoCallBack_MarshalStructByVal_IntStructPack8Explicit_Cdecl"))
            {
                breturn = false;
                TestFramework.LogError("003.08.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_IntStructPack8Explicit_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            ispe.i1 = 64;
            ispe.i2 = 64;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("003.08.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 3.9
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByValCdeclcaller_LongStructPack16Explicit([In, Out] LongStructPack16Explicit lspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DoCallBack_MarshalByValStruct_Cdecl_LongStructPack16Explicit(ByValCdeclcaller_LongStructPack16Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_LongStructPack16Explicit_Cdecl( LongStructPack16Explicit lspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Cdecl");
        try
        {
            LongStructPack16Explicit change_lspe = Helper.NewLongStructPack16Explicit(32, 32);

            if (!Helper.ValidateLongStructPack16Explicit(change_lspe, lspe, "TestMethod_DoCallBack_MarshalStructByVal_LongStructPack16Explicit_Cdecl"))
            {
                breturn = false;
                TestFramework.LogError("003.09.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_LongStructPack16Explicit_Cdecl.Expected:True;Actual:False");
            }

            //changed the value
            lspe.l1 = 64;
            lspe.l2 = 64;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("003.09.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    #endregion
    
    #region ReversePinvoke, ByVal, Stdcall
   
    // 4.1
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ByValStdcallcaller_INNER2([In, Out] INNER2 inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByValStruct_Stdcall_INNER2(ByValStdcallcaller_INNER2 caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_INNER2_Stdcall(INNER2 inner2)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Stdcall");
        try
        {
            INNER2 sourceINNER2 = Helper.NewINNER2(1, 1.0F, "some string");
            if (!Helper.ValidateINNER2(sourceINNER2, inner2, "TestMethod_DoCallBack_MarshalStructByVal_INNER2_Stdcall"))
            {
                breturn = false;
                Console.WriteLine(inner2.f1);
                Console.WriteLine(inner2.f2);
                Console.WriteLine(inner2.f3);
                TestFramework.LogError("004.01.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_INNER2_Stdcall.Expected:True;Actual:False");
            }
            //changed the value
            inner2.f1 = 77;
            inner2.f2 = 77.0F;
            inner2.f3 = "changed string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("004.01.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }
    
    // 4.2
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByValStdcallcaller_InnerExplicit([In, Out] InnerExplicit inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByValStruct_Stdcall_InnerExplicit(ByValStdcallcaller_InnerExplicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_InnerExplicit_Stdcall(InnerExplicit inner2)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Stdcall");
        try
        {
            InnerExplicit source_ie = new InnerExplicit();
            source_ie.f1 = 1;
            source_ie.f3 = "Native";

            if (!Helper.ValidateInnerExplicit(source_ie, inner2, "TestMethod_DoCallBack_MarshalStructByVal_InnerExplicit_Stdcall"))
            {
                breturn = false;
                Console.WriteLine(inner2.f1);
                Console.WriteLine(inner2.f3);
                TestFramework.LogError("004.02.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_InnerExplicit_Stdcall.Expected:True;Actual:False");
            }
            //changed the value
            inner2.f1 = 1;
            inner2.f3 = "changed string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("004.02.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }
   
    // 4.3
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByValStdcallcaller_InnerArrayExplicit([In, Out] InnerArrayExplicit inner2);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByValStruct_Stdcall_InnerArrayExplicit(ByValStdcallcaller_InnerArrayExplicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_InnerArrayExplicit_Stdcall(InnerArrayExplicit iae)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Stdcall");
        try
        {
            InnerArrayExplicit source_iae = Helper.NewInnerArrayExplicit(1, 1.0F, "some string", "some string");

            if (!Helper.ValidateInnerArrayExplicit(source_iae, iae, "TestMethod_DoCallBack_MarshalStructByVal_InnerArrayExplicit_Stdcall"))
            {
                breturn = false;
                Console.WriteLine(iae.arr[0].f1);
                Console.WriteLine(iae.arr[0].f3);
                Console.WriteLine(iae.f4);
                TestFramework.LogError("004.03.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_InnerArrayExplicit_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            for (int i = 0; i < Common.NumArrElements; i++)
            {
                iae.arr[i].f1 = 1;
                iae.arr[i].f3 = "changed string";
            }

            iae.f4 = "changed string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("003.03.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }
 
    // 4.4
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByValStdcallcaller_OUTER3([In, Out] OUTER3 outer3);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByValStruct_Stdcall_OUTER3(ByValStdcallcaller_OUTER3 caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_OUTER3_Stdcall(OUTER3 outer3)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Stdcall");
        try
        {
            OUTER3 sourceOUTER3 = Helper.NewOUTER3(1, 1.0F, "some string", "some string");

            if (!Helper.ValidateOUTER3(sourceOUTER3, outer3, "TestMethod_DoCallBack_MarshalStructByVal_OUTER3_Stdcall"))
            {
                breturn = false;
                Console.WriteLine(outer3.arr[0].f1);
                Console.WriteLine(outer3.arr[0].f2);
                Console.WriteLine(outer3.arr[0].f3);
                Console.WriteLine(outer3.f4);
                TestFramework.LogError("004.04.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_OUTER3_Stdcall.Expected:True;Actual:False");
            }
            //changed the value
            for (int i = 0; i < Common.NumArrElements; i++)
            {
                outer3.arr[i].f1 = 1;
                outer3.arr[i].f2 = 1.0F;
                outer3.arr[i].f3 = "changed string";
            }

            outer3.f4 = "changed string";
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("004.04.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 4.5
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByValStdcallcaller_U([In, Out] U u);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByValStruct_Stdcall_U(ByValStdcallcaller_U caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_U_Stdcall(U u)
    {

        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Stdcall");
        try
        {
            U changeU = Helper.NewU(Int32.MinValue, UInt32.MaxValue, new IntPtr(-32), new UIntPtr(32), short.MinValue, ushort.MaxValue, byte.MinValue, 
                sbyte.MaxValue, long.MinValue, ulong.MaxValue, 32.0F, 3.2);

            if (!Helper.ValidateU(changeU, u, "TestMethod_DoCallBack_MarshalStructByVal_U_Stdcall"))
            {
                breturn = false;
                TestFramework.LogError("004.05.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_U_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            u.d = 1.23;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("004.05.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }
   
    // 4.6
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByValStdcallcaller_ByteStructPack2Explicit([In, Out] ByteStructPack2Explicit bspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByValStruct_Stdcall_ByteStructPack2Explicit(ByValStdcallcaller_ByteStructPack2Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_ByteStructPack2Explicit_Stdcall(ByteStructPack2Explicit bspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Stdcall");
        try
        {
            ByteStructPack2Explicit change_bspe = Helper.NewByteStructPack2Explicit(32, 32);

            if (!Helper.ValidateByteStructPack2Explicit(change_bspe, bspe, "TestMethod_DoCallBack_MarshalStructByVal_ByteStructPack2Explicit_Stdcall"))
            {
                breturn = false;
                TestFramework.LogError("004.06.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_ByteStructPack2Explicit_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            bspe.b1 = 64;
            bspe.b2 = 64;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("004.06.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 4.7
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByValStdcallcaller_ShortStructPack4Explicit([In, Out] ShortStructPack4Explicit sspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByValStruct_Stdcall_ShortStructPack4Explicit(ByValStdcallcaller_ShortStructPack4Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_ShortStructPack4Explicit_Stdcall(ShortStructPack4Explicit sspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Stdcall");
        try
        {
            ShortStructPack4Explicit change_sspe = Helper.NewShortStructPack4Explicit(32, 32);

            if (!Helper.ValidateShortStructPack4Explicit(change_sspe, sspe, "TestMethod_DoCallBack_MarshalStructByVal_ShortStructPack4Explicit_Stdcall"))
            {
                breturn = false;
                TestFramework.LogError("004.07.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_ShortStructPack4Explicit_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            sspe.s1 = 64;
            sspe.s2 = 64;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("004.07.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 4.8
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByValStdcallcaller_IntStructPack8Explicit([In, Out] IntStructPack8Explicit ispe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByValStruct_Stdcall_IntStructPack8Explicit(ByValStdcallcaller_IntStructPack8Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_IntStructPack8Explicit_Stdcall(IntStructPack8Explicit ispe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Stdcall");
        try
        {
            IntStructPack8Explicit change_ispe = Helper.NewIntStructPack8Explicit(32, 32);

            if (!Helper.ValidateIntStructPack8Explicit(change_ispe, ispe, "TestMethod_DoCallBack_MarshalStructByVal_IntStructPack8Explicit_Stdcall"))
            {
                breturn = false;
                TestFramework.LogError("004.08.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_IntStructPack8Explicit_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            ispe.i1 = 64;
            ispe.i2 = 64;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("004.08.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    // 4.9
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool ByValStdcallcaller_LongStructPack16Explicit([In, Out] LongStructPack16Explicit lspe);

    [DllImport("ReversePInvokeNative.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool DoCallBack_MarshalByValStruct_Stdcall_LongStructPack16Explicit(ByValStdcallcaller_LongStructPack16Explicit caller);

    public static bool TestMethod_DoCallBack_MarshalStructByVal_LongStructPack16Explicit_Stdcall(LongStructPack16Explicit lspe)
    {
        bool breturn = true;
        TestFramework.BeginScenario("Reverse,Pinvoke,By Val,Stdcall");
        try
        {
            LongStructPack16Explicit change_lspe = Helper.NewLongStructPack16Explicit(32, 32);

            if (!Helper.ValidateLongStructPack16Explicit(change_lspe, lspe, "TestMethod_DoCallBack_MarshalStructByVal_LongStructPack16Explicit_Stdcall"))
            {
                breturn = false;
                TestFramework.LogError("004.09.01", "\tFAILED! Managed to Native failed in TestMethod_DoCallBack_MarshalStructByVal_LongStructPack16Explicit_Stdcall.Expected:True;Actual:False");
            }

            //changed the value
            lspe.l1 = 64;
            lspe.l2 = 64;
        }
        catch (Exception e)
        {
            breturn = false;
            TestFramework.LogError("004.09.02", "Unexpected Exception" + e.ToString());
        }

        return breturn;
    }

    #endregion
    
    #endregion

    static int Main()
    {
        bool bresult = true;

        #region calling method

        ////Reverse Pinvoke,ByRef,cdecl
        bresult = bresult && DoCallBack_MarshalByRefStruct_Cdecl_INNER2(new ByRefCdeclcaller_INNER2(TestMethod_DoCallBack_MarshalStructByRef_INNER2_Cdecl));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Cdecl_InnerExplicit(new ByRefCdeclcaller_InnerExplicit(TestMethod_DoCallBack_MarshalStructByRef_InnerExplicit_Cdecl));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Cdecl_InnerArrayExplicit(new ByRefCdeclcaller_InnerArrayExplicit(TestMethod_DoCallBack_MarshalStructByRef_InnerArrayExplicit_Cdecl));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Cdecl_OUTER3(new ByRefCdeclcaller_OUTER3(TestMethod_DoCallBack_MarshalStructByRef_OUTER3_Cdecl));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Cdecl_U(new ByRefCdeclcaller_U(TestMethod_DoCallBack_MarshalStructByRef_U_Cdecl));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Cdecl_ByteStructPack2Explicit(new ByRefCdeclcaller_ByteStructPack2Explicit(TestMethod_DoCallBack_MarshalStructByRef_ByteStructPack2Explicit_Cdecl));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Cdecl_ShortStructPack4Explicit(new ByRefCdeclcaller_ShortStructPack4Explicit(TestMethod_DoCallBack_MarshalStructByRef_ShortStructPack4Explicit_Cdecl));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Cdecl_IntStructPack8Explicit(new ByRefCdeclcaller_IntStructPack8Explicit(TestMethod_DoCallBack_MarshalStructByRef_IntStructPack8Explicit_Cdecl));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Cdecl_LongStructPack16Explicit(new ByRefCdeclcaller_LongStructPack16Explicit(TestMethod_DoCallBack_MarshalStructByRef_LongStructPack16Explicit_Cdecl));
        
        ////Reverse Pinvoke,ByRef,StdCall
        bresult = bresult && DoCallBack_MarshalByRefStruct_Stdcall_INNER2(new ByRefStdcallcaller_INNER2(TestMethod_DoCallBack_MarshalStructByRef_INNER2_Stdcall));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Stdcall_InnerExplicit(new ByRefStdcallcaller_InnerExplicit(TestMethod_DoCallBack_MarshalStructByRef_InnerExplicit_Stdcall));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Stdcall_InnerArrayExplicit(new ByRefStdcallcaller_InnerArrayExplicit(TestMethod_DoCallBack_MarshalStructByRef_InnerArrayExplicit_Stdcall));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Stdcall_OUTER3(new ByRefStdcallcaller_OUTER3(TestMethod_DoCallBack_MarshalStructByRef_OUTER3_Stdcall));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Stdcall_U(new ByRefStdcallcaller_U(TestMethod_DoCallBack_MarshalStructByRef_U_Stdcall));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Stdcall_ByteStructPack2Explicit(new ByRefStdcallcaller_ByteStructPack2Explicit(TestMethod_DoCallBack_MarshalStructByRef_ByteStructPack2Explicit_Stdcall));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Stdcall_ShortStructPack4Explicit(new ByRefStdcallcaller_ShortStructPack4Explicit(TestMethod_DoCallBack_MarshalStructByRef_ShortStructPack4Explicit_Stdcall));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Stdcall_IntStructPack8Explicit(new ByRefStdcallcaller_IntStructPack8Explicit(TestMethod_DoCallBack_MarshalStructByRef_IntStructPack8Explicit_Stdcall));
        bresult = bresult && DoCallBack_MarshalByRefStruct_Stdcall_LongStructPack16Explicit(new ByRefStdcallcaller_LongStructPack16Explicit(TestMethod_DoCallBack_MarshalStructByRef_LongStructPack16Explicit_Stdcall));

        ////Reverse Pinvoke,ByVal,cdecl
        bresult = bresult && DoCallBack_MarshalByValStruct_Cdecl_INNER2(new ByValCdeclcaller_INNER2(TestMethod_DoCallBack_MarshalStructByVal_INNER2_Cdecl));
        bresult = bresult && DoCallBack_MarshalByValStruct_Cdecl_InnerExplicit(new ByValCdeclcaller_InnerExplicit(TestMethod_DoCallBack_MarshalStructByVal_InnerExplicit_Cdecl));
        bresult = bresult && DoCallBack_MarshalByValStruct_Cdecl_InnerArrayExplicit(new ByValCdeclcaller_InnerArrayExplicit(TestMethod_DoCallBack_MarshalStructByVal_InnerArrayExplicit_Cdecl));
        bresult = bresult && DoCallBack_MarshalByValStruct_Cdecl_OUTER3(new ByValCdeclcaller_OUTER3(TestMethod_DoCallBack_MarshalStructByVal_OUTER3_Cdecl));
        bresult = bresult && DoCallBack_MarshalByValStruct_Cdecl_U(new ByValCdeclcaller_U(TestMethod_DoCallBack_MarshalStructByVal_U_Cdecl));
        bresult = bresult && DoCallBack_MarshalByValStruct_Cdecl_ByteStructPack2Explicit(new ByValCdeclcaller_ByteStructPack2Explicit(TestMethod_DoCallBack_MarshalStructByVal_ByteStructPack2Explicit_Cdecl));
        bresult = bresult && DoCallBack_MarshalByValStruct_Cdecl_ShortStructPack4Explicit(new ByValCdeclcaller_ShortStructPack4Explicit(TestMethod_DoCallBack_MarshalStructByVal_ShortStructPack4Explicit_Cdecl));
        bresult = bresult && DoCallBack_MarshalByValStruct_Cdecl_IntStructPack8Explicit(new ByValCdeclcaller_IntStructPack8Explicit(TestMethod_DoCallBack_MarshalStructByVal_IntStructPack8Explicit_Cdecl));
        bresult = bresult && DoCallBack_MarshalByValStruct_Cdecl_LongStructPack16Explicit(new ByValCdeclcaller_LongStructPack16Explicit(TestMethod_DoCallBack_MarshalStructByVal_LongStructPack16Explicit_Cdecl));

        ////Reverse Pinvoke,ByVal,stdcall
        bresult = bresult && DoCallBack_MarshalByValStruct_Stdcall_INNER2(new ByValStdcallcaller_INNER2(TestMethod_DoCallBack_MarshalStructByVal_INNER2_Stdcall));
        bresult = bresult && DoCallBack_MarshalByValStruct_Stdcall_InnerExplicit(new ByValStdcallcaller_InnerExplicit(TestMethod_DoCallBack_MarshalStructByVal_InnerExplicit_Stdcall));
        bresult = bresult && DoCallBack_MarshalByValStruct_Stdcall_InnerArrayExplicit(new ByValStdcallcaller_InnerArrayExplicit(TestMethod_DoCallBack_MarshalStructByVal_InnerArrayExplicit_Stdcall));
        bresult = bresult && DoCallBack_MarshalByValStruct_Stdcall_OUTER3(new ByValStdcallcaller_OUTER3(TestMethod_DoCallBack_MarshalStructByVal_OUTER3_Stdcall));
        bresult = bresult && DoCallBack_MarshalByValStruct_Stdcall_U(new ByValStdcallcaller_U(TestMethod_DoCallBack_MarshalStructByVal_U_Stdcall));
        bresult = bresult && DoCallBack_MarshalByValStruct_Stdcall_ByteStructPack2Explicit(new ByValStdcallcaller_ByteStructPack2Explicit(TestMethod_DoCallBack_MarshalStructByVal_ByteStructPack2Explicit_Stdcall));
        bresult = bresult && DoCallBack_MarshalByValStruct_Stdcall_ShortStructPack4Explicit(new ByValStdcallcaller_ShortStructPack4Explicit(TestMethod_DoCallBack_MarshalStructByVal_ShortStructPack4Explicit_Stdcall));
        bresult = bresult && DoCallBack_MarshalByValStruct_Stdcall_IntStructPack8Explicit(new ByValStdcallcaller_IntStructPack8Explicit(TestMethod_DoCallBack_MarshalStructByVal_IntStructPack8Explicit_Stdcall));
        bresult = bresult && DoCallBack_MarshalByValStruct_Stdcall_LongStructPack16Explicit(new ByValStdcallcaller_LongStructPack16Explicit(TestMethod_DoCallBack_MarshalStructByVal_LongStructPack16Explicit_Stdcall));
       
        #endregion

        if (bresult)
        {
            Console.WriteLine("Sucessed!");
        }
        else
        {
            Console.WriteLine("Failed!");
        }

        return bresult ? 100 : 101;
    }
}