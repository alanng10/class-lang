#include "Random.hpp"

CppClassNew(Random)

Int Random_Init(Int o)
{
    Random* m;
    m = CP(o);

    m->Intern = new QRandomGenerator;

    Random_SeedSet(o, 1);
    return true;
}

Int Random_Final(Int o)
{
    Random* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppFieldGet(Random, Seed)

Int Random_SeedSet(Int o, Int value)
{
    Random* m;
    m = CP(o);

    m->Seed = value;

    quint32 u;
    u = (quint32)(m->Seed);

    m->Intern->seed(u);
    return true;
}

Int Random_Execute(Int o)
{
    Random* m;
    m = CP(o);

    quint32 u;
    u = m->Intern->generate();

    Int a;
    a = u;
    return a;
}