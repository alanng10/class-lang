#include "Screen.hpp"

CppClassNew(Screen)

Int Screen_Init(Int o)
{
    return true;
}

Int Screen_Final(Int o)
{
    return true;
}

Int Screen_SizeGet(Int o)
{
    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int a;
    a = Stat_ScreenSize(stat);
    return a;
}

Int Screen_DimendGet(Int o)
{
    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int a;
    a = Stat_ScreenDimend(stat);
    return a;
}