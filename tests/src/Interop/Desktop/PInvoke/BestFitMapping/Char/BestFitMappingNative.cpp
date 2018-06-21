#include <stdlib.h>
#include <stdio.h>
#include <windows.h>
#include <string.h>
#include <mbstring.h>
#include <oleauto.h>


bool __cdecl Char_In(char c)
{
    printf ("Char_In ");
    printf ("%c",c);
    printf ("\n");

    return TRUE;
}

bool __cdecl Char_InByRef(char* c)
{
    printf ("Char_InByRef ");
    printf ("%c",*c);
    printf ("\n");

    return TRUE;
}

bool __cdecl Char_InOutByRef(char* c)
{
    printf ("Char_InOutByRef ");
    printf ("%c",*c);
    printf ("\n");

    return TRUE;
}

bool __cdecl CharBuffer_In_String(char* c)
{
    printf ("native %s \n", c);

    return TRUE;
}

bool __cdecl CharBuffer_InByRef_String(char** c)
{
    printf ("native %s \n", *c);

    return TRUE;
}

bool __cdecl CharBuffer_InOutByRef_String(char** c)
{
    printf ("native %s \n", *c);

    return TRUE;
}

bool __cdecl CharBuffer_In_StringBuilder(char* c)
{
    printf ("native %s \n", c);

    return TRUE;
}

bool __cdecl CharBuffer_InByRef_StringBuilder(char** c)
{
    printf ("native %s \n", *c);

    return TRUE;
}

bool __cdecl CharBuffer_InOutByRef_StringBuilder(char** c)
{
    printf ("native %s \n", *c);

    return TRUE;
}

bool __cdecl Char_In_ArrayWithOffset (char* pArrayWithOffset)
{
    return TRUE;
}

bool __cdecl Char_InOut_ArrayWithOffset (char* pArrayWithOffset)
{
    return TRUE;
}

bool __cdecl Char_InByRef_ArrayWithOffset (char** ppArrayWithOffset)
{
    return TRUE;
}

bool __cdecl Char_InOutByRef_ArrayWithOffset (char** ppArrayWithOffset)
{
    return TRUE;
}
