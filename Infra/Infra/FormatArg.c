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
Field(FormatArg, Base)
Field(FormatArg, FillChar)
Field(FormatArg, ValueCount)
Field(FormatArg, Count)
Field(FormatArg, Form)