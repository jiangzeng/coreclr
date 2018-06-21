#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (CPPComponent) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    module.cpp 
) 
# Additional files to reference: 
#    module.def 
# add the executable 
add_library (CPPComponent SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS CPPComponent DESTINATION bin) 
