#include <stdlib.h>
#include <stdio.h>
#include <windows.h>

#include "MarshalStructAsParamDLL.h"

///////////////////////////////////////////////////////////////////////////////////
//                            EXPORTED METHODS
///////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal(InnerSequential inner)
{
    if(!IsCorrectInnerSequential(&inner))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal: InnerSequential param not as expected\n");
        PrintInnerSequential(&inner,"inner");
        return FALSE;
    }
    inner.f1 = 77;
    inner.f2 = 77.0;
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef(InnerSequential* inner)
{
    if(!IsCorrectInnerSequential(inner))
    {
        printf("\tMarshalStructAsParam_AsSeqByRef: InnerSequential param not as expected\n");
        PrintInnerSequential(inner,"inner");
        return FALSE;
    }
    ChangeInnerSequential(inner);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn(InnerSequential* inner)
{
    if(!IsCorrectInnerSequential(inner))
    {
        printf("\tMarshalStructAsParam_AsSeqByRefIn: InnerSequential param not as expected\n");
        PrintInnerSequential(inner,"inner");
        return FALSE;
    }
    ChangeInnerSequential(inner);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut(InnerSequential inner)
{
    if(!IsCorrectInnerSequential(&inner))
    {
        printf("\tMarshalStructAsParam_AsSeqByValOut:NNER param not as expected\n");
        PrintInnerSequential(&inner,"inner");
        return FALSE;
    }
    inner.f1 = 77;
    inner.f2 = 77.0;
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut(InnerSequential* inner)
{
    //change struct
    inner->f1 = 77;
    inner->f2 = 77.0;
    inner->f3 = SysAllocString(L"changed string");
    return TRUE;
}

///////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal2(InnerArraySequential outer)
{
    if(!IsCorrectInnerArraySequential(&outer))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal2: InnerArraySequential param not as expected\n");
        PrintInnerArraySequential(&outer,"outer");
        return FALSE;
    }
    for(int i = 0; i < NumArrElements; i++)
    {
        outer.arr[i].f1 = 77;
        outer.arr[i].f2 = 77.0;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef2(InnerArraySequential* outer)
{
    if(!IsCorrectInnerArraySequential(outer))
    {
        printf("\tMarshalStructAsParam_AsSeqByRef2: InnerArraySequential param not as expected\n");
        PrintInnerArraySequential(outer,"outer");
        return FALSE;
    }
    ChangeInnerArraySequential(outer);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn2(InnerArraySequential* outer)
{
    if(!IsCorrectInnerArraySequential(outer))
    {
        printf("\tMarshalStructAsParam_AsSeqByRefIn2: InnerArraySequential param not as expected\n");
        PrintInnerArraySequential(outer,"inner");
        return FALSE;
    }
    ChangeInnerArraySequential(outer);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut2(InnerArraySequential outer)
{
    if(!IsCorrectInnerArraySequential(&outer))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal2:InnerArraySequential param not as expected\n");
        PrintInnerArraySequential(&outer,"outer");
        return FALSE;
    }
    for(int i = 0; i < NumArrElements; i++)
    {
        outer.arr[i].f1 = 77;
        outer.arr[i].f2 = 77.0;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut2(InnerArraySequential* outer)
{
    for(int i = 0;i<NumArrElements;i++)
    {
        if(outer->arr[i].f1 != 0 || outer->arr[i].f2 != 0.0)
        {
            printf("\tMarshalStructAsParam_AsSeqByRefOut2: InnerArraySequential param not as expected\n");
            return FALSE;
        }
    }
    ChangeInnerArraySequential(outer);
    return TRUE;
}

////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal3(CharSetAnsiSequential str1)
{
    if(!IsCorrectCharSetAnsiSequential(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal3:strCharStr param not as expected\n");
        PrintCharSetAnsiSequential(&str1,"CharSetAnsiSequential");
        return FALSE;
    }
    str1.f2 = 'n';
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef3(CharSetAnsiSequential* str1)
{
    if(!IsCorrectCharSetAnsiSequential(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRef3:strCharStr param not as expected\n");
        PrintCharSetAnsiSequential(str1,"CharSetAnsiSequential");
        return FALSE;
    }
    ChangeCharSetAnsiSequential(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn3(CharSetAnsiSequential* str1)
{
    if(!IsCorrectCharSetAnsiSequential(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRefIn3:strCharStr param not as expected\n");
        PrintCharSetAnsiSequential(str1,"CharSetAnsiSequential");
        return FALSE;
    }
    ChangeCharSetAnsiSequential(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut3(CharSetAnsiSequential str1)
{
    if(!IsCorrectCharSetAnsiSequential(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal3:strCharStr param not as expected\n");
        PrintCharSetAnsiSequential(&str1,"CharSetAnsiSequential");
        return FALSE;
    }
    str1.f2 = 'n';
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut3(CharSetAnsiSequential* str1)
{
    char* strSource = "change string";
    int len = strlen(strSource);
    LPCSTR temp = (LPCSTR)CoTaskMemAlloc(sizeof(char)*(len + 1));
    if(temp != NULL)
    {
        strcpy_s((char*)temp,len + 1,strSource);
        CoTaskMemFree((void*)(str1->f1));
        str1->f1 = temp;
        str1->f2 = 'n';
        return TRUE;
    }
    else
    {
        printf("Memory Allocated Failed !");
        return FALSE;
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal4(CharSetUnicodeSequential str1)
{
    if(!IsCorrectCharSetUnicodeSequential(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal4:CharSetUnicodeSequential param not as expected\n");
        PrintCharSetUnicodeSequential(&str1,"CharSetUnicodeSequential");
        return FALSE;
    }
    str1.f2 = L'n';
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef4(CharSetUnicodeSequential* str1)
{
    if(!IsCorrectCharSetUnicodeSequential(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRef4:strCharStr param not as expected\n");
        PrintCharSetUnicodeSequential(str1,"CharSetUnicodeSequential");
        return FALSE;
    }
    ChangeCharSetUnicodeSequential(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn4(CharSetUnicodeSequential* str1)
{
    if(!IsCorrectCharSetUnicodeSequential(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRefIn4:strCharStr param not as expected\n");
        PrintCharSetUnicodeSequential(str1,"CharSetUnicodeSequential");
        return FALSE;
    }
    ChangeCharSetUnicodeSequential(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut4(CharSetUnicodeSequential str1)
{
    if(!IsCorrectCharSetUnicodeSequential(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal4:strCharStrOut2 param not as expected\n");
        PrintCharSetUnicodeSequential(&str1,"CharSetUnicodeSequential");
        return FALSE;
    }
    str1.f2 = L'n';
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut4(CharSetUnicodeSequential* str1)
{
    wchar_t* strSource = L"change string";
    int len = wcslen(strSource);
    LPCWSTR temp = (LPCWSTR)CoTaskMemAlloc(sizeof(wchar_t)*(len + 1));
    if(temp != NULL)
    {
        wcscpy_s((wchar_t*)temp,len + 1,strSource);
        CoTaskMemFree((void*)(str1->f1));
        str1->f1 = temp;
        str1->f2 = L'n';
        return TRUE;
    }
    else
    {
        printf("Memory Allocated Failed !");
        return FALSE;
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal6(NumberSequential str1)
{
    if(!IsCorrectNumberSequential(&str1))
    {
        printf("\tManaged to Native failed in MarshalStructAsParam_AsSeqByVal6:NumberSequential param not as expected\n");
        PrintNumberSequential(&str1, "str1");
        return FALSE;
    }
    ChangeNumberSequential(&str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef6(NumberSequential* str1)
{
    if(!IsCorrectNumberSequential(str1))
    {
        printf("\tManaged to Native failed in MarshalStructAsParam_AsSeqByRef6:NumberSequential param not as expected\n");
        PrintNumberSequential(str1, "str1");
        return FALSE;
    }
    ChangeNumberSequential(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn6(NumberSequential* str1)
{
    if(!IsCorrectNumberSequential(str1))
    {
        printf("\tManaged to Native failed in MarshalStructAsParam_AsSeqByRefIn6:NumberSequential param not as expected\n");
        PrintNumberSequential(str1, "str1");
        return FALSE;
    }
    ChangeNumberSequential(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut6(NumberSequential str1)
{
    if(!IsCorrectNumberSequential(&str1))
    {
        printf("\tManaged to Native failed in MarshalStructAsParam_AsSeqByValOut6:NumberSequential param not as expected\n");
        PrintNumberSequential(&str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut6(NumberSequential* str1)
{
    ChangeNumberSequential(str1);
    return TRUE;
}

////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal7(StructSeqWithArrayField str1)
{
    if(!IsCorrectStructSeqWithArrayField(&str1))
    {
        printf("\tManaged to Native failed in MarshalStructAsParam_AsSeqByVal7:StructSeqWithArrayField param not as expected\n");
        PrintStructSeqWithArrayField(&str1, "str1");
        return FALSE;
    }
    str1.flag = false;
    return TRUE;

}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef7(StructSeqWithArrayField* str1)
{
    if(!IsCorrectStructSeqWithArrayField(str1))
    {
        printf("\tManaged to Native failed in MarshalStructAsParam_AsSeqByRef7:StructSeqWithArrayField param not as expected\n");
        PrintStructSeqWithArrayField(str1, "str1");
        return FALSE;
    }
    ChangeStructSeqWithArrayField(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn7(StructSeqWithArrayField* str1)
{
    if(!IsCorrectStructSeqWithArrayField(str1))
    {
        printf("\tManaged to Native failed in MarshalStructAsParam_AsSeqByRef7:StructSeqWithArrayField param not as expected\n");
        PrintStructSeqWithArrayField(str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut7(StructSeqWithArrayField str1)
{
    if(!IsCorrectStructSeqWithArrayField(&str1))
    {
        printf("\tManaged to Native failed in MarshalStructAsParam_AsSeqByValOut7:StructSeqWithArrayField param not as expected\n");
        PrintStructSeqWithArrayField(&str1, "str1");
        return FALSE;
    }
    str1.flag = false;
    return TRUE;

}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut7(StructSeqWithArrayField* str1)
{
    ChangeStructSeqWithArrayField(str1);
    return TRUE;
}

////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal8(StructSeqWithEnumField str1)
{
    if(!IsCorrectStructSeqWithEnumField(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal8:StructSeqWithEnumField param not as expected\n");
        PrintStructSeqWithEnumField(&str1, "str1");
        return FALSE;
    }
    // can not change anything in this struct because it is pass by value from managed side
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef8(StructSeqWithEnumField* str1)
{
    if(!IsCorrectStructSeqWithEnumField(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRef8:StructSeqWithEnumField param not as expected\n");
        PrintStructSeqWithEnumField(str1, "str1");
        return FALSE;
    }
    ChangeStructSeqWithEnumField(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn8(StructSeqWithEnumField* str1)
{
    if(!IsCorrectStructSeqWithEnumField(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRefIn8:StructSeqWithEnumField param not as expected\n");
        PrintStructSeqWithEnumField(str1, "str1");
        return FALSE;
    }
    ChangeStructSeqWithEnumField(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut8(StructSeqWithEnumField* str1)
{
    ChangeStructSeqWithEnumField(str1);
    return TRUE;
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal9(StringStructSequentialAnsi str1)
{
    if(!IsCorrectStringStructSequentialAnsi(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal9:StringStructSequentialAnsi param not as expected\n");
        PrintStringStructSequentialAnsi(&str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef9(StringStructSequentialAnsi* str1)
{
    if(!IsCorrectStringStructSequentialAnsi(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRef9:StringStructSequentialAnsi param not as expected\n");
        PrintStringStructSequentialAnsi(str1, "str1");
        return FALSE;
    }
    ChangeStringStructSequentialAnsi(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn9(StringStructSequentialAnsi* str1)
{
    if(!IsCorrectStringStructSequentialAnsi(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRefIn9:StringStructSequentialAnsi param not as expected\n");
        PrintStringStructSequentialAnsi(str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut9(StringStructSequentialAnsi str1)
{
    if(!IsCorrectStringStructSequentialAnsi(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal9:StringStructSequentialAnsi param not as expected\n");
        PrintStringStructSequentialAnsi(&str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut9(StringStructSequentialAnsi* str1)
{
    ChangeStringStructSequentialAnsi(str1);
    return TRUE;
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal10(StringStructSequentialUnicode str1)
{
    if(!IsCorrectStringStructSequentialUnicode(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal10:StringStructSequentialUnicode param not as expected\n");
        PrintStringStructSequentialUnicode(&str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef10(StringStructSequentialUnicode* str1)
{
    if(!IsCorrectStringStructSequentialUnicode(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRef10:StringStructSequentialUnicode param not as expected\n");
        PrintStringStructSequentialUnicode(str1, "str1");
        return FALSE;
    }
    ChangeStringStructSequentialUnicode(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn10(StringStructSequentialUnicode* str1)
{
    if(!IsCorrectStringStructSequentialUnicode(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRefIn10:StringStructSequentialUnicode param not as expected\n");
        PrintStringStructSequentialUnicode(str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut10(StringStructSequentialUnicode str1)
{
    if(!IsCorrectStringStructSequentialUnicode(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByValOut10:StringStructSequentialUnicode param not as expected\n");
        PrintStringStructSequentialUnicode(&str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut10(StringStructSequentialUnicode* str1)
{
    ChangeStringStructSequentialUnicode(str1);

    return TRUE;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal11(PritypeStructSeqWithUnmanagedType str1)
{
    if(!IsCorrectPritypeStructSeqWithUnmanagedType(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal11:PritypeStructSeqWithUnmanagedType param not as expected\n");
        PrintPritypeStructSeqWithUnmanagedType(&str1,"str1");
        return FALSE;
    }
    //str1.i32 = 256;
    //str1.ui32 = 256;
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef11(PritypeStructSeqWithUnmanagedType* str1)
{
    if(!IsCorrectPritypeStructSeqWithUnmanagedType(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRef11:PritypeStructSeqWithUnmanagedType param not as expected\n");
        PrintPritypeStructSeqWithUnmanagedType(str1,"str1");
        return FALSE;
    }
    ChangePritypeStructSeqWithUnmanagedType(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn11(PritypeStructSeqWithUnmanagedType* str1)
{
    if(!IsCorrectPritypeStructSeqWithUnmanagedType(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRefIn11:PritypeStructSeqWithUnmanagedType param not as expected\n");
        PrintPritypeStructSeqWithUnmanagedType(str1,"str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut11(PritypeStructSeqWithUnmanagedType str1)
{
    if(!IsCorrectPritypeStructSeqWithUnmanagedType(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByValOut11:PritypeStructSeqWithUnmanagedType param not as expected\n");
        PrintPritypeStructSeqWithUnmanagedType(&str1,"str1");
        return FALSE;
    }
    //str1.i32 = 256;
    //str1.ui32 = 256;
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut11(PritypeStructSeqWithUnmanagedType* str1)
{
    ChangePritypeStructSeqWithUnmanagedType(str1);

    return TRUE;
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) void NtestMethod(StructSequentialWithDelegateField str1)
{
    printf("\tAction of the delegate");
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal12(StructSequentialWithDelegateField str1)
{
    if(/*str1.i32 != 128 ||*/
        str1.myDelegate1 == NULL)
    {
        return FALSE;
    }
    //str1.i32 = 256;
    str1.myDelegate1 = NULL;
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef12(StructSequentialWithDelegateField* str1)
{
    if(/*str1->i32 != 128 ||*/
        str1->myDelegate1 == NULL)
    {
        return FALSE;
    }
    else
    {
        //str1->i32 = 256;
        str1->myDelegate1 = NULL;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn12(StructSequentialWithDelegateField* str1)
{
    if( /* str1->i32 != 128 ||*/
        str1->myDelegate1 == NULL)
    {
        return FALSE;
    }
    else
    {
        //str1->i32 = 256;
        str1->myDelegate1 = NULL;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut12(StructSequentialWithDelegateField str1)
{
    if(/*str1.i32 != 128 ||*/
        str1.myDelegate1 == NULL)
    {
        return FALSE;
    }
    //str1.i32 = 256;
    str1.myDelegate1 = NULL;
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut12(StructSequentialWithDelegateField* str1)
{
    //str1->i32 = 256;
    str1->myDelegate1 = NtestMethod;
    return TRUE;
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal13(IncludeOuterIntergerStructSequential str1)
{
    if(!IsCorrectIncludeOuterIntergerStructSequential(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal13:IncludeOuterIntergerStructSequential param not as expected\n");
        PrintIncludeOuterIntergerStructSequential(&str1, "str1");
        return FALSE;
    }
    str1.s.i = 64;
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef13(IncludeOuterIntergerStructSequential* str1)
{
    if(!IsCorrectIncludeOuterIntergerStructSequential(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRef13:IncludeOuterIntergerStructSequential param not as expected\n");
        PrintIncludeOuterIntergerStructSequential(str1, "str1");
        return FALSE;
    }
    ChangeIncludeOuterIntergerStructSequential(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn13(IncludeOuterIntergerStructSequential* str1)
{
    if(!IsCorrectIncludeOuterIntergerStructSequential(str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByRefIn13:IncludeOuterIntergerStructSequential param not as expected\n");
        PrintIncludeOuterIntergerStructSequential(str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut13(IncludeOuterIntergerStructSequential str1)
{
    if(!IsCorrectIncludeOuterIntergerStructSequential(&str1))
    {
        printf("\tMarshalStructAsParam_AsSeqByValOut13:IncludeOuterIntergerStructSequential param not as expected\n");
        PrintIncludeOuterIntergerStructSequential(&str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut13(IncludeOuterIntergerStructSequential* str1)
{
    ChangeIncludeOuterIntergerStructSequential(str1);

    return TRUE;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByVal14(StructSequentialWithPointerField str1)
{
    if(str1.i32 != (LPINT)(16) || str1.i != 32)
        return FALSE;
    str1.i = 64;
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRef14(StructSequentialWithPointerField* str1)
{
    if(str1->i32 != (LPINT)(16) || str1->i != 32)
        return FALSE;
    else
    {
        str1->i32 = (LPINT)(str1->i);
        str1->i = 64;
        return TRUE;
    }
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefIn14(StructSequentialWithPointerField* str1)
{
    if(str1->i32 != (LPINT)(16) || str1->i != 32)
        return FALSE;
    else
    {
        str1->i32 = (LPINT)(str1->i);
        str1->i = 64;
        return TRUE;
    }
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByValOut14(StructSequentialWithPointerField str1)
{
    if(str1.i32 != (LPINT)(16) || str1.i != 32)
        return FALSE;
    str1.i = 64;
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsSeqByRefOut14(StructSequentialWithPointerField* str1)
{
    str1->i32 = (LPINT)(str1->i);
    str1->i = 64;
    return TRUE;
}

////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByValInnerExplicit1(InnerExplicit1 inner)
{
    if(!IsCorrectInnerExplicit1(&inner))
    {
        printf("\tMarshalStructAsParam_AsSeqByVal: InnerSequential param not as expected\n");
        PrintInnerExplicit1(&inner,"inner");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInnerExplicit1(InnerExplicit1* inner)
{
    if(!IsCorrectInnerExplicit1(inner))
    {
        printf("\tMarshalStructAsParam_AsSeqByRef: InnerSequential param not as expected\n");
        PrintInnerExplicit1(inner,"inner");
        return FALSE;
    }
    ChangeInnerExplicit1(inner);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInInnerExplicit1(InnerExplicit1* inner)
{
    if(!IsCorrectInnerExplicit1(inner))
    {
        printf("\tMarshalStructAsParam_AsSeqByRefIn: InnerSequential param not as expected\n");
        PrintInnerExplicit1(inner,"inner");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByValOutInnerExplicit1(InnerExplicit1 inner)
{
    if(!IsCorrectInnerExplicit1(&inner))
    {
        printf("\tMarshalStructAsParam_AsSeqByValOut:NNER param not as expected\n");
        PrintInnerExplicit1(&inner,"inner");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefOutInnerExplicit1(InnerExplicit1* inner)
{
    //change struct
    inner->f1 = 77;
    inner->f2 = 77.0;
    inner->f3 = SysAllocString(L"changed string");
    return TRUE;
}

///////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByValInnerExplicit2(InnerExplicit2 inner)
{
    if((&inner)->f1 != 1 || memcmp((&inner)->f3, L"some string",11) != 0)
    {
        printf("\tMarshalStructAsParam_AsExpByVal: InnerSequential param not as expected\n");
        PrintInnerExplicit2(&inner,"inner");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInnerExplicit2(InnerExplicit2* inner)
{
    if(inner->f1 != 1 || memcmp(inner->f3, L"some string",11) != 0)
    {
        printf("\tMarshalStructAsParam_AsExpByRef: InnerSequential param not as expected\n");
        PrintInnerExplicit2(inner,"inner");
        return FALSE;
    }
    inner->f1 = 77;
    ::SysFreeString(inner->f3); 
    inner->f3 = SysAllocString(L"changed string");
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInInnerExplicit2(InnerExplicit2* inner)
{
    if(inner->f1 != 1 || memcmp(inner->f3, L"some string",11) != 0)
    {
        printf("\tMarshalStructAsParam_AsExpByRefIn: InnerSequential param not as expected\n");
        PrintInnerExplicit2(inner,"inner");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefOutInnerExplicit2(InnerExplicit2* inner)
{
    if(inner->f1 != 0 || inner->f2 != 0.0)
    {
        printf("\tMarshalStructAsParam_AsExpByRefOut: InnerSequential param not as expected\n");
        return FALSE;
    }
    inner->f1 = 77;
    inner->f3 = SysAllocString(L"changed string");
    return TRUE;
}

//////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByValInnerArrayExplicit1(InnerArrayExplicit1 outer2)
{
    for(int i = 0;i<NumArrElements;i++)
    {
        if((&outer2)->arr[i].f1 != 1)
        {
            printf("\tMarshalStructAsParam_AsExpByVal3:InnerArrayExplicit1 param not as expected\n");
            return FALSE;
        }
    }
    if(memcmp((&outer2)->f4,L"some string2",12) != 0)
    {
        printf("\tMarshalStructAsParam_AsExpByVal3:InnerArrayExplicit1 param f4 not as expected\n");
        return FALSE;
    }

    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInnerArrayExplicit1(InnerArrayExplicit1* outer2)
{
    for(int i = 0;i<NumArrElements;i++)
    {
        if(outer2->arr[i].f1 != 1)
        {
            printf("\tMarshalStructAsParam_AsExpByRef3:InnerArrayExplicit1 param not as expected\n");
            return FALSE;
        }
    }
    if(memcmp(outer2->f4,L"some string2",12) != 0)
    {
        printf("\tMarshalStructAsParam_AsExpByRef3:InnerArrayExplicit1 param f4 not as expected\n");
        return FALSE;
    }
    for(int i =0;i<NumArrElements;i++)
    {
        outer2->arr[i].f1 = 77;
        outer2->arr[i].f2 = 77.0F;
        ::SysFreeString(outer2->arr[i].f3);
        outer2->arr[i].f3 = SysAllocString(L"change string1");
    }
    ::SysFreeString(outer2->f4);
    outer2->f4 = SysAllocString(L"change string2");
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInInnerArrayExplicit1(InnerArrayExplicit1* outer2)
{
    for(int i = 0;i<NumArrElements;i++)
    {
        if(outer2->arr[i].f1 != 1)
        {
            printf("\tMarshalStructAsParam_AsExpByRefIn3:InnerArrayExplicit1 param not as expected\n");
            return FALSE;
        }
    }
    if(memcmp(outer2->f4,L"some string2",12) != 0)
    {
        printf("\tMarshalStructAsParam_AsExpByRefIn3:InnerArrayExplicit1 param f4 not as expected\n");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefOutInnerArrayExplicit1(InnerArrayExplicit1* outer2)
{
    outer2->arr[0].f1 = 77;
    outer2->arr[0].f2 = 77.0F;
    outer2->arr[0].f3 =  SysAllocString(L"change string1");
    outer2->arr[1].f1 = 77;
    outer2->arr[1].f2 = 77.0F;
    outer2->arr[1].f3 =  SysAllocString(L"change string1");

    outer2->f4 = SysAllocString(L"change string2");
    return TRUE;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByValInnerArrayExplicit2(InnerArrayExplicit2 outer3)
{
    if(!IsCorrectInnerArrayExplicit2(&outer3))
    {
        printf("\tMarshalStructAsParam_AsExoByVal4:InnerArrayExplicit2 param not as expected\n");
        PrintInnerArrayExplicit2(&outer3,"InnerArrayExplicit2");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInnerArrayExplicit2(InnerArrayExplicit2* outer3)
{
    if(!IsCorrectInnerArrayExplicit2(outer3))
    {
        printf("\tMarshalStructAsParam_AsExoByRef4:InnerArrayExplicit2 param not as expected\n");
        PrintInnerArrayExplicit2(outer3,"InnerArrayExplicit2");
        return FALSE;
    }
    ChangeInnerArrayExplicit2(outer3);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInInnerArrayExplicit2(InnerArrayExplicit2* outer3)
{
    if(!IsCorrectInnerArrayExplicit2(outer3))
    {
        printf("\tMarshalStructAsParam_AsExoByRefIn4:InnerArrayExplicit2 param not as expected\n");
        PrintInnerArrayExplicit2(outer3,"InnerArrayExplicit2");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefOutInnerArrayExplicit2(InnerArrayExplicit2* outer3)
{
    ChangeInnerArrayExplicit2(outer3);
    return TRUE;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByValNumberExplicit(NumberExplicit str1)
{
    if(!IsCorrectNumberExplicit(&str1))
    {
        printf("\tMarshalStructAsParam_AsExpByVal6:NumberExplicit param not as expected\n");
        PrintNumberExplicit(&str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefNumberExplicit(NumberExplicit* str1)
{
    if(!IsCorrectNumberExplicit(str1))
    {
        printf("\tMarshalStructAsParam_AsExpByRef6:NumberExplicit param not as expected\n");
        PrintNumberExplicit(str1, "str1");
        return FALSE;
    }
    ChangeNumberExplicit(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInNumberExplicit(NumberExplicit* str1)
{
    if(!IsCorrectNumberExplicit(str1))
    {
        printf("\tMarshalStructAsParam_AsExpByRefIn6:NumberExplicit param not as expected\n");
        PrintNumberExplicit(str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefOutNumberExplicit(NumberExplicit* str1)
{
    ChangeNumberExplicit(str1);

    return TRUE;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByValByteStructPack2Explicit(ByteStructPack2Explicit str1)
{
    if(!IsCorrectByteStructPack2Explicit(&str1))
    {
        printf("\tMarshalStructAsParam_AsExpByVal7:ByteStructPack2Explicit param not as expected\n");
        PrintByteStructPack2Explicit(&str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefByteStructPack2Explicit(ByteStructPack2Explicit* str1)
{
    if(!IsCorrectByteStructPack2Explicit(str1))
    {
        printf("\tMarshalStructAsParam_AsExpByRef7:ByteStructPack2Explicit param not as expected\n");
        PrintByteStructPack2Explicit(str1, "str1");
        return FALSE;
    }
    ChangeByteStructPack2Explicit(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInByteStructPack2Explicit(ByteStructPack2Explicit* str1)
{
    if(!IsCorrectByteStructPack2Explicit(str1))
    {
        printf("\tMarshalStructAsParam_AsExpByRefIn7:ByteStructPack2Explicit param not as expected\n");
        PrintByteStructPack2Explicit(str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefOutByteStructPack2Explicit(ByteStructPack2Explicit* str1)
{
    ChangeByteStructPack2Explicit(str1);

    return TRUE;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////
extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByValShortStructPack4Explicit(ShortStructPack4Explicit str1)
{
    if(!IsCorrectShortStructPack4Explicit(&str1))
    {
        printf("\tMarshalStructAsParam_AsExpByVal8:ShortStructPack4Explicit param not as expected\n");
        PrintShortStructPack4Explicit(&str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefShortStructPack4Explicit(ShortStructPack4Explicit* str1)
{
    if(!IsCorrectShortStructPack4Explicit(str1))
    {
        printf("\tMarshalStructAsParam_AsExpByRef8:ShortStructPack4Explicit param not as expected\n");
        PrintShortStructPack4Explicit(str1, "str1");
        return FALSE;
    }
    ChangeShortStructPack4Explicit(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInShortStructPack4Explicit(ShortStructPack4Explicit* str1)
{
    if(!IsCorrectShortStructPack4Explicit(str1))
    {
        printf("\tMarshalStructAsParam_AsExpByRefIn8:ShortStructPack4Explicit param not as expected\n");
        PrintShortStructPack4Explicit(str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefOutShortStructPack4Explicit(ShortStructPack4Explicit* str1)
{
    ChangeShortStructPack4Explicit(str1);

    return TRUE;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////
extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByValIntStructPack8Explicit(IntStructPack8Explicit str1)
{
    if(!IsCorrectIntStructPack8Explicit(&str1))
    {
        printf("\tMarshalStructAsParam_AsExpByVal9:IntStructPack8Explicit param not as expected\n");
        PrintIntStructPack8Explicit(&str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefIntStructPack8Explicit(IntStructPack8Explicit* str1)
{
    if(!IsCorrectIntStructPack8Explicit(str1))
    {
        printf("\tMarshalStructAsParam_AsExpByRef9:IntStructPack8Explicit param not as expected\n");
        PrintIntStructPack8Explicit(str1, "str1");
        return FALSE;
    }
    ChangeIntStructPack8Explicit(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInIntStructPack8Explicit(IntStructPack8Explicit* str1)
{
    if(!IsCorrectIntStructPack8Explicit(str1))
    {
        printf("\tMarshalStructAsParam_AsExpByRefIn9:IntStructPack8Explicit param not as expected\n");
        PrintIntStructPack8Explicit(str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefOutIntStructPack8Explicit(IntStructPack8Explicit* str1)
{
    ChangeIntStructPack8Explicit(str1);

    return TRUE;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////
extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByValLongStructPack16Explicit(LongStructPack16Explicit str1)
{
    if(!IsCorrectLongStructPack16Explicit(&str1))
    {
        printf("\tMarshalStructAsParam_AsExpByVal10:LongStructPack16Explicit param not as expected\n");
        PrintLongStructPack16Explicit(&str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefLongStructPack16Explicit(LongStructPack16Explicit* str1)
{
    if(!IsCorrectLongStructPack16Explicit(str1))
    {
        printf("\tMarshalStructAsParam_AsExpByRef10:LongStructPack16Explicit param not as expected\n");
        PrintLongStructPack16Explicit(str1, "str1");
        return FALSE;
    }
    ChangeLongStructPack16Explicit(str1);
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefInLongStructPack16Explicit(LongStructPack16Explicit* str1)
{
    if(!IsCorrectLongStructPack16Explicit(str1))
    {
        printf("\tMarshalStructAsParam_AsExpByRefIn10:LongStructPack16Explicit param not as expected\n");
        PrintLongStructPack16Explicit(str1, "str1");
        return FALSE;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) BOOL __stdcall MarshalStructAsParam_AsExpByRefOutLongStructPack16Explicit(LongStructPack16Explicit* str1)
{
    ChangeLongStructPack16Explicit(str1);

    return TRUE;
}

extern "C" __declspec(dllexport) BOOL WINAPI MarshalStructAsParam_AsExpByRefInOutStringExplicit(/*[in,out]*/ struct StringExplicit * str1)
{
    if(!IsCorrectStringExplicit(str1))
    {
        printf("\tMarshalStructAsParam_AsExpByRefInOutStringExplicit : StringExplicit param not as expected\n");
        PrintStringExplicit(str1,"StringExplicit");
        return FALSE;
    }
    ChangeStringExplicit(str1);
    return true;
}
