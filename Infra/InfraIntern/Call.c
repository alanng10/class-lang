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

    varA = varA & RefMaskMemoryClear;

        this.VarSetDeref(varA, varA, 0);

        this.VarSetDeref(varC, varA, 0);

        this.VarSet(varD, varB);

        this.VarMaskClear(varD, this.BaseMask);

        this.OperateLimit(varD, varD, this.BaseBitRightCount, this.LimitBitRite);

        this.VarSetDerefVar(varC, varC, varD);

        this.VarSetDeref(varC, varC, stateKind);

        this.VarSetDeref(varC, varC, stateIndex);

        this.VarSetDeref(varD, varA, 1);

        this.VarMaskClear(varB, this.BaseClearMask);

        this.VarMaskSet(varB, varD);

        this.EvalValueSet(thisEvalIndex, varB);

        this.CallCompState(varC);
    return true;
}