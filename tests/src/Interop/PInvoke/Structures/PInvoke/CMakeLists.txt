#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (AsParamNative) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    AsParamNative.cpp 
) 
# Additional files to reference: 
#    AsParamNative.h 
#    AsParamNative.def 
# add the executable 
add_library (AsParamNative SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS AsParamNative DESTINATION bin) 
