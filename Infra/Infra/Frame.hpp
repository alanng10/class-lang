#pragma once

#include "FrameIntern.hpp"

#include "Pronate.hpp"

struct Frame
{
    Int Title;
    Int Size;
    Int TypeState;
    Int DrawState;
    FrameIntern* Intern;
};

#define CP(a) ((Frame*)(a))
