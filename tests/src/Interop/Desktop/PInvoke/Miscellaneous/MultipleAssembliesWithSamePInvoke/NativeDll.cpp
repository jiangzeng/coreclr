#include <stdio.h>
#include <windows.h>

extern "C" int __stdcall GetInt()
{
    return 24;
}