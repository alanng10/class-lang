#include "Semaphore.hpp"




CppClassNew(Semaphore)






Bool Semaphore_Init(Int o)
{
    Semaphore* m;

    m = CP(o);




    Int initCount;

    initCount = m->InitCount;




    int ua;

    ua = initCount;




    m->Intern = new QSemaphore(ua);




    return true;
}






Bool Semaphore_Final(Int o)
{
    Semaphore* m;

    m = CP(o);



    delete m->Intern;




    return true;
}







Int Semaphore_GetInitCount(Int o)
{
    Semaphore* m;

    m = CP(o);



    return m->InitCount;
}





Int Semaphore_SetInitCount(Int o, Int value)
{
    Semaphore* m;

    m = CP(o);



    m->InitCount = value;



    return true;
}







Int Semaphore_GetCount(Int o)
{
    Semaphore* m;

    m = CP(o);



    int u;

    u = m->Intern->available();



    Int a;

    a = u;


    return a;
}





Bool Semaphore_SetCount(Int o, Int value)
{
    return true;
}





Bool Semaphore_Acquire(Int o)
{
    Semaphore* m;

    m = CP(o);



    m->Intern->acquire();



    return true;
}





Bool Semaphore_Release(Int o)
{
    Semaphore* m;

    m = CP(o);



    m->Intern->release();



    return true;
}



