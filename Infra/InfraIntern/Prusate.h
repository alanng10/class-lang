#pragma once

#include <Infra/Prusate.h>

#ifdef InfraIntern_Module
#define Intern_Api ExportApi
#else
#define Intern_Api ImportApi
#endif

typedef struct
{
    Int N;
    Int* S;
    Int Thread;
}
Eval;

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

#define EvalStackCount (512 * 1024)

typedef struct
{
    Int Var;
    Int Data[5];
    Int BaseItem[4];
}
Intern_Class;

typedef struct
{
    Int Init;
    Intern_Class* Class;
    Int Count;
}
Intern_Module;

typedef Int (*Intern_Module_State)();

typedef Int (*Intern_State)(Eval* eval, Int frame);

Intern_Api extern Int Intern_Value_Ref;

Intern_Api extern Int Intern_Value_Class;

Intern_Api Int Intern_New(Int kind, Int info, Eval* eval);

Intern_Api Int Intern_Share(Int info, Eval* eval);

Intern_Api Int Intern_Cast(Int classVar, Eval* eval);

Intern_Api Int Intern_Cast_RefKind(Int refKind, Eval* eval);

Intern_Api Int Intern_Cast_RefKindTwo(Int refKindA, Int refKindB, Eval* eval);

Intern_Api Int Intern_Init(Int entryModule, Int entryClassIndex, Int entryModuleInit, Int moduleCount);

Intern_Api Int Intern_Execute(Int eval);

Intern_Api Int Intern_Final(Int eval);

Intern_Api Int Intern_Value_Bool();

Intern_Api Int Intern_Value_Int();

Intern_Api Int Intern_Value_String();

Intern_Api Int Intern_Base_Set(Intern_Class* varClass, Intern_Class* baseClass, Int count);

Intern_Api Int Intern_Module_Set(Intern_Module* module);

Intern_Api Int Intern_StatusWrite(Int status);
