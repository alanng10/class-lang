#pragma once

#include "Pronate.h"

typedef struct
{
    Int Pos;
    Int Kind;
    Int Value;
    Int AlignLeft;
    Int FieldWidth;
    Int MaxWidth;
    Int Case;
    Int Base;
    Int Sign;
    Int FillChar;
    Int HasCount;
    Int ValueCount;
    Int Count;
}
FormatArg;
