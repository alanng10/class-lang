#pragma once

#include <QIODevice>

#include "Probate.hpp"

struct Stream
{
    Int Kind;
    Int Value;
    Int Status;
    Int HasPos;
    Int HasCount;
    Int CanRead;
    Int CanWrite;
    QIODevice* Intern;
};

#define CP(a) ((Stream*)(a))

typedef Int (*Stream_Flush_Maide)(Int device);

Int Stream_CheckRange(Int dataCount, Int start, Int end);

Int Stream_InternFlush(Int o);