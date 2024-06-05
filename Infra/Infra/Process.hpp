#pragma once

#include <QProcessEnvironment>

#include "ProcessIntern.hpp"

#include "Probate.hpp"

struct Process
{
    Int Program;
    Int Argue;
    Int WorkFold;
    Int Environment;
    Int StartState;
    Int FinishState;
    ProcessIntern* Intern;
};

#define CP(a) ((Process*)(a))

Int Process_InternArgueSet(Int result, Int argue);

Int Process_InternEnvironmentSet(Int result, Int environment);