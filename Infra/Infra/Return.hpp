#pragma once

#include <QString>
#include <QStringList>

#include "Probate.hpp"

struct Return
{
    Int String;
    Int StringList;
};

#define CP(a) ((Return*)(a))
