#pragma once

#include "Pronate.h"

#define Return(paramCount) \
Int ke;\
ke = 0;\
\
if (!(a == IntNull))\
{\
    ke = a;\
\
    RefKindClear(ke);\
    RefKindSet(ke, RefKindInt);\
}\
\
eval->S[frame - (paramCount + 1)] = ke;\
eval->N = frame - paramCount;\
return 0;\


#define Param(index) \
Int arg##index;\
arg##index = eval->S[frame - (paramCount - index)];\
Int a##index;\
a##index = IntNull;\
\
if (!(arg##index == null))\
{\
    a##index = arg##index;\
    RefKindClear(a##index);\
}\

