#include <stdlib.h>
#include <stdio.h>
#include <windows.h>
#include <string.h>
#include <mbstring.h>
#include <oleauto.h>

typedef struct TLPStr_Test_Struct
{
    LPSTR* pStr;
} LPStr_Test_Struct;

typedef struct TLPStr_Test_Class
{
    LPSTR* pStr;
} LPStr_Test_Class;

typedef struct TLPStrTestStructOfArrays
{
    LPSTR* pStr1;
    LPSTR* pStr2;
} LPStrTestStructOfArrays;

bool __cdecl LPStrBuffer_In_String(LPSTR pStr)
{
    printf ("xx %s \n", pStr);

    return TRUE;
}

bool __cdecl LPStrBuffer_InByRef_String(LPSTR* ppStr)
{
    printf ("yy %s \n", *ppStr);

    return TRUE;
}

bool __cdecl LPStrBuffer_InOutByRef_String(LPSTR* ppStr)
{
    printf ("zz %s \n", *ppStr);

    return TRUE;
}

bool __cdecl LPStrBuffer_In_StringBuilder(LPSTR pStr)
{
    return TRUE;
}

bool __cdecl LPStrBuffer_InByRef_StringBuilder(LPSTR* ppStr)
{
    return TRUE;
}

bool __cdecl LPStrBuffer_InOutByRef_StringBuilder(LPSTR* ppStr)
{
    return TRUE;
}

bool __cdecl LPStrBuffer_In_Struct_String (LPStr_Test_Struct strStruct)
{
    return TRUE;
}

bool __cdecl LPStrBuffer_InByRef_Struct_String (LPStr_Test_Struct* pSstrStruct)
{
    return TRUE;
}

bool __cdecl LPStrBuffer_InOutByRef_Struct_String (LPStr_Test_Struct* pStrStruct)
{
    return TRUE;
}

bool __cdecl LPStrBuffer_In_Array_String (LPSTR str[]) 
{
    printf ("%s \n", str[0]);
    printf ("%s \n", str[1]);
    printf ("%s \n", str[2]);

    return TRUE;
}

bool __cdecl LPStrBuffer_InByRef_Array_String (LPSTR* str[]) 
{
    printf ("%s \n", (*str)[0]);
    printf ("%s \n", (*str)[1]);
    printf ("%s \n", (*str)[2]);

    return TRUE;
}

bool __cdecl LPStrBuffer_InOutByRef_Array_String (LPSTR* str[]) 
{
    printf ("%s \n", (*str)[0]);
    printf ("%s \n", (*str)[1]);
    printf ("%s \n", (*str)[2]);

    return TRUE;
}

bool __cdecl LPStrBuffer_In_Class_String (LPStr_Test_Class strClass)
{
    return TRUE;
}

bool __cdecl LPStrBuffer_InByRef_Class_String (LPStr_Test_Class* pSstrClass)
{
    return TRUE;
}

bool __cdecl LPStrBuffer_InOutByRef_Class_String (LPStr_Test_Class* pStrClass)
{
    return TRUE;
}

bool __cdecl LPStrBuffer_In_Array_Struct (LPStr_Test_Struct str[]) 
{
    printf ("** %s \n", str[0].pStr);
    printf ("** %s \n", str[1].pStr);

    return TRUE;
}

bool __cdecl LPStrBuffer_InByRef_Array_Struct (LPStr_Test_Struct* str[]) 
{
    printf ("++ %s \n", (*str)[0].pStr);
    printf ("++ %s \n", (*str)[1].pStr);

    return TRUE;
}

bool __cdecl LPStrBuffer_InOutByRef_Array_Struct (LPStr_Test_Struct* str[]) 
{
    printf ("-- %s \n", (*str)[0].pStr);
    printf ("-- %s \n", (*str)[1].pStr);

    return TRUE;
}

bool __cdecl LPStrBuffer_In_Struct_String_nothrow (LPStr_Test_Struct strStruct)
{
    return TRUE;
}
