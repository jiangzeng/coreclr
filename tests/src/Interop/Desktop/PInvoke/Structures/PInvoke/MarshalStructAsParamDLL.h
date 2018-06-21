#include <stdlib.h>
#include <stdio.h>
#include <windows.h>
#include <string.h>
#include <errno.h>
#include <tchar.h>
#include <memory.h>
#include <wchar.h>
#include <OleAuto.h>

const int NumArrElements = 2;

struct InnerSequential
{
    int f1;
    float f2;
    BSTR f3;
};

void PrintInnerSequential(InnerSequential* p, char* name)
{
    printf("\t%s.f1 = %d\n", name, p->f1);
    printf("\t%s.f2 = %f\n", name, p->f2);
    printf("\t%s.f3 = %s\n", name, p->f3);
}

void ChangeInnerSequential(InnerSequential* p)
{
    p->f1 = 77;
    p->f2 = 77.0;
    ::SysFreeString(p->f3); 
    p->f3 = SysAllocString(L"changed string");
}

bool IsCorrectInnerSequential(InnerSequential* p)
{
    if(p->f1 != 1)
        return false;
    if(p->f2 != 1.0)
        return false;
    if(memcmp(p->f3, L"some string",11) != 0 )
        return false;
    return true;
}

struct InnerExplicit1 
{
    INT f1;
    FLOAT f2;
    BSTR f3;
};

void ChangeInnerExplicit1(InnerExplicit1* p)
{
    p->f1 = 77;
    p->f2 = 77.0;
    ::SysFreeString(p->f3); 
    p->f3 = SysAllocString(L"changed string");
}

void PrintInnerExplicit1(InnerExplicit1* p, char* name)
{
    printf("\t%s.f1 = %d\n", name, p->f1);
    printf("\t%s.f2 = %f\n", name, p->f2);
    printf("\t%s.f3 = %s\n", name, p->f3);
}

bool IsCorrectInnerExplicit1(InnerExplicit1* p)
{
    if(p->f1 != 1)
        return false;
    if(p->f2 != 1.0)
        return false;
    if(memcmp(p->f3, L"some string",11) != 0 )
        return false;
    return true;
}

struct InnerExplicit2  
{
    int f1;
    float f2;
    BSTR f3;
};

void PrintInnerExplicit2(InnerExplicit2* p, char* name)
{
    printf("\t%s.f1 = %d\n", name, p->f1);
    printf("\t%s.f2 = %f\n", name, p->f2);
    printf("\t%s.f3 = %s\n", name, p->f3);
}

struct InnerArraySequential
{
    InnerSequential arr[NumArrElements];
};

void PrintInnerArraySequential(InnerArraySequential* p, char* name)
{
    for(int i = 0; i < NumArrElements; i++)
    {
        printf("\t%s.arr[%d].f1 = %d\n", name, i, (p->arr)[i].f1);
        printf("\t%s.arr[%d].f2 = %f\n", name, i, (p->arr)[i].f2);
        printf("\t%s.arr[%d].f3 = %S\n", name, i, (p->arr)[i].f3);
    }
}

void ChangeInnerArraySequential(InnerArraySequential* p)
{
    for(int i = 0; i < NumArrElements; i++)
    {
        (p->arr)[i].f1 = 77;
        (p->arr)[i].f2 = 77.0;
        ::SysFreeString((p->arr)[i].f3); 
        (p->arr)[i].f3 = SysAllocString(L"changed string");
    }
}

bool IsCorrectInnerArraySequential(InnerArraySequential* p)
{
    for(int i = 0; i < NumArrElements; i++)
    {
        if( (p->arr)[i].f1 != 1 )
            return false;
        if( (p->arr)[i].f2 != 1.0 )
            return false;
        if( memcmp((p->arr)[i].f3, L"some string",11) != 0 )
            return false;
    }
    return true;
}

struct InnerArrayExplicit1 
{
    struct InnerSequential arr[2];
#ifndef _WIN64
    char padding[8];
#endif
    BSTR f4;
};


struct InnerArrayExplicit2 
{   
    struct InnerSequential arr[2];
#ifndef _WIN64
    char padding[8];
#endif
    BSTR f4;
};

void PrintInnerArrayExplicit2(InnerArrayExplicit2* p, char* name)
{
    for(int i = 0; i < NumArrElements; i++)
    {
        printf("\t%s.arr[%d].f1 = %d\n", name, i, (p->arr)[i].f1);
        printf("\t%s.arr[%d].f2 = %f\n", name, i, (p->arr)[i].f2);
        printf("\t%s.arr[%d].f3 = %S\n", name, i, (p->arr)[i].f3);
    }
    printf("\t%s.f4 = %s\n",name,p->f4);
}

void ChangeInnerArrayExplicit2(InnerArrayExplicit2* p)
{
    for(int i = 0; i < NumArrElements; i++)
    {
        (p->arr)[i].f1 = 77;
        (p->arr)[i].f2 = 77.0;
        ::SysFreeString((p->arr)[i].f3); 
        (p->arr)[i].f3 = SysAllocString(L"changed string");
    }
    ::SysFreeString(p->f4); 
    p->f4 = SysAllocString(L"changed string");
}

bool IsCorrectInnerArrayExplicit2(InnerArrayExplicit2* p)
{
    for(int i = 0; i < NumArrElements; i++)
    {
        if( (p->arr)[i].f1 != 1 )
            return false;
        if( (p->arr)[i].f2 != 1.0 )
            return false;
        if( memcmp((p->arr)[i].f3, L"some string",11) != 0 )
            return false;
    }
    return true;
}

struct CharSetAnsiSequential
{
    LPCSTR f1;
    CHAR f2;
};

void PrintCharSetAnsiSequential(CharSetAnsiSequential* p, char* name)
{
    printf("\t%s.f1 = %s\n", name, p->f1);
    printf("\t%s.f2 = %c\n", name, p->f2);
}

void ChangeCharSetAnsiSequential(CharSetAnsiSequential* p)
{
    char* strSource = "change string";
    size_t len = strlen(strSource);
    LPCSTR temp = (LPCSTR)CoTaskMemAlloc(sizeof(char)*(len + 1));
    if(temp != NULL)
    {
        strcpy_s((char*)temp, len + 1, strSource);
        CoTaskMemFree((void*) p->f1);
        p->f1 = temp;
        p->f2 = 'n';
    }
    else
    {
        printf("Memory Allocated Failed!");
    }
}

bool IsCorrectCharSetAnsiSequential(CharSetAnsiSequential* p)
{
    if(strcmp(p->f1, "some string") != 0 )
        return false;
    if(p->f2 != 'c')
        return false;
    return true;
}

struct CharSetUnicodeSequential 
{
    LPCWSTR f1;
    WCHAR f2;
};

void PrintCharSetUnicodeSequential(CharSetUnicodeSequential* p, char* name)
{
    printf("\t%s.f1 = %s\n", name, p->f1);
    printf("\t%s.f2 = %c\n", name, p->f2);
}

void ChangeCharSetUnicodeSequential(CharSetUnicodeSequential* p)
{
    wchar_t* strSource = L"change string";
    size_t len = wcslen(strSource);
    LPCWSTR temp = (LPCWSTR)CoTaskMemAlloc(sizeof(wchar_t)*(len + 1));
    if(temp != NULL)
    {
        wcscpy_s((wchar_t*)temp, len + 1, strSource);
        CoTaskMemFree((void*) p->f1);
        p->f1 = temp;
        p->f2 = L'n';
    }
    else
    {
        printf("Memory Allocated Failed!");
    }
}

bool IsCorrectCharSetUnicodeSequential(CharSetUnicodeSequential* p)
{
    if(memcmp(p->f1, L"some string",11) != 0 )
        return false;
    if(p->f2 != L'c')
        return false;
    return true;
}

struct NumberSequential 
{
    INT i32;
    UINT ui32;
    SHORT s1;
    WORD us1;
    BYTE b;
    CHAR sb;
    SHORT i16;
    WORD ui16;
    LONG64 i64;
    ULONG64 ui64;
    FLOAT sgl;
    DOUBLE d;
};

void PrintNumberSequential(NumberSequential* str, char* name)
{
    printf("\t%s.i32 = %d\n", name, str->i32);
    printf("\t%s.ui32 = %d\n", name, str->ui32);
    printf("\t%s.s1 = %d\n", name, str->s1);
    printf("\t%s.us1 = %u\n", name, str->us1);
    printf("\t%s.b = %u\n", name, str->b);
    printf("\t%s.sb = %d\n", name, str->sb);
    printf("\t%s.i16 = %d\n", name, str->i16);
    printf("\t%s.ui16 = %u\n", name, str->ui16);
    printf("\t%s.i64 = %d\n", name, str->i64);
    printf("\t%s.ui64 = %u\n", name, str->ui64);
    printf("\t%s.sgl = %f\n", name, str->sgl);
    printf("\t%s.d = %f\n",name, str->d);
}

void ChangeNumberSequential(NumberSequential* p)
{
    p->i32 = 0;
    p->ui32 = 32;
    p->s1 = 0;
    p->us1 = 16;
    p->b = 0;
    p->sb = 8;
    p->i16 = 0;
    p->ui16 = 16;
    p->i64 = 0;
    p->ui64 = 64;
    p->sgl = 64.0;
    p->d = 6.4;
}

bool IsCorrectNumberSequential(NumberSequential* p)
{
    if(p->i32 != INT_MIN || p->ui32 != 4294967295 || p->s1 != -32768 || p->us1 != 65535 || p->b != 0 || 
        p->sb != 127 ||p->i16 != -32768 || p->ui16 != 65535 || p->i64 != _I64_MIN || 
        p->ui64 != 18446744073709551615 || (p->sgl) != 32.0 || p->d != 3.2) 
        //replaced negative literal values since C Compiler treated them as 
        //unsigned with a negative unary operator and gave a compile error
    {
        return false;
    }
    return true;
}

struct StructSeqWithArrayField // size = 1032 bytes
{
    BOOL flag;
    LPCSTR str;
    INT vals[256];
};

void PrintStructSeqWithArrayField(StructSeqWithArrayField* str, char* name)
{
    printf("\t%s.flag = %d\n", name, str->flag);
    printf("\t%s.str = %s\n", name, str->str);
    for(int i = 0; i<256 ;i++)
    {
        printf("\t%s.vals[%d] = %d\n",name,i,str->vals[i]);
    }
}

void ChangeStructSeqWithArrayField(StructSeqWithArrayField* p)
{
    p->flag = false;

    char* strSource = "change string";
    size_t len = strlen(strSource);
    LPCSTR temp = (LPCSTR)CoTaskMemAlloc(sizeof(char)*(len + 1));
    if(temp != NULL)
    {
        strcpy_s((char*)temp, len + 1, strSource);
        if(p->str != NULL)
            CoTaskMemFree((void*) p->str);
        p->str = temp;
    }
    for(int i = 1;i<257;i++)
    {
        p->vals[i-1] = i;
    }
}

bool IsCorrectStructSeqWithArrayField(StructSeqWithArrayField* p)
{
    int iflag = 0;
    if(!p->flag || strcmp(p->str,"some string") != 0)
        return false;
    for (int i = 0; i < 256; i++)
    {
        if (p->vals[i] != i)
        {
            printf("\tThe Index of %i is not expected",i);
            iflag++;
        }
    }
    if (iflag != 0)
    {
        return false;
    }
    return true;
}

struct S4 // size = 8 bytes
{
    INT age;

    LPCSTR name;
};

enum Enum1 : INT
{
    e1 = 1,
    e2 = 3 
};

struct StructSeqWithEnumField // size = 8 bytes
{
    struct S4 s4;
    Enum1 ef;
};

void PrintStructSeqWithEnumField(StructSeqWithEnumField* str, char* name)
{
    printf("\t%s.s4.age = %d", name, str->s4.age);
    printf("\t%s.s4.name = %s", name, str->s4.name);
    printf("\t%s.ef = %d", name, str->ef);
}

void ChangeStructSeqWithEnumField(StructSeqWithEnumField* str)
{
    Enum1 eInstance = e2;
    char* strSource = "change string";    
    size_t len = strlen(strSource);
    LPCSTR temp = (LPCSTR)CoTaskMemAlloc(sizeof(char)*(len + 1));
    if(temp != NULL)
    {
        strcpy_s((char*)temp, len + 1, strSource);
        CoTaskMemFree((void*) str->s4.name);
        str->s4.name = temp;
    }
    str->s4.age = 64;
    str->ef = eInstance;
}

bool IsCorrectStructSeqWithEnumField(StructSeqWithEnumField* str)
{
    Enum1 eInstance = e1;
    if(str->s4.age != 32 || strcmp(str->s4.name,"some string") != 0)
        return false;
    if(str->ef != eInstance)
    {
        return false;
    }
    return true;
}

struct StringStructSequentialAnsi // size = 8 bytes
{
    BSTR first;
    LPCSTR last;
};

void PrintStringStructSequentialAnsi(StringStructSequentialAnsi* str, char* name)
{
    printf("\t%s.first = %s\n", name, str->first);
    printf("\t%s.last = %s\n", name, str->last);
}

bool IsCorrectStringStructSequentialAnsi(StringStructSequentialAnsi* str)
{
    wchar_t strOne[512];
    char strTwo[512];
    for(int i= 0;i<512;i++)
    {
        strOne[i] = L'a';
    }
    for(int i = 0;i<512;i++)
    {
        strTwo[i] = 'b';
    }

    if(memcmp(str->first,strOne,512) != 0)
        return false;
    if(memcmp(str->last,strTwo,512)!= 0)
        return false;
    return true;
}

void ChangeStringStructSequentialAnsi(StringStructSequentialAnsi* str)
{
    wchar_t strOne[513];
    for(int i= 0;i<512;i++)
    {
        strOne[i] = L'b';
    }
    strOne[512] = '\0';
    char strTwo[513];
    for(int i = 0;i<512;i++)
    {
        strTwo[i] = 'a';
    }
    strTwo[512] = '\0';

    ::SysFreeString(str->first);
    str->first = SysAllocString(strOne);

    char* strSource = strTwo;    
    size_t len = strlen(strSource) + 1;
    LPCSTR temp = (LPCSTR)CoTaskMemAlloc(sizeof(char)*(len + 1));
    if(temp != NULL)
    {
        strcpy_s((char*)temp, len + 1, strSource);
        CoTaskMemFree((void*) str->last);
        str->last = temp;
    }
}

struct StringStructSequentialUnicode // size = 8 bytes
{
    BSTR first;
    LPCWSTR last;
};

void PrintStringStructSequentialUnicode(StringStructSequentialUnicode* str, char* name)
{
    printf("\t%s.first = %s\n", name, str->first);
    printf("\t%s.last = %s\n", name, str->last);
}

bool IsCorrectStringStructSequentialUnicode(StringStructSequentialUnicode* str)
{
    wchar_t strOne[256];
    wchar_t strTwo[256];
    for(int i= 0;i<256;i++)
    {
        strOne[i] = L'a';
    }
    for(int i = 0;i<256;i++)
    {
        strTwo[i] = L'b';
    }

    if(memcmp(str->first,strOne,256) != 0)
        return false;
    if(memcmp(str->last,strTwo,256)!= 0)
        return false;
    return true;
}

void ChangeStringStructSequentialUnicode(StringStructSequentialUnicode* str)
{
    wchar_t strOne[257];
    for(int i= 0;i<256;i++)
    {
        strOne[i] = L'b';
    }
    strOne[256] = '\0';
    wchar_t strTwo[257];
    for(int i = 0;i<256;i++)
    {
        strTwo[i] = L'a';
    }
    strTwo[256] = '\0';

    ::SysFreeString(str->first);
    str->first = SysAllocString(strOne);

    wchar_t* strSource = strTwo;    
    size_t len = wcslen(strSource) + 1;
    LPCWSTR temp = (LPCWSTR)CoTaskMemAlloc(sizeof(wchar_t)*(len + 1));
    if(temp != NULL)
    {
        wcscpy_s((wchar_t*)temp, len + 1, strSource);
        CoTaskMemFree((void*) str->last);
        str->last = temp;
    }
}

struct PritypeStructSeqWithUnmanagedType // size = 32 bytes
{
    BSTR name;
    VARIANT_BOOL gender;
    //CURRENCY wage;//In ProjectN V1, we dont support Marshal Decimal as Currency
    WORD jobNum;
    //HRESULT i32; //In ProjectN V1, we dont support MarshalAs Error 
    //HRESULT ui32;
    CHAR mySByte;
};

void PrintPritypeStructSeqWithUnmanagedType(PritypeStructSeqWithUnmanagedType* str, char* name)
{
    printf("\t%s.name = %s\n",name, str->name);
    printf("\t%s.gender = %d\n", name, str->gender);
    //printf("\t%s.wage = %f\n", name, str->wage);//In ProjectN V1, we dont support Marshal Decimal as Currency
    printf("\t%s.jobNum = %d\n",name, str->jobNum);
    //printf("\t%s.i32 = %d\n", name, str->i32); //In ProjectN V1, we dont support MarshalAs Error 
    //printf("\t%s.ui32 = %u\n", name, str->ui32);
    printf("\t%s.mySByte = %c\n", name, str->mySByte);
}

bool IsCorrectPritypeStructSeqWithUnmanagedType(PritypeStructSeqWithUnmanagedType* str)
{
    if(memcmp(str->name,L"hello",5)!= 0)
        return false;
    if(!str->gender)
        return false;
    //if(VarCyCmpR8(str->wage,128.00)!= 1)//In ProjectN V1, we dont support Marshal Decimal as Currency
    //    return false;
    if(str->jobNum != 10)
        return false;
    //if(str->i32!= 128 || str->ui32 != 128)
    //   return false;
    if(str->mySByte != 32)
        return false;
    return true;
}

void ChangePritypeStructSeqWithUnmanagedType(PritypeStructSeqWithUnmanagedType* str)
{
    CURRENCY* Csource = new CURRENCY();
    (*Csource).Hi = 2560000;
    (*Csource).Lo = 0;
    (*Csource).int64 = 2560000;

    ::SysFreeString(str->name);
    str->name = SysAllocString(L"world");

    str->gender = VARIANT_FALSE;
    //str->wage = *Csource;//In ProjectN V1, we dont support Marshal Decimal as Currency
    str->jobNum = 1;
    //str->i32 = 256; //In ProjectN V1, we dont support MarshalAs Error 
    //str->ui32 = 256;//In ProjectN V1, we dont support MarshalAs Error 
    str->mySByte = 64;
}

#pragma pack (push)
#pragma pack (8)

struct IntergerStructSequential // size = 4 bytes
{
    INT i;
};

#pragma pack (pop)

#pragma pack (push)
#pragma pack (8)

struct StructSequentialWithDelegateField;
typedef void (*TestDelegate1)(struct StructSequentialWithDelegateField myStruct);

#pragma pack (pop)

#pragma pack (push)
#pragma pack (8)

struct StructSequentialWithDelegateField // size = 8 bytes
{
    //HRESULT i32;
    TestDelegate1 myDelegate1;
};

struct IncludeOuterIntergerStructSequential1 // size = 8 bytes
{
    INT i;
    struct IntergerStructSequential s_int;
};

#pragma pack (pop)

#pragma pack (push)
#pragma pack (8)

struct IncludeOuterIntergerStructSequential // size = 8 bytes
{
    struct IncludeOuterIntergerStructSequential1 s;
};

#pragma pack (pop)

void PrintIncludeOuterIntergerStructSequential(IncludeOuterIntergerStructSequential* str, char* name)
{
    printf("\t%s.s.s_int.i = %d\n", name, str->s.s_int.i);
    printf("\t%s.s.i = %d\n", name, str->s.i);
}

bool IsCorrectIncludeOuterIntergerStructSequential(IncludeOuterIntergerStructSequential* str)
{
    if(str->s.s_int.i != 32)
        return false;
    if(str->s.i != 32)
        return false;
    return true;
}

void ChangeIncludeOuterIntergerStructSequential(IncludeOuterIntergerStructSequential* str)
{
    str->s.s_int.i = 64;
    str->s.i = 64;
}

#pragma pack (push)
#pragma pack (8)

struct StructSequentialWithPointerField 
{
    LPINT i32;
    INT i;
};

#pragma pack (pop)

#pragma pack (push)
#pragma pack (8)

union NumberExplicit 
{
    INT i32;
    UINT ui32;
    LPVOID iPtr;
    LPVOID uiPtr;
    SHORT s;
    WORD us;
    BYTE b;
    CHAR sb;
    LONG64 l;
    ULONG64 ul;
    FLOAT f;
    DOUBLE d;
};

#pragma pack (pop)

void PrintNumberExplicit(NumberExplicit* str, char* name)
{
    printf("\t%s.i32 = %d\n", name, str->i32);
    printf("\t%s.ui32 = %u\n", name, str->ui32);
    printf("\t%s.iPtr = %d\n", name, (size_t)str->iPtr);
    printf("\t%s.uiPtr = %u\n", name, (size_t)str->uiPtr);
    printf("\t%s.s = %d\n", name, str->s);
    printf("\t%s.us = %u\n", name, str->us);
    printf("\t%s.b = %u\n", name, str->b);
    printf("\t%s.sb = %d\n", name, str->sb);
    printf("\t%s.l = %d\n", name, str->l);
    printf("\t%s.ul = %u\n", name, str->ul);
    printf("\t%s.f = %f\n", name, str->f);
    printf("\t%s.d = %f\n", name, str->d);
}
void ChangeNumberExplicit(NumberExplicit* p)
{
    p->i32 = 2147483647;
    p->ui32 = 0;
    p->iPtr = (LPVOID)(-64);
    p->uiPtr = (LPVOID)(64);
    p->s = 32767;
    p->us = 0;
    p->b = 255;
    p->sb = -128;
    p->l = 9223372036854775807;
    p->ul = 0;
    p->f = 64.0;
    p->d = 6.4;
}

bool IsCorrectNumberExplicit(NumberExplicit* p)
{
    if(p->d != 3.2)
    {
        return false;
    }
    return true;
}

struct ByteStructPack2Explicit // size = 2 bytes
{
    BYTE b1;
    BYTE b2;
};

void PrintByteStructPack2Explicit(ByteStructPack2Explicit* str, char* name)
{
    printf("\t%s.b1 = %d", name, str->b1);
    printf("\t%s.b2 = %d", name, str->b2);
}

void ChangeByteStructPack2Explicit(ByteStructPack2Explicit* p)
{
    p->b1 = 64;
    p->b2 = 64;
}

bool IsCorrectByteStructPack2Explicit(ByteStructPack2Explicit* p)
{
    if(p->b1 != 32 || p->b2 != 32)
        return false;
    return true;
}

#pragma pack (push)
#pragma pack (8)

struct ShortStructPack4Explicit // size = 4 bytes
{
    SHORT s1;
    SHORT s2;
};

#pragma pack (pop)

void PrintShortStructPack4Explicit(ShortStructPack4Explicit* str, char* name)
{
    printf("\t%s.s1 = %d", name, str->s1);
    printf("\t%s.s2 = %d", name, str->s2);
}

void ChangeShortStructPack4Explicit(ShortStructPack4Explicit* p)
{
    p->s1 = 64;
    p->s2 = 64;
}

bool IsCorrectShortStructPack4Explicit(ShortStructPack4Explicit* p)
{
    if(p->s1 != 32 || p->s2 != 32)
        return false;
    return true;
}

#pragma pack (push)
#pragma pack (8)

struct IntStructPack8Explicit // size = 8 bytes
{
    INT i1;
    INT i2;
};

#pragma pack (pop)

void PrintIntStructPack8Explicit(IntStructPack8Explicit* str, char* name)
{
    printf("\t%s.i1 = %d", name, str->i1);
    printf("\t%s.i2 = %d", name, str->i2);
}

void ChangeIntStructPack8Explicit(IntStructPack8Explicit* p)
{
    p->i1 = 64;
    p->i2 = 64;
}

bool IsCorrectIntStructPack8Explicit(IntStructPack8Explicit* p)
{
    if(p->i1 != 32 || p->i2 != 32)
        return false;
    return true;
}

#pragma pack (push)
#pragma pack (8)

struct LongStructPack16Explicit // size = 16 bytes
{
    long l1;
    char padding1[4];
    long l2;
    char padding2[4];
};

#pragma pack (pop)

void PrintLongStructPack16Explicit(LongStructPack16Explicit* str, char* name)
{
    printf("\t%s.l1 = %d", name, str->l1);
    printf("\t%s.l2 = %d", name, str->l2);
}

void ChangeLongStructPack16Explicit(LongStructPack16Explicit* p)
{
    p->l1 = 64;
    p->l2 = 64;
}

bool IsCorrectLongStructPack16Explicit(LongStructPack16Explicit* p)
{
    if(p->l1 != 32 || p->l2 != 32)
        return false;
    return true;
}

#pragma pack (push)
#pragma pack (8)

struct StringExplicit // size = 20 bytes
{
    LPCSTR str1;
#ifndef _WIN64
    char padding1[4];
#endif
    LPCTSTR str2;
#ifndef _WIN64
    char padding2[4];
#endif
    CHAR charr[10];
};

#pragma pack (pop)

void PrintStringExplicit(StringExplicit* str, char* name)
{
    printf("\t%s.str1 = %s", name, str->str1);
    printf("\t%s.str2 = %s", name, str->str2);
    wprintf(L"\t%s.charr = %s", name, str->charr);
}

void ChangeStringExplicit(StringExplicit* p)
{
    LPCSTR str1 = "Managed_LPCSTR\0";
    LPCTSTR str2 = (LPCTSTR)L"Managed_LPCSTR\0";
    size_t lenstr1 = strlen(str1);
    size_t lenstr2 = wcslen((LPWSTR)str2);

    CoTaskMemFree((LPVOID) p->str1);
    CoTaskMemFree((LPVOID) p->str2);

    p->str1 = (LPCSTR)CoTaskMemAlloc(sizeof(CHAR)*(lenstr1 + 1));
    memset((LPVOID)p->str1,'\0',lenstr1+1);
    p->str2 = (LPCTSTR)CoTaskMemAlloc(sizeof(WCHAR)*(lenstr2 + 1));    
    wmemset((LPWSTR)p->str2,L'\0',lenstr2+1);
    strcpy_s((LPSTR)p->str1, lenstr1 + 1, str1);
    strcpy_s((LPSTR)p->charr, 10, "bbbbbbbbb\0");
    wcsncpy_s((LPWSTR)p->str2, lenstr2 + 1, (LPWSTR)str2, lenstr2);
}

bool IsCorrectStringExplicit(StringExplicit* p)
{
    LPCSTR expectedstr1 = "Native_LPCSTR";
    LPCTSTR expectedstr2 = (LPCTSTR)L"Native_LPCSTR";
    LPCSTR expectedstr3 = "ggggggggg\0";

    size_t lenstr1 = strlen(p->str1);
    size_t lenexpectedrstr1 = strlen(expectedstr1);
    if((lenstr1 != lenexpectedrstr1)||(strncmp(p->str1,expectedstr1,lenstr1)!=0))
    {
        printf("Error in IsCorrectStringExplicit, values for p->str1 don't match\n");
        return false;
    }

    size_t lenstr2 = _tcslen(p->str2);
    size_t lenexpectedrstr2 = _tcslen(expectedstr2);
    if((lenstr2 != lenexpectedrstr2)||(_tcsncmp(p->str2,expectedstr2,lenstr2)!=0))
    {
        printf("Error in IsCorrectStringExplicit, values for p->str2 don't match\n");
        return false;
    }

    size_t lenstr3 = strlen(p->charr);
    size_t lenexpectedrstr3 = strlen(expectedstr3);
    if((lenstr3 != lenexpectedrstr3)||(strncmp(p->charr,expectedstr3,lenstr3)!=0))
    {
        printf("Error in IsCorrectStringExplicit, values for p->charr don't match\n");
        printf("Expected:%s\n",expectedstr3);
        printf("Actual:  %s\n",p->charr);
        return false;
    }
    return true;
}
