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
    intCount = kk + 4;

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

    NodeFieldSize(n) = dataCount;

    NodeFieldFlag(n) = kind << 8;

    Int* pa;
    pa = CastPoiner(n);

    pa = pa + 4;

    Int ke;
    ke = CastInt(pa);

    if (kind == 0)
    {
        *pa = info;

        ke = ke | RefKindAny;
    }

    m->TotalAllocCount = m->TotalAllocCount + dataCount;

    eval->S[eval->N] = ke;

    eval->N = eval->N + 1;

    if (m->AllocCap < m->TotalAllocCount)
    {
        Int threadThis;
        threadThis = Thread_This();

        Int thisIdent;
        thisIdent = Thread_IdentGet(threadThis);

        m->ThisThreadIdent = thisIdent;

        Intern_New_PauseOtherThread();

        Intern_New_QueueAllRoot();

        Intern_New_Traverse();

        Intern_New_ResumeOtherThread();
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

Bool Intern_New_ResumeOtherThread()
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
                Thread_Resume(thread);
            }
        }

        i = i + 1;
    }

    return true;
}

Bool Intern_New_Travarse()
{
    InternNewData* m;
    m = CastPointer(NewData);

    while (!(m->QueueFirstNode == null))
    {
        Int node;
        node = m->QueueFirstNode;

        Int nextNode;
        nextNode = NodeFieldNext(node);

        NodeFieldPrevious(nextNode) = null;

        m->QueueFirstNode = nextNode;

        Int flag;
        flag = NodeFieldFlag(node);
        
        Int kind;
        kind = flag >> 8;

        Int* p;
        p = CastPointer(node);
        p = p + 4;

        Int ka;
        ka = null;

        QueueNodeVar;

        if (kind == 0)
        {
            Int kaa;
            kaa = *p;

            Int* paa;
            paa = CastPointer(kaa);
            
            Int countA;
            countA = paa[2];

            Int* pa;
            pa = p + 1;

            Int iA;
            iA = 0;
            while (iA < countA)
            {
                ka = pa[iA];

                QueueNode;

                iA = iA + 1;
            }
        }
        if (kind == 1)
        {
            ka = *p;

            QueueNode;
        }
    }

    return true;
}

Bool Intern_New_QueueAllRoot()
{
    Intern_New_QueueAllThreadEvalStack();

    Intern_New_QueueClassShare();

    return true;
}

Bool Intern_New_QueueAllThreadEvalStack()
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int count;
    count = 1024;

    Int i;
    i = 0;

    while (i < count)
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

        i = i + 1;
    }

    return true;
}

Bool Intern_New_QueueClassShare()
{
    Int array;
    array = Intern_Module_Array;

    Int count;
    count = Array_CountGet(array);
    Int i;
    i = 0;
    while (i < count)
    {
        Int a;
        a = Array_ItemGet(array, i);

        Module* module;
        module = CastPointer(a);

        Intern_New_QueueClassShareModule(module);

        i = i + 1;
    }

    return true;
}

Bool Intern_New_QueueClassShareModule(Module* module)
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int* array;
    array = CastPointer(module->ClassArray);

    QueueNodeVar;

    Int count;
    count = module->ClassArrayCount;

    Int i;
    i = 0;
    while (i < count)
    {
        Int a;
        a = array[i];

        Int* p;
        p = CastPointer(a);

        Int share;
        share = p[3];

        Int ka;
        ka = share;

        QueueNode;

        i = i + 1;
    } 

    return true;
}

Bool Intern_New_QueueEvalStack(Eval* eval)
{
    InternNewData* m;
    m = CastPointer(NewData);

    QueueNodeVar;

    Int count;
    count = eval->N;

    Int i;
    i = 0;

    while (i < count)
    {
        Int ka;
        ka = eval->S[i];

        QueueNode;

        i = i + 1;
    }

    return true;
}