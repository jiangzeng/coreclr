#include <stdio.h>
#include <windows.h>

typedef BOOL(__stdcall *HandleCallback)(void*);

size_t __stdcall In(void* handle, HandleCallback handleCallback)
{
    if (handleCallback != nullptr && !handleCallback(handle))
    {
        return -1;
    }

    return reinterpret_cast<size_t>(handle);
}

void* __stdcall Ret(void* handleValue)
{
    return handleValue;
}

void __stdcall Out(void* handleValue, void** pHandle)
{
    if (pHandle == nullptr)
    {
        return;
    }

    *pHandle = handleValue;
}

size_t __stdcall Ref(void** pHandle, HandleCallback handleCallback)
{
    if (handleCallback != nullptr && !handleCallback(*pHandle))
    {
        return -1;
    }

    return reinterpret_cast<size_t>(*pHandle);
}

size_t __stdcall RefModify(void* handleValue, void** pHandle, HandleCallback handleCallback)
{
    if (handleCallback != nullptr && !handleCallback(*pHandle))
    {
        return -1;
    }

    void* originalHandle = *pHandle;

    *pHandle = handleValue;

    return reinterpret_cast<size_t>(originalHandle);
}

typedef void(__stdcall *InCallback)(void*);

void __stdcall InvokeInCallback(InCallback callback, void* handle)
{
    callback(handle);
}

typedef void(__stdcall *RefCallback)(void**);

void __stdcall InvokeRefCallback(RefCallback callback, void** pHandle)
{
    callback(pHandle);
}

typedef void*(__stdcall *RetCallback)();

void* __stdcall InvokeRetCallback(RetCallback callback)
{
    return callback();
}