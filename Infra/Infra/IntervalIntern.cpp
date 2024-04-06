#include "IntervalIntern.hpp"

Bool IntervalIntern::Init()
{
    this->setTimerType(Qt::PreciseTimer);

    connect(this, &QTimer::timeout, this, &IntervalIntern::TimeOutHandle);
    return true;
}

void IntervalIntern::TimeOutHandle()
{
    Int interval;
    interval = this->Interval;
    Interval_Elapse(interval);
}