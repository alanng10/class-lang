#pragma once

#include <iostream>

#include <QString>

#include "Probate.hpp"

struct Console
{
    Int Phore;
};

#define CP(a) ((Console*)(a))

Int Console_StreamWrite(Int o, Int text, Int stream);
