#include "Share.h"

Int Intern_Share(Int info, Eval* eval)
{
    Int* p;
    p = CastPointer(info);

    Int phore;
    phore = p[4];

    Phore_Open(phore);

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

        eval->S[eval->N] = k;

        eval->N = eval->N + 1;

        Intern_Call(eval, 1, 3, 0);

        eval->N = eval->N - 1;
    }

    Phore_Close(phore);

    return 0;
}