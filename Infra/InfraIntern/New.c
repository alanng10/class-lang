#include "New.h"

Int Intern_New_Phore;

Int Intern_New(Int kind, Int info, Eval* eval)
{
    Phore_Acquire(Intern_New_Phore);

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


    Phore_Release(Intern_New_Phore);

    return 0;
}