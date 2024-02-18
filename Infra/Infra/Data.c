#include "Data.h"




InfraClassNew(Data)





Bool Data_Init(Int o)
{
    return true;
}




Bool Data_Final(Int o)
{
    return true;
}





Int Data_GetCount(Int o)
{
    Data* m;

    m = CastPointer(o);


    return m->Count;
}





Bool Data_SetCount(Int o, Int value)
{
    Data* m;

    m = CastPointer(o);



    m->Count = value;



    return true;
}





Int Data_GetValue(Int o)
{
    Data* m;

    m = CastPointer(o);


    return m->Value;
}





Bool Data_SetValue(Int o, Int value)
{
    Data* m;

    m = CastPointer(o);



    m->Value = value;



    return true;
}