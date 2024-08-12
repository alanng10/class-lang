#pragma once

#include <Infra/Prudate.h>

typedef struct
{
    Int Index;
    Int* Stack;
}
Eval;

typedef Int (*Intern_State)(Eval* eval, Int frame);

