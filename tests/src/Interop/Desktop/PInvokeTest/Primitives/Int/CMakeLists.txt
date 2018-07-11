#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (PInvokeInt) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES PInvokeInt.cpp) 
# Additional files to reference: 
#    PInvokeInt.def 
# add the executable 
add_library (PInvokeInt SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS PInvokeInt DESTINATION bin) 
