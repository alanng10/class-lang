#include "Intern.h"

Int Intern_Intern_RefLess(Eval* eval, Int frame)
{
    Int ka;
    Int kb;
    ka = eval->Stack[frame - 2];
    kb = eval->Stack[frame - 1];

    SInt kc;
    kc = 0;

    if (ka < kb)
    {
        kc = -1;
    }
    if (kb < ka)
    {
        kc = 1;
    }

    Int ke;
    ke = kc;

    RefKindClear(ke);
    RefKindInt(ke);

    Return(ke, 2);
}

Int Intern_Intern_StringCount(Eval* eval, Int frame)
{
    Int s;
    s = eval->Stack[frame - 1];

    Int k;
    k = s;
    RefMemoryAddress(k);

    k = k + sizeof(Int);

    Int* p;
    p = CastPointer(k);

    Int ke;
    ke = *p;

    Return(ke, 1);
}

Int Intern_Any_Init(Eval* eval, Int frame)
{
    Int k;
    k = BoolTrue;

    Return(k, 0);
}