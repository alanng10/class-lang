#pragma once

#include "Prusate.h"

#include "Pronate_Part.h"

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


extern Int Intern_Intern_MaideCall[];

Int Intern_Intern_Init(Eval* eval, Int frame);
