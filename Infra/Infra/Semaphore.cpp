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

CppField(Semaphore, InitCount)

Int Semaphore_CountGet(Int o)
{
    Semaphore* m;

    m = CP(o);



    int u;

    u = m->Intern->available();



    Int a;

    a = u;


    return a;
}





Bool Semaphore_CountSet(Int o, Int value)
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