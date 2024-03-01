#include "Entry.h"

InfraClassNew(Entry)

Int Entry_Init(Int o)
{
    return true;
}

Int Entry_Final(Int o)
{
    return true;
}

Field(Entry, Index)
Field(Entry, Value)