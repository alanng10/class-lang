#include "Memory.h"


InternNewData Var_NewData;

Int NewData = CastInt(&Var_NewData);

Int Intern_New(Int kind, Int info, Eval* eval)
{
    InternNewData* m;
    m = CastPointer(NewData);

    Intern_New_Open();

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

    if (kind == RefKindAny)
    {
        Int* ppp;
        ppp = CastPointer(info);

        Int baseMask;
        baseMask = ppp[1];

        ke = ke | baseMask;
    }

    m->TotalAllocCount = m->TotalAllocCount + dataCount;

    eval->S[eval->N] = ke;

    eval->N = eval->N + 1;

    if (m->AllocCap < m->TotalAllocCount)
    {
        Intern_New_AutoDelete();
    }

    Intern_New_Close();

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

    Intern_New_PauseOtherThread(thisIdent);

    Intern_New_QueueAllRoot();

    Intern_New_Traverse();

    m->TotalAllocCount = Intern_New_DeleteUnused();

    Int capCount;
    capCount = 2 * (m->TotalAllocCount);

    m->AllocCap = capCount;

    Intern_New_ResumeOtherThread(thisIdent);

    return true;
}

Bool Intern_New_PauseOtherThread(Int thisThreadIdent)
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int count;
    count = ThreadCountMax;

    Int* array;
    array = CastPointer(ThreadArray);

    Int i;
    i = 0;

    while (i < count)
    {
        if (!(i == thisThreadIdent))
        {
            Int ka;
            ka = array[i];

            if (!(ka == null))
            {
                ThreadData* p;
                p = CastPointer(ka);

                if (!(p->Flag == 0))
                {
                    Int thread;
                    thread = p->Thread;

                    Thread_Pause(thread);
                }
            }
        }

        i = i + 1;
    }

    return true;
}

Bool Intern_New_ResumeOtherThread(Int thisThreadIdent)
{
    InternNewData* m;
    m = CastPointer(NewData);

    Int count;
    count = ThreadCountMax;

    Int* array;
    array = CastPointer(ThreadArray);

    Int i;
    i = 0;

    while (i < count)
    {
        if (!(i == thisThreadIdent))
        {
            Int ka;
            ka = array[i];

            if (!(ka == null))
            {
                ThreadData* p;
                p = CastPointer(ka);

                if (!(p->Flag == 0))
                {
                    Int thread;
                    thread = p->Thread;

                    Thread_Resume(thread);
                }
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

Int Intern_New_DeleteUnused()
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

            Environ_Delete(node);
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

    return totalDataCount;
}

Bool Intern_New_QueueAllRoot()
{
    Intern_New_QueueAllThreadEvalStack();

    Intern_New_QueueAllThreadAny();

    Intern_New_QueueClassShare();

    return true;
}

Bool Intern_New_QueueAllThreadEvalStack()
{
    Int count;
    count = ThreadCountMax;

    Int* array;
    array = CastPointer(ThreadArray);

    Int i;
    i = 0;

    while (i < count)
    {
        Int ka;
        ka = array[i];

        if (!(ka == null))
        {
            ThreadData* p;
            p = CastPointer(ka);

            if (!(p->Flag == 0))
            {
                Eval* k;
                k = CastPointer(p->Eval);

                Intern_New_QueueEvalStack(k);
            }
        }

        i = i + 1;
    }

    return true;
}

Bool Intern_New_QueueClassShare()
{
    Int array;
    array = ModuleArray;

    Int count;
    count = ModuleArrayCount;

    Int* p;
    p = CastPointer(array);

    Int i;
    i = 0;
    while (i < count)
    {
        Int a;
        a = p[i];

        Intern_New_QueueClassShareModule(a);

        i = i + 1;
    }

    return true;
}

Bool Intern_New_QueueClassShareModule(Int module)
{
    InternNewData* m;
    m = CastPointer(NewData);

    Intern_Module* kk;
    kk = CastPointer(module);

    Intern_Class* kka;
    kka = kk->Class;

    Int count;
    count = kk->Count;

    QueueNodeVar;

    Int i;
    i = 0;
    while (i < count)
    {
        Intern_Class* a;
        a = &(kka[i]);

        Int share;
        share = (a->Data)[3];

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

    Int* array;
    array = CastPointer(ThreadArray);

    Int i;
    i = 0;

    while (i < count)
    {
        Int kk;
        kk = array[i];

        if (!(kk == null))
        {
            ThreadData* p;
            p = CastPointer(kk);

            Int ka;
            ka = p->ThreadAny;

            QueueNodeVar;

            QueueNode;
        }

        i = i + 1;
    }

    return true;
}

Bool Intern_New_Open()
{
    InternNewData* m;
    m = CastPointer(NewData);

    Phore_Open(m->Phore);
    
    return true;
}

Bool Intern_New_Close()
{
    InternNewData* m;
    m = CastPointer(NewData);

    Phore_Close(m->Phore);
    
    return true;
}

Bool Intern_New_PhoreSet(Int value)
{
    InternNewData* m;
    m = CastPointer(NewData);

    m->Phore = value;
    return true;
}

Bool Intern_New_AllocCapSet(Int value)
{
    InternNewData* m;
    m = CastPointer(NewData);

    m->AllocCap = value;
    return true;
}