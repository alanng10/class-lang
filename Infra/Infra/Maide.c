#include "Maide.hpp"

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
        Exit(0x100);
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