#pragma once

#include "Pronate.h"

#define Return(ret, paramCount) \
eval->S[frame - (paramCount + 1)] = ret;\
eval->N = frame - paramCount;\
return 0;\
