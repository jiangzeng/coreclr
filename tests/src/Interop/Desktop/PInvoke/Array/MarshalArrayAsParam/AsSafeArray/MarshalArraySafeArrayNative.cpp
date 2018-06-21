#include <stdio.h>
#include <windows.h>
#include <atlsafe.h>
#include <oleauto.h>
#include "MarshalArray.h"

// Do not output struct, and suppress the boring template compile warning
std::ostream &operator<<(std::ostream &ostr, TestStructSA &ts)
{
    return ostr;
}

bool operator==(TestStructSA s1, TestStructSA s2)
{
    return IsObjectEquals(s1.x, s2.x) &&
        IsObjectEquals(s1.d, s2.d) &&
        IsObjectEquals(s1.l, s2.l) &&
        IsObjectEquals(s1.str, s2.str);
}

bool IsObjectEquals(int i, TestStructSA ts)
{
    bstr_t bstr = ToBSTR(i);

    return IsObjectEquals(ts.x, i) &&
        IsObjectEquals(ts.d, (double)i) &&
        IsObjectEquals(ts.l, (LONG64)i) &&
        IsObjectEquals(ts.str, (BSTR)bstr);
}

void InitTestStructSA(TestStructSA &ts, int i)
{
    ts.x = i;
    ts.d = i;
    ts.l = i;
    ts.str = ToBSTR(i);
}

const int NumArrOfStructElements1 = 10;

//////////////////////////////////// 1D ByVal /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_1D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        int arr[ARRAY_SIZE];
    for ( int i = 0; i < ARRAY_SIZE; ++i )
        arr[i] = i;
    CComSafeArray<int> *pExpected = CreateFrom(arr, COUNTOF(arr));

    bool retval = Equals(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_1D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        BSTR arr[ARRAY_SIZE];
    int nullIdx = ARRAY_SIZE / 2;
    int nestedIdx = nullIdx + 1;
    for ( int i = 0; i < ARRAY_SIZE; ++i )
    {
        if ( nullIdx == i )
            arr[i] = NULL;
        else if ( nestedIdx == i )
            arr[i] = SysAllocString(L"This is a nested 0 string");
        else
            arr[i] = ToBSTR(i);
    }

    CComSafeArray<BSTR> *pExpected = CreateFrom(arr, COUNTOF(arr));
    pExpected->GetAt(nestedIdx)[17] = L'\0';

    bool retval = Equals(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_Byte_1D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        BYTE arr[ARRAY_SIZE];
    for ( int i = 0; i < ARRAY_SIZE; ++i )
        arr[i] = i;
    CComSafeArray<BYTE> *pExpected = CreateFrom(arr, COUNTOF(arr));

    bool retval = Equals(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_1D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        double arr[ARRAY_SIZE];
    for ( int i = 0; i < ARRAY_SIZE; ++i )
        arr[i] = i;
    CComSafeArray<double> *pExpected = CreateFrom(arr, COUNTOF(arr));

    bool retval = Equals(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_1D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        VARIANT_BOOL arr[ARRAY_SIZE]; 
    for ( size_t i = 0; i < ARRAY_SIZE; ++i )
    {
        if ( i % 2 == 0 )
            arr[i] = VARIANT_TRUE;
        else
            arr[i] = VARIANT_FALSE;
    }
    CComSafeArray<VARIANT_BOOL, VT_BOOL> *pExpected = 
        CreateFromVarType<VARIANT_BOOL, VT_BOOL>(arr, COUNTOF(arr));

    bool retval = EqualsVarType<VARIANT_BOOL, VT_BOOL>(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_1D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        CComSafeArray<LPUNKNOWN> sa(pActual);
    UINT count = sa.GetCount();
    for ( UINT i = 0; i < count - 1; ++i )
    {
        LPUNKNOWN pUnk = sa.GetAt(i);
        LPDELEGATE pDele = NULL;
        if ( FAILED(pUnk->QueryInterface(__uuidof(_Delegate), (void **)&pDele)) )
        {
            TRACE("Delegate safe array marshaling error\n");
            return false;
        }
        pUnk->Release();

        VARIANT obj = pDele->DynamicInvoke(NULL);
        pDele->Release();
        if ( i != obj.lVal )
        {
            VERIFY_ERROR_MSG("delegate marshal error: EXPECT: %d, ACTUAL %d\n", i, obj.lVal);
            return false;
        }
    }

    if ( sa.GetAt(count - 1) != NULL )
    {
        VERIFY_ERROR_MSG("delegate marshal error: EXPECT: %d, ACTUAL %x\n", NULL, sa.GetAt(count - 1));
        return false;
    }

    return true;
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_1D(LPSAFEARRAY pActual)
{
    int arr[ARRAY_SIZE];
    for ( int i = 0; i < ARRAY_SIZE; ++i )
        arr[i] = i;

    CComSafeArray<int> *pExpected = CreateFrom(arr, COUNTOF(arr));

    bool retval = EqualsVarType<int, VT_I4, TestStructSA>(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_1D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        VARIANT arr[ARRAY_SIZE];
    int nullIdx = ARRAY_SIZE / 2;
    for ( int i = 0; i < ARRAY_SIZE; ++i )
    {
        VariantInit(&arr[i]);
        if ( nullIdx == i )
            arr[i].vt = VT_EMPTY;
        else
        {
            arr[i].vt = VT_I4;
            arr[i].lVal = i;
        }
    }

    CComSafeArray<VARIANT> *pExpected = CreateFrom(arr, COUNTOF(arr));

    bool retval = Equals(*pExpected, pActual);
    delete pExpected;

    return retval;
}

//////////////////////////////////// 2D ByVal /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_2D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        int arr[ROWS][COLUMNS] = {0, 1, 2, 3, 4, 5};

    CComSafeArray<int> *pExpected = CreateFrom(
        (int *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    bool retval = Equals(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_2D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        int arr[ROWS][COLUMNS] = {0, 1, 2, 3, 4, 5};

    CComSafeArray<int> *pExpected = CreateFrom(
        (int *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    bool retval = EqualsVarType<int, VT_I4, TestStructSA>(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_2D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        BSTR arr[ROWS][COLUMNS] = { 
            ToBSTR(0), 
            ToBSTR(1), 
            ToBSTR(2), 
            NULL, 
            SysAllocString(L"This is a nested 0 string"),
            ToBSTR(5) };
    arr[1][1][17] = L'\0';

    CComSafeArray<BSTR> *pExpected = CreateFrom(
        (BSTR *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));
    LONG idx[2] = {1, 1};
    BSTR bstr = NULL;
    pExpected->MultiDimGetAt(idx, bstr);
    bstr[17] = L'\0';

    bool retval = Equals(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_Byte_2D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        BYTE arr[ROWS][COLUMNS] = {0, 1, 2, 3, 4, 5};

    CComSafeArray<BYTE> *pExpected = CreateFrom(
        (BYTE *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    bool retval = Equals(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_2D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        double arr[ROWS][COLUMNS] = {0, 1, 2, 3, 4, 5};

    CComSafeArray<double> *pExpected = CreateFrom(
        (double *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    bool retval = Equals(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_2D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        VARIANT_BOOL arr[ROWS][COLUMNS];
    int v = 0;
    for ( int i = 0; i < ROWS; ++i )
    {
        for ( int j = 0; j < COLUMNS; ++j )
        {
            if ( (v++) % 2 == 0 )
                arr[i][j] = VARIANT_TRUE;
            else
                arr[i][j] = VARIANT_FALSE;
        }
    }

    CComSafeArray<VARIANT_BOOL, VT_BOOL> *pExpected = CreateFromVarType<VARIANT_BOOL, VT_BOOL>(
        (VARIANT_BOOL *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    bool retval = EqualsVarType<VARIANT_BOOL, VT_BOOL>(*pExpected, pActual);
    delete pExpected;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_2D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        CComSafeArray<LPUNKNOWN> sa(pActual);
    UINT l1 = sa.GetLowerBound(0);
    UINT l2 = sa.GetLowerBound(1);
    UINT u1 = sa.GetUpperBound(0);
    UINT u2 = sa.GetUpperBound(1);

    for ( UINT i = l1; i < u1 - 1; ++i )
    {
        for ( UINT j = l2; j < u2; ++j )
        {
            LONG idx[2] = {i, j};
            LPUNKNOWN pUnk = NULL;
            LPDELEGATE pDele = NULL;

            if ( FAILED(sa.MultiDimGetAt(idx, pUnk)) )
            {
                TRACE("Delegate safe array marshaling error\n");
                return false;
            }

            if ( FAILED(pUnk->QueryInterface(__uuidof(_Delegate), (void **)&pDele)) )
            {
                TRACE("Delegate safe array marshaling error\n");
                return false;
            }
            pUnk->Release();

            VARIANT obj = pDele->DynamicInvoke(NULL);
            pDele->Release();
            if ( i != obj.lVal )
            {
                VERIFY_ERROR_MSG("delegate marshal error: EXPECT: %d, ACTUAL %d\n", i, obj.lVal);
                return false;
            }
        }
    }

    return true;
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_2D(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        VARIANT arr[ROWS][COLUMNS];
    int value = 0;
    for ( int r = 0; r < ROWS; ++r )
    {
        for ( int c = 0; c < COLUMNS; ++c )
        {
            VariantInit(&arr[r][c]);
            arr[r][c].vt = VT_I4;
            arr[r][c].lVal = value++;
        }
    }
    VariantClear(&arr[1][0]);
    arr[1][0].vt = VT_EMPTY;

    CComSafeArray<VARIANT> *pExpected = CreateFrom(
        (VARIANT *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    bool retval = Equals(*pExpected, pActual);
    delete pExpected;

    return retval;
}


//////////////////////////////////// 1D ByRef /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_1D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Int_1D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_1D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_String_1D(*ppActual);
}
extern "C" __declspec(dllexport) BOOL SafeArray_Byte_1D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Byte_1D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_1D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Double_1D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_1D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Bool_1D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_1D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Delegate_1D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_1D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_TestStruct_1D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_1D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Object_1D(*ppActual);
}

//////////////////////////////////// 2D ByRef /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_2D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Int_2D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_2D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_String_2D(*ppActual);
}
extern "C" __declspec(dllexport) BOOL SafeArray_Byte_2D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Byte_2D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_2D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Double_2D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_2D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Bool_2D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_2D_ByRef(LPSAFEARRAY * ppActual)
{	
    return SafeArray_Delegate_2D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_2D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Object_2D(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_2D_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_TestStruct_2D(*ppActual);
}

//////////////////////////////////// 1D ByVal Out /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_1D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        int arr[ARRAY_SIZE];
    for ( int i = 0; i < ARRAY_SIZE; ++i )
        arr[i] = i;
    CComSafeArray<int> *ppExpected = CreateFrom(arr, COUNTOF(arr));

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_1D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        BSTR arr[ARRAY_SIZE];
    int nullIdx = ARRAY_SIZE / 2 - 1;
    int nestIdx = nullIdx - 1;
    for ( int i = 0; i < ARRAY_SIZE; ++i )
    {
        if ( i == nullIdx )
            arr[i] = NULL;
        else if ( i == nestIdx )
            arr[i] = SysAllocString(L"This is a nested 0 string");
        else
            arr[i] = ToBSTR(i);
    }

    CComSafeArray<BSTR> *ppExpected = CreateFrom(arr, COUNTOF(arr));
    ppExpected->GetAt(nestIdx)[17] = L'\0';

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}
extern "C" __declspec(dllexport) BOOL SafeArray_Byte_1D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        BYTE arr[ARRAY_SIZE];
    for ( int i = 0; i < ARRAY_SIZE; ++i )
        arr[i] = i;
    CComSafeArray<BYTE> *ppExpected = CreateFrom(arr, COUNTOF(arr));

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_1D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        double arr[ARRAY_SIZE];
    for ( int i = 0; i < ARRAY_SIZE; ++i )
        arr[i] = i;
    CComSafeArray<double> *ppExpected = CreateFrom(arr, COUNTOF(arr));

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_1D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        VARIANT_BOOL arr[ARRAY_SIZE]; 
    for ( size_t i = 0; i < ARRAY_SIZE; ++i )
    {
        if ( i % 2 != 0 )
            arr[i] = VARIANT_TRUE;
        else
            arr[i] = VARIANT_FALSE;
    }
    CComSafeArray<VARIANT_BOOL, VT_BOOL> *ppExpected = 
        CreateFromVarType<VARIANT_BOOL, VT_BOOL>(arr, COUNTOF(arr));

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_1D_Out(LPSAFEARRAY pActual, LPSAFEARRAY pExpected)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        return SUCCEEDED(SafeArrayCopyData(pExpected, pActual));
}

bool CopyStructSafeArray(LPSAFEARRAY pActual, LPSAFEARRAY pExpect)
{
    bool retval = true;
    UINT dimens = SafeArrayGetDim(pExpect);
    LONG *idx = new LONG[dimens];
    LONG *lowers = new LONG[dimens];
    LONG *uppers = new LONG[dimens];

    for ( UINT i = 0; i < dimens; ++i )
    {
        LONG lower1 = 0;
        LONG lower2 = 0;
        SafeArrayGetLBound(pExpect, i + 1, &lower1);
        SafeArrayGetLBound(pActual, i + 1, &lower2);

        LONG upper1 = 0;
        LONG upper2 = 0; 
        SafeArrayGetUBound(pExpect, i + 1, &upper1);
        SafeArrayGetUBound(pActual, i + 1, &upper2);

        if ( lower1 != (UINT)lower2 )
        {
            VERIFY_ERROR_MSG("Safearray lower bound wrong, EXPECT: %d, ACTUAL: %d\n", lower1, lower2);
            retval = false;
            goto Leave;
        }
        if ( upper1 != (UINT)upper2 )
        {
            VERIFY_ERROR_MSG("Safearray upper bound wrong, EXPECT: %d, ACTUAL: %d\n", upper1, upper2);
            retval = false;
            goto Leave;
        }

        lowers[i] = lower1;
        uppers[i] = upper1;
    }

    for ( UINT i = 0; i < dimens; ++i )
        idx[i] = lowers[i];

    while ( idx[0] <= uppers[0] )
    {
        TestStructSA *ptsExpect = NULL;
        TestStructSA *ptsActual = NULL;
        SafeArrayPtrOfIndex(pExpect, idx, (void **)&ptsExpect);
        SafeArrayPtrOfIndex(pActual, idx, (void **)&ptsActual);

        if ( ptsActual == NULL )
            ptsActual = new TestStructSA;

        if ( ptsActual != NULL )
        {
            if ( ptsActual->str )
                SysFreeString(ptsActual->str);

            ptsActual->x = ptsExpect->x;
            ptsActual->d = ptsExpect->d;
            ptsActual->l = ptsExpect->l;
        }

        UINT uLen = SysStringLen(ptsExpect->str);
        ptsActual->str = SysAllocStringLen(ptsExpect->str, uLen);

        int curDimens = ((int)dimens - 1);
        while ( ++idx[curDimens] > uppers[curDimens] )
        {
            if ( curDimens == 0 )
                break;

            idx[curDimens] = lowers[curDimens];
            curDimens--;
        }
    }

Leave:
    if ( idx != NULL ) delete[] idx;
    if ( lowers != NULL ) delete[] lowers;
    if ( uppers != NULL ) delete[] uppers;

    return retval;
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_1D_Out(LPSAFEARRAY pActual, LPSAFEARRAY pExpect)
{
    CHECK_PARAM_NOT_EMPTY(pActual)
        CHECK_PARAM_NOT_EMPTY(pExpect)

        return CopyStructSafeArray(pActual, pExpect);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_1D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        VARIANT arr[ARRAY_SIZE];
    int nullIdx = ARRAY_SIZE / 2 -1;
    for ( int i = 0; i < ARRAY_SIZE; ++i )
    {
        VariantInit(&arr[i]);
        if ( i == nullIdx )
            arr[i].vt = VT_EMPTY;
        else
        {
            arr[i].vt = VT_I4;
            arr[i].lVal = i;
        }
    }
    CComSafeArray<VARIANT> *ppExpected = CreateFrom(arr, COUNTOF(arr));

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

//////////////////////////////////// 2D ByVal Out /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_2D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        int arr[ROWS][COLUMNS] = {5, 4, 3, 2, 1, 0};

    CComSafeArray<int> *ppExpected = CreateFrom(
        (int *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_2D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        BSTR arr[ROWS][COLUMNS] = { 
            NULL, 
            SysAllocString(L"This is a nested 0 string"),
            ToBSTR(3), 
            ToBSTR(2), 
            ToBSTR(1), 
            ToBSTR(0) };
    arr[0][1][17] = L'\0';

    CComSafeArray<BSTR> *ppExpected = CreateFrom(
        (BSTR *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Byte_2D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        BYTE arr[ROWS][COLUMNS] = {5, 4, 3, 2, 1, 0};

    CComSafeArray<BYTE> *ppExpected = CreateFrom(
        (BYTE *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_2D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        double arr[ROWS][COLUMNS] = {5, 4, 3, 2, 1, 0};

    CComSafeArray<double> *ppExpected = CreateFrom(
        (double *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_2D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        VARIANT_BOOL arr[ROWS][COLUMNS];
    int v = 0;
    for ( int i = 0; i < ROWS; ++i )
    {
        for ( int j = 0; j < COLUMNS; ++j )
        {
            if ( (v++) % 2 != 0 )
                arr[i][j] = VARIANT_TRUE;
            else
                arr[i][j] = VARIANT_FALSE;
        }
    }

    CComSafeArray<VARIANT_BOOL, VT_BOOL> *ppExpected = CreateFromVarType<VARIANT_BOOL, VT_BOOL>(
        (VARIANT_BOOL *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_2D_Out(LPSAFEARRAY pActual, LPSAFEARRAY pExpected)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        return SUCCEEDED(SafeArrayCopyData(pExpected, pActual));
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_2D_Out(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        VARIANT arr[ROWS][COLUMNS];
    int value = ROWS * COLUMNS - 1;
    for ( int r = 0; r < ROWS; ++r )
    {
        for ( int c = 0; c < COLUMNS; ++c )
        {
            VariantInit(&arr[r][c]);
            arr[r][c].vt = VT_I4;
            arr[r][c].lVal = value--;
        }
    }
    VariantClear(&arr[0][0]);
    arr[0][0].vt = VT_EMPTY;

    CComSafeArray<VARIANT> *ppExpected = CreateFrom(
        (VARIANT *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopyData(*ppExpected, pActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_2D_Out(LPSAFEARRAY pActual, LPSAFEARRAY pExpect)
{
    CHECK_PARAM_NOT_EMPTY(pActual)
        CHECK_PARAM_NOT_EMPTY(pExpect)

        return CopyStructSafeArray(pActual, pExpect);
}

//////////////////////////////////// 1D ByRef Out /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_1D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        int arr[ARRAY_SIZE];
    for ( int i = 0; i < ARRAY_SIZE; ++i )
        arr[i] = i;
    CComSafeArray<int> *ppExpected = CreateFrom(arr, COUNTOF(arr));

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_1D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        BSTR arr[ARRAY_SIZE];
    int nullIdx = ARRAY_SIZE / 2 - 1;
    int nestIdx = nullIdx - 1;
    for ( int i = 0; i < ARRAY_SIZE; ++i )
    {
        if ( i == nullIdx )
            arr[i] = NULL;
        else if ( i == nestIdx )
            arr[i] = SysAllocString(L"This is a nested 0 string");
        else
            arr[i] = ToBSTR(i);
    }

    CComSafeArray<BSTR> *ppExpected = CreateFrom(arr, COUNTOF(arr));
    ppExpected->GetAt(nestIdx)[17] = L'\0';

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Byte_1D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        BYTE arr[ARRAY_SIZE];
    for ( int i = 0; i < ARRAY_SIZE; ++i )
        arr[i] = i;
    CComSafeArray<BYTE> *ppExpected = CreateFrom(arr, COUNTOF(arr));

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_1D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        double arr[ARRAY_SIZE];
    for ( int i = 0; i < ARRAY_SIZE; ++i )
        arr[i] = i;
    CComSafeArray<double> *ppExpected = CreateFrom(arr, COUNTOF(arr));

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_1D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        VARIANT_BOOL arr[ARRAY_SIZE]; 
    for ( size_t i = 0; i < ARRAY_SIZE; ++i )
    {
        if ( i % 2 != 0 )
            arr[i] = VARIANT_TRUE;
        else
            arr[i] = VARIANT_FALSE;
    }
    CComSafeArray<VARIANT_BOOL, VT_BOOL> *ppExpected = 
        CreateFromVarType<VARIANT_BOOL, VT_BOOL>(arr, COUNTOF(arr));

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_1D_Out_ByRef(LPSAFEARRAY * ppActual, LPSAFEARRAY pExpected)
{
    CHECK_PARAM_EMPTY(*ppActual)

        return SUCCEEDED(SafeArrayCopy(pExpected, ppActual));
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_1D_Out_ByRef(LPSAFEARRAY * ppActual, LPSAFEARRAY pExpect)
{
    CHECK_PARAM_EMPTY(*ppActual)
        CHECK_PARAM_NOT_EMPTY(pExpect)

        IRecordInfo *pRecInfo = NULL;
    SAFEARRAYBOUND saBound;

    SafeArrayGetRecordInfo(pExpect, &pRecInfo);
    SafeArrayGetLBound(pExpect, 1, &saBound.lLbound);
    SafeArrayGetUBound(pExpect, 1, (LONG *)&saBound.cElements);
    saBound.cElements = saBound.cElements - saBound.lLbound + 1;

    *ppActual = SafeArrayCreateEx(VT_RECORD, 1, &saBound, pRecInfo);

    return CopyStructSafeArray(*ppActual, pExpect);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_1D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        VARIANT arr[ARRAY_SIZE];
    int nullIdx = ARRAY_SIZE / 2 - 1;
    for ( int i = 0; i < ARRAY_SIZE; ++i )
    {
        VariantInit(&arr[i]);
        if ( i == nullIdx )
            arr[i].vt = VT_EMPTY;
        else
        {
            arr[i].vt = VT_I4;
            arr[i].lVal = i;
        }
    }
    CComSafeArray<VARIANT> *ppExpected = CreateFrom(arr, COUNTOF(arr));

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

//////////////////////////////////// 2D ByRef Out /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_2D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        int arr[ROWS][COLUMNS] = {5, 4, 3, 2, 1, 0};

    CComSafeArray<int> *ppExpected = CreateFrom(
        (int *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_2D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        BSTR arr[ROWS][COLUMNS] = { 
            NULL, 
            SysAllocString(L"This is a nested 0 string"),
            ToBSTR(3), 
            ToBSTR(2), 
            ToBSTR(1), 
            ToBSTR(0) };
    arr[0][1][17] = L'\0';

    CComSafeArray<BSTR> *ppExpected = CreateFrom(
        (BSTR *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Byte_2D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        BYTE arr[ROWS][COLUMNS] = {5, 4, 3, 2, 1, 0};

    CComSafeArray<BYTE> *ppExpected = CreateFrom(
        (BYTE *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_2D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        double arr[ROWS][COLUMNS] = {5, 4, 3, 2, 1, 0};

    CComSafeArray<double> *ppExpected = CreateFrom(
        (double *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_2D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        VARIANT_BOOL arr[ROWS][COLUMNS];
    int v = 0;
    for ( int i = 0; i < ROWS; ++i )
    {
        for ( int j = 0; j < COLUMNS; ++j )
        {
            if ( (v++) % 2 != 0 )
                arr[i][j] = VARIANT_TRUE;
            else
                arr[i][j] = VARIANT_FALSE;
        }
    }

    CComSafeArray<VARIANT_BOOL, VT_BOOL> *ppExpected = CreateFromVarType<VARIANT_BOOL, VT_BOOL>(
        (VARIANT_BOOL *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_2D_Out_ByRef(LPSAFEARRAY * ppActual, LPSAFEARRAY pExpected)
{
    CHECK_PARAM_EMPTY(*ppActual)

        return SUCCEEDED(SafeArrayCopy(pExpected, ppActual));
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_2D_Out_ByRef(LPSAFEARRAY * ppActual)
{
    CHECK_PARAM_EMPTY(*ppActual)

        VARIANT arr[ROWS][COLUMNS];
    int value = ROWS * COLUMNS - 1;
    for ( int r = 0; r < ROWS; ++r )
    {
        for ( int c = 0; c < COLUMNS; ++c )
        {
            VariantInit(&arr[r][c]);
            arr[r][c].vt = VT_I4;
            arr[r][c].lVal = value--;
        }
    }
    ::VariantClear(&arr[0][0]);
    arr[0][0].vt = VT_EMPTY;

    CComSafeArray<VARIANT> *ppExpected = CreateFrom(
        (VARIANT *)arr, ELEM_PER_ROW_2D(arr), ROWS_2D(arr));

    HRESULT hr = SafeArrayCopy(*ppExpected, ppActual);
    delete ppExpected;

    return SUCCEEDED(hr);
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_2D_Out_ByRef(LPSAFEARRAY * ppActual, LPSAFEARRAY pExpect)
{
    CHECK_PARAM_EMPTY(*ppActual)
        CHECK_PARAM_NOT_EMPTY(pExpect)

        IRecordInfo *pRecInfo = NULL;
    SAFEARRAYBOUND psaBound[2];

    SafeArrayGetRecordInfo(pExpect, &pRecInfo);
    SafeArrayGetLBound(pExpect, 1, &psaBound[0].lLbound);
    SafeArrayGetUBound(pExpect, 1, (LONG *)&psaBound[0].cElements);
    SafeArrayGetLBound(pExpect, 2, &psaBound[1].lLbound);
    SafeArrayGetUBound(pExpect, 2, (LONG *)&psaBound[1].cElements);

    psaBound[0].cElements = psaBound[0].cElements - psaBound[0].lLbound + 1;
    psaBound[1].cElements = psaBound[1].cElements - psaBound[1].lLbound + 1;

    *ppActual = SafeArrayCreateEx(VT_RECORD, 2, psaBound, pRecInfo);

    return CopyStructSafeArray(*ppActual, pExpect);
}

//////////////////////////////////// 1D ByVal In Out /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_1D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Int_1D(pActual) )
            return false;

    return SafeArray_Int_1D_Out(pActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_1D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_String_1D(pActual) )
            return false;

    return SafeArray_String_1D_Out(pActual);
}
extern "C" __declspec(dllexport) BOOL SafeArray_Byte_1D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Byte_1D(pActual) )
            return false;

    return SafeArray_Byte_1D_Out(pActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_1D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Double_1D(pActual) )
            return false;

    return SafeArray_Double_1D_Out(pActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_1D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Bool_1D(pActual) )
            return false;

    return SafeArray_Bool_1D_Out(pActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_1D_InOut(LPSAFEARRAY pActual, LPSAFEARRAY pExpected)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Delegate_1D(pActual) )
            return false;

    return SUCCEEDED(SafeArrayCopyData(pExpected, pActual));
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_1D_InOut(LPSAFEARRAY pActual, LPSAFEARRAY pExpected)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_TestStruct_1D(pActual) )
            return false;

    return SafeArray_TestStruct_1D_Out(pActual, pExpected);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_1D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Object_1D(pActual) )
            return false;

    return SafeArray_Object_1D_Out(pActual);
}

//////////////////////////////////// 2D ByVal In Out /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_2D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Int_2D(pActual) )
            return false;

    return SafeArray_Int_2D_Out(pActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_2D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_String_2D(pActual) )
            return false;

    return SafeArray_String_2D_Out(pActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Byte_2D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Byte_2D(pActual) )
            return false;

    return SafeArray_Byte_2D_Out(pActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_2D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Double_2D(pActual) )
            return false;

    return SafeArray_Double_2D_Out(pActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_2D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Bool_2D(pActual) )
            return false;

    return SafeArray_Bool_2D_Out(pActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_2D_InOut(LPSAFEARRAY pActual, LPSAFEARRAY pExpected)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Delegate_2D(pActual) )
            return false;

    return SUCCEEDED(SafeArrayCopyData(pExpected, pActual));
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_2D_InOut(LPSAFEARRAY pActual)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_Object_2D(pActual) )
            return false;

    return SafeArray_Object_2D_Out(pActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_2D_InOut(LPSAFEARRAY pActual, LPSAFEARRAY pExpected)
{
    CHECK_PARAM_NOT_EMPTY(pActual)

        if ( !SafeArray_TestStruct_2D(pActual) )
            return false;

    return SafeArray_TestStruct_2D_Out(pActual, pExpected);
}


////////////////////////////////////// 1D ByRef In Out /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_1D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Int_1D_InOut(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_1D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_String_1D_InOut(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Byte_1D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Byte_1D_InOut(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_1D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Double_1D_InOut(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_1D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Bool_1D_InOut(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_1D_InOut_ByRef(LPSAFEARRAY * ppActual, LPSAFEARRAY pExpected)
{
    return SafeArray_Delegate_1D_InOut(*ppActual, pExpected);
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_1D_InOut_ByRef(LPSAFEARRAY * ppActual, LPSAFEARRAY pExpect)
{
    return SafeArray_TestStruct_1D_InOut(*ppActual, pExpect);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_1D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Object_1D_InOut(*ppActual);
}

//////////////////////////////////// 2D ByRef In Out /////////////////////////////////////
extern "C" __declspec(dllexport) BOOL SafeArray_Int_2D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Int_2D_InOut(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_String_2D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_String_2D_InOut(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Byte_2D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Byte_2D_InOut(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Double_2D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Double_2D_InOut(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Bool_2D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Bool_2D_InOut(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Delegate_2D_InOut_ByRef(LPSAFEARRAY * ppActual, LPSAFEARRAY pExpected)
{
    return SafeArray_Delegate_2D_InOut(*ppActual, pExpected);
}

extern "C" __declspec(dllexport) BOOL SafeArray_Object_2D_InOut_ByRef(LPSAFEARRAY * ppActual)
{
    return SafeArray_Object_2D_InOut(*ppActual);
}

extern "C" __declspec(dllexport) BOOL SafeArray_TestStruct_2D_InOut_ByRef(LPSAFEARRAY * ppActual, LPSAFEARRAY pExpect)
{
    return SafeArray_TestStruct_2D_InOut(*ppActual, pExpect);
}
/////////////////////////////////////////////method for added array of struct as SafeArray//////////////////////////
extern "C" __declspec(dllexport) BOOL MarshalArrayOfStructAsParam_AsSafeArrayByVal(LPSAFEARRAY arrS2,LPSAFEARRAY pExpect)
{
    bool breturn = true;
    SAFEARRAY* correctArrS2 = ReturnArrOfStructS2(NumArrOfStructElements1,VT_RECORD,INT_MIN, 4294967295, 
        -32768, 65535, 0, 127, -32768, 65535, _I64_MIN, 18446744073709551615, 32.0, 3.2);
    if(!ValidateArrS2(arrS2, correctArrS2, 1, NumArrOfStructElements1))
    {
        printf("\t The Actual SafeArray is not the Expected SafeArray!");
        breturn = false;
    }
    SafeArrayDestroy(correctArrS2);
    SafeArrayDestroy(arrS2);

    IRecordInfo *pRecInfo = NULL;
    SAFEARRAYBOUND saBound;

    SafeArrayGetRecordInfo(pExpect, &pRecInfo);
    SafeArrayGetLBound(pExpect, 1, &saBound.lLbound);
    SafeArrayGetUBound(pExpect, 1, (LONG *)&saBound.cElements);
    saBound.cElements = saBound.cElements - saBound.lLbound + 1;

    arrS2 = SafeArrayCreateEx(VT_RECORD, 1, &saBound, pRecInfo);

    breturn = breturn&CopyStructS2SafeArray(arrS2, pExpect);
    return breturn;
}
extern "C" __declspec(dllexport) BOOL MarshalArrayOfStructAsParam_AsSafeArrayByRef(LPSAFEARRAY* arrS2,LPSAFEARRAY pExpect)
{
    return MarshalArrayOfStructAsParam_AsSafeArrayByVal(*arrS2, pExpect);
}
extern "C" __declspec(dllexport) BOOL MarshalArrayOfStructAsParam_AsSafeArrayByRefOut(LPSAFEARRAY *arrS2,LPSAFEARRAY pExpect)
{
    bool breturn = true;
    IRecordInfo *pRecInfo = NULL;
    SAFEARRAYBOUND saBound;

    SafeArrayGetRecordInfo(pExpect, &pRecInfo);
    SafeArrayGetLBound(pExpect, 1, &saBound.lLbound);
    SafeArrayGetUBound(pExpect, 1, (LONG *)&saBound.cElements);
    saBound.cElements = saBound.cElements - saBound.lLbound + 1;

    *arrS2 = SafeArrayCreateEx(VT_RECORD, 1, &saBound, pRecInfo);

    breturn = breturn&CopyStructS2SafeArray(*arrS2, pExpect);
    return breturn;
}
