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

Int Gradient_InternStopSet(Int result, Int stop);

Int Gradient_InternStopPointSet(Int result, Int pos, Int color);