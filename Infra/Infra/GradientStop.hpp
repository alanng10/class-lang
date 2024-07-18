#pragma once

#include <QBrush>

#include "Probate.hpp"

struct GradientStopPoint
{
    Int Pos;
    Int Color;
};

struct GradientStop
{
    Int Count;
    QGradientStops* Intern;
};

#define CP(a) ((GradientStop*)(a))
