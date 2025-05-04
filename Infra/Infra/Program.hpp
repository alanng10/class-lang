#pragma once

#include <QProcess>
#include <QProcessEnvironment>

#include "Pronate.hpp"

struct Program
{
    Int Name;
    Int Argue;
    Int WorkFold;
    Int Environ;
    QProcess* Intern;
};

#define CP(a) ((Program*)(a))

Int Program_InternArgueSet(Int result, Int argue);

Int Program_InternEnvironSet(Int result, Int environment);