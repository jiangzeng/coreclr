#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (PInvoke_ExactSpellingServer) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    Server.cpp 
) 
# Additional files to reference: 
#    PInvoke_ExactSpelling.def 
# add the executable 
add_library (PInvoke_ExactSpellingServer SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS PInvoke_ExactSpellingServer DESTINATION bin) 
