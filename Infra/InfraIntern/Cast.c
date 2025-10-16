#include "Cast.h"

Int Intern_Cast(Int classVar, Eval* eval)
{
    Int any;
    any = eval->S[eval->N - 1];

    Int refKind;
    refKind = any >> 60;

    Int k;
    k = 0;

    if (refKind == RefKindAny)
    {
        Int* requireClass;
        requireClass = CastPointer(classVar);

        Int requireBaseMask;
        requireBaseMask = requireClass[1];

        Int requireBaseIndex;
        requireBaseIndex = requireBaseMask >> 52;

        Int kka;
        kka = any;
        MaskClear(kka, RefMaskMemory);

        Int* kke;
        kke = CastPointer(kka);

        Int anyClassVar;
        anyClassVar = kke[0];

        Int* anyClass;
        anyClass = CastPointer(anyClassVar);

        Int anyBaseMask;
        anyBaseMask = anyClass[1];

        Int anyBaseIndex;
        anyBaseIndex = anyBaseMask >> 52;

        if (!(anyBaseIndex < requireBaseIndex))
        {
            Int anyBaseArrayVar;
            anyBaseArrayVar = anyClass[0];

            Int* anyBaseArray;
            anyBaseArray = CastPointer(anyBaseArrayVar);
        }
    }

    eval->S[eval->N - 1] = k;

    return 0;
}