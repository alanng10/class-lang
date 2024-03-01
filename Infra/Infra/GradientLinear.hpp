#pragma once

#include <QLinearGradient>

#include "Probate.hpp"

struct GradientLinear
{
    Int StartPos;
    Int EndPos;
    QLinearGradient* Intern;
};

#define CP(a) ((GradientLinear*)(a))
