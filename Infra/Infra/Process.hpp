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

Int Process_InternSetArgue(Int result, Int argue);

Int Process_InternSetEnvironment(Int result, Int environment);