// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the NATIVEDATETIME_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// NATIVEDATETIME_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef NATIVEDATETIME_EXPORTS
#define NATIVEDATETIME_API __declspec(dllexport)
#else
#define NATIVEDATETIME_API __declspec(dllimport)
#endif

// This class is exported from the NativeDateTime.dll
class NATIVEDATETIME_API CNativeDateTime {
public:
	CNativeDateTime(void);
	// TODO: add your methods here.
};

extern NATIVEDATETIME_API int nNativeDateTime;

NATIVEDATETIME_API int fnNativeDateTime(void);
