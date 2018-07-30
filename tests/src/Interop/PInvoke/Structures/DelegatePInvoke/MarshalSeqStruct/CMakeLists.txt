#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (SeqPInvokeNative) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    SeqStructDelRevPInvokeNative.cpp 
) 
# Additional files to reference: 
#    SeqStructDelRevPInvokeNative.h 
#    SeqStructDelRevPInvokeNative.def 
# add the executable 
add_library (SeqPInvokeNative SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS SeqPInvokeNative DESTINATION bin) 
