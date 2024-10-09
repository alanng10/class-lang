#include "New.h"

Int Intern_New_Phore;

Int Intern_New(Int kind, Int info, Eval* eval)
{
    Phore_Open(Intern_New_Phore);

    Int kk;

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

    


    Phore_Close(Intern_New_Phore);

    return 0;
}