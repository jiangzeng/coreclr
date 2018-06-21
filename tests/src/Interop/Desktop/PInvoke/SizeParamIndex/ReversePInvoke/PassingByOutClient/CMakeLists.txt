#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (ReversePInvoke_PassingByOutServer) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    PassingByOutServer.cpp 
) 
# Additional files to reference: 
# add the executable 
add_library (ReversePInvoke_PassingByOutServer SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS ReversePInvoke_PassingByOutServer DESTINATION bin) 
