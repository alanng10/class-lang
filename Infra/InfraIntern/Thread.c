#include "Thread.h"


Int Var_ThreadArray[ThreadCountMax];

Int ThreadArray = CastInt(&Var_ThreadArray);


Bool Intern_InitThread(Int thread, Int threadAny)
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

    return true;
}