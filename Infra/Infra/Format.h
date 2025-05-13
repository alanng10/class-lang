#pragma once

#include "Pronate.h"

#include "FormatArg.h"

typedef struct
{
}
Format;

typedef Int (*Format_ArgValueCountMaide)(Int o, Int arg);

Int Format_ArgValueCountBool(Int o, Int arg);
Int Format_ArgValueCountInt(Int o, Int arg);
Int Format_ArgValueCountString(Int o, Int arg);

Int Format_IntDigitCount(Int o, Int value, Int varBase);

typedef Int (*Format_ArgResultMaide)(Int o, Int arg, Int result);

Int Format_ArgResultBool(Int o, Int arg, Int result);
Int Format_ArgResultInt(Int o, Int arg, Int result);
Int Format_ArgResultString(Int o, Int arg, Int result);

Int Format_ResultBool(Int o, Int result, Int value, Int varCase, Int valueWriteCount, Int valueStart, Int valueIndex);
Int Format_ResultInt(Int o, Int result, Int value, Int varBase, Int varCase, Int valueCount, Int valueWriteCount, Int valueStart, Int valueIndex);
Int Format_ResultString(Int o, Int result, Int value, Int varCase, Int valueWriteCount, Int valueStart, Int valueIndex);

Int Format_ResultFill(Int dest, Int fillIndex, Int fillCount, Int fillChar);

Int Format_IntDigit(Int digit, Int letterStart);

typedef Int (*Format_FormMaide)(Int arg, Int value);
