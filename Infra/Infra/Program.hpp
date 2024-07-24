#pragma once

#include <QProcessEnvironment>

#include "ProgramIntern.hpp"

#include "Probate.hpp"

struct Program
{
    Int Name;
    Int Argue;
    Int WorkFold;
    Int Environment;
    Int StartState;
    Int FinishState;
    ProgramIntern* Intern;
};

#define CP(a) ((Program*)(a))

Int Program_InternArgueSet(Int result, Int argue);

Int Program_InternEnvironmentSet(Int result, Int environment);