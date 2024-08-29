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

Int Intern_Intern_StringCountGet(Eval* eval, Int frame)
{
    Int s;
    s = eval->Stack[frame - 1];

    Int* p;
    p = Intern_Intern_FieldMemory(s, 0);

    Int ke;
    ke = *p;

    Return(ke, 1);
}

Int Intern_Intern_StringCountSet(Eval* eval, Int frame)
{
    Int s;
    s = eval->Stack[frame - 2];

    Int value;
    value = eval->Stack[frame - 1];

    Int* p;
    p = Intern_Intern_FieldMemory(s, 0);

    *p = value;

    Int ke;
    ke = BoolTrue;

    Return(ke, 2);
}

Int Intern_Any_Init(Eval* eval, Int frame)
{
    Int k;
    k = BoolTrue;

    Return(k, 0);
}

Int* Intern_Intern_FieldMemory(Int o, Int index)
{
    Int k;
    k = o;
    RefMemory(k);

    Int* a;
    a = CastPointer(k);

    Int ka;
    ka = index + 1;

    a = a + ka;

    return a;
}