#include "State.h"

Int Intern_State_Thread_Execute(Int thread, Int arg)
{
    Int index;
    index = Thread_IdentGet(thread);

    Int* array;
    array = CastPointer(ThreadArray);

    Int kk;
    kk = array[index];

    Int count;
    count = EvalStackCount;

    Int kaa;
    kaa = count * Constant_IntByteCount();

    Int p;
    p = New(kaa);

    Int* stack;
    stack = CastPointer(p);

    Int kab;
    kab = sizeof(Eval);

    Int pa;
    pa = New(kab);

    Eval* eval;
    eval = CastPointer(pa);

    eval->S = stack;
    eval->Thread = kk;

    Intern_New_Open();

    ThreadData* threadData;
    threadData = CastPointer(kk);

    threadData->Eval = pa;
    threadData->Flag = 1;

    Intern_New_Close();

    return 0;
}