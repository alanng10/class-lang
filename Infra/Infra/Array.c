#include "Array.h"

InfraClassNew(Array)

Int Array_Init(Int o)
{
    Array* m;
    m = CastPointer(o);

    Int count;
    count = m->Count;
    Int byteCount;
    byteCount = count * Constant_IntByteCount();

    Int u;
    u = New(byteCount);
    m->Item = u;
    return true;
}

Int Array_Final(Int o)
{
    Array* m;
    m = CastPointer(o);
    Delete(m->Item);
    return true;
}

Int Array_CountGet(Int o)
{
    Array* m;
    m = CastPointer(o);
    return m->Count;
}

Int Array_CountSet(Int o, Int value)
{
    Array* m;
    m = CastPointer(o);
    m->Count = value;
    return true;
}

Int Array_ItemGet(Int o, Int index)
{
    Array* m;
    m = CastPointer(o);
    Int u;
    u = m->Item;
    Int* p;
    p = CastPointer(u);
    Int a;
    a = p[index];
    return a;
}

Int Array_ItemSet(Int o, Int index, Int value)
{
    Array* m;
    m = CastPointer(o);
    Int u;
    u = m->Item;
    Int* p;
    p = CastPointer(u);
    p[index] = value;
    return true;
}
