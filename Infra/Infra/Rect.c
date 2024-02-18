#include "Rect.h"



InfraClassNew(Rect)






Bool Rect_Init(Int o)
{
    return true;
}




Bool Rect_Final(Int o)
{
    return true;
}





Int Rect_GetPos(Int o)
{
    Rect* m;

    m = CastPointer(o);


    return m->Pos;
}





Bool Rect_SetPos(Int o, Int value)
{
    Rect* m;

    m = CastPointer(o);



    m->Pos = value;



    return true;
}





Int Rect_GetSize(Int o)
{
    Rect* m;

    m = CastPointer(o);


    return m->Size;
}





Bool Rect_SetSize(Int o, Int value)
{
    Rect* m;

    m = CastPointer(o);



    m->Size = value;



    return true;
}