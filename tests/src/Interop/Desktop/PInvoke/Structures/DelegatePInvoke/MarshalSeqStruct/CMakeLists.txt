#VCXPROJ 
cmake_minimum_required (VERSION 2.6) 
project (SeqPInvokeNative) 
include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake") 
include_directories(${INC_PLATFORM_DIR}) 
set(SOURCES 
    MarshalSeqStructDelRevPInvokeNative.cpp 
) 
# Additional files to reference: 
#    MarshalSeqStructDelRevPInvokeNative.h 
#    MarshalSeqStructDelRevPInvokeNative.def 
# add the executable 
add_library (SeqPInvokeNative SHARED ${SOURCES}) 
# add the install targets 
install (TARGETS SeqPInvokeNative DESTINATION bin) 
