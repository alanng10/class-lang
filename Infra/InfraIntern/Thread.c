#include "Thread.h"


Int Var_ThreadArray[ThreadCountMax];

Int ThreadArray = CastInt(&Var_ThreadArray);


Int Intern_InitMainThread()
{
    
}

Int Intern_InitThread(Int thread, Int threadAny)
{
    Int dataCount;
    dataCount = sizeof(ThreadData);

    Int p;
    p = New(dataCount);

    Int* array;
    array = CastPointer(ThreadArray);

    Intern_New_Open();

    Bool b;
    b = false;

    Int index;
    index = 0;

    Int count;
    count = ThreadCountMax;

    Int i;
    i = 0;
    while ((!b) & (i < count))
    {
        if (array[i] == null)
        {
            index = i;
            b = true;
        }

        i = i + 1;
    }

    if (!b)
    {
        Exit(30);
    }

    ThreadData* kk;
    kk = CastPointer(p);

    kk->Index = index;
    kk->ThreadAny = threadAny;
    kk->Thread = thread;

    array[index] = p;

    Thread_IdentSet(thread, index);

    Intern_New_Close();

    Int a;
    a = index;
    return a;
}

Bool Intern_FinalThread(Int thread)
{
    Int index;
    index = Thread_IdentGet(thread);

    Int* array;
    array = CastPointer(ThreadArray);

    Int ka;
    ka = null;

    Intern_New_Open();

    ka = array[index];

    array[index] = null;

    SInt kk;
    kk = -1;
    Int kka;
    kka = kk;

    Thread_IdentSet(thread, kka);

    Intern_New_Close();

    Delete(ka);

    return true;
}