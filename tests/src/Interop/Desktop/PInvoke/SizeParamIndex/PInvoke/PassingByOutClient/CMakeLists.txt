#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (PInvoke_PassingByOutServer) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    PassingByOutServer.cpp 
) 
# Additional files to reference: 
#    PassingByOutServer.def 
# add the executable 
add_library (PInvoke_PassingByOutServer SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS PInvoke_PassingByOutServer DESTINATION bin) 
