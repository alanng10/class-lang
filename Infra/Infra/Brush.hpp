#pragma once

#include <QBrush>
#include <QGradient>

#include "Probate.hpp"

struct Brush
{
    Int Kind;
    Int Color;
    Int Image;
    Int Gradient;
    QBrush* Intern;
};

#define CP(a) ((Brush*)(a))
