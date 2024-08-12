#pragma once

#include "Prudate.h"

#define RefKindClear(name) name = name & 0x0fffffffffffffff;

#define RefKindInt(name) name = name | 0x3000000000000000;

#define RefMemoryAddress(name) name = name & 0x0000ffffffffffff;

#define Return(ret, paramCount) \
eval->Stack[frame - (paramCount + 1)] = ret;\
eval->Index = frame - paramCount;\
return 0;\

