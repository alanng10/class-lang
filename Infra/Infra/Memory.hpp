#pragma once

#include <QBuffer>

#include "Probate.hpp"

struct Memory
{
    Int Stream;
};

#define CP(a) ((Memory*)(a))
