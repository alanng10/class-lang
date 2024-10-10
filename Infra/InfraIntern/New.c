#include "New.h"

Int NewData;

Int Intern_New(Int kind, Int info, Eval* eval)
{
    InternNewData* m;
    m = CastPointer(NewData);

    Phore_Acquire(m->Phore);

    Int kk;
    kk = 0;

    if (kind == RefKindAny)
    {
        Int* cc;
        cc = CastPointer(info);

        kk = cc[2];
        kk = kk + 1;
    }
    if (kind == RefKindString)
    {
        kk = 2;
    }
    if (kind == RefKindData)
    {
        Int kaa;
        kaa = info / Constant_IntByteCount();
        
        Int kae;
        kae = kaa * Constant_IntByteCount();

        kk = kaa;

        if (kae < info)
        {
            kk = kk + 1;
        }
    }
    if (kind == RefKindArray)
    {
        kk = info;
        kk = kk + 1;
    }

    Int intCount;
    intCount = kk + NodeFieldCount;

    Int dataCount;
    dataCount = intCount * Constant_IntByteCount();

    Int p;
    p = New(dataCount);

    Int n;
    n = p;

    if (!(m->LastNode == null))
    {
        NodeFieldNext(m->LastNode) = n;
    }

    if (m->FirstNode == null)
    {
        m->FirstNode = n;
    }
    
    m->LastNode = n;

    NodeFieldSize(n) = dataCount;

    NodeFieldFlag(n) = kind;

    Int* pa;
    pa = CastPointer(n);

    pa = pa + NodeFieldCount;

    if ((kind == RefKindAny) | (kind == RefKindArray))
    {
        *pa = info;
    }

    Int ke;
    ke = CastInt(pa);

    Int kka;
    kka = kind;
    kka = kka << 60;
    
    ke = ke | kka;

    m->TotalAllocCount = m->TotalAllocCount + dataCount;

    eval->S[eval->N] = ke;

    eval->N = eval->N + 1;

    if (m->AllocCap < m->TotalAllocCount)
    {
        Intern_New_AutoDelete();
    }

    Phore_Release(m->Phore);

    return 0;
}

Bool Intern_New_AutoDelete()
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int threadThis;
    threadThis = Thread_This();

    Int thisIdent;
    thisIdent = Thread_IdentGet(threadThis);

    m->ThisThreadIdent = thisIdent;

    Intern_New_PauseOtherThread();

    Intern_New_QueueAllRoot();

    Intern_New_Traverse();

    Intern_New_DeleteUnused();

    Intern_New_ResumeOtherThread();

    m->ThisThreadIdent = 0;

    return true;
}

Bool Intern_New_PauseOtherThread()
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int count;
    count = ThreadCountMax;

    Int i;
    i = 0;

    while (i < count)
    {
        if (!(i == m->ThisThreadIdent))
        {
            Int ka;
            ka = m->Thread[i];

            if (!(ka == null))
            {
                ThreadData* p;
                p = CastPoiner(ka);

                Int thread;
                thread = p->Thread;

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
    count = ThreadCountMax;

    Int i;
    i = 0;

    while (i < count)
    {
        if (!(i == m->ThisThreadIdent))
        {
            Int ka;
            ka = m->Thread[i];

            if (!(ka == null))
            {
                ThreadData* p;
                p = CastPoiner(ka);

                Int thread;
                thread = p->Thread;

                Thread_Resume(thread);
            }
        }

        i = i + 1;
    }

    return true;
}

Bool Intern_New_Traverse()
{
    InternNewData* m;
    m = CastPointer(NewData);

    while (!(m->QueueFirstNode == null))
    {
        Int node;
        node = m->QueueFirstNode;

        Int nextNode;
        nextNode = NodeFieldQueueNext(node);

        m->QueueFirstNode = nextNode;

        Int flag;
        flag = NodeFieldFlag(node);
        
        Int kind;
        kind = flag & 0xffff;

        Int* p;
        p = CastPointer(node);
        p = p + NodeFieldCount;

        Int ka;
        ka = null;

        QueueNodeVar;

        if (kind == RefKindAny)
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

        if (kind == RefKindString)
        {
            ka = *p;

            QueueNode;
        }

        if (kind == RefKindArray)
        {
            Int countB;
            countB = *p;

            Int* pb;
            pb = p + 1;

            Int iB;
            iB = 0;
            while (iB < countB)
            {
                ka = pb[iB];

                QueueNode;

                iB = iB + 1;
            }
        }
    }

    return true;
}

Bool Intern_New_DeleteUnused()
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int totalDataCount;
    totalDataCount = 0;

    Int previousNode;
    previousNode = null;

    Int node;
    node = m->FirstNode;

    while (!(node == null))
    {
        Int flag;
        flag = NodeFieldFlag(node);

        Bool b;
        b = ((flag & QueueFlag) == 0);
        
        Int nextNode;
        nextNode = NodeFieldNext(node);

        if (b)
        {
            if (!(previousNode == null))
            {
                NodeFieldNext(previousNode) = nextNode;
            }

            if (m->FirstNode == node)
            {
                m->FirstNode = nextNode;
            }

            if (m->LastNode == node)
            {
                m->LastNode = previousNode;
            }

            Delete(node);
        }

        if (!b)
        {
            flag = flag & 0xffff;

            Int dataCount;
            dataCount = NodeFieldSize(node);

            totalDataCount = totalDataCount + dataCount;

            NodeFieldFlag(node) = flag;

            previousNode = node;
        }

        node = nextNode;
    }

    m->TotalAllocCount = totalDataCount;

    Int capCount;
    capCount = 2 * (m->TotalAllocCount);

    m->AllocCap = capCount;

    return true;
}

Bool Intern_New_QueueAllRoot()
{
    Intern_New_QueueAllThreadEvalStack();

    Intern_New_QueueClassShare();

    Intern_New_QueueAllThreadAny();

    return true;
}

Bool Intern_New_QueueAllThreadEvalStack()
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int count;
    count = ThreadCountMax;

    Int i;
    i = 0;

    while (i < count)
    {
        Int ka;
        ka = m->Thread[i];

        if (!(ka == null))
        {
            ThreadData* p;
            p = CastPoiner(ka);

            Eval* k;
            k = p->Eval;

            Intern_New_QueueEvalStack(k);
        }

        i = i + 1;
    }

    return true;
}

Bool Intern_New_QueueClassShare()
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int array;
    array = m->ModuleArray;

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

Bool Intern_New_QueueAllThreadAny()
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int count;
    count = ThreadCountMax;

    Int i;
    i = 0;

    while (i < count)
    {
        Int kk;
        kk = m->Thread[i];

        if (!(kk == null))
        {
            ThreadData* p;
            p = CastPoiner(kk);

            Int ka;
            ka = p->ThreadAny;

            QueueNodeVar;

            QueueNode;
        }

        i = i + 1;
    }

    return true;
}