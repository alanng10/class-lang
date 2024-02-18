#include "Stat.hpp"





CppClassNew(Stat)







Int Stat_Init(Int o)
{
    Stat* m;

    m = CP(o);




    m->TimeInit = Stat_TimeInitCreate(o);




    return true;
}







Int Stat_Final(Int o)
{
    Stat* m;

    m = CP(o);




    Stat_TimeInitDelete(o, m->TimeInit);




    return true;
}






Int Stat_TimeInit(Int o)
{
    Stat* m;

    m = CP(o);



    return m->TimeInit;
}







Int Stat_TimeInitCreate(Int o)
{
    QDate date;

    date = QDate(1, 1, 1);



    QTime time;

    time = QTime(0, 0, 0, 0);




    QDateTime* u;

    u = new QDateTime();



    QDateTime ua;

    ua = u->toOffsetFromUtc(0);



    *u = ua;



    u->setDate(date);

    u->setTime(time);




    Int oa;

    oa = CastInt(u);



    return oa;
}





Int Stat_TimeInitDelete(Int o, Int a)
{
    QDateTime* u;

    u = (QDateTime*)a;



    delete u;



    return true;
}




