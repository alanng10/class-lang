#include "Maide.h"

Int Memory_M_K;

Int New(Int k)
{
    if (k == 0)
    {
        Int d;
        d = CastInt(&Memory_M_K);
        return d;
    }

    void* p;
    p = calloc(1, k);

    if (p == null)
    {
        Exit(100);
    }

    Int memory;
    memory = CastInt(p);

    TrigAlloc(k, memory);

    Int a;
    a = memory;
    return a;
}

Int TrigAlloc(Int k, Int memory)
{
    Int kaa;
    kaa = 4 * 1024;

    Int ka;
    ka = k / kaa;

    Int kk;
    kk = ka * kaa;

    Int kh;
    kh = k - kk;

    if (0 < kh)
    {
        ka = ka + 1;
    }

    Byte* p;
    p = CastPointer(memory);

    Int count;
    count = ka;

    Int i;
    i = 0;
    while (i < count)
    {
        Int index;
        index = i * kaa;

        p[index] = 0;

        i = i + 1;
    }

    return true;
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