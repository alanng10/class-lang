#pragma once

#include <QBrush>

#include "Pronate.hpp"

struct GradientStop
{
    Int Count;
    QGradientStops* Intern;
};

#define CP(a) ((GradientStop*)(a))
