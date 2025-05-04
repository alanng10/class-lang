#pragma once

#include <QRadialGradient>

#include "Pronate.hpp"

struct PolateRadial
{
    Int CenterPos;
    Int CenterRadius;
    Int FocusPos;
    Int FocusRadius;
    QRadialGradient* Intern;
};

#define CP(a) ((PolateRadial*)(a))
