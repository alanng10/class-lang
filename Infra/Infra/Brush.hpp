#pragma once

#include <QBrush>
#include <QPen>
#include <QGradient>

#include "Probate.hpp"

struct Brush
{
    Int Kind;
    Int Color;
    Int Gradient;
    Int Image;
    Int Width;
    Int Line;
    Int Cap;
    Int Join;
    QBrush* InternBrush;
    QPen* Intern;
};

#define CP(a) ((Brush*)(a))
