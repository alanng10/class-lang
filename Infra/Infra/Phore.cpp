#include "Phore.hpp"

CppClassNew(Phore)

Int Phore_Init(Int o)
{
    Phore* m;
    m = CP(o);
    Int initCount;
    initCount = m->InitCount;
    int ua;
    ua = initCount;
    m->Intern = new QSemaphore(ua);
    return true;
}

Int Phore_Final(Int o)
{
    Phore* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(Phore, InitCount)

Int Phore_CountGet(Int o)
{
    Phore* m;
    m = CP(o);
    int u;
    u = m->Intern->available();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Phore, Count)

Int Phore_Open(Int o)
{
    Phore* m;
    m = CP(o);
    m->Intern->acquire();
    return true;
}

Int Phore_Close(Int o)
{
    Phore* m;
    m = CP(o);
    m->Intern->release();
    return true;
}