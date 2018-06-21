#include <stdio.h>
#include <iostream>
#include "WTypes.h"
//#include "atlcomcli.h"
using namespace std;

/*-------------------------------------------------------------
Macro
-------------------------------------------------------------*/
#define ARRAY_SIZE 100

#define ENTERFUNC() printf("============ [%s]\t ============\n", __FUNCTION__)

#define COUNTOF(__arr) sizeof(__arr) / sizeof(__arr[0])

#define CHECK_PARAM_NOT_EMPTY(__p) \
    if ( (__p) == NULL ) \
{ \
    printf("[%s] Error: parameter actual is NULL\n", __FUNCTION__); \
    return false; \
}

#define INIT_ARRAY(__type, __array_name, __size) \
    __type __array_name[__size]; \
    for ( size_t i = 0; i < __size; ++i ) \
    __array_name[i] = (__type)i

#define VERIFY_ERROR(__expect, __actual) \
    std::cout << '[' << __FUNCSIG__ << "] EXPECT: " << (__expect) << ", ACTUAL: " << (__actual) << std::endl

#define TRACE(__msg) \
    std::cout << __msg << std::endl

#define VERIFY_ERROR_MSG(__msg, __expect, __actual) \
    printf("["##__FUNCSIG__##"] "##__msg, (__expect), (__actual))

/*-------------------------------------------------------------
Helper
-------------------------------------------------------------*/
template<typename T>
bool IsObjectEquals(T o1, T o2)
{
    // T::operator== required.
    return o1 == o2;
}

template<>
bool IsObjectEquals(BSTR o1, BSTR o2)
{
    UINT uLen1 = SysStringLen(o1);
    UINT uLen2 = SysStringLen(o2);

    if (uLen1 != uLen2 )
        return false;

    return memcmp(o1, o2, uLen1) == 0;
}

template<>
bool IsObjectEquals(VARIANT o1, VARIANT o2)
{
    CComVariant v1(o1);
    CComVariant v2(o2);

    return v1 == v2;
}

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


template<typename T, VARTYPE _vartype>
bool EqualsVarType(CComSafeArray<T, _vartype> &arr1, 
                   LPSAFEARRAY pSafeArray)
{
    CComSafeArray<T, _vartype> arr2(pSafeArray);
    bool retval = true;
    LONG *idx = NULL;
    UINT *lowers = NULL;
    UINT *uppers = NULL;

    if ( arr1.GetDimensions() != arr2.GetDimensions() )
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
        UINT lower2 = arr2.GetLowerBound(i);

        UINT upper1 = arr1.GetUpperBound(i);
        UINT upper2 = arr2.GetUpperBound(i);

        if ( lower1 != lower2 )
        {
            VERIFY_ERROR_MSG("Safearray lower bound wrong, EXPECT: %d, ACTUAL: %d\n", lower1, lower2);
            retval = false;
            goto Leave;
        }
        if ( upper1 != upper2 )
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

    while ( ((UINT) idx[0]) <= uppers[0] )
    {
        T elem1, elem2;
        if ( FAILED(arr1.MultiDimGetAt(idx, elem1)) )
        {
            TRACE("Failed to get element\n");
            retval = false;
            goto Leave;
        }

        if ( FAILED(arr2.MultiDimGetAt(idx, elem2)) )
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
        while ( ((UINT) ++idx[curDimens]) > uppers[curDimens] )
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

    while ( idx[0] <= uppers[0] )
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

template<typename T>
bool Equals(CComSafeArray<T> &arr1, 
            LPSAFEARRAY pSafeArray)
{
    return EqualsVarType<T, _ATL_AutomationType<T>::type>(arr1, pSafeArray);
}

BSTR ToBSTR(int i)
{
    BSTR bstrRet = NULL;
    VarBstrFromI4(i, 0, 0, &bstrRet);

    return bstrRet;
}

////////////////////////////////////////////struct declaration//////////////////////////////////////////////
struct Struct_Sequential
{
    LPSAFEARRAY longArr;
    LPSAFEARRAY ulongArr;
    LPSAFEARRAY shortArr;
    LPSAFEARRAY ushortArr;
    LPSAFEARRAY long64Arr;
    LPSAFEARRAY ulong64Arr;
    LPSAFEARRAY doubleArr;
    LPSAFEARRAY floatArr;
    LPSAFEARRAY byteArr;
    LPSAFEARRAY bstrArr;
    LPSAFEARRAY boolArr;
};

struct Struct_Explicit 
{
#ifdef _WIN64
    LPSAFEARRAY longArr;
    LPSAFEARRAY ulongArr;
    LPSAFEARRAY shortArr;
    LPSAFEARRAY ushortArr;
    LPSAFEARRAY long64Arr;
    LPSAFEARRAY ulong64Arr;
    LPSAFEARRAY doubleArr;
    LPSAFEARRAY floatArr;
    LPSAFEARRAY byteArr;
    LPSAFEARRAY bstrArr;
    LPSAFEARRAY boolArr;
#else
    LPSAFEARRAY longArr;
    int _unused0;
    LPSAFEARRAY ulongArr;
    int _unused1;
    LPSAFEARRAY shortArr;
    int _unused2;
    LPSAFEARRAY ushortArr;
    int _unused3;
    LPSAFEARRAY long64Arr;
    int _unused4;
    LPSAFEARRAY ulong64Arr;
    int _unused5;
    LPSAFEARRAY doubleArr;
    int _unused6;
    LPSAFEARRAY floatArr;
    int _unused7;
    LPSAFEARRAY byteArr;
    int _unused8;
    LPSAFEARRAY bstrArr;
    int _unused9;
    LPSAFEARRAY boolArr;
#endif
};

typedef struct S2
{
    INT i32; //4
    UINT ui32; //4
    SHORT s1;  //2
    WORD us1;  //2
    BYTE b;    //1
    CHAR sb;   //1
    SHORT i16; //2
    WORD ui16; //2
    LONG64 i64; //8
    ULONG64 ui64; //8
    FLOAT sgl;    //4
    DOUBLE d;     //8
} S2;

struct Struct_SeqWithArrOfStr
{
    LPSAFEARRAY arrS2;
};

struct Struct_ExpWithArrOfStr
{
    LPSAFEARRAY arrS2;
};

bool ValidateArrS2(S2 actualS2, S2 expectedS2)
{
    bool bResult = true;

    if(actualS2.i32 != expectedS2.i32)
    {
        bResult = false;
        printf("The i32 element doesnt match. Expected:%d,Actual:%d\n",expectedS2.i32,actualS2.i32);
    }
    if(actualS2.ui32 != expectedS2.ui32)
    {
        bResult = false;
        printf("The ui32 element doesnt match. Expected:%d,Actual:%d\n",expectedS2.ui32,actualS2.ui32);
    }

    if(actualS2.s1 != expectedS2.s1)
    {
        bResult = false;
        printf("The s1 element doesnt match. Expected:%d,Actual:%d\n",expectedS2.s1,actualS2.s1);
    }

    if(actualS2.us1 != expectedS2.us1)
    {
        bResult = false;
        printf("The us1 element doesnt match. Expected:%d,Actual:%d\n",expectedS2.us1,actualS2.us1);
    }

    if(actualS2.b != expectedS2.b)
    {
        bResult = false;
        printf("The b element doesnt match. Expected:%d,Actual:%d\n",expectedS2.b,actualS2.b);
    }
    if(actualS2.sb != expectedS2.sb)
    {
        bResult = false;
        printf("The sb element doesnt match. Expected:%d,Actual:%d\n",expectedS2.sb,actualS2.sb);
    }

    if(actualS2.i16 != expectedS2.i16)
    {
        bResult = false;
        printf("The i16 element doesnt match. Expected:%d,Actual:%d\n",expectedS2.i16,actualS2.i16);
    }
    if(actualS2.ui16 != expectedS2.ui16)
    {
        bResult = false;
        printf("The ui16 element doesnt match. Expected:%d,Actual:%d\n",expectedS2.ui16,actualS2.ui16);
    }

    if(actualS2.i64 != expectedS2.i64)
    {
        bResult = false;
        printf("The i64 element doesnt match. Expected:%d,Actual:%d\n",expectedS2.i64,actualS2.i64);
    }
    if(actualS2.ui64 != expectedS2.ui64)
    {
        bResult = false;
        printf("The ui64 element doesnt match. Expected:%d,Actual:%d\n",expectedS2.ui64,actualS2.ui64);
    }

    if(actualS2.sgl != expectedS2.sgl)
    {
        bResult = false;
        printf("The sgl element doesnt match. Expected:%d,Actual:%d\n",expectedS2.sgl,actualS2.sgl);
    }
    if(actualS2.d != expectedS2.d)
    {
        bResult = false;
        printf("The d element doesnt match. Expected:%d,Actual:%d\n",expectedS2.d,actualS2.d);
    }
    return bResult;
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
