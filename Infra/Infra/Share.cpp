#include "Share.hpp"

CppClassNew(Share)

Int Share_Init(Int o)
{
    Share* m;
    m = CP(o);

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
    return true;
}

Int Share_Stat(Int o)
{
    Share* m;
    m = CP(o);
    return m->Stat;
}