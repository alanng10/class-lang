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

Int Time_Set(Int o, Int year, Int month, Int day, Int hour, Int minute, Int second, Int millisecond, Int isLocalTime, Int offsetUtc)
{
    Time* m;
    m = CP(o);

    Bool b;
    b = isLocalTime;

    QDateTime dtO;

    if (b)
    {
        dtO = dtO.toLocalTime();
    }
    if (!b)
    {
        int offsetUtcU;
        offsetUtcU = offsetUtc;

        dtO = dtO.toOffsetFromUtc(offsetUtcU);
    }

    int yearU;
    int monthU;
    int dayU;
    yearU = year;
    monthU = month;
    dayU = day;

    QDate dateO(yearU, monthU, dayU);

    int hourU;
    int minuteU;
    int secondU;
    int millisecondU;
    hourU = hour;
    minuteU = minute;
    secondU = second;
    millisecondU = millisecond;

    QTime timeO(hourU, minuteU, secondU, millisecondU);

    dtO.setDate(dateO);
    dtO.setTime(timeO);

    if (!dtO.isValid())
    {
        return true;
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

Int Time_MinuteGet(Int o)
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

FieldDefaultSet(Time, Minute)

Int Time_SecondGet(Int o)
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

FieldDefaultSet(Time, Second)

Int Time_MillisecondGet(Int o)
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

FieldDefaultSet(Time, Millisecond)

Int Time_OffsetUtcGet(Int o)
{
    Time* m;
    m = CP(o);
    int u;
    u = m->Intern->offsetFromUtc();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Time, OffsetUtc)

Int Time_LocalTimeGet(Int o)
{
    Time* m;
    m = CP(o);
    Qt::TimeSpec timeSpec;
    timeSpec = m->Intern->timeSpec();
    Bool a;
    a = (timeSpec == Qt::LocalTime);
    return a;
}

FieldDefaultSet(Time, LocalTime)

Int Time_Current(Int o)
{
    Time* m;
    m = CP(o);
    QDateTime u;
    u = QDateTime::currentDateTime();
    (*(m->Intern)) = u;
    return true;
}

Int Time_ToLocalTime(Int o)
{
    Time* m;
    m = CP(o);
    QDateTime u;
    u = m->Intern->toLocalTime();
    (*(m->Intern)) = u;
    return true;
}

Int Time_ToOffsetUtc(Int o, Int offset)
{
    Time* m;
    m = CP(o);
    int ua;
    ua = offset;
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
    (*(m->Intern)) = u;
    return true;
}

Int Time_AddHour(Int o, Int offset)
{
    qint64 u;
    u = offset;
    u = u * 60 * 60 * 1000;
    Int oa;
    oa = u;
    return Time_AddMillisecond(o, oa);
}

Int Time_AddMinute(Int o, Int offset)
{
    qint64 u;
    u = offset;
    u = u * 60 * 1000;
    Int oa;
    oa = u;
    return Time_AddMillisecond(o, oa);
}

Int Time_AddSecond(Int o, Int offset)
{
    qint64 u;
    u = offset;
    u = u * 1000;
    Int oa;
    oa = u;
    return Time_AddMillisecond(o, oa);
}

Int Time_AddMillisecond(Int o, Int offset)
{
    Time* m;
    m = CP(o);
    qint64 offsetU;
    offsetU = offset;
    QDateTime u;
    u = m->Intern->addMSecs(offsetU);
    (*(m->Intern)) = u;
    return true;
}

Int Time_MillisecondTo(Int o, Int other)
{
    Time* m;
    m = CP(o);
    Time* ma;
    ma = CP(other);
    qint64 u;
    u = m->Intern->msecsTo(*(ma->Intern));
    Int a;
    a = u;
    return a;
}

Int Time_DayTo(Int o, Int other)
{
    Time* m;
    m = CP(o);
    Time* ma;
    ma = CP(other);
    QDate da;
    da = m->Intern->date();
    QDate db;
    db = ma->Intern->date();
    qint64 u;
    u = da.daysTo(db);
    Int a;
    a = u;
    return a;
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

Int Time_ValidTime(Int hour, Int minute, Int second, Int millisecond)
{
    int hourU;
    int minuteU;
    int secondU;
    int millisecondU;
    hourU = hour;
    minuteU = minute;
    secondU = second;
    millisecondU = millisecond;
    bool bu;
    bu = QTime::isValid(hourU, minuteU, secondU, millisecondU);
    Bool a;
    a = bu;
    return a;
}