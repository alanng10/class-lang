#pragma once

#include <QString>

#include "Pronate.hpp"

struct String
{
    Int Value;
    Int Count;
};

#define CP(a) ((String*)(a))

Int String_ConstantCount(Int o);