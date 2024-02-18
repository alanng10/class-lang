#include "Range.h"




InfraClassNew(Range)






Bool Range_Init(Int o)
{
    return true;
}




Bool Range_Final(Int o)
{
    return true;
}




Int Range_GetStart(Int o)
{
    Range* m;

    m = CastPointer(o);


    return m->Start;
}





Bool Range_SetStart(Int o, Int value)
{
    Range* m;

    m = CastPointer(o);



    m->Start = value;



    return true;
}





Int Range_GetEnd(Int o)
{
    Range* m;

    m = CastPointer(o);


    return m->End;
}





Bool Range_SetEnd(Int o, Int value)
{
    Range* m;

    m = CastPointer(o);



    m->End = value;



    return true;
}