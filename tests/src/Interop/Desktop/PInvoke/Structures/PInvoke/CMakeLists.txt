#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (MarshalStructAsParam) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    MarshalStructAsParamDLL.cpp 
) 
# Additional files to reference: 
#    MarshalStructAsParamDLL.h 
#    MarshalStructAsParamDLL.def 
# add the executable 
add_library (MarshalStructAsParam SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS MarshalStructAsParam DESTINATION bin) 
