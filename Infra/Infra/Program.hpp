#pragma once

#include <QProcessEnvironment>

#include "ProgramIntern.hpp"

#include "Pronate.hpp"

struct Program
{
    Int Name;
    Int Argue;
    Int WorkFold;
    Int Environ;
    ProgramIntern* Intern;
};

#define CP(a) ((Program*)(a))

Int Program_InternArgueSet(Int result, Int argue);

Int Program_InternEnvironSet(Int result, Int environment);