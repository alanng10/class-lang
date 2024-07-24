#include "Pos.h"

InfraClassNew(Pos)

Int Pos_Init(Int o)
{
    return true;
}

Int Pos_Final(Int o)
{
    return true;
}

Field(Pos, Left)
Field(Pos, Up)