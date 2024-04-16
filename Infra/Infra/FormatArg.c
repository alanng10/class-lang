#include "FormatArg.h"

InfraClassNew(FormatArg)

Int FormatArg_Init(Int o)
{
    return true;
}

Int FormatArg_Final(Int o)
{
    return true;
}

Field(FormatArg, Pos)
Field(FormatArg, Kind)
Field(FormatArg, Value)
Field(FormatArg, AlignLeft)
Field(FormatArg, FieldWidth)
Field(FormatArg, MaxWidth)
Field(FormatArg, Case)
Field(FormatArg, Base)
Field(FormatArg, Sign)
Field(FormatArg, FillChar)
Field(FormatArg, HasCount)
Field(FormatArg, ValueCount)
Field(FormatArg, Count)