namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public virtual ClassGen Gen { get; set; }

    public override bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        base.ExecuteReturnExecute(returnExecute);

        ClassGen gen;
        gen = this.Gen;

        string argA;
        argA = gen.VarA;

        int k;
        k = gen.ParamCount;

        int ka;
        ka = gen.LocalVarCount + k;

        gen.EvalValueGet(1, argA);

        gen.EvalFrameValueSet(k, argA);

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

            object ka;
            ka = setTarget.NodeAny;

            ModuleInfo info;
            info = (ModuleInfo)ka;

            Field varField;
            varField = info.SetField;

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

            this.ExecuteVirtualCall(k, 1, kk);
        }
        return true;
    }

    public override bool ExecuteGetOperate(GetOperate getOperate)
    {
        base.ExecuteGetOperate(getOperate);

        object ka;
        ka = getOperate.NodeAny;

        ModuleInfo info;
        info = (ModuleInfo)ka;

        Field varField;
        varField = info.GetField;

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

        this.ExecuteVirtualCall(k, 0, kk);

        return true;
    }

    public override bool ExecuteCallOperate(CallOperate callOperate)
    {
        base.ExecuteCallOperate(callOperate);

        object ka;
        ka = callOperate.NodeAny;

        ModuleInfo info;
        info = (ModuleInfo)ka;
        
        Maide varMaide;
        varMaide = info.CallMaide;

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

        this.ExecuteVirtualCall(k, 2, kk);

        return true;
    }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        argA = gen.VarA;

        int k;
        k = gen.ParamCount;

        gen.EvalFrameValueGet(k, argA);

        gen.EvalValueSet(0, argA);

        gen.EvalIndexPosSet(1);
        return true;
    }

    public override bool ExecuteBaseOperate(BaseOperate baseOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        argA = gen.VarA;

        int k;
        k = gen.ParamCount;

        gen.EvalFrameValueGet(k, argA);

        gen.VarMaskClear(argA, gen.BaseClearMask);

        gen.VarMaskSet(argA, gen.ClassBaseMask);

        gen.EvalValueSet(0, argA);

        gen.EvalIndexPosSet(1);
        return true;
    }

    public override bool ExecuteNullOperate(NullOperate nullOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        argA = gen.VarA;

        gen.VarSet(argA, gen.Zero);

        gen.EvalValueSet(0, argA);

        gen.EvalIndexPosSet(1);
        return true;
    }

    public override bool ExecuteEqualOperate(EqualOperate equalOperate)
    {
        base.ExecuteEqualOperate(equalOperate);

        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        argA = gen.VarA;
        argB = gen.VarB;

        gen.EvalValueGet(2, argA);
        gen.EvalValueGet(1, argB);

        gen.OperateDelimit(argA, argA, argB, gen.DelimitEqual);

        gen.VarMaskSet(argA, gen.RefKindBoolMask);

        gen.EvalValueSet(2, argA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    public override bool ExecuteLessOperate(LessOperate lessOperate)
    {
        base.ExecuteLessOperate(lessOperate);

        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        argA = gen.VarA;
        argB = gen.VarB;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(2, argA);
        gen.EvalValueGet(1, argB);

        gen.VarMaskClear(argA, ka);
        gen.VarMaskClear(argB, ka);

        gen.OperateDelimit(argA, argA, argB, gen.DelimitLess);

        gen.VarMaskSet(argA, gen.RefKindBoolMask);

        gen.EvalValueSet(2, argA);

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

        string argA;
        argA = gen.VarA;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(1, argA);

        gen.OperateDelimitOne(argA, argA, gen.DelimitBitNot);

        gen.VarMaskClear(argA, ka);

        gen.VarMaskSet(argA, gen.RefKindIntMask);

        gen.EvalValueSet(1, argA);

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

    public virtual bool ExecuteVirtualCall(int thisEvalIndex, int stateKind, int stateIndex)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        string argC;
        string argD;
        argA = gen.VarA;
        argB = gen.VarB;
        argC = gen.VarC;
        argD = gen.VarD;

        gen.EvalValueGet(thisEvalIndex, argA);

        gen.VarSetArg(argB, argA);

        gen.VarMaskClear(argA, gen.MemoryIndexMask);

        gen.VarSetDeref(argA, argA, 0);

        gen.VarSetDeref(argC, argA, 0);

        gen.VarSetArg(argD, argB);

        gen.VarMaskClear(argD, gen.BaseMask);

        gen.VarSetDelimit(argD, argD, gen.DelimitBitRight, gen.BaseBitRightCount);

        gen.VarSetDerefArg(argC, argC, argD);

        gen.VarSetDeref(argC, argC, stateKind);

        gen.VarSetDeref(argC, argC, stateIndex);

        gen.VarSetDeref(argD, argA, 1);

        gen.VarMaskClear(argB, gen.BaseClearMask);

        gen.VarMaskSetArg(argB, argD);

        gen.EvalValueSet(thisEvalIndex, argB);

        gen.CallCompState(argC);
        return true;
    }

    protected virtual bool ExecuteOperateDelimit(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        argA = gen.VarA;
        argB = gen.VarB;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(2, argA);
        gen.EvalValueGet(1, argB);

        gen.VarMaskClear(argA, ka);
        gen.VarMaskClear(argB, ka);

        gen.OperateDelimit(argA, argA, argB, delimit);

        gen.VarMaskClear(argA, ka);

        gen.VarMaskSet(argA, gen.RefKindIntMask);

        gen.EvalValueSet(2, argA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    protected virtual bool ExecuteOperateDelimitAA(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        argA = gen.VarA;
        argB = gen.VarB;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(2, argA);
        gen.EvalValueGet(1, argB);

        gen.VarMaskClear(argB, ka);

        gen.OperateDelimit(argA, argA, argB, delimit);

        gen.VarMaskClear(argA, ka);

        gen.VarMaskSet(argA, gen.RefKindIntMask);

        gen.EvalValueSet(2, argA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    protected virtual bool ExecuteOperateDelimitAB(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        argA = gen.VarA;
        argB = gen.VarB;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(2, argA);
        gen.EvalValueGet(1, argB);

        gen.VarMaskClear(argA, ka);
        gen.VarMaskClear(argB, ka);

        gen.OperateDelimit(argA, argA, argB, delimit);

        gen.VarMaskSet(argA, gen.RefKindIntMask);

        gen.EvalValueSet(2, argA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    protected virtual bool ExecuteOperateDelimitA(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        argA = gen.VarA;
        argB = gen.VarB;

        gen.EvalValueGet(2, argA);
        gen.EvalValueGet(1, argB);

        gen.OperateDelimit(argA, argA, argB, delimit);

        gen.VarMaskSet(argA, gen.RefKindIntMask);

        gen.EvalValueSet(2, argA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    protected virtual bool ExecuteOperateDelimitBool(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        argA = gen.VarA;
        argB = gen.VarB;

        gen.EvalValueGet(2, argA);
        gen.EvalValueGet(1, argB);

        gen.OperateDelimit(argA, argA, argB, delimit);

        gen.VarMaskSet(argA, gen.RefKindBoolMask);

        gen.EvalValueSet(2, argA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    protected virtual bool ExecuteOperateDelimitBoolOne(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        argA = gen.VarA;

        string ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(1, argA);

        gen.VarMaskClear(argA, ka);

        gen.OperateDelimitOne(argA, argA, delimit);

        gen.VarMaskSet(argA, gen.RefKindBoolMask);

        gen.EvalValueSet(1, argA);

        return true;
    }
}