#include "Data.h"

InfraClassNew(Data)

Int Data_Init(Int o)
{
    return true;
}

Int Data_Final(Int o)
{
    return true;
}

Int Data_CountGet(Int o)
{
    Data* m;
    m = CastPointer(o);
    return m->Count;
}

Int Data_CountSet(Int o, Int value)
{
    Data* m;
    m = CastPointer(o);
    m->Count = value;
    return true;
}

Int Data_ValueGet(Int o)
{
    Data* m;
    m = CastPointer(o);
    return m->Value;
}

Int Data_ValueSet(Int o, Int value)
{
    Data* m;
    m = CastPointer(o);
    m->Value = value;
    return true;
}