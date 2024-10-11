namespace Saber.Console;

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

        Mark mark;
        mark = areExecute.Mark;

        if (mark is VarMark)
        {
            VarMark varMark;
            varMark = (VarMark)mark;

            Var varVar;
            varVar = this.Info(varMark).Var;

            gen.ExecuteVarSet(varVar);
        }

        if (mark is SetMark)
        {
            SetMark setMark;
            setMark = (SetMark)mark;

            Field varField;
            varField = this.Info(setMark).SetField;

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

    public override bool ExecuteOperateExecute(OperateExecute operateExecute)
    {
        base.ExecuteOperateExecute(operateExecute);

        this.Gen.EvalIndexPosSet(-1);
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

    public override bool ExecuteNewOperate(NewOperate newOperate)
    {
        ClassClass ka;
        ka = this.Info(newOperate).OperateClass;
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

        this.Gen.ExecuteOperateLimitBoolOne(this.Gen.LimitNot);
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

    public override bool ExecuteSignLessOperate(SignLessOperate signLessOperate)
    {
        base.ExecuteSignLessOperate(signLessOperate);

        ClassGen gen;
        gen = this.Gen;

        String varA;
        String varB;
        varA = gen.VarA;
        varB = gen.VarB;

        String varSA;
        String varSB;
        varSA = gen.VarSA;
        varSB = gen.VarSB;

        gen.EvalValueGet(2, varA);
        gen.EvalValueGet(1, varB);

        gen.VarSet(varSA, varA);
        gen.VarSet(varSB, varB);

        gen.SignExtend(varSA);
        gen.SignExtend(varSB);

        gen.OperateLimit(varA, varSA, varSB, gen.LimitLess);

        gen.VarMaskSet(varA, gen.RefKindBoolMask);

        gen.EvalValueSet(2, varA);

        gen.EvalIndexPosSet(-1);

        return true;
    }

    public override bool ExecuteSignMulOperate(SignMulOperate signMulOperate)
    {
        base.ExecuteSignMulOperate(signMulOperate);

        this.Gen.ExecuteOperateLimitSign(this.Gen.LimitMul);
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

        gen.OperateLimitOne(varA, varA, gen.LimitBitNot);

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

    public override bool ExecuteValueOperate(ValueOperate valueOperate)
    {
        Value value;
        value = valueOperate.Value;

        ClassGen gen;
        gen = this.Gen;

        String varA;
        varA = gen.VarA;

        gen.VarSetPre(varA);

        base.ExecuteValueOperate(valueOperate);

        gen.VarSetPost();

        gen.EvalValueSet(0, varA);

        gen.EvalIndexPosSet(1);

        return true;
    }

    public override bool ExecuteBoolValue(BoolValue boolValue)
    {
        this.Gen.BoolValueRef(boolValue.Value);
        return true;
    }

    public override bool ExecuteIntValue(IntValue intValue)
    {
        this.Gen.IntValueRef(intValue.Value);
        return true;
    }

    public override bool ExecuteIntSignValue(IntSignValue intSignValue)
    {
        this.Gen.IntValueRef(intSignValue.Value);
        return true;
    }

    public override bool ExecuteIntHexValue(IntHexValue intHexValue)
    {
        this.Gen.IntValueRef(intHexValue.Value);
        return true;
    }

    public override bool ExecuteIntHexSignValue(IntHexSignValue intHexSignValue)
    {
        this.Gen.IntValueRef(intHexSignValue.Value);
        return true;
    }

    public override bool ExecuteStringValue(StringValue stringValue)
    {
        long index;
        index = this.Gen.StringValueIndex;

        this.Gen.StringValueRef(index);

        index = index + 1;

        this.Gen.StringValueIndex = index;
        return true;
    }

    protected virtual ModuleInfo Info(NodeNode node)
    {
        return (ModuleInfo)node.NodeAny;
    }
}