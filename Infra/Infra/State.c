#include "State.h"

InfraClassNew(State)

Int State_Init(Int o)
{
    return true;
}

Int State_Final(Int o)
{
    return true;
}

Field(State, Maide)
Field(State, Arg)