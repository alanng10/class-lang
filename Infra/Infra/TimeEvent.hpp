#pragma once

#include "TimeEventIntern.hpp"
#include <QThread>

#include "Pronate.hpp"

struct TimeEvent
{
    Int Time;
    Int Single;
    Int ElapseState;
    TimeEventIntern* Intern;
};

#define CP(a) ((TimeEvent*)(a))
