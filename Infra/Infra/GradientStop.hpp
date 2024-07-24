#pragma once

#include <QBrush>

#include "Probate.hpp"

struct GradientStop
{
    Int Count;
    QGradientStops* Intern;
};

#define CP(a) ((GradientStop*)(a))
