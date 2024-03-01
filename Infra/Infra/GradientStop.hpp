#pragma once

#include "Probate.hpp"

struct GradientStopPoint
{
    Int Pos;
    Int Color;
};

struct GradientStop
{
    Int Count;
    Int Data;
};

#define CP(a) ((GradientStop*)(a))

GradientStopPoint* GradientStop_PointPointer(Int o, Int index);
