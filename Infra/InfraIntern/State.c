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

    Int ka;
    ka = arg;
    RefKindSet(ka, RefKindAny);

    eval->S[eval->N] = ka;

    eval->N = eval->N + 1;

    Intern_Call(eval, 1, 3, 1);

    Int a;
    a = eval->S[eval->N - 1];

    eval->N = eval->N - 1;

    RefKindClear(a);

    Intern_New_Open();

    threadData->Eval = 0;
    threadData->Flag = 0;

    Intern_New_Close();

    Delete(pa);

    Delete(p);

    return a;
}