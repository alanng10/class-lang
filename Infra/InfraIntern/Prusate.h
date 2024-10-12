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

typedef struct
{
    Int ClassArray;
    Int ClassArrayCount;
}
Module;

#define EvalStackCount (512 * 1024)

typedef Int (*Intern_State)(Eval* eval, Int frame);

Intern_Api Int Intern_New(Int kind, Int info, Eval* eval);

Intern_Api Int Intern_Init(Int entryClass, Int entryModuleInit);

Intern_Api Int Intern_Execute(Int eval);

Intern_Api Int Intern_Final(Int eval);

Intern_Api Int Intern_ModuleInitStage();
