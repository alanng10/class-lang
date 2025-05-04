#pragma once

#include <QGradient>

#include "Pronate.hpp"

struct Polate
{
    Int Kind;
    Int Value;
    Int Stop;
    Int Spread;
    QGradient* Intern;
};

#define CP(a) ((Polate*)(a))
