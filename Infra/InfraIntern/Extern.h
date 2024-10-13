#pragma once

#include "Pronate.h"

#define Return \
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
if (!(arg##index == 0))\
{\
    a##index = arg##index;\
    RefKindClear(a##index);\
}\

