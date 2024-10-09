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

    InternNewNode* node;
    node = CastPointer(p);

    if (!(m->LastNode == null))
    {
        node->Previous = m->LastNode;
        m->LastNode->Next = node;
    }

    if (m->FirstNode == null)
    {
        m->FirstNode = node;
    }
    
    m->LastNode = node;

    Int ka;
    ka = dataCount + m->TotalAllocCount;

    m->TotalAllocCount = ka;

    if (m->AllocCap < ka)
    {
        
    }


    Phore_Release(m->Phore);

    return 0;
}