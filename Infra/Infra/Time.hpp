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

Int Time_TotalMillisecIntern(Int u);
