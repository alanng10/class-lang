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
}
Eval;

typedef Int (*Intern_State)(Eval* eval, Int frame);

Intern_Api extern Int Intern_Intern_Class;

Intern_Api extern Int Intern_Extern_Class;

Intern_Api extern Int Intern_Entry_Module;

Intern_Api Int Intern_New(Int kind, Int info, Eval* eval);
