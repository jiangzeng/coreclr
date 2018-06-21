#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

bool g_myResourceReleaseMethodCalled = false;

void __stdcall MyResourceReleaseMethod(HANDLE hnd)
{
    g_myResourceReleaseMethodCalled = true;
    
    //call CloseHandle to actually release the handle corresponding to the SafeFileHandle
    CloseHandle(hnd);
}

bool GetMyResourceReleaseMethodCalled()
{
    return g_myResourceReleaseMethodCalled;
}

void ResetMyResourceReleaseMethodCalled()
{
    g_myResourceReleaseMethodCalled = false;
}

void __stdcall SHReleasing_OutParams(IUnknown* ppIUnknFOO, HANDLE* phnd, IUnknown** ppIUnknBAR, int* pInt)
{
    //initialize the hnd out param
    *phnd = (HANDLE)123;

    //initialize the IUnknBAR out param
    *ppIUnknBAR = ppIUnknFOO;
    ppIUnknFOO->AddRef(); //addref Foo

    //initialize the int out param
    *pInt = 123;
}
