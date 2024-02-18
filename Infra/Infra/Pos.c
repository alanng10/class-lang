#include "Pos.h"



InfraClassNew(Pos)






Bool Pos_Init(Int o)
{
    return true;
}




Bool Pos_Final(Int o)
{
    return true;
}




Int Pos_GetLeft(Int o)
{
    Pos* m;

    m = CastPointer(o);


    return m->Left;
}





Bool Pos_SetLeft(Int o, Int value)
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





Int Pos_GetUp(Int o)
{
    Pos* m;

    m = CastPointer(o);


    return m->Up;
}





Bool Pos_SetUp(Int o, Int value)
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