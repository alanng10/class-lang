#pragma once

#include <QDateTime>
#include <QDate>
#include <QTime>

#include "Pronate.hpp"

struct Time
{
    QDateTime* Intern;
};

#define CP(a) ((Time*)(a))

Int Time_SetValidTick(Int o, Int k);
Int Time_TotalTickIntern(Int u);
Int Time_ValidTotalTick(Int k);
