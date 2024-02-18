#include "Size.h"



InfraClassNew(Size)







Bool Size_Init(Int o)
{
    return true;
}




Bool Size_Final(Int o)
{
    return true;
}




Int Size_GetWidth(Int o)
{
    Size* m;

    m = CastPointer(o);


    return m->Width;
}





Bool Size_SetWidth(Int o, Int value)
{
    Size* m;

    m = CastPointer(o);



    m->Width = value;



    return true;
}





Int Size_GetHeight(Int o)
{
    Size* m;

    m = CastPointer(o);


    return m->Height;
}





Bool Size_SetHeight(Int o, Int value)
{
    Size* m;

    m = CastPointer(o);



    m->Height = value;



    return true;
}