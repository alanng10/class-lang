#pragma once

#include <iostream>

#include <QString>

#include "Pronate.hpp"

struct Console
{
};

#define CP(a) ((Console*)(a))

Int Console_StreamWrite(Int o, Int text, Int stream);
