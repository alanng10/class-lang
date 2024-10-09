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
        Int threadThis;
        threadThis = Thread_This();

        Int thisIdent;
        thisIdent = Thread_IdentGet(threadThis);

        m->ThisThreadIdent = thisIdent;

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

                Intern_New_QueueEvalStack(ka);
            }
        }

        i = i + 1;
    }

    return true;
}

Bool Intern_New_QueueEvalStack(Eval* eval)
{
    Int count;
    count = eval->N;

    Int i;
    i = 0;

    while (i < count)
    {
        Int ka;
        ka = eval->S[i];

        Int refKind;
        refKind = ka >> 60;

        if (refKind == 1 | refKind == 4 | refKind == 5 | refKind == 6)
        {
            Int p;
            p = ka & 0x000fffffffffffff;

            p = p - 3 * Constant_IntByteCount();

            NodeFieldFlag(p) = 1;
        
            
        }

        i = i + 1;
    }

    return true;
}