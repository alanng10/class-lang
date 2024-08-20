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

Int Time_Set(Int o, Int year, Int month, Int day, Int hour, Int min, Int sec, Int millisec, Int pos)
{
    Time* m;
    m = CP(o);

    QDateTime dtO;

    int offsetUtcU;
    offsetUtcU = pos;

    dtO = dtO.toOffsetFromUtc(offsetUtcU);

    int yearU;
    int monthU;
    int dayU;
    yearU = year;
    monthU = month;
    dayU = day;

    QDate dateO(yearU, monthU, dayU);

    int hourU;
    int minU;
    int secU;
    int millisecU;
    hourU = hour;
    minU = min;
    secU = sec;
    millisecU = millisec;

    QTime timeO(hourU, minU, secU, millisecU);

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

Int Time_YearGet(Int o)
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

FieldDefaultSet(Time, Year)

Int Time_MonthGet(Int o)
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

FieldDefaultSet(Time, Month)

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

Int Time_HourGet(Int o)
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

FieldDefaultSet(Time, Hour)

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

Int Time_YearDayGet(Int o)
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

FieldDefaultSet(Time, YearDay)

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

Int Time_YearDayCountGet(Int o)
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

FieldDefaultSet(Time, YearDayCount)

Int Time_MonthDayCountGet(Int o)
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

FieldDefaultSet(Time, MonthDayCount)

Int Time_AddYear(Int o, Int offset)
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

Int Time_AddMonth(Int o, Int offset)
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

Int Time_LeapYear(Int year)
{
    int yearU;
    yearU = year;
    bool bu;
    bu = QDate::isLeapYear(yearU);
    Bool a;
    a = bu;
    return a;
}

Int Time_ValidDate(Int year, Int month, Int day)
{
    int yearU;
    int monthU;
    int dayU;
    yearU = year;
    monthU = month;
    dayU = day;
    bool bu;
    bu = QDate::isValid(yearU, monthU, dayU);
    Bool a;
    a = bu;
    return a;
}

Int Time_ValidTime(Int hour, Int min, Int sec, Int millisec)
{
    int hourU;
    int minuteU;
    int secondU;
    int millisecondU;
    hourU = hour;
    minuteU = min;
    secondU = sec;
    millisecondU = millisec;
    bool bu;
    bu = QTime::isValid(hourU, minuteU, secondU, millisecondU);
    Bool a;
    a = bu;
    return a;
}

Int Time_TotalMillisecIntern(Int u)
{
    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int timeInit;
    timeInit = Stat_TimeInit(stat);

    QDateTime* ua;
    ua = (QDateTime*)timeInit;

    QDateTime* ka;
    ka = (QDateTime*)u;

    qint64 uu;
    uu = ua->msecsTo(*ka);

    SInt u;
    u = uu;

    if (u < 0)
    {
        u = -1;
    }

    Int k;
    k = u;

    Int a;
    a = k;
    return a;
}