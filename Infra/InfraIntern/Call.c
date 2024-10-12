#include "Call.h"

Bool Intern_Call(Eval* eval, Int thisEvalIndex, Int stateKind, Int stateIndex)
{
    Int varA;
    Int varB;
    Int varC;
    Int varD;
    varA = 0;
    varB = 0;
    varC = 0;
    varD = 0;

    varA = eval->S[eval->N - thisEvalIndex];

    varB = varA;

    MaskClear(varA, RefMaskMemory);

    VarSetDeref(varA, varA, 0);

    VarSetDeref(varC, varA, 0);

    varD = varB;

    MaskClear(varD, RefMaskBase);

    varD = varD >> 52;

    VarSetDeref(varC, varC, varD);

    VarSetDeref(varC, varC, stateKind);

    VarSetDeref(varC, varC, stateIndex);

    VarSetDeref(varD, varA, 1);

    MaskClear(varB, RefMaskBaseClear);

    MaskSet(varB, varD);

        this.EvalValueSet(thisEvalIndex, varB);

        this.CallCompState(varC);
    return true;
}