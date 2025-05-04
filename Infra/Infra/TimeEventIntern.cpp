#include "TimeEventIntern.hpp"

Bool TimeEventIntern::Init()
{
    this->setTimerType(Qt::PreciseTimer);

    connect(this, &QTimer::timeout, this, &TimeEventIntern::TimeOutHandle);
    return true;
}

void TimeEventIntern::TimeOutHandle()
{
    Int m;
    m = this->TimeEvent;
    TimeEvent_Elapse(m);
}