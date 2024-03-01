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

#define Field(name) \
Int FormatArg_##name##Get(Int o)\
{\
    FormatArg* m;\
    m = CastPointer(o);\
    return m->name;\
}\
\
Int FormatArg_##name##Set(Int o, Int value)\
{\
    FormatArg* m;\
    m = CastPointer(o);\
    m->name = value;\
    return true;\
}\

