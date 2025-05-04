#pragma once

#include <QThreadStorage>

#include "Pronate.hpp"

struct Share
{
    Int Stat;
    Int ThreadStorage;
};

#define CP(a) ((Share*)(a))
