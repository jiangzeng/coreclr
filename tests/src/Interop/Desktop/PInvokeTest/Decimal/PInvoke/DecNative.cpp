#include <wtypes.h>
#include <oaidl.h>
#include <iostream>
#include <xplatform.h>

DECIMAL g_DECIMAL_MaxValue = { 0, { 0, 0 }, 0xffffffff, 0xffffffff, 0xffffffffffffffff };
DECIMAL g_DECIMAL_MinValue  = { 0, { 0, DECIMAL_NEG }, 0xffffffff, 0xffffffff, 0xffffffffffffffff };
DECIMAL g_DECIMAL_Zero = { 0 };

CY g_CY_MaxValue = { 0xffffffff, 0x7fffffff };
CY g_CY_MinValue = { 0x00000000, 0x80000000 };
CY g_CY_Zero = { 0 };

typedef struct _Stru_Exp_DecAsCYAsFld
{
    WCHAR wc;
    CY cy;
} Stru_Exp_DecAsCYAsFld;

typedef struct _Stru_Seq_DecAsLPStructAsFld
{
    DOUBLE dblVal;
    WCHAR cVal;
    DECIMAL* lpDec;
} Stru_Seq_DecAsLPStructAsFld;

void DecDisplay(const DECIMAL& dec)
{
    std::cout << "\twReserved" << "\t\t" << dec.wReserved << "\n"
        << "\tscale" << "\t\t" << dec.scale << "\n"
        << "\tsign" << "\t\t" << dec.sign << "\n"
        << "\tsignscale" << "\t\t" << dec.signscale << "\n"
        << "\tHi32" << "\t\t" << dec.Hi32 << "\n"
        << "\tLo32" << "\t\t" << dec.Lo32 << "\n"
        << "\tMid32" << "\t\t" << dec.Mid32 << "\n"
        << "\tLo64" << "\t\t" << dec.Lo64 << std::endl;
}

template<typename T>
bool operator==(const T& t1, const T& t2)
{
    return 0 == memcmp((void*)&t1, (void*)&t2, sizeof(T));
}

template<typename T>
bool Equals(LPCSTR err_id, T expected, T actual)
{
    if(expected == actual)
        return true;
    else
    {
        std::cout << "\t#Native Side Err# -- " << err_id 
            << "\n\tExpected = " << expected << std::endl;
        std::wcout << "\tActual is = " << actual << std::endl;

        return false;
    }
}

bool DecEqualsToExpected(LPCSTR err_id, const DECIMAL& expected, const DECIMAL& actual)
{
    if(expected == actual)
        return true;
    else
    {
        std::cout << "\t#Native Side Err # -- " << err_id 
            << "DECIMAL Expected is :" << std::endl;
        DecDisplay(expected);

        std::cout << "\t" << "____________________________________" << std::endl;

        std::cout << "\tDECIMAL Actual is :" << std::endl;
        DecDisplay(actual);

        return false;
    }
}

bool CYEqualsToExpected(LPCSTR err_id, const CY& expected, const CY& actual)
{
    if(expected == actual)
        return true;
    else
    {
        std::cout << "\t#Native Side Err# -- " << err_id 
            << "\n\tCY Expected is :" << "Hi = " << expected.Hi
            << "Lo = " << expected.Lo << std::endl;

        std::cout << "\tCY Actual is :" << "Hi = " << actual.Hi
            << "Lo = " << actual.Lo << std::endl;

        return false;
    }
}

// DECIMAL
extern "C" __declspec(dllexport) BOOL TakeDecAsInOutParamAsLPStructByRef(DECIMAL** lppDec)
{
    if(DecEqualsToExpected("001.01", g_DECIMAL_MaxValue, **lppDec))
    {
        **lppDec = g_DECIMAL_MinValue;
        return true;
    }
    else
        return false;
}

extern "C" __declspec(dllexport) BOOL TakeDecAsOutParamAsLPStructByRef(DECIMAL** lppDec)
{
    if(*lppDec)
    {
        std::cout << "\t#Native Side Err# -- 001.02 DECIMAL* is not NULL" << std::endl;
        return false;
    }
    else
    {
        *lppDec = (DECIMAL*)CoTaskMemAlloc(sizeof(DECIMAL));
        **lppDec = g_DECIMAL_MinValue;

        return true;
    }
}

extern "C" __declspec(dllexport) DECIMAL RetDec()
{
    return g_DECIMAL_MaxValue;
}

extern "C" __declspec(dllexport) BOOL TakeStru_Seq_DecAsLPStructAsFldByInOutRef(Stru_Seq_DecAsLPStructAsFld* s)
{
    if(DecEqualsToExpected("001.04.01", g_DECIMAL_MaxValue, *(s->lpDec)) 
        && Equals("001.04.02", 1.23, s->dblVal) 
        && Equals("001.04.03", L'I', s->cVal))
    {
        *(s->lpDec) = g_DECIMAL_MaxValue;
        s->dblVal = 3.21;
        s->cVal = L'C';

        return true;
    }
    else
        return false;
}

// CY
extern "C" __declspec(dllexport) BOOL TakeCYAsInOutParamAsLPStructByRef(CY* lpCy)
{
    if(CYEqualsToExpected("002.01", g_CY_MaxValue, *lpCy))
    {
        *lpCy = g_CY_MinValue;
        return true;
    }
    else
        return false;
}

extern "C" __declspec(dllexport) BOOL TakeCYAsOutParamAsLPStructByRef(CY* lpCy)
{
    if(g_CY_Zero == *lpCy) 
    {        
        *lpCy = g_CY_MinValue;

        return true;
    }
    else
    {
        std::cout << "\t#Native Side Err# -- 002.02 CY is not clear up." << std::endl;
        return false;
    }
}

extern "C" __declspec(dllexport) CY RetCY()
{
    return g_CY_MinValue;
}

extern "C" __declspec(dllexport) BOOL TakeStru_Exp_DecAsCYAsFldByInOutRef(Stru_Exp_DecAsCYAsFld* s)
{
    if(CYEqualsToExpected("001.04.01", g_CY_Zero, s->cy) && Equals("001.04.02", (wchar_t)0, s->wc))
    {
        s->cy = g_CY_MaxValue;
        s->wc = L'C';

        return true;
    }
    else
    {
        std::cout << "\t#Native Side Err# -- 002.02 Stru_Exp_DecAsCYAsFld is not clear up." << std::endl;
        return false;
    }
}