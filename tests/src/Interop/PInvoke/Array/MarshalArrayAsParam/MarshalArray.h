// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#pragma once 
#include <stdio.h>
#include <stdlib.h> // required by itoa
#include <windows.h>
#include <atlcomcli.h>
#include <atlsafe.h>

#import "mscorlib.tlb" no_namespace
#include <iostream>

//////////////////////////////////////////////////////////////////////////////
// Macro definitions
//////////////////////////////////////////////////////////////////////////////
#define ARRAY_SIZE 100
#define ROWS 2
#define COLUMNS 3

#define COUNTOF(__arr) sizeof(__arr) / sizeof(__arr[0])
#define ELEM_PER_ROW_2D(__arr) (&(__arr[1][0]) - &(__arr[0][0]))
#define ROWS_2D(__arr) sizeof(__arr) / (ELEM_PER_ROW_2D(__arr) * sizeof(__arr[0][0]))

#define ENTERFUNC() printf("============ [%s]\t ============\n", __FUNCTION__)

#define CHECK_PARAM_NOT_EMPTY(__p) \
    ENTERFUNC(); \
    if ( (__p) == NULL ) \
    { \
    printf("[%s] Error: parameter actual is NULL\n", __FUNCTION__); \
    return false; \
    }

#define CHECK_PARAM_EMPTY(__p) \
    ENTERFUNC(); \
    if ( __p != NULL ) \
    { \
    printf("[%s] Error: parameter ppActual is not NULL\n", __FUNCTION__); \
    return false; \
    }

#define VERIFY_ERROR(__expect, __actual) \
    std::cout << '[' << __FUNCSIG__ << "] EXPECT: " << (__expect) << ", ACTUAL: " << (__actual) << std::endl

#define TRACE(__msg) \
    std::cout << __msg << std::endl

#define VERIFY_ERROR_MSG(__msg, __expect, __actual) \
    printf("["##__FUNCSIG__##"] "##__msg, (__expect), (__actual))

//////////////////////////////////////////////////////////////////////////////
// Verify helper methods
//////////////////////////////////////////////////////////////////////////////
template<typename T> bool IsObjectEquals(T o1, T o2)
{
    // T::operator== required.
    return o1 == o2;
}

// Special for LPCSTR, LPSTR will fall to this method
template<> bool IsObjectEquals(LPSTR o1, LPSTR o2)
{
    if ( o1 == NULL && o2 == NULL )
        return true;
    else if ( o1 == NULL && o2 != NULL )
        return false;
    else if ( o1 != NULL && o2 == NULL )
        return false;

    size_t cLen1 = strlen(o1);
    size_t cLen2 = strlen(o2);

    if (cLen1 != cLen2 )
        return false;

    return strncmp(o1, o2, cLen1) == 0;
}

template<> bool IsObjectEquals(BSTR o1, BSTR o2)
{
    if ( o1 == NULL && o2 == NULL )
        return true;
    else if ( o1 == NULL && o2 != NULL )
        return false;
    else if ( o1 != NULL && o2 == NULL )
        return false;

    UINT uLen1 = SysStringLen(o1);
    UINT uLen2 = SysStringLen(o2);

    if (uLen1 != uLen2 )
        return false;

    return memcmp(o1, o2, uLen1) == 0;
}

#ifndef BUG649499
template<> bool IsObjectEquals(VARIANT o1, VARIANT o2)
{
    CComVariant v1(o1);
    CComVariant v2(o2);

    return v1 == v2;
}
#endif
//////////////////////////////////////////////////////////////////////////////
// Test Data Structure
//////////////////////////////////////////////////////////////////////////////

LPSTR ToString(int i)
{
    CHAR *pBuffer = (CHAR *)::CoTaskMemAlloc(10 * sizeof(CHAR)); // 10 is enough for our case
    _itoa_s(i, pBuffer, sizeof(pBuffer) / sizeof(pBuffer[0]), 10);

    return pBuffer;
}

BSTR ToBSTR(int i)
{
    BSTR bstrRet = NULL;
    VarBstrFromI4(i, 0, 0, &bstrRet);

    return bstrRet;
}

struct TestStructSA
{
    inline TestStructSA()
        : x(0)
        , d(0)
        , l(0)
        , str(NULL)
    {
    }

    inline TestStructSA(int v)
        : x(v)
        , d(v)
        , l(v)
    {
        str = ToBSTR(v);
    }

    inline ~TestStructSA()
    {
        if ( str != NULL )
            SysFreeString(str);
    }

    int x;
    double d;
    LONG64 l;
    BSTR str;

    inline bool operator==(TestStructSA &other)
    {
        return IsObjectEquals(x, other.x) &&
            IsObjectEquals(d, other.d) &&
            IsObjectEquals(l, other.l) &&
            IsObjectEquals(str, other.str);
    }
};

struct TestStruct
{
    inline TestStruct()
        : x(0)
        , d(0)
        , l(0)
        , str(NULL)
    {
    }

    inline TestStruct(int v)
        : x(v)
        , d(v)
        , l(v)
    {
        str = ToString(v);
    }

    int x;
    double d;
    LONG64 l;
    LPSTR str;

    inline bool operator==(TestStruct &other)
    {
        return IsObjectEquals(x, other.x) &&
            IsObjectEquals(d, other.d) &&
            IsObjectEquals(l, other.l) &&
            IsObjectEquals(str, other.str);
    }
};

typedef struct S2
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
}S2;

// used in delegate array testing
typedef _Delegate * LPDELEGATE;
typedef LPDELEGATE * LPPDELEGATE;

//////////////////////////////////////////////////////////////////////////////
// Other methods
//////////////////////////////////////////////////////////////////////////////

// Do not output variants, and suppress the boring template compile warning
std::ostream &operator<<(std::ostream &ostr, VARIANT &v)
{
    return ostr;
}

std::ostream &operator<<(std::ostream &ostr, BSTR &b)
{
    std::wcout << b;
    return ostr;
}

//////////////////////////////////////////////////////////////////////////////
// SafeArray methods
//////////////////////////////////////////////////////////////////////////////
#ifndef BUG649499

template<typename T, VARTYPE _vartype> 
CComSafeArray<T, _vartype> *CreateFromVarType(T *arr, size_t cElem)
{
    CComSafeArray<T, _vartype> *pArray = 
        new CComSafeArray<T, _vartype>(cElem);

    for ( size_t i = 0; i < cElem; ++i )
        pArray->SetAt(i, arr[i]);

    return pArray;
}

template<typename T>
CComSafeArray<T, _ATL_AutomationType<T>::type> *CreateFrom(T *arr, size_t cElem)
{
    return CreateFromVarType<T, _ATL_AutomationType<T>::type>(arr, cElem);
}

template<typename T, VARTYPE _vartype>
CComSafeArray<T, _vartype> *CreateFromVarType(T *arr, size_t cElemPerRow, size_t rows)
{
    SAFEARRAYBOUND bounds[2];

    bounds[0].cElements = rows;
    bounds[0].lLbound = 0;
    bounds[1].cElements = cElemPerRow;
    bounds[1].lLbound = 0;

    CComSafeArray<T, _vartype> *pArray = 
        new CComSafeArray<T, _vartype>(bounds, 2);

    for ( size_t i = 0; i < rows; ++i )
    {
        for ( size_t j = 0; j < cElemPerRow; ++j )
        {
            LONG idx[2] = {i, j};
            T v = *(arr++);
            pArray->MultiDimSetAt(idx, v);
        }
    }

    return pArray;
}

template<typename T>
CComSafeArray<T, _ATL_AutomationType<T>::type> *CreateFrom(T *arr, size_t cElemPerRow, size_t rows)
{
    return CreateFromVarType<T, _ATL_AutomationType<T>::type>(arr, cElemPerRow, rows);
}

template<typename T, VARTYPE _vartype>
CComSafeArray<T, _vartype> *CreateFromVarType(T *arr, size_t xs, size_t ys, size_t zs)
{
    SAFEARRAYBOUND bounds[3];

    bounds[0].cElements = zs;
    bounds[0].lLbound = 0;
    bounds[1].cElements = ys;
    bounds[1].lLbound = 0;
    bounds[2].cElements = xs;
    bounds[2].lLbound = 0;

    CComSafeArray<T, _vartype> *pArray = 
        new CComSafeArray<T, _vartype>(bounds, 3);

    for ( size_t i = 0; i < zs; ++i )
    {
        for ( size_t j = 0; j < ys; ++j )
        {
            for ( size_t k = 0; k < xs; ++k )
            {
                LONG idx[3] = {i, j, k};
                T v = *(arr++);
                pArray->MultiDimSetAt(idx, v);
            }
        }
    }

    return pArray;
}

template<typename T>
CComSafeArray<T, _ATL_AutomationType<T>::type> *CreateFrom(T *arr, size_t xs, size_t ys, size_t zs)
{
    return CreateFromVarType<T, _ATL_AutomationType<T>::type>(arr, xs, ys, zs);
}

template<typename T, VARTYPE _vartype1, typename U>
bool EqualsVarType(CComSafeArray<T, _vartype1> &arr1, 
                   LPSAFEARRAY pSafeArray)
{	
    bool retval = true;
    LONG *idx = NULL;
    UINT *lowers = NULL;
    UINT *uppers = NULL;

    if ( arr1.GetDimensions() != SafeArrayGetDim(pSafeArray) )
    {
        printf("Safearray dimensions is not as expected\n");
        retval = false;
        goto Leave;
    }

    UINT dimens = arr1.GetDimensions();
    idx = new LONG[dimens];
    lowers = new UINT[dimens];
    uppers = new UINT[dimens];

    for ( UINT i = 0; i < dimens; ++i )
    {
        UINT lower1 = arr1.GetLowerBound(i);
        LONG lower2 = 0;
        SafeArrayGetLBound(pSafeArray, i + 1, &lower2);

        UINT upper1 = arr1.GetUpperBound(i);
        LONG upper2 = 0; 
        SafeArrayGetUBound(pSafeArray, i + 1, &upper2);

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

    while ( ((UINT)idx[0]) <= uppers[0] )
    {
        T elem1;
        U elem2;
        memset(&elem1, 0, sizeof(elem1));
        memset(&elem2, 0, sizeof(elem2));
        if ( FAILED(arr1.MultiDimGetAt(idx, elem1)) )
        {
            TRACE("Failed to get element\n");
            retval = false;
            goto Leave;
        }

        if ( FAILED(SafeArrayGetElement(pSafeArray, idx, &elem2)) )
        {
            TRACE("Failed to get element\n");
            retval = false;
            goto Leave;
        }

        if ( !IsObjectEquals(elem1, elem2) )
        {
            VERIFY_ERROR(elem1, elem2);
            retval = false;
            goto Leave;
        }

        int curDimens = ((int)dimens - 1);
        while ( ((UINT)++idx[curDimens]) > uppers[curDimens] )
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

template<typename T, VARTYPE _vartype1, typename U, VARTYPE _vartype2>
bool EqualsVarType(CComSafeArray<T, _vartype1> &arr1, 
                   CComSafeArray<U, _vartype2> &arr2)
{
    return EqualsVarType<T, _vartype1, U>(arr1, (LPSAFEARRAY)arr2);
}

template<typename T, typename U>
bool Equals(CComSafeArray<T> &arr1, 
            CComSafeArray<U> &arr2)
{
    return EqualsVarType<T, _ATL_AutomationType<T>::type, 
        U, _ATL_AutomationType<U>::type>(arr1, arr2);
}

template<typename T, VARTYPE _vartype>
bool EqualsVarType(CComSafeArray<T, _vartype> &arr1, 
                   LPSAFEARRAY pSafeArray)
{
    return EqualsVarType<T, _vartype, T>(arr1, pSafeArray);
}

template<typename T>
bool Equals(CComSafeArray<T> &arr1, 
            LPSAFEARRAY pSafeArray)
{
    return EqualsVarType<T, _ATL_AutomationType<T>::type>(arr1, pSafeArray);
}
#endif

//////////////////////////////////Methods for Array of Struct As SafeArray///////////////////////////
////////////////////////////Validate SAFEARRAY's Bound and Dims//////////////////////////////////////
bool ValidateBoundsAndDim(SAFEARRAY* psa, int nDim, int numArrElements)
{
    long lUbound, lLbound;
    HRESULT hr;

    //get upperbound
    hr = SafeArrayGetUBound(psa, nDim, &lUbound);
    if( FAILED(hr) )
    {
        printf("\t\tSafeArrayGetUBound call in ValidateBoundsAndDim failed!\n");
        return false;
    }

    //check upperbound
    if( lUbound != numArrElements-1 ) 
    {
        printf("\t\tlUbound not as expected in ValidateBoundsAndDim!\n");
        printf("\t\t\tlUbound = %d",lUbound);
        return false;
    }

    //get lowerbound
    hr = SafeArrayGetLBound(psa, nDim, &lLbound);
    if( FAILED(hr) )
    {
        printf("\t\tSafeArrayGetLBound call in ValidateBoundsAndDim failed!\n");
        return false;
    }

    //check lowerbound
    if( lLbound != 0 ) 
    {
        printf("\t\tlLbound not as expected in ValidateBoundsAndDim!\n");
        printf("\t\t\tlLbound = %d",lLbound);
        return false;
    }

    //check dimension
    if( SafeArrayGetDim(psa) != nDim )
    {
        printf("\t\tDimension not as expected in ValidateBoundsAndDim!\n");
        return false;
    }
    return true;
}

//////////////////////////////////method for struct S2////////////////////////////////////////////////
void InstanceS2(S2 HUGEP* pREC, int i32,UINT ui32,SHORT s1,WORD us1,BYTE b,CHAR sb,SHORT i16,WORD ui16,
                LONG64 i64,ULONG64 ui64,FLOAT sgl,DOUBLE d)
{
    pREC->i32 = i32;
    pREC->ui32 = ui32;
    pREC->s1 = s1;
    pREC->us1 = us1;
    pREC->b = b;
    pREC->sb = sb;
    pREC->i16 = i16;
    pREC->ui16 = ui16;
    pREC->i64 = i64;
    pREC->ui64 = ui64;
    pREC->sgl = sgl;
    pREC->d = d;
}

SAFEARRAY* ReturnArrOfStructS2(int numArrElements, VARTYPE vt,int i32,UINT ui32,SHORT s1,WORD us1,BYTE b,CHAR sb,SHORT i16,WORD ui16,
                               LONG64 i64,ULONG64 ui64,FLOAT sgl,DOUBLE d)
{
    SAFEARRAY FAR* psa;
    int dims = 1;
    HRESULT hr;
    S2 pREC;

    SAFEARRAYBOUND rgsabound;
    rgsabound.cElements = numArrElements;
    rgsabound.lLbound = 0;

    InstanceS2(&pREC, i32, ui32, s1, us1, b, sb, i16, ui16, i64, ui64, sgl, d);
    psa = SafeArrayCreate(VT_VARIANT, dims, &rgsabound);

    if( psa == NULL )
    {
        printf("\t\tSafeArrayCreate VT_VARIANT call in ReturnArrOfStruct failed!\n");
        return NULL;
    }

    for(long i = 0;i<numArrElements;i++)
    {
        VARIANT tempVar;
        tempVar.vt = VT_RECORD;
        tempVar.pvRecord = &pREC;
        hr = SafeArrayPutElement(psa, &i,tempVar.pvRecord);
        if(FAILED(hr))
        {
            printf("\tPut Elements to Array has failures!");
            return NULL;
        }
    }
    return psa;
}

bool ValidateS2Data(SAFEARRAY* psa, SAFEARRAY* correctArr, int numArrElements)
{
    VARIANT FAR rgvarpsa[10];
    VARIANT FAR rgvarcorrectArr[10];
    for(long i = 0;i<numArrElements;i++)
    {
        VariantInit(&rgvarpsa[i]);
        VariantInit(&rgvarcorrectArr[i]); 

        HRESULT hr1 = SafeArrayGetElement(psa,&i,&rgvarpsa[i]);
        HRESULT hr2 = SafeArrayGetElement(correctArr, &i, &rgvarcorrectArr[i]);

        if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->i32 != ((S2*)(rgvarcorrectArr[i].pvRecord))->i32)
        {
            printf("\t The field of int is not the expected!");
            printf("\t\tpsa[%d].S2->i32 = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->i32);
            printf("\t\tcorrectArr[%d].S2->i32 = %d\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->i32);
            return false;
        }
        else if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->ui32 != ((S2*)(rgvarcorrectArr[i].pvRecord))->ui32)
        {
            printf("\t The field of UInt32 is not the expected!");
            printf("\t\tpsa[%d].S2->ui32 = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->ui32);
            printf("\t\tcorrectArr[%d].S2->ui32 = %u\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->ui32);
            return false;
        }
        else if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->s1 != ((S2*)(rgvarcorrectArr[i].pvRecord))->s1)
        {
            printf("\t The field of short is not the expected!");
            printf("\t\tpsa[%d].S2->s1 = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->s1);
            printf("\t\tcorrectArr[%d].S2->s1 = %d\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->s1);
            return false;
        }
        else if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->us1 != ((S2*)(rgvarcorrectArr[i].pvRecord))->us1)
        {
            printf("\t The field of ushort is not the expected!");
            printf("\t\tpsa[%d].S2->us1 = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->us1);
            printf("\t\tcorrectArr[%d].S2->us1 = %u\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->us1);
            return false;
        }
        else if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->b != ((S2*)(rgvarcorrectArr[i].pvRecord))->b)
        {
            printf("\t The field of byte is not the expected!");
            printf("\t\tpsa[%d].S2->b = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->b);
            printf("\t\tcorrectArr[%d].S2->b = %d\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->b);
            return false;
        }
        else if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->sb != ((S2*)(rgvarcorrectArr[i].pvRecord))->sb)
        {
            printf("\t The field of sbyte is not the expected!");
            printf("\t\tpsa[%d].S2->sb = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->sb);
            printf("\t\tcorrectArr[%d].S2->sb = %u\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->sb);
            return false;
        }
        else if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->i16 != ((S2*)(rgvarcorrectArr[i].pvRecord))->i16)
        {
            printf("\t The field of Int16 is not the expected!");
            printf("\t\tpsa[%d].S2->i16 = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->i16);
            printf("\t\tcorrectArr[%d].S2->i16 = %d\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->i16);
            return false;
        }
        else if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->ui16 != ((S2*)(rgvarcorrectArr[i].pvRecord))->ui16)
        {
            printf("\t The field of UInt16 is not the expected!");
            printf("\t\tpsa[%d].S2->ui16 = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->ui16);
            printf("\t\tcorrectArr[%d].S2->ui16 = %u\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->ui16);
            return false;
        }
        else if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->i64 != ((S2*)(rgvarcorrectArr[i].pvRecord))->i64)
        {
            printf("\t The field of Int64 is not the expected!");
            printf("\t\tpsa[%d].S2->i64 = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->i64);
            printf("\t\tcorrectArr[%d].S2->i64 = %d\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->i64);
            return false;
        }
        else if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->ui64 != ((S2*)(rgvarcorrectArr[i].pvRecord))->ui64)
        {
            printf("\t The field of UInt64 is not the expected!");
            printf("\t\tpsa[%d].S2->ui64 = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->ui64);
            printf("\t\tcorrectArr[%d].S2->ui64 = %u\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->ui64);
            return false;
        }
        else if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->sgl != ((S2*)(rgvarcorrectArr[i].pvRecord))->sgl)
        {
            printf("\t The field of single is not the expected!");
            printf("\t\tpsa[%d].S2->sgl = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->sgl);
            printf("\t\tcorrectArr[%d].S2->sgl = %f\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->sgl);
            return false;
        }
        else if(rgvarpsa[i].vt != rgvarcorrectArr[i].vt && ((S2*)rgvarpsa[i].pvRecord)->d != ((S2*)(rgvarcorrectArr[i].pvRecord))->d)
        {
            printf("\t The field of double is not the expected!");
            printf("\t\tpsa[%d].S2->d = %d\n", i, ((S2*)rgvarpsa[i].pvRecord)->d);
            printf("\t\tcorrectArr[%d].S2->d = %f\n", i, ((S2*)rgvarcorrectArr[i].pvRecord)->d);
            return false;
        }
    }
    return true;
}

bool ValidateArrS2(SAFEARRAY* psa, SAFEARRAY* correctArr, int nDim,int numArrElements)
{
    if( !ValidateBoundsAndDim(psa, nDim,numArrElements) )
        return false;

    if( !ValidateS2Data(psa, correctArr, numArrElements) )
        return false;

    return true;
}

bool CopyStructS2SafeArray(LPSAFEARRAY pActual, LPSAFEARRAY pExpect)
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
            retval = false;
            goto Leave;
        }
        if ( upper1 != (UINT)upper2 )
        {
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
        S2 *ptsExpect = NULL;
        S2 *ptsActual = NULL;
        SafeArrayPtrOfIndex(pExpect, idx, (void **)&ptsExpect);
        SafeArrayPtrOfIndex(pActual, idx, (void **)&ptsActual);

        if ( ptsActual == NULL )
            ptsActual = new S2;

        if ( ptsActual != NULL )
        {
            ptsActual->i32 = ptsExpect->i32;
            ptsActual->ui32 = ptsExpect->ui32;
            ptsActual->s1 = ptsExpect->s1;
            ptsActual->us1 = ptsExpect->us1;
            ptsActual->b = ptsExpect->b;
            ptsActual->sb = ptsExpect->sb;
            ptsActual->i16 = ptsExpect->i16;
            ptsActual->ui16 = ptsExpect->ui16;
            ptsActual->i64 = ptsExpect->i64;
            ptsActual->ui64 = ptsExpect->ui64;
            ptsActual->sgl = ptsExpect->sgl;
            ptsActual->d = ptsExpect->d;
        }

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

bool ValidateS2LPArray(S2 HUGEP* pREC, S2 HUGEP* pRECCorrect, int numArrElement)
{
    for(int i = 0; i<numArrElement;i++)
    {
        if(pREC[i].i32 != pRECCorrect[i].i32)
        {
            printf("\t The field of int is not the expected!");
            printf("\t\tpREC[%d].i32 = %d\n", i, pREC[i].i32);
            printf("\t\tpRECCorrect[%d].i32 = %d\n", i, pRECCorrect[i].i32);
            return false;
        }
        else if(pREC[i].ui32 != pRECCorrect[i].ui32)
        {
            printf("\t The field of UInt32 is not the expected!");
            printf("\t\tpREC[%d].ui32 = %d\n", i, pREC[i].ui32);
            printf("\t\tpRECCorrect[%d].ui32 = %u\n", i, pRECCorrect[i].ui32);
            return false;
        }
        else if(pREC[i].s1 != pRECCorrect[i].s1)
        {
            printf("\t The field of short is not the expected!");
            printf("\t\tpREC[%d].s1 = %d\n", i, pREC[i].s1);
            printf("\t\tpRECCorrect[%d].s1 = %d\n", i, pRECCorrect[i].s1);
            return false;
        }
        else if(pREC[i].us1 != pRECCorrect[i].us1)
        {
            printf("\t The field of ushort is not the expected!");
            printf("\t\tpREC[%d].us1 = %d\n", i, pREC[i].us1);
            printf("\t\tpRECCorrect[%d].us1 = %u\n", i, pRECCorrect[i].us1);
            return false;
        }
        else if(pREC[i].b != pRECCorrect[i].b)
        {
            printf("\t The field of byte is not the expected!");
            printf("\t\tpREC[%d].b = %d\n", i, pREC[i].b);
            printf("\t\tpRECCorrect[%d].b = %d\n", i, pRECCorrect[i].b);
            return false;
        }
        else if(pREC[i].sb != pRECCorrect[i].sb)
        {
            printf("\t The field of sbyte is not the expected!");
            printf("\t\tpREC[%d].sb = %d\n", i, pREC[i].sb);
            printf("\t\tpRECCorrect[%d].sb = %u\n", i, pRECCorrect[i].sb);
            return false;
        }
        else if(pREC[i].i16 != pRECCorrect[i].i16)
        {
            printf("\t The field of Int16 is not the expected!");
            printf("\t\tpREC[%d].i16 = %d\n", i, pREC[i].i16);
            printf("\t\tpRECCorrect[%d].i16 = %d\n", i, pRECCorrect[i].i16);
            return false;
        }
        else if(pREC[i].ui16 != pRECCorrect[i].ui16)
        {
            printf("\t The field of UInt16 is not the expected!");
            printf("\t\tpREC[%d].ui16 = %d\n", i, pREC[i].ui16);
            printf("\t\tpRECCorrect[%d].ui16 = %u\n", i, pRECCorrect[i].ui16);
            return false;
        }
        else if(pREC[i].i64 != pRECCorrect[i].i64)
        {
            printf("\t The field of Int64 is not the expected!");
            printf("\t\tpREC[%d].i64 = %d\n", i, pREC[i].i64);
            printf("\t\tpRECCorrect[%d].i64 = %d\n", i, pRECCorrect[i].i64);
            return false;
        }
        else if(pREC[i].ui64 != pRECCorrect[i].ui64)
        {
            printf("\t The field of UInt64 is not the expected!");
            printf("\t\tpREC[%d].ui64 = %d\n", i, pREC[i].ui64);
            printf("\t\tpRECCorrect[%d].ui64 = %u\n", i, pRECCorrect[i].ui64);
            return false;
        }
        else if(pREC[i].sgl != pRECCorrect[i].sgl)
        {
            printf("\t The field of single is not the expected!");
            printf("\t\tpREC[%d].sgl = %d\n", i, pREC[i].sgl);
            printf("\t\tpRECCorrect[%d].sgl = %f\n", i, pRECCorrect[i].sgl);
            return false;
        }
        else if(pREC[i].d != pRECCorrect[i].d)
        {
            printf("\t The field of double is not the expected!");
            printf("\t\tpREC[%d].d = %d\n", i, pREC[i].d);
            printf("\t\tpRECCorrect[%d].d = %f\n", i, pRECCorrect[i].d);
            return false;
        }
    }
    return true;
}