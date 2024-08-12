#pragma once

#include "Prudate.h"

#define RefClear(name) name = name & 0x0fffffffffffffff;

#define RefKindInt(name) name = name | 0x2000000000000000;

#define Return(ret, paramCount) \
eval->Stack[frame - (paramCount + 1)] = ret;\
eval->Index = frame - (paramCount + 1);\
return 0;\
