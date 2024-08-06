#pragma once

#include <QTransform>

#include "Probate.hpp"

struct Form
{
    QTransform* Intern;
};

#define CP(a) ((Form*)(a))

#define ValidDouble(a) \
if (std::isnan(a) | std::isinf(a))\
{\
    return false;\
}\

