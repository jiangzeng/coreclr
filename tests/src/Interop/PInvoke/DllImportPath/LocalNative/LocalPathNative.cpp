// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#include <stdio.h>
#include <tchar.h>
#include <windows.h>
#include <xplatform.h>

LPTSTR strManaged = "Managed\0String\0";
size_t lenstrManaged = 7; // the length of strManaged

LPTSTR strNative = " Native\0String\0";
size_t lenstrNative = 7; //the len of strNative

extern "C" DLL_EXPORT bool MarshalStringPointer_InOut(/*[in,out]*/LPTSTR *s)
{
    //Check the Input
    size_t len = _tcslen(*s);
    if((len != lenstrManaged)||(_tcscmp(*s,strManaged)!=0))
    {
        printf("Error in Function MarshalString_InOut\n");

        //Expected
        printf("Expected:");
        _tprintf_s(strManaged);
        printf("\tThe length of Expected:%d\n",lenstrManaged);

        //Actual
        printf("Actual:");
        _tprintf_s(*s);
        printf("\tThe length of Actual:%d\n",len);

        return false;
    }

    //Allocate New
    CoTaskMemFree(*s);

    //Alloc New
    size_t length = lenstrNative + 1;
    *s = (LPTSTR)CoTaskMemAlloc(length * sizeof(TCHAR));
    memset(*s,'\0',length * sizeof(TCHAR));
    _tcsncpy_s(*s,length,strNative,lenstrNative);

    //Return
    return true;
}