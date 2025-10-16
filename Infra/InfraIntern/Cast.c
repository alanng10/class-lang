#include "Cast.h"

Int Intern_Cast(Int classVar, Eval* eval)
{
    Int any;
    any = eval->S[eval->N - 1];

    Int k;
    k = 0;

    Int refKind;
    refKind = any >> 60;

    if (refKind == RefKindAny)
    {
        Int* requireClass;
        requireClass = CastPointer(classVar);

        Int requireBaseMask;
        requireBaseMask = requireClass[1];

        Int requireBaseIndex;
        requireBaseIndex = requireBaseMask >> 52;

        Int anyMemory;
        anyMemory = any;
        MaskClear(anyMemory, RefMaskMemory);

        Int* anyArray;
        anyArray = CastPointer(anyMemory);

        Int anyClassVar;
        anyClassVar = anyArray[0];

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

            Int anyBaseItemVar;
            anyBaseItemVar = anyBaseArray[requireBaseIndex];

            Int* anyBaseItem;
            anyBaseItem = CastPointer(anyBaseItemVar);

            Int anyBaseItemClassVar;
            anyBaseItemClassVar = anyBaseItem[0];

            if (classVar == anyBaseItemClassVar)
            {
                k = any;
            }
        }
    }

    eval->S[eval->N - 1] = k;

    return 0;
}

Int Intern_Cast_RefKind(Int refKind, Eval* eval)
{
    Int any;
    any = eval->S[eval->N - 1];

    Int k;
    k = 0;

    Int anyRefKind;
    anyRefKind = any >> 60;

    if (anyRefKind == refKind)
    {
        k = any;
    }

    eval->S[eval->N - 1] = k;

    return 0;
}

Int Intern_Cast_RefKindTwo(Int refKindA, Int refKindB, Eval* eval)
{
    Int any;
    any = eval->S[eval->N - 1];

    Int k;
    k = 0;

    Int anyRefKind;
    anyRefKind = any >> 60;

    if ((anyRefKind == refKindA) | (anyRefKind == refKindB))
    {
        k = any;
    }

    eval->S[eval->N - 1] = k;

    return 0;
}