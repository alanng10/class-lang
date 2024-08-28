#pragma once

#include <QRandomGenerator>

#include "Pronate.hpp"

struct Rand
{
    Int Seed;
    QRandomGenerator* Intern;
};

#define CP(a) ((Rand*)(a))
