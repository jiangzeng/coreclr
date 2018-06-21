#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (NativeDll) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    NativeDll.cpp 
) 
# Additional files to reference: 
#    NativeDll.def 
# add the executable 
add_library (NativeDll SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS NativeDll DESTINATION bin) 
