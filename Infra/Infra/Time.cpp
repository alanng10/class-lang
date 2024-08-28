#include "Time.hpp"

CppClassNew(Time)

Int Time_Init(Int o)
{
    Time* m;
    m = CP(o);

    m->Intern = new QDateTime;

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int timeInit;
    timeInit = Stat_TimeInit(stat);

    QDateTime* u;
    u = (QDateTime*)timeInit;

    (*(m->Intern)) = (*u);
    return true;
}

Int Time_Final(Int o)
{
    Time* m;
    m = CP(o);
    delete m->Intern;
    return true;
}

Int Time_Set(Int o, Int yea, Int mon, Int day, Int our, Int min, Int sec, Int millisec, Int pos)
{
    Time* m;
    m = CP(o);

    QDateTime dtO;

    int offsetUtcU;
    offsetUtcU = pos;

    dtO = dtO.toOffsetFromUtc(offsetUtcU);

    int yeaU;
    int monU;
    int dayU;
    yeaU = yea;
    monU = mon;
    dayU = day;

    QDate dateO(yeaU, monU, dayU);

    int ourU;
    int minU;
    int secU;
    int millisecU;
    ourU = our;
    minU = min;
    secU = sec;
    millisecU = millisec;

    QTime timeO(ourU, minU, secU, millisecU);

    dtO.setDate(dateO);
    dtO.setTime(timeO);

    if (!dtO.isValid())
    {
        return true;
    }

    Int ka;
    ka = CastInt(&dtO);

    Int k;
    k = Time_TotalMillisecIntern(ka);

    SInt kka;
    kka = k;

    if (kka < 0)
    {
        return false;
    }

    (*(m->Intern)) = dtO;
    return true;
}

Int Time_YeaGet(Int o)
{
    Time* m;
    m = CP(o);
    QDate date;
    date = m->Intern->date();
    int u;
    u = date.year();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, Yea)

Int Time_MonGet(Int o)
{
    Time* m;
    m = CP(o);
    QDate date;
    date = m->Intern->date();
    int u;
    u = date.month();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, Mon)

Int Time_DayGet(Int o)
{
    Time* m;
    m = CP(o);
    QDate date;
    date = m->Intern->date();
    int u;
    u = date.day();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, Day)

Int Time_OurGet(Int o)
{
    Time* m;
    m = CP(o);
    QTime time;
    time = m->Intern->time();
    int u;
    u = time.hour();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, Our)

Int Time_MinGet(Int o)
{
    Time* m;
    m = CP(o);
    QTime time;
    time = m->Intern->time();
    int u;
    u = time.minute();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, Min)

Int Time_SecGet(Int o)
{
    Time* m;
    m = CP(o);
    QTime time;
    time = m->Intern->time();
    int u;
    u = time.second();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, Sec)

Int Time_MillisecGet(Int o)
{
    Time* m;
    m = CP(o);
    QTime time;
    time = m->Intern->time();
    int u;
    u = time.msec();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, Millisec)

Int Time_PosGet(Int o)
{
    Time* m;
    m = CP(o);
    int u;
    u = m->Intern->offsetFromUtc();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, Pos)

Int Time_TotalMillisecGet(Int o)
{
    Time* m;
    m = CP(o);
    
    Int ka;
    ka = CastInt(m->Intern);
    
    Int k;
    k = Time_TotalMillisecIntern(ka);
    
    Int a;
    a = k;
    return a;
}

FieldDefaultSet(Time, TotalMillisec)

Int Time_This(Int o)
{
    Time* m;
    m = CP(o);
    QDateTime u;
    u = QDateTime::currentDateTime();
    (*(m->Intern)) = u;
    return true;
}

Int Time_ToPos(Int o, Int pos)
{
    Time* m;
    m = CP(o);
    int ua;
    ua = pos;
    QDateTime u;
    u = m->Intern->toOffsetFromUtc(ua);
    (*(m->Intern)) = u;
    return true;
}

Int Time_YeaDayGet(Int o)
{
    Time* m;
    m = CP(o);
    QDate date;
    date = m->Intern->date();
    int u;
    u = date.dayOfYear();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, YeaDay)

Int Time_WeekDayGet(Int o)
{
    Time* m;
    m = CP(o);
    QDate date;
    date = m->Intern->date();
    int u;
    u = date.dayOfWeek();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, WeekDay)

Int Time_YeaDayCountGet(Int o)
{
    Time* m;
    m = CP(o);
    QDate date;
    date = m->Intern->date();
    int u;
    u = date.daysInYear();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, YeaDayCount)

Int Time_MonDayCountGet(Int o)
{
    Time* m;
    m = CP(o);
    QDate date;
    date = m->Intern->date();
    int u;
    u = date.daysInMonth();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, MonDayCount)

Int Time_AddYea(Int o, Int offset)
{
    Time* m;
    m = CP(o);
    int ua;
    ua = offset;
    QDateTime u;
    u = m->Intern->addYears(ua);

    Int ka;
    ka = CastInt(&u);

    Int k;
    k = Time_TotalMillisecIntern(ka);

    SInt kka;
    kka = k;

    if (kka < 0)
    {
        return false;
    }

    (*(m->Intern)) = u;
    return true;
}

Int Time_AddMon(Int o, Int offset)
{
    Time* m;
    m = CP(o);
    int ua;
    ua = offset;
    QDateTime u;
    u = m->Intern->addMonths(ua);

    Int ka;
    ka = CastInt(&u);

    Int k;
    k = Time_TotalMillisecIntern(ka);

    SInt kka;
    kka = k;

    if (kka < 0)
    {
        return false;
    }

    (*(m->Intern)) = u;
    return true;
}

Int Time_AddDay(Int o, Int offset)
{
    Time* m;
    m = CP(o);
    qint64 ua;
    ua = offset;
    QDateTime u;
    u = m->Intern->addDays(ua);

    Int ka;
    ka = CastInt(&u);

    Int k;
    k = Time_TotalMillisecIntern(ka);

    SInt kka;
    kka = k;

    if (kka < 0)
    {
        return false;
    }

    (*(m->Intern)) = u;
    return true;
}

Int Time_AddMillisec(Int o, Int offset)
{
    Time* m;
    m = CP(o);
    qint64 offsetU;
    offsetU = offset;
    QDateTime u;
    u = m->Intern->addMSecs(offsetU);

    Int ka;
    ka = CastInt(&u);

    Int k;
    k = Time_TotalMillisecIntern(ka);

    SInt kka;
    kka = k;

    if (kka < 0)
    {
        return false;
    }

    (*(m->Intern)) = u;
    return true;
}

Int Time_LeapYea(Int yea)
{
    int yearU;
    yearU = yea;
    bool bu;
    bu = QDate::isLeapYear(yearU);
    Bool a;
    a = bu;
    return a;
}

Int Time_ValidDate(Int yea, Int mon, Int day)
{
    int yeaU;
    int monU;
    int dayU;
    yeaU = yea;
    monU = mon;
    dayU = day;

    if (yeaU < 1)
    {
        return false;
    }
    if (monU < 1)
    {
        return false;
    }
    if (dayU < 1)
    {
        return false;
    }

    bool bu;
    bu = QDate::isValid(yeaU, monU, dayU);
    Bool a;
    a = bu;
    return a;
}

Int Time_ValidTime(Int our, Int min, Int sec, Int millisec)
{
    int ourU;
    int minU;
    int secU;
    int millisecU;
    ourU = our;
    minU = min;
    secU = sec;
    millisecU = millisec;
    bool bu;
    bu = QTime::isValid(ourU, minU, secU, millisecU);
    Bool a;
    a = bu;
    return a;
}

Int Time_TotalMillisecIntern(Int o)
{
    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int timeInit;
    timeInit = Stat_TimeInit(stat);

    QDateTime* ua;
    ua = (QDateTime*)timeInit;

    QDateTime* oa;
    oa = (QDateTime*)o;

    qint64 uu;
    uu = ua->msecsTo(*oa);

    SInt kka;
    kka = uu;

    if (kka < 0)
    {
        kka = -1;
    }

    Int k;
    k = kka;

    Int a;
    a = k;
    return a;
}