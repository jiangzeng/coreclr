#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (ExactSpellingNative) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES ExactSpellingNative.cpp) 
# Additional files to reference: 
#    ExactSpellingNative.def 
# add the executable 
add_library (ExactSpellingNative SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS ExactSpellingNative DESTINATION bin) 
