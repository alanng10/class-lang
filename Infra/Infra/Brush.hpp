#pragma once

#include <QBrush>
#include <QGradient>

#include "Probate.hpp"

struct Brush
{
    Int Kind;
    Int Color;
    Int Gradient;
    Int Image;
    QBrush* Intern;
};

#define CP(a) ((Brush*)(a))
