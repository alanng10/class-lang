#pragma once

#include "IntervalIntern.hpp"

#include "Probate.hpp"

struct Interval
{
    Int Time;
    Int SingleShot;
    Int ElapseState;
    IntervalIntern* Intern;
};

#define CP(a) ((Interval*)(a))
