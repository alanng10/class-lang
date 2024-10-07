#include "Intern.h"

Int Intern_Intern_Init(Eval* eval, Int frame)
{
    Int k;
    k = BoolTrue;

    Return(k, 0);
}

Int Intern_Intern_RefLess(Eval* eval, Int frame)
{
    Int ka;
    Int kb;
    ka = eval->S[frame - 2];
    kb = eval->S[frame - 1];

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

Int Intern_Intern_DataNew(Eval* eval, Int frame)
{
    return 0;
}

Int Intern_Intern_DataGet(Eval* eval, Int frame)
{
    return 0;
}

Int Intern_Intern_DataSet(Eval* eval, Int frame)
{
    return 0;
}

Int Intern_Intern_StringNew(Eval* eval, Int frame)
{
    return 0;
}

Int Intern_Intern_StringValueGet(Eval* eval, Int frame)
{
    return Intern_Intern_FieldGet(eval, frame, 0);
}

Int Intern_Intern_StringValueSet(Eval* eval, Int frame)
{
    return Intern_Intern_FieldSet(eval, frame, 0);
}

Int Intern_Intern_StringCountGet(Eval* eval, Int frame)
{
    return Intern_Intern_FieldGet(eval, frame, 1);
}

Int Intern_Intern_StringCountSet(Eval* eval, Int frame)
{
    return Intern_Intern_FieldSet(eval, frame, 1);
}

Int Intern_Intern_FieldGet(Eval* eval, Int frame, Int index)
{
    Int s;
    s = eval->S[frame - 1];

    Int* p;
    p = Intern_Intern_FieldMemory(s, index);

    Int ke;
    ke = *p;

    Return(ke, 1);
}

Int Intern_Intern_FieldSet(Eval* eval, Int frame, Int index)
{
    Int s;
    s = eval->S[frame - 2];

    Int value;
    value = eval->S[frame - 1];

    Int* p;
    p = Intern_Intern_FieldMemory(s, index);

    *p = value;

    Int ke;
    ke = BoolTrue;

    Return(ke, 2);
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