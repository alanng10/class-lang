namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public virtual ClassGen Gen { get; set; }

    public virtual int ParamCount { get; set; }

    public virtual int LocalVarCount { get; set; }

    public override bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        base.ExecuteReturnExecute(returnExecute);

        ClassGen gen;
        gen = this.Gen;

        string argA;
        argA = gen.VarArgA;

        int k;
        k = this.ParamCount;

        int ka;
        ka = this.LocalVarCount + k;

        gen.EvalValueGet(1, argA);

        gen.EvalFrameValueSet(k, argA);

        gen.EvalIndexPosSet(-ka);

        gen.Return();
        return true;
    }

    public override bool ExecuteCallOperate(CallOperate callOperate)
    {
        base.ExecuteCallOperate(callOperate);

        ClassGen gen;
        gen = this.Gen;

        object ka;
        ka = callOperate.NodeAny;

        ModuleInfo info;
        info = (ModuleInfo)ka;
        
        Maide maide;
        maide = info.CallMaide;

        if (!(maide.Virtual == null))
        {
            maide = maide.Virtual;
        }

        ClassClass varClass;
        varClass = maide.Parent;

        int kk;
        kk = varClass.MaideRange.Index;
        kk = kk + maide.Index;

        int k;
        k = maide.Param.Count;
        k = k + 1;

        string argA;
        string argB;
        string argC;
        string argD;
        argA = gen.VarArgA;
        argB = gen.VarArgB;
        argC = gen.VarArgC;
        argD = gen.VarArgD;

        gen.EvalValueGet(k, argA);

        gen.VarSetArg(argB, argA);

        gen.VarMaskClear(argA, gen.MemoryIndexMask);

        gen.VarSetDeref(argA, argA, 0);

        gen.VarSetDeref(argC, argA, 0);

        gen.VarSetDeref(argC, argC, 2);

        gen.VarSetDeref(argC, argC, kk);

        gen.VarSetDeref(argD, argA, 1);

        gen.VarMaskClear(argB, gen.BaseClearMask);

        gen.VarMaskSetArg(argB, argD);

        gen.EvalValueSet(k, argB);

        gen.CallCompState(argC);

        return true;
    }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        argA = gen.VarArgA;

        gen.EvalFrameValueGet(1, argA);

        gen.EvalValueSet(0, argA);

        gen.EvalIndexPosSet(1);
        return true;
    }

    public override bool ExecuteBaseOperate(BaseOperate baseOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        argA = gen.VarArgA;

        gen.EvalFrameValueGet(1, argA);

        gen.VarMaskClear(argA, gen.BaseClearMask);

        gen.VarMaskSet(argA, gen.BaseMask);

        gen.EvalValueSet(0, argA);

        gen.EvalIndexPosSet(1);
        return true;
    }

    public override bool ExecuteNullOperate(NullOperate nullOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        argA = gen.VarArgA;

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
        argA = gen.VarArgA;
        argB = gen.VarArgB;

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
        argA = gen.VarArgA;
        argB = gen.VarArgB;

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
        argA = gen.VarArgA;

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

    protected virtual bool ExecuteOperateDelimit(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        argA = gen.VarArgA;
        argB = gen.VarArgB;

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
        argA = gen.VarArgA;
        argB = gen.VarArgB;

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
        argA = gen.VarArgA;
        argB = gen.VarArgB;

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
        argA = gen.VarArgA;
        argB = gen.VarArgB;

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
        argA = gen.VarArgA;
        argB = gen.VarArgB;

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
        argA = gen.VarArgA;

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