// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;
using System;
using System.Reflection;
using System.Text;
using CoreFXTestLibrary;

class ExactSpellingTest
{
    class Ansi
    {
        [DllImport(@"ExactSpellingNative", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern int Marshal_Int_InOut([In, Out] int intValue);

        [DllImport(@"ExactSpellingNative", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern int MarshalPointer_Int_InOut([In, Out] ref int intValue);

        [DllImport(@"ExactSpellingNative", CharSet = CharSet.Ansi, ExactSpelling = false)]
        public static extern int Marshal_Int_InOut2([In, Out] int intValue);

        [DllImport(@"ExactSpellingNative", CharSet = CharSet.Ansi, ExactSpelling = false)]
        public static extern int MarshalPointer_Int_InOut2([In, Out] ref int intValue);
    }

    class Unicode
    {
        [DllImport(@"ExactSpellingNative", CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern int Marshal_Int_InOut([In, Out] int intValue);

        [DllImport(@"ExactSpellingNative", CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern int MarshalPointer_Int_InOut([In, Out] ref int intValue);

        [DllImport(@"ExactSpellingNative", CharSet = CharSet.Unicode, ExactSpelling = false)]
        public static extern int Marshal_Int_InOut2([In, Out] int intValue);

        [DllImport(@"ExactSpellingNative", CharSet = CharSet.Unicode, ExactSpelling = false)]
        public static extern int MarshalPointer_Int_InOut2([In, Out] ref int intValue);
    }

    public static int Main(string[] args)
    {
        try{
            int intManaged = 1000;
            int intNative = 2000;
            int intReturn = 3000;
            
            Console.WriteLine("Method Unicode.Marshal_Int_InOut: ExactSpelling = true");
            int int1 = intManaged;
            int intRet1 = Unicode.Marshal_Int_InOut(int1);
            Assert.AreEqual(intReturn, intRet1, "The return value is wrong");
            Assert.AreEqual(intManaged, int1, "The parameter value is changed");
            
            Console.WriteLine("Method Unicode.MarshalPointer_Int_InOut: ExactSpelling = true");
            int int2 = intManaged;
            int intRet2 = Unicode.MarshalPointer_Int_InOut(ref int2);
            Assert.AreEqual(intReturn, intRet2, "The return value is wrong");
            Assert.AreEqual(intNative, int2, "The parameter value is wrong");

            Console.WriteLine("Method Ansi.Marshal_Int_InOut: ExactSpelling = true");
            int int3 = intManaged;
            int intRet3 = Ansi.Marshal_Int_InOut(int3);
            Assert.AreEqual(intReturn, intRet3, "The return value is wrong");
            Assert.AreEqual(intManaged, int3, "The parameter value is changed");

            Console.WriteLine("Method Ansi.MarshalPointer_Int_InOut: ExactSpelling = true");
            int int4 = intManaged;
            int intRet4 = Ansi.MarshalPointer_Int_InOut(ref int4);
            Assert.AreEqual(intReturn, intRet4, "The return value is wrong");
            Assert.AreEqual(intNative, int4, "The parameter value is changed");

            int intReturnAnsi = 4000;
            int intReturnUnicode = 5000;

            Console.WriteLine("Method Unicode.Marshal_Int_InOut2: ExactSpelling = false");
            int int5 = intManaged;
            int intRet5 = Unicode.Marshal_Int_InOut2(int5);
            Assert.AreEqual(intReturnUnicode, intRet5, "The return value is wrong");
            Assert.AreEqual(intManaged, int5, "The parameter value is changed");
            
            Console.WriteLine("Method Unicode.MarshalPointer_Int_InOut2: ExactSpelling = false");
            int int6 = intManaged;
            int intRet6 = Unicode.MarshalPointer_Int_InOut2(ref int6);
            Assert.AreEqual(intReturnUnicode, intRet6, "The return value is wrong");
            Assert.AreEqual(intNative, int6, "The parameter value is changed");

            Console.WriteLine("Method Ansi.Marshal_Int_InOut2: ExactSpelling = false");
            int int7 = intManaged;
            int intRet7 = Ansi.Marshal_Int_InOut2(int7);
            Assert.AreEqual(intReturnAnsi, intRet7, "The return value is wrong");
            Assert.AreEqual(intManaged, int7, "The parameter value is changed");

            Console.WriteLine("Method Ansi.MarshalPointer_Int_InOut2: ExactSpelling = false");
            int int8 = intManaged;
            int intRet8 = Ansi.MarshalPointer_Int_InOut2(ref int8);
            Assert.AreEqual(intReturnAnsi, intRet8, "The return value is wrong");
            Assert.AreEqual(intNative, int8, "The parameter value is changed");
            
            return 100;
        } catch (Exception e){
            Console.WriteLine($"Test Failure: {e}"); 
            return 101; 
        }
    }
}