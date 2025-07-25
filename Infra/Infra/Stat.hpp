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
#include <QScreen>

#include "Pronate.hpp"

struct Stat
{
    Int TimeInit;
    Int ConsolePhore;
    Int ScreenSize;
    Int ScreenDimend;
};

#define CP(a) ((Stat*)(a))

Int Stat_TimeInitCreate(Int o);
Int Stat_TimeInitDelete(Int o, Int a);
