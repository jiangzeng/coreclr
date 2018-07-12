#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (RevNative) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    RevNative.cpp 
) 
# Additional files to reference: 
#    RevNative.def 
# add the executable 
add_library (RevNative SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS RevNative DESTINATION bin) 
