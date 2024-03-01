#include "Size.h"

InfraClassNew(Size)

Int Size_Init(Int o)
{
    return true;
}

Int Size_Final(Int o)
{
    return true;
}

Field(Size, Width)
Field(Size, Height)