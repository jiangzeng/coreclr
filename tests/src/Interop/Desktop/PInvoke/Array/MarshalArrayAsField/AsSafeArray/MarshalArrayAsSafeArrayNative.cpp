#include "MarshalArrayAsSafeArrayNative.h"


/*-------------------------------------------------------------
EXPORT FUNC
-------------------------------------------------------------*/
extern "C" __declspec(dllexport) BOOL SafeArray_In_Sequential_Struct( Struct_Sequential s )
{
    ENTERFUNC();

    CHECK_PARAM_NOT_EMPTY( s.longArr );
    CHECK_PARAM_NOT_EMPTY( s.ulongArr );
    CHECK_PARAM_NOT_EMPTY( s.shortArr );
    CHECK_PARAM_NOT_EMPTY( s.ushortArr );
    CHECK_PARAM_NOT_EMPTY( s.long64Arr );
    CHECK_PARAM_NOT_EMPTY( s.ulong64Arr );
    CHECK_PARAM_NOT_EMPTY( s.doubleArr );
    CHECK_PARAM_NOT_EMPTY( s.floatArr );
    CHECK_PARAM_NOT_EMPTY( s.byteArr );
    CHECK_PARAM_NOT_EMPTY( s.bstrArr );
    CHECK_PARAM_NOT_EMPTY( s.boolArr );

    INIT_ARRAY( LONG, longArr, ARRAY_SIZE );
    CComSafeArray<LONG> *pExpected_longArr = CreateFrom(longArr, COUNTOF(longArr));

    INIT_ARRAY( ULONG, ulongArr, ARRAY_SIZE );
    CComSafeArray<ULONG> *pExpected_ulongArr = CreateFrom(ulongArr, COUNTOF(ulongArr));

    INIT_ARRAY( SHORT, shortArr, ARRAY_SIZE );
    CComSafeArray<SHORT> *pExpected_shortArr = CreateFrom(shortArr, COUNTOF(shortArr));

    INIT_ARRAY( USHORT, ushortArr, ARRAY_SIZE );
    CComSafeArray<USHORT> *pExpected_ushortArr = CreateFrom(ushortArr, COUNTOF(ushortArr));

    INIT_ARRAY( LONG64, long64Arr, ARRAY_SIZE );
    CComSafeArray<LONG64> *pExpected_long64Arr = CreateFrom(long64Arr, COUNTOF(long64Arr));

    INIT_ARRAY( ULONG64, ulong64Arr, ARRAY_SIZE );
    CComSafeArray<ULONG64> *pExpected_ulong64Arr = CreateFrom(ulong64Arr, COUNTOF(ulong64Arr));

    INIT_ARRAY( DOUBLE, doubleArr, ARRAY_SIZE );
    CComSafeArray<DOUBLE> *pExpected_doubleArr = CreateFrom(doubleArr, COUNTOF(doubleArr));

    INIT_ARRAY( FLOAT, floatArr, ARRAY_SIZE );
    CComSafeArray<FLOAT> *pExpected_floatArr = CreateFrom(floatArr, COUNTOF(floatArr));

    INIT_ARRAY( BYTE, byteArr, ARRAY_SIZE );
    CComSafeArray<BYTE> *pExpected_byteArr = CreateFrom(byteArr, COUNTOF(byteArr));

    BSTR bstrArr[ARRAY_SIZE];
    for( size_t i = 0; i < ARRAY_SIZE; ++i )
        bstrArr[i] = ToBSTR(i);
    CComSafeArray<BSTR> *pExpected_bstrArr = CreateFrom(bstrArr, COUNTOF(bstrArr));

    VARIANT_BOOL boolArr[ARRAY_SIZE];
    for( size_t i = 0; i < ARRAY_SIZE; ++i )
        i % 2 == 0 ? boolArr[i] = VARIANT_TRUE : boolArr[i] = VARIANT_FALSE ;
    CComSafeArray<VARIANT_BOOL, VT_BOOL> *pExpected_boolArr = CreateFromVarType<VARIANT_BOOL, VT_BOOL>(boolArr, COUNTOF(boolArr));

    bool retval = Equals(*pExpected_longArr, s.longArr) && 
        Equals(*pExpected_ulongArr, s.ulongArr) &&
        Equals(*pExpected_shortArr, s.shortArr) && 
        Equals(*pExpected_ushortArr, s.ushortArr) &&
        Equals(*pExpected_long64Arr, s.long64Arr) && 
        Equals(*pExpected_ulong64Arr, s.ulong64Arr) &&
        Equals(*pExpected_doubleArr, s.doubleArr) && 
        Equals(*pExpected_floatArr, s.floatArr) &&
        Equals(*pExpected_byteArr, s.byteArr) && 
        Equals(*pExpected_bstrArr, s.bstrArr) &&
        EqualsVarType<VARIANT_BOOL, VT_BOOL>(*pExpected_boolArr, s.boolArr);

    delete pExpected_longArr, pExpected_ulongArr, pExpected_shortArr, 
        pExpected_ushortArr, pExpected_long64Arr, pExpected_ulong64Arr,
        pExpected_ulong64Arr, pExpected_floatArr, pExpected_byteArr,
        pExpected_bstrArr, pExpected_boolArr;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_In_Explicit_Struct( Struct_Explicit s )
{
    ENTERFUNC();

    CHECK_PARAM_NOT_EMPTY( s.longArr );
    CHECK_PARAM_NOT_EMPTY( s.ulongArr );
    CHECK_PARAM_NOT_EMPTY( s.shortArr );
    CHECK_PARAM_NOT_EMPTY( s.ushortArr );
    CHECK_PARAM_NOT_EMPTY( s.long64Arr );
    CHECK_PARAM_NOT_EMPTY( s.ulong64Arr );
    CHECK_PARAM_NOT_EMPTY( s.doubleArr );
    CHECK_PARAM_NOT_EMPTY( s.floatArr );
    CHECK_PARAM_NOT_EMPTY( s.byteArr );
    CHECK_PARAM_NOT_EMPTY( s.bstrArr );
    CHECK_PARAM_NOT_EMPTY( s.boolArr );

    INIT_ARRAY( LONG, longArr, ARRAY_SIZE );
    CComSafeArray<LONG> *pExpected_longArr = CreateFrom(longArr, COUNTOF(longArr));

    INIT_ARRAY( ULONG, ulongArr, ARRAY_SIZE );
    CComSafeArray<ULONG> *pExpected_ulongArr = CreateFrom(ulongArr, COUNTOF(ulongArr));

    INIT_ARRAY( SHORT, shortArr, ARRAY_SIZE );
    CComSafeArray<SHORT> *pExpected_shortArr = CreateFrom(shortArr, COUNTOF(shortArr));

    INIT_ARRAY( USHORT, ushortArr, ARRAY_SIZE );
    CComSafeArray<USHORT> *pExpected_ushortArr = CreateFrom(ushortArr, COUNTOF(ushortArr));

    INIT_ARRAY( LONG64, long64Arr, ARRAY_SIZE );
    CComSafeArray<LONG64> *pExpected_long64Arr = CreateFrom(long64Arr, COUNTOF(long64Arr));

    INIT_ARRAY( ULONG64, ulong64Arr, ARRAY_SIZE );
    CComSafeArray<ULONG64> *pExpected_ulong64Arr = CreateFrom(ulong64Arr, COUNTOF(ulong64Arr));

    INIT_ARRAY( DOUBLE, doubleArr, ARRAY_SIZE );
    CComSafeArray<DOUBLE> *pExpected_doubleArr = CreateFrom(doubleArr, COUNTOF(doubleArr));

    INIT_ARRAY( FLOAT, floatArr, ARRAY_SIZE );
    CComSafeArray<FLOAT> *pExpected_floatArr = CreateFrom(floatArr, COUNTOF(floatArr));

    INIT_ARRAY( BYTE, byteArr, ARRAY_SIZE );
    CComSafeArray<BYTE> *pExpected_byteArr = CreateFrom(byteArr, COUNTOF(byteArr));

    BSTR bstrArr[ARRAY_SIZE];
    for( size_t i = 0; i < ARRAY_SIZE; ++i )
        bstrArr[i] = ToBSTR(i);
    CComSafeArray<BSTR> *pExpected_bstrArr = CreateFrom(bstrArr, COUNTOF(bstrArr));

    VARIANT_BOOL boolArr[ARRAY_SIZE];
    for( size_t i = 0; i < ARRAY_SIZE; ++i )
        i % 2 == 0 ? boolArr[i] = VARIANT_TRUE : boolArr[i] = VARIANT_FALSE ;
    CComSafeArray<VARIANT_BOOL, VT_BOOL> *pExpected_boolArr = CreateFromVarType<VARIANT_BOOL, VT_BOOL>(boolArr, COUNTOF(boolArr));

    bool retval = Equals(*pExpected_longArr, s.longArr) && 
        Equals(*pExpected_ulongArr, s.ulongArr) &&
        Equals(*pExpected_shortArr, s.shortArr) && 
        Equals(*pExpected_ushortArr, s.ushortArr) &&
        Equals(*pExpected_long64Arr, s.long64Arr) && 
        Equals(*pExpected_ulong64Arr, s.ulong64Arr) &&
        Equals(*pExpected_doubleArr, s.doubleArr) && 
        Equals(*pExpected_floatArr, s.floatArr) &&
        Equals(*pExpected_byteArr, s.byteArr) && 
        Equals(*pExpected_bstrArr, s.bstrArr) &&
        EqualsVarType<VARIANT_BOOL, VT_BOOL>(*pExpected_boolArr, s.boolArr);

    delete pExpected_longArr, pExpected_ulongArr, pExpected_shortArr, 
        pExpected_ushortArr, pExpected_long64Arr, pExpected_ulong64Arr,
        pExpected_ulong64Arr, pExpected_floatArr, pExpected_byteArr,
        pExpected_bstrArr, pExpected_boolArr;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_In_Sequential_Class( Struct_Sequential *s )
{
    ENTERFUNC();
    return SafeArray_In_Sequential_Struct( *s );
}

extern "C" __declspec(dllexport) BOOL SafeArray_In_Explicit_Class( Struct_Explicit *s )
{
    ENTERFUNC();
    return SafeArray_In_Explicit_Struct( *s );
}

/////////////////////////////methods for marshaling ArrayOfStruct As Field//////////////////////////////////
const int NumArrOfStructElements1 = 10;

//////////////////////////////////////////As Field in struct/////////////////////////////////////////////////
extern "C" __declspec(dllexport) BOOL MarshalArrayOfStructAsFieldInSeqStructByRef(Struct_SeqWithArrOfStr* str, LPSAFEARRAY pExpect)
{
    bool breturn = true;

    S2 expectedS2= {INT_MIN,4294967295,-32768,65535,0,127,-32768,65535,_I64_MIN,18446744073709551615,32.0,3.2};
    S2 rgvarpsa[NumArrOfStructElements1];
    for(long i = 0;i < NumArrOfStructElements1; i++)
    {
        HRESULT hr = SafeArrayGetElement(str->arrS2,&i,&rgvarpsa[i]);
        S2 p = (S2)rgvarpsa[i];
        if(!ValidateArrS2(p,expectedS2))
        {
            breturn = false;
            printf("Error: The %d S2 doesnt match\n",i);
        }
    }

    SafeArrayDestroy(str->arrS2);

    IRecordInfo *pRecInfo = NULL;
    SAFEARRAYBOUND saBound;

    SafeArrayGetRecordInfo(pExpect, &pRecInfo);
    SafeArrayGetLBound(pExpect, 1, &saBound.lLbound);
    SafeArrayGetUBound(pExpect, 1, (LONG *)&saBound.cElements);
    saBound.cElements = saBound.cElements - saBound.lLbound + 1;

    str->arrS2 = SafeArrayCreateEx(VT_RECORD, 1, &saBound, pRecInfo);

    breturn = breturn & CopyStructS2SafeArray(str->arrS2, pExpect);
    return breturn;    

}

extern "C" __declspec(dllexport) BOOL MarshalArrayOfStructAsFieldInSeqStructByVal(Struct_SeqWithArrOfStr str, LPSAFEARRAY pExpect)
{
    bool breturn = true;

    S2 expectedS2= {INT_MIN,4294967295,-32768,65535,0,127,-32768,65535,_I64_MIN,18446744073709551615,32.0,3.2};
    S2 rgvarpsa[NumArrOfStructElements1];
    for(long i = 0;i < NumArrOfStructElements1; i++)
    {
        HRESULT hr = SafeArrayGetElement(str.arrS2,&i,&rgvarpsa[i]);
        S2 p = (S2)rgvarpsa[i];
        if(!ValidateArrS2(p,expectedS2))
        {
            breturn = false;
            printf("Error: The %d S2 doesnt match\n",i);
        }
    }  

    return breturn;
}

extern "C" __declspec(dllexport) BOOL MarshalArrayOfStructAsFieldInExpStructByRef(Struct_ExpWithArrOfStr* str, LPSAFEARRAY pExpect)
{
    bool breturn = true;

    S2 expectedS2= {INT_MIN,4294967295,-32768,65535,0,127,-32768,65535,_I64_MIN,18446744073709551615,32.0,3.2};
    S2 rgvarpsa[NumArrOfStructElements1];
    for(long i = 0;i < NumArrOfStructElements1; i++)
    {
        HRESULT hr = SafeArrayGetElement(str->arrS2,&i,&rgvarpsa[i]);
        S2 p = (S2)rgvarpsa[i];
        if(!ValidateArrS2(p,expectedS2))
        {
            breturn = false;
            printf("Error: The %d S2 doesnt match\n",i);
        }
    }

    SafeArrayDestroy(str->arrS2);

    IRecordInfo *pRecInfo = NULL;
    SAFEARRAYBOUND saBound;

    SafeArrayGetRecordInfo(pExpect, &pRecInfo);
    SafeArrayGetLBound(pExpect, 1, &saBound.lLbound);
    SafeArrayGetUBound(pExpect, 1, (LONG *)&saBound.cElements);
    saBound.cElements = saBound.cElements - saBound.lLbound + 1;

    str->arrS2 = SafeArrayCreateEx(VT_RECORD, 1, &saBound, pRecInfo);

    breturn = breturn&CopyStructS2SafeArray(str->arrS2, pExpect);
    return breturn;
}

extern "C" __declspec(dllexport) BOOL MarshalArrayOfStructAsFieldInExpStructByVal(Struct_ExpWithArrOfStr str, LPSAFEARRAY pExpect)
{
    bool breturn = true;

    S2 expectedS2= {INT_MIN,4294967295,-32768,65535,0,127,-32768,65535,_I64_MIN,18446744073709551615,32.0,3.2};
    S2 rgvarpsa[NumArrOfStructElements1];
    for(long i = 0;i < NumArrOfStructElements1; i++)
    {
        HRESULT hr = SafeArrayGetElement(str.arrS2,&i,&rgvarpsa[i]);
        S2 p = (S2)rgvarpsa[i];
        if(!ValidateArrS2(p,expectedS2))
        {
            breturn = false;
            printf("Error: The %d S2 doesnt match\n",i);
        }
    }

    return breturn;
}

//////////////////////////////////////////As Field in class/////////////////////////////////////////////////
extern "C" __declspec(dllexport) BOOL MarshalArrayOfStructAsFieldInSeqClassByVal(Struct_SeqWithArrOfStr* str, LPSAFEARRAY pExpect)
{
    bool breturn = true;

    S2 expectedS2= {INT_MIN,4294967295,-32768,65535,0,127,-32768,65535,_I64_MIN,18446744073709551615,32.0,3.2};
    S2 rgvarpsa[NumArrOfStructElements1];
    for(long i = 0;i < NumArrOfStructElements1; i++)
    {
        HRESULT hr = SafeArrayGetElement(str->arrS2,&i,&rgvarpsa[i]);
        S2 p = (S2)rgvarpsa[i];
        if(!ValidateArrS2(p,expectedS2))
        {
            breturn = false;
            printf("Error: The %d S2 doesnt match\n",i);
        }
    }

    SafeArrayDestroy(str->arrS2);

    IRecordInfo *pRecInfo = NULL;
    SAFEARRAYBOUND saBound;

    SafeArrayGetRecordInfo(pExpect, &pRecInfo);
    SafeArrayGetLBound(pExpect, 1, &saBound.lLbound);
    SafeArrayGetUBound(pExpect, 1, (LONG *)&saBound.cElements);
    saBound.cElements = saBound.cElements - saBound.lLbound + 1;

    str->arrS2 = SafeArrayCreateEx(VT_RECORD, 1, &saBound, pRecInfo);

    breturn = breturn&CopyStructS2SafeArray(str->arrS2, pExpect);
    return breturn;
}

extern "C" __declspec(dllexport) BOOL MarshalArrayOfStructAsFieldInSeqClassByRef(Struct_SeqWithArrOfStr** str, LPSAFEARRAY pExpect)
{
    return MarshalArrayOfStructAsFieldInSeqClassByVal(*str,pExpect);
}

extern "C" __declspec(dllexport) BOOL MarshalArrayOfStructAsFieldInExpClassByVal(Struct_ExpWithArrOfStr* str, LPSAFEARRAY pExpect)
{
    bool breturn = true;

    S2 expectedS2= {INT_MIN,4294967295,-32768,65535,0,127,-32768,65535,_I64_MIN,18446744073709551615,32.0,3.2};
    S2 rgvarpsa[NumArrOfStructElements1];
    for(long i = 0;i < NumArrOfStructElements1; i++)
    {
        HRESULT hr = SafeArrayGetElement(str->arrS2,&i,&rgvarpsa[i]);
        S2 p = (S2)rgvarpsa[i];
        if(!ValidateArrS2(p,expectedS2))
        {
            breturn = false;
            printf("Error: The %d S2 doesnt match\n",i);
        }
    }

    SafeArrayDestroy(str->arrS2);

    IRecordInfo *pRecInfo = NULL;
    SAFEARRAYBOUND saBound;

    SafeArrayGetRecordInfo(pExpect, &pRecInfo);
    SafeArrayGetLBound(pExpect, 1, &saBound.lLbound);
    SafeArrayGetUBound(pExpect, 1, (LONG *)&saBound.cElements);
    saBound.cElements = saBound.cElements - saBound.lLbound + 1;

    str->arrS2 = SafeArrayCreateEx(VT_RECORD, 1, &saBound, pRecInfo);

    breturn = breturn&CopyStructS2SafeArray(str->arrS2, pExpect);
    return breturn;
}

extern "C" __declspec(dllexport) BOOL MarshalArrayOfStructAsFieldInExpClassByRef(Struct_ExpWithArrOfStr** str, LPSAFEARRAY pExpect)
{
    return MarshalArrayOfStructAsFieldInExpClassByVal(*str,pExpect);
}
