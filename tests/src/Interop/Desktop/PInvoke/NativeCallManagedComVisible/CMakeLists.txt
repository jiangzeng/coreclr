#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (ComVisibleClient) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    ComVisibleClient.cpp 
) 
# Additional files to reference: 
# add the executable 
add_library (ComVisibleClient SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS ComVisibleClient DESTINATION bin) 
