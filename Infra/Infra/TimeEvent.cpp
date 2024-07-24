#include "TimeEvent.hpp"

CppClassNew(TimeEvent)

Int TimeEvent_Init(Int o)
{
    TimeEvent* m;
    m = CP(o);
    m->Intern = new TimeEventIntern;
    m->Intern->TimeEvent = o;
    m->Intern->Init();
    return true;
}

Int TimeEvent_Final(Int o)
{
    TimeEvent* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(TimeEvent, Time)
CppField(TimeEvent, Single)

Int TimeEvent_ActiveGet(Int o)
{
    TimeEvent* m;
    m = CP(o);
    bool bu;
    bu = m->Intern->isActive();
    Bool b;
    b = bu;
    return b;
}

FieldDefaultSet(TimeEvent, Active)
CppField(TimeEvent, ElapseState)

Int TimeEvent_Start(Int o)
{
    TimeEvent* m;
    m = CP(o);
    Int time;
    time = m->Time;
    Int single;
    single = m->Single;

    int timeU;
    timeU = time;
    bool singleShotU;
    singleShotU = single;

    m->Intern->setInterval(timeU);
    m->Intern->setSingleShot(singleShotU);
    m->Intern->start();
    return true;
}

Int TimeEvent_Stop(Int o)
{
    TimeEvent* m;
    m = CP(o);
    m->Intern->stop();
    return true;
}

Int TimeEvent_Elapse(Int o)
{
    TimeEvent* m;
    m = CP(o);

    Int state;
    state = m->ElapseState;

    if (state == null)
    {
        return true;
    }
    
    Int aa;
    aa = State_MaideGet(state);
    Int arg;
    arg = State_ArgGet(state);

    if (aa == null)
    {
        return true;
    }

    TimeEvent_Elapse_Maide maide;
    maide = (TimeEvent_Elapse_Maide)aa;
    
    maide(o, arg);
    
    return true;
}