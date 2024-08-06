#pragma once

#include <QTransform>

#include "Probate.hpp"

struct Form
{
    QTransform* Intern;
};

#define CP(a) ((Form*)(a))

#define ValidValue(a) \
if (a == CastInt(-1))\
{\
    return false;\
}\


#define ValidDouble(a) \
if (std::isnan(a) | std::isinf(a))\
{\
    return false;\
}\

