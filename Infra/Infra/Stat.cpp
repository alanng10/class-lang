#include "Stat.hpp"

CppClassNew(Stat)

Int Stat_Init(Int o)
{
    Stat* m;
    m = CP(o);
    m->TimeInit = Stat_TimeInitCreate(o);

    Int aa;
    aa = Phore_New();
    Phore_InitCountSet(aa, 1);
    Phore_Init(aa);
    m->ConsolePhore = aa;

    Int screen;
    screen = Main_Screen();

    QScreen* k;
    k = (QScreen*)screen;

    QSize ka;
    ka = k->size();

    QSizeF kb;
    kb = k->physicalSize();

    int widthA;
    int hegthA;
    widthA = ka.width();
    hegthA = ka.height();

    Int width;
    Int hegth;
    width = widthA;
    hegth = hegthA;

    m->ScreenSize = Size_New();
    Size_Init(m->ScreenSize);
    Size_WidthSet(m->ScreenSize, width);
    Size_HegthSet(m->ScreenSize, hegth);

    qreal widthB;
    qreal hetB;
    widthB = kb.width();
    hetB = kb.height();

    ValueFromInternValue(widthB);
    ValueFromInternValue(hetB);

    m->ScreenDimend = Size_New();
    Size_Init(m->ScreenDimend);
    Size_WidthSet(m->ScreenDimend, widthBA);
    Size_HegthSet(m->ScreenDimend, hetBA);

    return true;
}

Int Stat_Final(Int o)
{
    Stat* m;
    m = CP(o);

    Size_Final(m->ScreenDimend);
    Size_Delete(m->ScreenDimend);

    Size_Final(m->ScreenSize);
    Size_Delete(m->ScreenSize);

    Phore_Final(m->ConsolePhore);
    Phore_Delete(m->ConsolePhore);

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

    Int a;
    a = CastInt(u);
    return a;
}

Int Stat_TimeInitDelete(Int o, Int a)
{
    QDateTime* u;
    u = (QDateTime*)a;

    delete u;
    return true;
}

Int Stat_ConsolePhore(Int o)
{
    Stat* m;
    m = CP(o);
    return m->ConsolePhore;
}

Int Stat_ScreenSize(Int o)
{
    Stat* m;
    m = CP(o);
    return m->ScreenSize;
}

Int Stat_ScreenDimend(Int o)
{
    Stat* m;
    m = CP(o);
    return m->ScreenDimend;
}