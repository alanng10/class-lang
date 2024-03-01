#pragma once

#include "Probate.h"

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
    Int Precision;
    Int FillChar;
    Int HasCount;
    Int ValueCount;
    Int Count;
}
FormatArg;
