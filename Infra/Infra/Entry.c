#include "Entry.h"




InfraClassNew(Entry)





Int Entry_Init(Int o)
{
    return true;
}




Int Entry_Final(Int o)
{
    return true;
}





Int Entry_GetIndex(Int o)
{
    Entry* m;

    m = CastPointer(o);


    return m->Index;
}





Int Entry_SetIndex(Int o, Int value)
{
    Entry* m;

    m = CastPointer(o);



    m->Index = value;



    return true;
}





Int Entry_GetValue(Int o)
{
    Entry* m;

    m = CastPointer(o);


    return m->Value;
}





Int Entry_SetValue(Int o, Int value)
{
    Entry* m;

    m = CastPointer(o);



    m->Value = value;



    return true;
}