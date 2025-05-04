#include "Intern.h"

Int Intern_Intern_Memory(Eval* eval, Int frame)
{
    Int ka;
    ka = eval->S[frame - 1];

    Int ke;
    ke = ka;

    RefKindClear(ke);
    RefKindSet(ke, RefKindInt);

    Return(ke, 1);
}

Int Intern_Intern_DataNew(Eval* eval, Int frame)
{
    Int ka;
    ka = eval->S[frame - 1];

    RefKindClear(ka);

    Intern_New(RefKindData, ka, eval);

    Int ke;
    ke = eval->S[frame];

    Return(ke, 1);
}

Int Intern_Intern_DataGet(Eval* eval, Int frame)
{
    Int s;
    s = eval->S[frame - 2];

    Int sa;
    sa = eval->S[frame - 1];

    Int k;
    k = s;
    RefMemory(k);

    Byte* a;
    a = CastPointer(k);

    RefKindClear(sa);

    a = a + sa;

    Byte kk;
    kk = *a;

    Int ke;
    ke = kk;

    RefKindSet(ke, RefKindInt);

    Return(ke, 2);
}

Int Intern_Intern_DataSet(Eval* eval, Int frame)
{
    Int s;
    s = eval->S[frame - 3];

    Int sa;
    sa = eval->S[frame - 2];

    Int sb;
    sb = eval->S[frame - 1];

    Int k;
    k = s;
    RefMemory(k);

    Byte* a;
    a = CastPointer(k);

    RefKindClear(sa);

    RefKindClear(sb);

    a = a + sa;

    Byte kaa;
    kaa = sb;

    *a = kaa;

    Int ke;
    ke = BoolTrue;

    Return(ke, 3);
}

Int Intern_Intern_ArrayNew(Eval* eval, Int frame)
{
    Int ka;
    ka = eval->S[frame - 1];

    RefKindClear(ka);

    Intern_New(RefKindArray, ka, eval);

    Int ke;
    ke = eval->S[frame];

    Return(ke, 1);
}

Int Intern_Intern_ArrayGet(Eval* eval, Int frame)
{
    Int s;
    s = eval->S[frame - 2];

    Int sa;
    sa = eval->S[frame - 1];

    Int k;
    k = s;
    RefMemory(k);

    Int* a;
    a = CastPointer(k);

    RefKindClear(sa);

    a = a + 1 + sa;

    Int ke;
    ke = *a;

    Return(ke, 2);
}

Int Intern_Intern_ArraySet(Eval* eval, Int frame)
{
    Int s;
    s = eval->S[frame - 3];

    Int sa;
    sa = eval->S[frame - 2];

    Int sb;
    sb = eval->S[frame - 1];

    Int k;
    k = s;
    RefMemory(k);

    Int* a;
    a = CastPointer(k);

    RefKindClear(sa);

    a = a + 1 + sa;

    *a = sb;

    Int ke;
    ke = BoolTrue;

    Return(ke, 3);
}

Int Intern_Intern_StringNew(Eval* eval, Int frame)
{
    Intern_New(RefKindString, 0, eval);

    Int ke;
    ke = eval->S[frame];

    Return(ke, 0);
}

Int Intern_Intern_StringValueGet(Eval* eval, Int frame)
{
    return Intern_Intern_FieldGet(eval, frame, 0);
}

Int Intern_Intern_StringValueSet(Eval* eval, Int frame)
{
    return Intern_Intern_FieldSet(eval, frame, 0);
}

Int Intern_Intern_StringCountGet(Eval* eval, Int frame)
{
    return Intern_Intern_FieldGet(eval, frame, 1);
}

Int Intern_Intern_StringCountSet(Eval* eval, Int frame)
{
    return Intern_Intern_FieldSet(eval, frame, 1);
}

Int Intern_Intern_FieldGet(Eval* eval, Int frame, Int index)
{
    Int s;
    s = eval->S[frame - 1];

    Int* p;
    p = Intern_Intern_FieldMemory(s, index);

    Int ke;
    ke = *p;

    Return(ke, 1);
}

Int Intern_Intern_FieldSet(Eval* eval, Int frame, Int index)
{
    Int s;
    s = eval->S[frame - 2];

    Int value;
    value = eval->S[frame - 1];

    Int* p;
    p = Intern_Intern_FieldMemory(s, index);

    *p = value;

    Int ke;
    ke = BoolTrue;

    Return(ke, 2);
}

Int* Intern_Intern_FieldMemory(Int o, Int index)
{
    Int k;
    k = o;
    RefMemory(k);

    Int* a;
    a = CastPointer(k);

    a = a + index;

    return a;
}

Int Intern_Intern_RefLess(Eval* eval, Int frame)
{
    Int ka;
    Int kb;
    ka = eval->S[frame - 2];
    kb = eval->S[frame - 1];

    SInt kc;
    kc = 0;

    if (ka < kb)
    {
        kc = -1;
    }
    if (kb < ka)
    {
        kc = 1;
    }

    Int ke;
    ke = kc;

    RefKindClear(ke);
    RefKindSet(ke, RefKindInt);

    Return(ke, 2);
}

Int Intern_Intern_ThisThread(Eval* eval, Int frame)
{
    Int ka;
    ka = eval->Thread;

    ThreadData* kk;
    kk = CastPointer(ka);

    Int ke;
    ke = kk->ThreadAny;

    Return(ke, 0);
}

Intern_Api Int Intern_Intern_MainThreadSet(Eval* eval, Int frame)
{
    Int thread;
    thread = eval->S[frame - 1];

    Int ka;
    ka = eval->Thread;

    ThreadData* kk;
    kk = CastPointer(ka);

    kk->ThreadAny = thread;

    Int ke;
    ke = BoolTrue;

    Return(ke, 1);
}

Int Intern_Intern_InitThread(Eval* eval, Int frame)
{
    Int thread;
    thread = eval->S[frame - 2];
    Int threadAny;
    threadAny = eval->S[frame - 1];

    RefKindClear(thread);

    Intern_InitThread(thread, threadAny);

    Int ke;
    ke = BoolTrue;

    Return(ke, 2);
}

Int Intern_Intern_FinalThread(Eval* eval, Int frame)
{
    Int thread;
    thread = eval->S[frame - 1];

    RefKindClear(thread);

    Intern_FinalThread(thread);

    Int ke;
    ke = BoolTrue;

    Return(ke, 1);
}

Int Intern_Intern_ArgCount(Eval* eval, Int frame)
{
    Int ka;
    ka = ArgCount;

    RefKindClear(ka);
    RefKindSet(ka, RefKindInt);

    Int ke;
    ke = ka;

    Return(ke, 0);
}

Int Intern_Intern_Arg(Eval* eval, Int frame)
{
    Int ka;
    ka = eval->S[frame - 1];

    RefKindClear(ka);

    Int* p;
    p = CastPointer(ArgArray);

    Int kaa;
    kaa = ka * 2;

    p = p + kaa;

    Int k;
    k = CastInt(p);

    RefKindSet(k, RefKindStringValue);

    Int ke;
    ke = k;

    Return(ke, 1);
}

Int Intern_Intern_StateThreadExecute(Eval* eval, Int frame)
{
    return Intern_Intern_State(eval, frame, InternState(Thread_Execute));
}

Int Intern_Intern_StateTimeEventElapse(Eval* eval, Int frame)
{
    return Intern_Intern_State(eval, frame, InternState(TimeEvent_Elapse));
}

Int Intern_Intern_StateNetworkStatusEvent(Eval* eval, Int frame)
{
    return Intern_Intern_State(eval, frame, InternState(Network_StatusEvent));
}

Int Intern_Intern_StateNetworkCaseEvent(Eval* eval, Int frame)
{
    return Intern_Intern_State(eval, frame, InternState(Network_CaseEvent));
}

Int Intern_Intern_StateNetworkDataEvent(Eval* eval, Int frame)
{
    return Intern_Intern_State(eval, frame, InternState(Network_DataEvent));
}

Int Intern_Intern_StateNetworkHostNewPeer(Eval* eval, Int frame)
{
    return Intern_Intern_State(eval, frame, InternState(NetworkHost_NewPeer));
}

Int Intern_Intern_StateFrameTypeEvent(Eval* eval, Int frame)
{
    return Intern_Intern_State(eval, frame, InternState(Frame_TypeEvent));
}

Int Intern_Intern_StateFrameDrawEvent(Eval* eval, Int frame)
{
    return Intern_Intern_State(eval, frame, InternState(Frame_DrawEvent));
}

Int Intern_Intern_StateVideoOutFrameEvent(Eval* eval, Int frame)
{
    return Intern_Intern_State(eval, frame, InternState(VideoOut_FrameEvent));
}

Int Intern_Intern_State(Eval* eval, Int frame, Int state)
{
    Int ka;
    ka = state;

    RefKindSet(ka, RefKindInt);

    Int ke;
    ke = ka;

    Return(ke, 0);
}