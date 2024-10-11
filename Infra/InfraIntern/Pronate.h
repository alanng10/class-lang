#pragma once

#include "Prusate.h"

#define RefMaskMemoryClear (0x000fffffffffffff)

#define RefKindNull (0x0ULL)
#define RefKindAny (0x1ULL)
#define RefKindBool (0x2ULL)
#define RefKindInt (0x3ULL)
#define RefKindString (0x4ULL)
#define RefKindStringValue (0x5ULL)
#define RefKindData (0x6ULL)
#define RefKindArray (0x7ULL)

#define RefKindMaskAny (RefKindAny << 60)

typedef struct
{
    Int Index;
    Int Thread;
    Int ThreadAny;
    Int Eval;
}
ThreadData;

extern Int NewData;

extern Int ThreadArray;