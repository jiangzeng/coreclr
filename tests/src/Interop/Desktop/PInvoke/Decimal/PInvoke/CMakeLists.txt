#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (NativeServer) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    DecLib.cpp 
) 
# Additional files to reference: 
# add the executable 
add_library (NativeServer SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS NativeServer DESTINATION bin) 
