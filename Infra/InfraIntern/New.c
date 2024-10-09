#include "New.h"

Int NewData;

Int Intern_New(Int kind, Int info, Eval* eval)
{
    InternNewData* m;
    m = CastPointer(NewData);

    Phore_Acquire(m->Phore);

    Int kk;
    kk = 0;

    if (kind == 0)
    {
        Int* cc;
        cc = CastPointer(info);

        kk = cc[2];
    }

    Int intCount;
    intCount = kk + 3;

    Int dataCount;
    dataCount = intCount * Constant_IntByteCount();

    Int p;
    p = New(dataCount);

    Int n;
    n = p;

    if (!(m->LastNode == null))
    {
        NodeFieldPrevious(n) = m->LastNode;
        NodeFieldNext(m->LastNode) = n;
    }

    if (m->FirstNode == null)
    {
        m->FirstNode = n;
    }
    
    m->LastNode = n;

    m->TotalAllocCount = m->TotalAllocCount + dataCount;

    if (m->AllocCap < m->TotalAllocCount)
    {
        Intern_New_PauseOtherThread();

        Intern_New_QueueAllRoot();
    }

    Phore_Release(m->Phore);

    return 0;
}

Bool Intern_New_PauseOtherThread()
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int threadThis;
    threadThis = Thread_This();

    Int thisIdent;
    thisIdent = Thread_IdentGet(threadThis);

    m->ThisThreadIdent = thisIdent;

    Int count;
    count = 1024;

    Int i;
    i = 0;

    while (i < count)
    {
        if (!(i == thisIdent))
        {
            Int thread;
            thread = m->Thread[i * 2];

            if (!(thread == null))
            {
                Thread_Pause(thread);
            }
        }

        i = i + 1;
    }

    return true;
}

Bool Intern_New_QueueAllRoot()
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int count;
    count = 1024;

    Int i;
    i = 0;

    while (i < count)
    {
        if (!(i == m->ThisThreadIdent))
        {
            Int thread;
            thread = m->Thread[i * 2];

            Int oo;
            oo = m->Thread[i * 2 + 1];

            if (!(thread == null))
            {
                Eval* ka;
                ka = CastPointer(oo);


            }
        }

        i = i + 1;
    }

    return true;
}