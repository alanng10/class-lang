#include "Interval.hpp"

CppClassNew(Interval)

Int Interval_Init(Int o)
{
    Interval* m;
    m = CP(o);
    m->Intern = new IntervalIntern();
    m->Intern->Interval = o;
    m->Intern->Init();
    return true;
}

Int Interval_Final(Int o)
{
    Interval* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(Interval, Time)
CppField(Interval, SingleShot)

Int Interval_ActiveGet(Int o)
{
    Interval* m;
    m = CP(o);
    bool bu;
    bu = m->Intern->isActive();
    Bool b;
    b = bu;
    return b;
}

FieldDefaultSet(Interval, Active)
CppField(Interval, ElapseState)

Int Interval_Start(Int o)
{
    Interval* m;
    m = CP(o);
    Int time;
    time = m->Time;
    Int singleShot;
    singleShot = m->SingleShot;

    int timeU;
    timeU = time;
    bool singleShotU;
    singleShotU = singleShot;

    m->Intern->setInterval(timeU);
    m->Intern->setSingleShot(singleShotU);
    m->Intern->start();
    return true;
}

Int Interval_Stop(Int o)
{
    Interval* m;
    m = CP(o);
    m->Intern->stop();
    return true;
}

Int Interval_Elapse(Int o)
{
    Interval* m;
    m = CP(o);

    Int state;
    state = m->ElapseState;
    Int aa;
    aa = State_MaideGet(state);
    Int arg;
    arg = State_ArgGet(state);

    Interval_Elapse_Maide maide;
    maide = (Interval_Elapse_Maide)aa;
    if (!(maide == null))
    {
        maide(o, arg);
    }
    return true;
}