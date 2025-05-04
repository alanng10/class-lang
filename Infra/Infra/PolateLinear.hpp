#pragma once

#include <QLinearGradient>

#include "Pronate.hpp"

struct PolateLinear
{
    Int StartPos;
    Int EndPos;
    QLinearGradient* Intern;
};

#define CP(a) ((PolateLinear*)(a))
