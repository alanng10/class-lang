#pragma once

#include <QBuffer>

#include "Pronate.hpp"

struct Memory
{
    Int Stream;
};

#define CP(a) ((Memory*)(a))
