#include "Cast.h"

Int Intern_Cast(Int classVar, Eval* eval)
{
    Int ka;
    ka = eval->S[eval->N - 1];

    Int refKind;
    refKind = ka >> 60;

    Int k;
    k = 0;

    if (refKind == RefKindAny)
    {
        Int* kd;
        kd = CastPointer(classVar);

        Int baseMask;
        baseMask = kd[1];
    }

    eval->S[eval->N - 1] = k;

    return 0;
}