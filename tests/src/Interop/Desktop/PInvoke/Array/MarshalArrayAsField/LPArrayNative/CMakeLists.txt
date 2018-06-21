#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (MarshalArrayByValArrayNative) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    MarshalArrayByValArrayNative.cpp 
) 
# Additional files to reference: 
# add the executable 
add_library (MarshalArrayByValArrayNative SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS MarshalArrayByValArrayNative DESTINATION bin) 
