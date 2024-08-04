namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public virtual ClassGen Gen { get; set; }

    public override bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        base.ExecuteReturnExecute(returnExecute);

        ClassGen gen;
        gen = this.Gen;

        string varA;
        varA = gen.VarA;

        int k;
        k = gen.ParamCount;

        int ka;
        ka = gen.LocalVarCount + k;

        gen.EvalValueGet(1, varA);

        gen.EvalFrameValueSet(k, varA);

        gen.EvalIndexPosSet(-ka);

        gen.Return();
        return true;
    }

    public override bool ExecuteAreExecute(AreExecute areExecute)
    {
        base.ExecuteAreExecute(areExecute);

        Target target;
        target = areExecute.Target;

        if (target is VarTarget)
        {
            
        }

        if (target is SetTarget)
        {
            SetTarget setTarget;
            setTarget = (SetTarget)target;

            Field varField;
            varField = this.Info(setTarget).SetField;

            if (!(varField.Virtual == null))
            {
                varField = varField.Virtual;
            }

            ClassClass varClass;
            varClass = varField.Parent;

            int kk;
            kk = varClass.FieldRange.Index;
            kk = kk + varField.BinaryIndex;

            int k;
            k = 2;

            this.ExecuteVirtualCall(k, this.Gen.StateKindSet, kk);
        }
        return true;
    }

    public override bool ExecuteGetOperate(GetOperate getOperate)
    {
        base.ExecuteGetOperate(getOperate);

        Field varField;
        varField = this.Info(getOperate).GetField;

        if (!(varField.Virtual == null))
        {
            varField = varField.Virtual;
        }

        ClassClass varClass;
        varClass = varField.Parent;

        int kk;
        kk = varClass.FieldRange.Index;
        kk = kk + varField.BinaryIndex;

        int k;
        k = 1;

        this.ExecuteVirtualCall(k, this.Gen.StateKindGet, kk);

        return true;
    }

    public override bool ExecuteCallOperate(CallOperate callOperate)
    {
        base.ExecuteCallOperate(callOperate);
        
        Maide varMaide;
        varMaide = this.Info(callOperate).CallMaide;

        if (!(varMaide.Virtual == null))
        {
            varMaide = varMaide.Virtual;
        }

        ClassClass varClass;
        varClass = varMaide.Parent;

        int kk;
        kk = varClass.MaideRange.Index;
        kk = kk + varMaide.BinaryIndex;

        int k;
        k = varMaide.Param.Count;
        k = k + 1;

        this.ExecuteVirtualCall(k, this.Gen.StateKindCall, kk);

        return true;
    }

    public override bool ExecuteVarOperate(VarOperate varOperate)
    {
        Var varVar;
        varVar = this.Info(varOperate).Var;

        this.ExecuteVarGet(varVar);
        return true;
    }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        varA = gen.VarA;

        int k;
        k = gen.ParamCount;
        k = -k;

        gen.EvalFrameValueGet(k, varA);

        gen.EvalValueSet(0, varA);

        gen.EvalIndexPosSet(1);
        return true;
    }

    public override bool ExecuteBaseOperate(BaseOperate baseOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        varA = gen.VarA;

        int k;
        k = gen.ParamCount;
        k = -k;

        gen.EvalFrameValueGet(k, varA);

        gen.VarMaskClear(varA, gen.BaseClearMask);

        gen.VarMaskSet(varA, gen.ClassBaseMask);

        gen.EvalValueSet(0, varA);

        gen.EvalIndexPosSet(1);
        return true;
    }

    public override bool ExecuteNullOperate(NullOperate nullOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        varA = gen.VarA;

        gen.VarSet(varA, gen.Zero);

        gen.EvalValueSet(0, varA);

        gen.EvalIndexPosSet(1);
        return true;
    }

    public override bool ExecuteEqualOperate(EqualOperate equalOperate)
    {
        base.ExecuteEqualOperate(equalOperate);

        ClassGen gen;
        gen = this.Gen;

        string varA;
        string varB;
        varA = gen.VarA;
        varB = gen.VarB;

        gen.EvalValueGet(2, varA);
        gen.EvalValueGet(1, varB);

        gen.OperateDelimit(varA, varA, varB, gen.DelimitEqual);

        gen.VarMaskSet(varA, gen.RefKindBoolMask);

        gen.EvalValueSet(2, varA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    public override bool ExecuteLessOperate(LessOperate lessOperate)
    {
        base.ExecuteLessOperate(lessOperate);

        ClassGen gen;
        gen = this.Gen;

        string varA;
        string varB;
        varA = gen.VarA;
        varB = gen.VarB;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(2, varA);
        gen.EvalValueGet(1, varB);

        gen.VarMaskClear(varA, ka);
        gen.VarMaskClear(varB, ka);

        gen.OperateDelimit(varA, varA, varB, gen.DelimitLess);

        gen.VarMaskSet(varA, gen.RefKindBoolMask);

        gen.EvalValueSet(2, varA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        base.ExecuteAndOperate(andOperate);

        this.ExecuteOperateDelimitBool(this.Gen.DelimitAnd);
        return true;
    }

    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        base.ExecuteOrnOperate(ornOperate);

        this.ExecuteOperateDelimitBool(this.Gen.DelimitOrn);
        return true;
    }

    public override bool ExecuteNotOperate(NotOperate notOperate)
    {
        base.ExecuteNotOperate(notOperate);

        this.ExecuteOperateDelimitBoolOne(this.Gen.DelimitNot);
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        base.ExecuteAddOperate(addOperate);

        this.ExecuteOperateDelimit(this.Gen.DelimitAdd);
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        base.ExecuteSubOperate(subOperate);

        this.ExecuteOperateDelimit(this.Gen.DelimitSub);
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        base.ExecuteMulOperate(mulOperate);

        this.ExecuteOperateDelimit(this.Gen.DelimitMul);
        return true;
    }

    public override bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        base.ExecuteBitAndOperate(bitAndOperate);

        this.ExecuteOperateDelimitA(this.Gen.DelimitAnd);
        return true;
    }

    public override bool ExecuteBitOrnOperate(BitOrnOperate bitOrnOperate)
    {
        base.ExecuteBitOrnOperate(bitOrnOperate);

        this.ExecuteOperateDelimitA(this.Gen.DelimitOrn);
        return true;
    }

    public override bool ExecuteBitNotOperate(BitNotOperate bitNotOperate)
    {
        base.ExecuteBitNotOperate(bitNotOperate);

        ClassGen gen;
        gen = this.Gen;

        string varA;
        varA = gen.VarA;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(1, varA);

        gen.OperateDelimitOne(varA, varA, gen.DelimitBitNot);

        gen.VarMaskClear(varA, ka);

        gen.VarMaskSet(varA, gen.RefKindIntMask);

        gen.EvalValueSet(1, varA);

        return true;
    }

    public override bool ExecuteBitLeftOperate(BitLeftOperate bitLeftOperate)
    {
        base.ExecuteBitLeftOperate(bitLeftOperate);

        this.ExecuteOperateDelimitAA(this.Gen.DelimitBitLeft);
        return true;
    }

    public override bool ExecuteBitRightOperate(BitRightOperate bitRightOperate)
    {
        base.ExecuteBitRightOperate(bitRightOperate);

        this.ExecuteOperateDelimitAB(this.Gen.DelimitBitRight);
        return true;
    }

    public virtual bool ExecuteVarGet(Var varVar)
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        varA = gen.VarA;
        
        int stateKind;
        stateKind = gen.CompStateKind;

        int k;
        k = gen.ParamCount;
        
        int kk;
        kk = varVar.Index;

        if (stateKind == gen.StateKindCall)
        {
            int ka;
            ka = k - 1;

            bool b;
            b = (kk < ka);
            if (b)
            {
                int kkk;
                kkk = ka - kk;
                kkk = -kkk;

                gen.EvalFrameValueGet(kkk, varA);
            }

            if (!b)
            {
                int pos;
                pos = kk - ka;

                gen.EvalFrameValueGet(pos, varA);
            }
        }

        if (stateKind == gen.StateKindGet)
        {
            bool ba;
            ba = (kk == 0);

            if (ba)
            {
                this.ExecuteThisFieldData();

                gen.VarSetDeref(varA, varA, 0);
            }

            if (!ba)
            {
                int pos;
                pos = kk - 1;

                gen.EvalFrameValueGet(pos, varA);
            }
        }

        if (stateKind == gen.StateKindSet)
        {
            bool bc;
            bc = (kk == 0);
            bool bd;
            bd = (kk == 1);

            if (bc)
            {
                this.ExecuteThisFieldData();

                gen.VarSetDeref(varA, varA, 0);
            }

            if (bd)
            {
                int pos;
                pos = -1;

                gen.EvalFrameValueGet(pos, varA);
            }

            if (!(bc | bd))
            {
                int pos;
                pos = kk - 2;

                gen.EvalFrameValueGet(pos, varA);
            }
        }

        gen.EvalValueSet(0, varA);

        gen.EvalIndexPosSet(1);

        return true;
    }

    public virtual bool ExecuteThisFieldData()
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        varA = gen.VarA;

        Field varField;
        varField = gen.ThisField;

        ClassClass varClass;
        varClass = gen.Class;
        
        int k;
        k = gen.ParamCount;
        k = -k;

        int kk;
        kk = varClass.FieldRange.Index;
        kk = kk + varField.BinaryIndex;
        kk = kk + 1;

        int pos;
        pos = kk * sizeof(ulong);

        gen.EvalFrameValueGet(k, varA);

        gen.VarMaskClear(varA, gen.MemoryIndexMask);

        gen.VarSetPos(varA, varA, pos);
        return true;
    }

    public virtual bool ExecuteVirtualCall(int thisEvalIndex, int stateKind, int stateIndex)
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        string varB;
        string varC;
        string varD;
        varA = gen.VarA;
        varB = gen.VarB;
        varC = gen.VarC;
        varD = gen.VarD;

        gen.EvalValueGet(thisEvalIndex, varA);

        gen.VarSet(varB, varA);

        gen.VarMaskClear(varA, gen.MemoryIndexMask);

        gen.VarSetDeref(varA, varA, 0);

        gen.VarSetDeref(varC, varA, 0);

        gen.VarSet(varD, varB);

        gen.VarMaskClear(varD, gen.BaseMask);

        gen.OperateDelimit(varD, varD, gen.BaseBitRightCount, gen.DelimitBitRight);

        gen.VarSetDerefVar(varC, varC, varD);

        gen.VarSetDeref(varC, varC, stateKind);

        gen.VarSetDeref(varC, varC, stateIndex);

        gen.VarSetDeref(varD, varA, 1);

        gen.VarMaskClear(varB, gen.BaseClearMask);

        gen.VarMaskSet(varB, varD);

        gen.EvalValueSet(thisEvalIndex, varB);

        gen.CallCompState(varC);
        return true;
    }

    protected virtual bool ExecuteOperateDelimit(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        string varB;
        varA = gen.VarA;
        varB = gen.VarB;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(2, varA);
        gen.EvalValueGet(1, varB);

        gen.VarMaskClear(varA, ka);
        gen.VarMaskClear(varB, ka);

        gen.OperateDelimit(varA, varA, varB, delimit);

        gen.VarMaskClear(varA, ka);

        gen.VarMaskSet(varA, gen.RefKindIntMask);

        gen.EvalValueSet(2, varA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    protected virtual bool ExecuteOperateDelimitAA(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        string varB;
        varA = gen.VarA;
        varB = gen.VarB;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(2, varA);
        gen.EvalValueGet(1, varB);

        gen.VarMaskClear(varB, ka);

        gen.OperateDelimit(varA, varA, varB, delimit);

        gen.VarMaskClear(varA, ka);

        gen.VarMaskSet(varA, gen.RefKindIntMask);

        gen.EvalValueSet(2, varA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    protected virtual bool ExecuteOperateDelimitAB(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        string varB;
        varA = gen.VarA;
        varB = gen.VarB;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(2, varA);
        gen.EvalValueGet(1, varB);

        gen.VarMaskClear(varA, ka);
        gen.VarMaskClear(varB, ka);

        gen.OperateDelimit(varA, varA, varB, delimit);

        gen.VarMaskSet(varA, gen.RefKindIntMask);

        gen.EvalValueSet(2, varA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    protected virtual bool ExecuteOperateDelimitA(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        string varB;
        varA = gen.VarA;
        varB = gen.VarB;

        gen.EvalValueGet(2, varA);
        gen.EvalValueGet(1, varB);

        gen.OperateDelimit(varA, varA, varB, delimit);

        gen.VarMaskSet(varA, gen.RefKindIntMask);

        gen.EvalValueSet(2, varA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    protected virtual bool ExecuteOperateDelimitBool(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        string varB;
        varA = gen.VarA;
        varB = gen.VarB;

        gen.EvalValueGet(2, varA);
        gen.EvalValueGet(1, varB);

        gen.OperateDelimit(varA, varA, varB, delimit);

        gen.VarMaskSet(varA, gen.RefKindBoolMask);

        gen.EvalValueSet(2, varA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    protected virtual bool ExecuteOperateDelimitBoolOne(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string varA;
        varA = gen.VarA;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(1, varA);

        gen.VarMaskClear(varA, ka);

        gen.OperateDelimitOne(varA, varA, delimit);

        gen.VarMaskSet(varA, gen.RefKindBoolMask);

        gen.EvalValueSet(1, varA);

        return true;
    }

    protected virtual ModuleInfo Info(NodeNode node)
    {
        return (ModuleInfo)node.NodeAny;
    }
}