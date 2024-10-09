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

    Phore_Release(m->Phore);

    return 0;
}