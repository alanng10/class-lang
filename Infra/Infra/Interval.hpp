#pragma once

#include "IntervalIntern.hpp"

#include "Probate.hpp"

struct Interval
{
    Int Time;
    Int Single;
    Int ElapseState;
    IntervalIntern* Intern;
};

#define CP(a) ((Interval*)(a))
