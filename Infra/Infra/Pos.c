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

FieldGet(Pos, Left)

Int Pos_LeftSet(Int o, Int value)
{
    Pos* m;
    m = CastPointer(o);

    SInt oa;
    oa = value;
    oa = oa << 4;
    oa = oa >> 4;

    Int ob;
    ob = oa;
    m->Left = ob;
    return true;
}

FieldGet(Pos, Up)

Int Pos_UpSet(Int o, Int value)
{
    Pos* m;
    m = CastPointer(o);

    SInt oa;
    oa = value;
    oa = oa << 4;
    oa = oa >> 4;

    Int ob;
    ob = oa;
    m->Up = ob;
    return true;
}