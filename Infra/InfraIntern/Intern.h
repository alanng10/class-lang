#pragma once

#include "Pronate.h"
#include "Prusate_Intern.h"

#define RefMemory(name) name = name & RefMaskMemory;

#define Return(ret, paramCount) \
eval->S[frame - (paramCount + 1)] = ret;\
eval->N = frame - paramCount;\
return 0;\


#define State(name) \
{\
    Int ka;\
    ka = CastInt(Intern_State_##name);\
\
    RefKindSet(ka, RefKindInt);\
\
    Int ke;\
    ke = ka;\
\
    Return(ke, 0);\
}\


Int Intern_Intern_FieldGet(Eval* eval, Int frame, Int index);
Int Intern_Intern_FieldSet(Eval* eval, Int frame, Int index);

Int* Intern_Intern_FieldMemory(Int o, Int index);
