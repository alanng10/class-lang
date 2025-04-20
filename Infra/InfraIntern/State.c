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
    p = Environ_New(kaa);

    Int* stack;
    stack = CastPointer(p);

    Int kab;
    kab = sizeof(Eval);

    Int pa;
    pa = Environ_New(kab);

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

    Environ_Delete(pa);

    Environ_Delete(p);

    return a;
}

Int Intern_State_TimeEvent_Elapse(Int timeEvent, Int arg)
{
    return Intern_State_Call(timeEvent, arg, 1);
}

Int Intern_State_Network_StatusEvent(Int network, Int arg)
{
    return Intern_State_Call(network, arg, 1);
}

Int Intern_State_Network_CaseEvent(Int network, Int arg)
{
    return Intern_State_Call(network, arg, 2);
}

Int Intern_State_Network_DataEvent(Int network, Int arg)
{
    return Intern_State_Call(network, arg, 3);
}

Int Intern_State_NetworkHost_NewPeer(Int networkHost, Int arg)
{
    return Intern_State_Call(networkHost, arg, 1);
}

Int Intern_State_Frame_TypeEvent(Int frame, Int arg, Int index, Int value)
{
    Int k;
    k = Intern_State_CallEval();

    Eval* eval;
    eval = CastPointer(k);

    Int ka;
    ka = arg;
    RefKindSet(ka, RefKindAny);

    RefKindSet(index, RefKindInt);
    RefKindSet(value, RefKindInt);

    eval->S[eval->N] = ka;

    eval->N = eval->N + 1;

    eval->S[eval->N] = index;

    eval->N = eval->N + 1;

    eval->S[eval->N] = value;

    eval->N = eval->N + 1;

    Intern_Call(eval, 3, 3, 1);

    eval->N = eval->N - 1;

    return true;
}

Int Intern_State_Frame_DrawEvent(Int frame, Int arg)
{
    return Intern_State_Call(frame, arg, 2);
}

Int Intern_State_VideoOut_FrameEvent(Int videoOut, Int arg)
{
    return Intern_State_Call(videoOut, arg, 1);
}

Int Intern_State_CallEval()
{
    Int thread;
    thread = Thread_This();

    Int index;
    index = Thread_IdentGet(thread);

    Int* array;
    array = CastPointer(ThreadArray);

    Int kk;
    kk = array[index];

    ThreadData* threadData;
    threadData = CastPointer(kk);

    Int a;
    a = threadData->Eval;

    return a;
}

Int Intern_State_Call(Int o, Int arg, Int stateIndex)
{
    Int k;
    k = Intern_State_CallEval();

    Eval* eval;
    eval = CastPointer(k);

    Int ka;
    ka = arg;
    RefKindSet(ka, RefKindAny);

    eval->S[eval->N] = ka;

    eval->N = eval->N + 1;

    Intern_Call(eval, 1, 3, stateIndex);

    eval->N = eval->N - 1;

    return true;
}