#pragma once

#include "Prusate.h"

#define RefMaskMemory (0x000fffffffffffff)

#define RefMaskBase (0x0ff0000000000000)
#define RefMaskBaseClear (0xf00fffffffffffff)

#define RefKindNull (0x0ULL)
#define RefKindAny (0x1ULL)
#define RefKindBool (0x2ULL)
#define RefKindInt (0x3ULL)
#define RefKindString (0x4ULL)
#define RefKindStringValue (0x5ULL)
#define RefKindData (0x6ULL)
#define RefKindArray (0x7ULL)
#define RefKindStringValueData (0x8ULL)
#define RefKindValueAny (0x9ULL)

#define RefKindMaskAny (RefKindAny << 60)

#define BoolFalse 0x2000000000000000

#define BoolTrue 0x2000000000000001

#define RefKindClear(name) name = name & 0x0fffffffffffffff;

#define RefKindSet(name, kind) name = name | (kind << 60);

#define ThreadCountMax (1024)

typedef struct
{
    Int Index;
    Int Thread;
    Int ThreadAny;
    Int Eval;
    Int Flag;
}
ThreadData;


typedef Int (*Intern_ModuleInit_Maide)();

extern Int ModuleArray;

extern Int ModuleArrayCount;

extern Int NewData;

extern Int ThreadArray;

extern Int ArgArray;

extern Int ArgCount;

Bool Intern_New_Open();

Bool Intern_New_Close();

Bool Intern_New_PhoreSet(Int value);

Bool Intern_New_AllocCapSet(Int value);

Int Intern_InitThread(Int thread, Int threadAny);

Bool Intern_FinalThread(Int thread);

Int Intern_InitMainThread();

Bool Intern_Call(Eval* eval, Int thisEvalIndex, Int stateKind, Int stateIndex);
