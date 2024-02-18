#pragma once





#include "Probate.h"






typedef struct
{
    Int Pos;


    Int Kind;


    Int Value;


    Int Align;

    Int FieldWidth;

    Int MaxWidth;

    Int Case;

    Int Base;

    Int Precision;

    Int FillChar;


    Int HasCount;

    Int ValueCount;

    Int Count;
}
FormatArg;




#define Field(name) \
Int FormatArg_Get##name(Int o)\
{\
    FormatArg* m;\
\
    m = CastPointer(o);\
\
\
    return m->name;\
}\
\
\
\
Int FormatArg_Set##name(Int o, Int value)\
{\
    FormatArg* m;\
\
    m = CastPointer(o);\
\
\
    m->name = value;\
\
\
    return true;\
}\


