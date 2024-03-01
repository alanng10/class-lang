#pragma once

#include <QRadialGradient>

#include "Probate.hpp"

struct GradientRadial
{
    Int CenterPos;
    Int CenterRadius;
    Int FocusPos;
    Int FocusRadius;
    QRadialGradient* Intern;
};

#define CP(a) ((GradientRadial*)(a))
