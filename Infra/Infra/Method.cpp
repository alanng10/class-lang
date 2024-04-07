#include "Method.hpp"

Int Memory_M_K;

Int New(Int count)
{
    if (count == 0)
    {
        Int d;
        d = CastInt(&Memory_M_K);
        return d;
    }

    void* p;
    p = calloc(1, count);

    if (p == null)
    {
        Exit(140);
    }

    Int a;
    a = CastInt(p);
    return a;
}

Int Delete(Int o)
{
    if (o == null)
    {
        return true;
    }

    Int ua;
    ua = CastInt(&Memory_M_K);
    if (o == ua)
    {
        return true;
    }

    void* p;
    p = CastPointer(o);

    free(p);
    return true;
}

Int Copy(Int dest, Int source, Int count)
{
    void* pa;
    pa = CastPointer(dest);
    void* pb;
    pb = CastPointer(source);
    size_t n;
    n = count;

    memcpy(pa, pb, n);
    return true;
}

Int Exit(Int code)
{
    int o;
    o = (int)code;
    exit(o);
    return true;
}

Int HasFlag(Int value, Int flag)
{
    Bool a;
    a = (!((value & flag) == 0));
    return a;
}

Int InternValueGet(Int o)
{
    SInt k;
    k = o;
    k = k << 12;
    k = k >> 12;

    Int ka;
    ka = 1 << 20;

    qreal u;
    u = k;
    u = u / ka;

    Int a;
    a = CastDoubleToInt(u);
    return a;
}

Int ValueGetFromInternValue(Int o)
{
    qreal au;
    au = CastIntToDouble(o);

    Int ka;
    ka = 1 << 20;

    qreal u;
    u = au;
    u = u * ka;

    SInt k;
    k = u;
    k = k << 12;
    k = k >> 12;

    Int a;
    a = k;
    return a;
}