#pragma once

#include "TimeEventIntern.hpp"

#include "Probate.hpp"

struct TimeEvent
{
    Int Time;
    Int Single;
    Int ElapseState;
    TimeEventIntern* Intern;
};

#define CP(a) ((TimeEvent*)(a))
