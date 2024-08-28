#pragma once

#include <QString>
#include <QStringList>

#include "Pronate.hpp"

struct Return
{
    Int String;
    Int StringList;
};

#define CP(a) ((Return*)(a))
