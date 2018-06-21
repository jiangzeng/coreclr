#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (PInvoke_PassingByRefServer) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    PassingByRefServer.cpp 
) 
# Additional files to reference: 
#    PassingByRefServer.def 
# add the executable 
add_library (PInvoke_PassingByRefServer SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS PInvoke_PassingByRefServer DESTINATION bin) 
