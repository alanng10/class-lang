#pragma once

#include <QGradient>

#include "Probate.hpp"

struct Gradient
{
    Int Kind;
    Int Value;
    Int Stop;
    Int Spread;
    QGradient* Intern;
};

#define CP(a) ((Gradient*)(a))
