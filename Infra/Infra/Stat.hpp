#pragma once

#include <QDateTime>
#include <QDate>
#include <QTime>
#include <QFileDevice>
#include <QBrush>
#include <QPainter>
#include <QPoint>
#include <QAbstractSocket>
#include <QHostAddress>

#include "Pronate.hpp"

struct Stat
{
    Int TimeInit;
    Int ConsolePhore;
};

#define CP(a) ((Stat*)(a))

Int Stat_TimeInitCreate(Int o);
Int Stat_TimeInitDelete(Int o, Int a);
