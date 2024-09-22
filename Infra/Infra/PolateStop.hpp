#pragma once

#include <QBrush>

#include "Pronate.hpp"

struct PolateStop
{
    Int Count;
    QGradientStops* Intern;
};

#define CP(a) ((PolateStop*)(a))
