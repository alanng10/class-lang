#pragma once

#include <QRandomGenerator>

#include "Probate.hpp"

struct Rand
{
    Int Seed;
    QRandomGenerator* Intern;
};

#define CP(a) ((Rand*)(a))
