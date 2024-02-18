#include "Mutex.hpp"




CppClassNew(Mutex)







Bool Mutex_Init(Int o)
{
    Mutex* m;

    m = CP(o);



    m->Intern = new QMutex();




    return true;
}






Bool Mutex_Final(Int o)
{
    Mutex* m;

    m = CP(o);



    delete m->Intern;




    return true;
}





Bool Mutex_Acquire(Int o)
{
    Mutex* m;

    m = CP(o);



    m->Intern->lock();



    return true;
}





Bool Mutex_Release(Int o)
{
    Mutex* m;

    m = CP(o);



    m->Intern->unlock();



    return true;
}

