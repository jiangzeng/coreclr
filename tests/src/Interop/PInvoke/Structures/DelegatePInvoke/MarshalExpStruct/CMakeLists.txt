#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (ReversePInvokeNative) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    ExpStructAsParamNative.cpp 
) 
# Additional files to reference: 
#    ExpStructAsParamNative.h 
#    ExpStructAsParamNative.def 
# add the executable 
add_library (ReversePInvokeNative SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS ReversePInvokeNative DESTINATION bin) 
