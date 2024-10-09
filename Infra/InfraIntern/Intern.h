#pragma once

#include "Pronate.h"

#define BoolFalse 0x2000000000000000

#define BoolTrue 0x2000000000000001

#define RefKindClear(name) name = name & 0x0fffffffffffffff;

#define RefKindInt(name) name = name | 0x3000000000000000;

#define RefMemory(name) name = name & RefMaskMemory;

#define Return(ret, paramCount) \
eval->S[frame - (paramCount + 1)] = ret;\
eval->N = frame - paramCount;\
return 0;\


Int Intern_Intern_FieldGet(Eval* eval, Int frame, Int index);
Int Intern_Intern_FieldSet(Eval* eval, Int frame, Int index);

Int* Intern_Intern_FieldMemory(Int o, Int index);
