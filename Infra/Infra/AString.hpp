#pragma once

#include <QString>

#include "Pronate.hpp"

struct String
{
    Int Count;
    Int Data;
};

#define CP(a) ((String*)(a))

Int String_ConstantCount(Int o);