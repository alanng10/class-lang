#include "Data.h"

InfraClassNew(Data)

Int Data_Init(Int o)
{
    return true;
}

Int Data_Final(Int o)
{
    return true;
}

Field(Data, Count)
Field(Data, Value)