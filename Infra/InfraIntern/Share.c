#include "Share.h"

Int Intern_Share(Int info, Eval* eval)
{
    Intern_Class_Maide mm;
    mm = (Intern_Class_Maide)info;

    Int nn;
    nn = mm();

    Int* p;
    p = CastPointer(nn);

    Int phore;
    phore = p[4];

    Phore_Acquire(phore);

    Int share;
    share = p[3];

    Bool b;
    b = (share == null);

    if (!b)
    {
        eval->S[eval->N] = share;

        eval->N = eval->N + 1;
    }

    if (b)
    {
        Intern_New(1, info, eval);

        Int k;
        k = eval->S[eval->N - 1];

        p[3] = k;

        Intern_Call(eval, 1, 3, 0);
    }

    Phore_Release(phore);

    return 0;
}