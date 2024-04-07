#include "Share.hpp"

CppClassNew(Share)

Int Share_Init(Int o)
{
    Share* m;
    m = CP(o);
    m->ThreadStorage = Thread_CreateStore();

    Int stat;
    stat = Stat_New();
    Stat_Init(stat);
    m->Stat = stat;
    return true;
}

Int Share_Final(Int o)
{
    Share* m;
    m = CP(o);
    Stat_Final(m->Stat);
    Stat_Delete(m->Stat);

    Thread_DeleteStore(m->ThreadStorage);
    return true;
}

Int Share_Stat(Int o)
{
    Share* m;
    m = CP(o);
    return m->Stat;
}

Int Share_ThreadStorage(Int o)
{
    Share* m;
    m = CP(o);
    return m->ThreadStorage;
}