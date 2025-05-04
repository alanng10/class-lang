#include "Rand.hpp"

CppClassNew(Rand)

Int Rand_Init(Int o)
{
    Rand* m;
    m = CP(o);

    m->Intern = new QRandomGenerator;

    Rand_SeedSet(o, 1);
    return true;
}

Int Rand_Final(Int o)
{
    Rand* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppFieldGet(Rand, Seed)

Int Rand_SeedSet(Int o, Int value)
{
    Rand* m;
    m = CP(o);

    m->Seed = value;

    quint32 u;
    u = (quint32)(m->Seed);

    m->Intern->seed(u);
    return true;
}

Int Rand_Execute(Int o)
{
    Rand* m;
    m = CP(o);

    quint64 u;
    u = m->Intern->generate64();

    Int ka;
    ka = 1;
    ka = ka << 60;
    ka = ka - 1;

    Int k;
    k = u;
    k = k & ka;

    Int a;
    a = k;
    return a;
}