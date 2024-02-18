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





Int Interval_GetTime(Int o)
{
    Interval* m;

    m = CP(o);


    return m->Time;
}




Int Interval_SetTime(Int o, Int value)
{
    Interval* m;

    m = CP(o);


    m->Time = value;


    return true;
}






Int Interval_GetSingleShot(Int o)
{
    Interval* m;

    m = CP(o);


    return m->SingleShot;
}




Int Interval_SetSingleShot(Int o, Int value)
{
    Interval* m;

    m = CP(o);


    m->SingleShot = value;


    return true;
}






Int Interval_GetActive(Int o)
{
    Interval* m;

    m = CP(o);



    bool bu;

    bu = m->Intern->isActive();



    Bool b;

    b = bu;


    return b;
}




Int Interval_SetActive(Int o, Int value)
{
    return true;
}





Int Interval_GetElapseState(Int o)
{
    Interval* m;

    m = CP(o);


    return m->ElapseState;
}




Int Interval_SetElapseState(Int o, Int value)
{
    Interval* m;

    m = CP(o);


    m->ElapseState = value;


    return true;
}





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

    singleShotU = (!(singleShot == 0));





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

    aa = State_GetMaide(state);


    Int arg;

    arg = State_GetArg(state);




    Interval_Elapse_Maide maide;

    maide = (Interval_Elapse_Maide)aa;



    if (!(maide == null))
    {
        maide(o, arg);
    }




    return true;
}




