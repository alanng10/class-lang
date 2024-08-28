#pragma once

#include "VideoOutIntern.hpp"

#include "Pronate.hpp"

struct VideoOut
{
    Int Frame;
    Int FrameState;
    VideoOutIntern* Intern;
};

#define CP(a) ((VideoOut*)(a))
