#pragma once

#include <QThreadStorage>

#include "Pronate.hpp"

struct Share
{
    Int Stat;
};

#define CP(a) ((Share*)(a))
