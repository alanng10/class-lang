namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public virtual ClassGen Gen { get; set; }

    public override bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        base.ExecuteReturnExecute(returnExecute);

        ClassGen gen;
        gen = this.Gen;

        String varA;
        varA = gen.VarA;

        long k;
        k = gen.ParamCount;

        long ka;
        ka = gen.LocalVarCount + k;

        gen.EvalValueGet(1, varA);

        gen.EvalFrameValueSet(-k, varA);

        gen.EvalIndexPosSet(-ka);

        gen.Return();
        return true;
    }

    public override bool ExecuteAreExecute(AreExecute areExecute)
    {
        base.ExecuteAreExecute(areExecute);

        ClassGen gen;
        gen = this.Gen;

        Target target;
        target = areExecute.Target;

        if (target is VarTarget)
        {
            VarTarget varTarget;
            varTarget = (VarTarget)target;

            Var varVar;
            varVar = this.Info(varTarget).Var;

            gen.ExecuteVarSet(varVar);
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

            long kk;
            kk = varClass.FieldRange.Index;
            kk = kk + varField.BinaryIndex;

            long k;
            k = 2;

            gen.ExecuteVirtualCall(k, gen.StateKindSet, kk);
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

        long kk;
        kk = varClass.FieldRange.Index;
        kk = kk + varField.BinaryIndex;

        long k;
        k = 1;

        ClassGen gen;
        gen = this.Gen;
        gen.ExecuteVirtualCall(k, gen.StateKindGet, kk);

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

        long kk;
        kk = varClass.MaideRange.Index;
        kk = kk + varMaide.BinaryIndex;

        long k;
        k = varMaide.Param.Count;
        k = k + 1;

        ClassGen gen;
        gen = this.Gen;
        gen.ExecuteVirtualCall(k, gen.StateKindCall, kk);

        return true;
    }

    public override bool ExecuteVarOperate(VarOperate varOperate)
    {
        Var varVar;
        varVar = this.Info(varOperate).Var;

        this.Gen.ExecuteVarGet(varVar);
        return true;
    }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        String varA;
        varA = gen.VarA;

        long k;
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

        String varA;
        varA = gen.VarA;

        long k;
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

        String varA;
        varA = gen.VarA;

        gen.VarSet(varA, gen.Zero);

        gen.EvalValueSet(0, varA);

        gen.EvalIndexPosSet(1);
        return true;
    }

    public override bool ExecuteSameOperate(SameOperate sameOperate)
    {
        base.ExecuteSameOperate(sameOperate);

        ClassGen gen;
        gen = this.Gen;

        String varA;
        String varB;
        varA = gen.VarA;
        varB = gen.VarB;

        gen.EvalValueGet(2, varA);
        gen.EvalValueGet(1, varB);

        gen.OperateLimit(varA, varA, varB, gen.LimitSame);

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

        String varA;
        String varB;
        varA = gen.VarA;
        varB = gen.VarB;

        String ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(2, varA);
        gen.EvalValueGet(1, varB);

        gen.VarMaskClear(varA, ka);
        gen.VarMaskClear(varB, ka);

        gen.OperateLimit(varA, varA, varB, gen.LimitLess);

        gen.VarMaskSet(varA, gen.RefKindBoolMask);

        gen.EvalValueSet(2, varA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        base.ExecuteAndOperate(andOperate);

        this.Gen.ExecuteOperateLimitBool(this.Gen.LimitAnd);
        return true;
    }

    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        base.ExecuteOrnOperate(ornOperate);

        this.Gen.ExecuteOperateLimitBool(this.Gen.LimitOrn);
        return true;
    }

    public override bool ExecuteNotOperate(NotOperate notOperate)
    {
        base.ExecuteNotOperate(notOperate);

        this.Gen.ExecuteOperateDelimitBoolOne(this.Gen.LimitNot);
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        base.ExecuteAddOperate(addOperate);

        this.Gen.ExecuteOperateLimit(this.Gen.LimitAdd);
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        base.ExecuteSubOperate(subOperate);

        this.Gen.ExecuteOperateLimit(this.Gen.LimitSub);
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        base.ExecuteMulOperate(mulOperate);

        this.Gen.ExecuteOperateLimit(this.Gen.LimitMul);
        return true;
    }

    public override bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        base.ExecuteBitAndOperate(bitAndOperate);

        this.Gen.ExecuteOperateLimitA(this.Gen.LimitAnd);
        return true;
    }

    public override bool ExecuteBitOrnOperate(BitOrnOperate bitOrnOperate)
    {
        base.ExecuteBitOrnOperate(bitOrnOperate);

        this.Gen.ExecuteOperateLimitA(this.Gen.LimitOrn);
        return true;
    }

    public override bool ExecuteBitNotOperate(BitNotOperate bitNotOperate)
    {
        base.ExecuteBitNotOperate(bitNotOperate);

        ClassGen gen;
        gen = this.Gen;

        String varA;
        varA = gen.VarA;

        String ka;
        ka = gen.RefKindClearMask;

        gen.EvalValueGet(1, varA);

        gen.OperateDelimitOne(varA, varA, gen.LimitBitNot);

        gen.VarMaskClear(varA, ka);

        gen.VarMaskSet(varA, gen.RefKindIntMask);

        gen.EvalValueSet(1, varA);

        return true;
    }

    public override bool ExecuteBitLiteOperate(BitLiteOperate bitLiteOperate)
    {
        base.ExecuteBitLiteOperate(bitLiteOperate);

        this.Gen.ExecuteOperateLimitAA(this.Gen.LimitBitLite);
        return true;
    }

    public override bool ExecuteBitRiteOperate(BitRiteOperate bitRiteOperate)
    {
        base.ExecuteBitRiteOperate(bitRiteOperate);

        this.Gen.ExecuteOperateLimitAB(this.Gen.LimitBitRite);
        return true;
    }

    protected virtual ModuleInfo Info(NodeNode node)
    {
        return (ModuleInfo)node.NodeAny;
    }
}