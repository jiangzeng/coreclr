#include <stdio.h>
#include <tchar.h>
#include <windows.h>

LPTSTR strManaged = L"Managed\0String\0";
size_t lenstrManaged = 7; // the length of strManaged

LPTSTR strNative = L" Native\0String\0";
size_t lenstrNative = 7; //the len of strNative

extern "C" __declspec(dllexport) bool MarshalStringPointer_InOut(/*[in,out]*/LPTSTR *s)
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