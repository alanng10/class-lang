#pragma once

#include <QString>
#include <QFile>
#include <QIODevice>

#include "Pronate.hpp"

struct Storage
{
    Int Path;
    Int Mode;
    Int Stream;
    Int Status;
    Int OpenFile;
};

#define CP(a) ((Storage*)(a))
