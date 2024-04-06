#pragma once

#include <QTimer>

#include "Probate.hpp"

class IntervalIntern : public QTimer
{
    Q_OBJECT

public:
    Bool Init();
    Int Interval;

private slots:
    void TimeOutHandle();
};
