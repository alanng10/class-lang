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