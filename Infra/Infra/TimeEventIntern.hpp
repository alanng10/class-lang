#pragma once

#include <QTimer>

#include "Probate.hpp"

class TimeEventIntern : public QTimer
{
    Q_OBJECT

public:
    Bool Init();
    Int TimeEvent;

private slots:
    void TimeOutHandle();
};
