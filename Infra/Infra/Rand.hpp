#pragma once

#include <QRandomGenerator>

#include "Probate.hpp"

struct Random
{
    Int Seed;
    QRandomGenerator* Intern;
};

#define CP(a) ((Random*)(a))
