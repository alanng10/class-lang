#pragma once

#include <QLinearGradient>

#include "Pronate.hpp"

struct GradientLinear
{
    Int StartPos;
    Int EndPos;
    QLinearGradient* Intern;
};

#define CP(a) ((GradientLinear*)(a))
