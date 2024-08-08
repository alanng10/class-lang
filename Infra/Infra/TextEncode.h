#pragma once

#include "Probate.h"

typedef struct
{
}
TextEncode;

typedef Int (*TextEncode_CountMaide)(Int o, Int data);
typedef Int (*TextEncode_ResultMaide)(Int o, Int result, Int data);

Int TextEncode_ExecuteCount32To8(Int o, Int data);
Int TextEncode_ExecuteCount32To16(Int o, Int data);
Int TextEncode_ExecuteCount16To8(Int o, Int data);
Int TextEncode_ExecuteCount16To32(Int o, Int data);
Int TextEncode_ExecuteCount8To16(Int o, Int data);
Int TextEncode_ExecuteCount8To32(Int o, Int data);

Int TextEncode_ExecuteResult32To8(Int o, Int result, Int data);
Int TextEncode_ExecuteResult32To16(Int o, Int result, Int data);
Int TextEncode_ExecuteResult16To8(Int o, Int result, Int data);
Int TextEncode_ExecuteResult16To32(Int o, Int result, Int data);
Int TextEncode_ExecuteResult8To16(Int o, Int result, Int data);
Int TextEncode_ExecuteResult8To32(Int o, Int result, Int data);
