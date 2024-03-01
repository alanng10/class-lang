#include "Rect.h"

InfraClassNew(Rect)

Int Rect_Init(Int o)
{
    return true;
}

Int Rect_Final(Int o)
{
    return true;
}

Field(Rect, Pos)
Field(Rect, Size)