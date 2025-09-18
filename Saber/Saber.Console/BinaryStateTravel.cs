namespace Saber.Console;

public class BinaryStateTravel : Travel
{
    public override bool Init()
    {
        base.Init();
        this.Kind = BinaryOperateKindList.This;

        this.Operate = this.CreateOperate();
        this.ArgA = this.CreateArgA();
        this.ArgB = this.CreateArgB();
        this.NullArg = this.CreateNullArg();
        return true;
    }

    protected virtual BinaryOperate CreateOperate()
    {
        BinaryOperate a;
        a = new BinaryOperate();
        a.Init();
        return a;
    }

    protected virtual BinaryOperateArg CreateArgA()
    {
        BinaryOperateArg a;
        a = new BinaryOperateArg();
        a.Init();
        return a;
    }

    protected virtual BinaryOperateArg CreateArgB()
    {
        BinaryOperateArg a;
        a = new BinaryOperateArg();
        a.Init();
        return a;
    }

    protected virtual BinaryOperateArg CreateNullArg()
    {
        BinaryOperateArg a;
        a = new BinaryOperateArg();
        a.Init();
        a.Kind = 0;
        a.Bool = false;
        a.Int = -1;
        a.String = null;
        return a;
    }

    public virtual BinaryState State { get; set; }
    protected virtual BinaryOperateKindList Kind { get; set; }
    protected virtual BinaryOperate Operate { get; set; }
    protected virtual BinaryOperateArg ArgA { get; set; }
    protected virtual BinaryOperateArg ArgB { get; set; }
    protected virtual BinaryOperateArg NullArg { get; set; }

    public override bool ExecuteOperateExecute(OperateExecute operateExecute)
    {
        base.ExecuteOperateExecute(operateExecute);

        this.Op(this.Kind.End, null, null);
        return true;
    }

    public override bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        base.ExecuteReturnExecute(returnExecute);

        this.Op(this.Kind.Ret, null, null);
        return true;
    }

    public override bool ExecuteReferExecute(ReferExecute referExecute)
    {
        NodeVar nodeVar;
        nodeVar = referExecute.Var;

        Var varVar;
        varVar = this.Info(nodeVar).Var;

        this.Op(this.Kind.Refer, this.IntArg(this.ArgA, varVar.Index), null);
        return true;
    }

    public override bool ExecuteAreExecute(AreExecute areExecute)
    {
        base.ExecuteAreExecute(areExecute);

        Mark mark;
        mark = areExecute.Mark;

        long k;
        k = 0;

        VarMark ka;
        ka = mark as VarMark;

        if (ka == null)
        {
            k = 1;
        }

        this.Op(this.Kind.Are, this.IntArg(this.ArgA, k), null);
        return true;
    }

    public override bool ExecuteInfExecute(InfExecute infExecute)
    {
        Operate cond;
        cond = infExecute.Cond;
        State then;
        then = infExecute.Then;

        this.ExecuteOperate(cond);

        this.Op(this.Kind.InfStart, null, null);

        this.ExecuteState(then);

        this.Op(this.Kind.InfEnd, null, null);
        return true;
    }

    public override bool ExecuteWhileExecute(WhileExecute whileExecute)
    {
        Operate cond;
        cond = whileExecute.Cond;
        State loop;
        loop = whileExecute.Loop;

        this.Op(this.Kind.WhileStart, null, null);

        this.ExecuteOperate(cond);

        this.Op(this.Kind.While, null, null);

        this.ExecuteState(loop);

        this.Op(this.Kind.WhileEnd, null, null);
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
        kk = varClass.FieldStart;
        kk = kk + varField.Index;

        this.Op(this.Kind.ItemGet, this.IntArg(this.ArgA, kk), null);
        return true;
    }

    public override bool ExecuteSetMark(SetMark setMark)
    {
        base.ExecuteSetMark(setMark);

        Field varField;
        varField = this.Info(setMark).SetField;

        if (!(varField.Virtual == null))
        {
            varField = varField.Virtual;
        }

        ClassClass varClass;
        varClass = varField.Parent;

        long kk;
        kk = varClass.FieldStart;
        kk = kk + varField.Index;

        this.Op(this.Kind.SetMark, this.IntArg(this.ArgA, kk), null);
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
        kk = varClass.MaideStart;
        kk = kk + varMaide.Index;

        long k;
        k = varMaide.Param.Count;

        this.Op(this.Kind.Call, this.IntArg(this.ArgA, kk), this.IntArg(this.ArgB, k));

        return true;
    }

    public override bool ExecuteVarOperate(VarOperate varOperate)
    {
        Var varVar;
        varVar = this.Info(varOperate).Var;

        this.Op(this.Kind.Var, this.IntArg(this.ArgA, varVar.Index), null);
        return true;
    }

    public override bool ExecuteVarMark(VarMark varMark)
    {
        Var varVar;
        varVar = this.Info(varMark).Var;

        this.Op(this.Kind.VarMark, this.IntArg(this.ArgA, varVar.Index), null);
        return true;
    }

    public override bool ExecuteNewOperate(NewOperate newOperate)
    {
        ClassClass ka;
        ka = this.Info(newOperate).OperateClass;

        long k;
        k = this.State.ClassIndex(ka);

        this.Op(this.Kind.New, this.IntArg(this.ArgA, k), null);
        return true;
    }

    public override bool ExecuteShareOperate(ShareOperate shareOperate)
    {
        ClassClass ka;
        ka = this.Info(shareOperate).OperateClass;

        long k;
        k = this.State.ClassIndex(ka);

        this.Op(this.Kind.Share, this.IntArg(this.ArgA, k), null);
        return true;
    }

    public override bool ExecuteCastOperate(CastOperate castOperate)
    {
        ClassClass ka;
        ka = this.Info(castOperate).OperateClass;

        long k;
        k = this.State.ClassIndex(ka);

        this.Op(this.Kind.Cast, this.IntArg(this.ArgA, k), null);
        return true;
    }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        this.Op(this.Kind.ItemThis, null, null);
        return true;
    }

    public override bool ExecuteBaseOperate(BaseOperate baseOperate)
    {
        this.Op(this.Kind.Base, null, null);
        return true;
    }

    public override bool ExecuteNullOperate(NullOperate nullOperate)
    {
        this.Op(this.Kind.Null, null, null);
        return true;
    }

    public override bool ExecuteSameOperate(SameOperate sameOperate)
    {
        base.ExecuteSameOperate(sameOperate);

        this.Op(this.Kind.Same, null, null);
        return true;
    }

    public override bool ExecuteLessOperate(LessOperate lessOperate)
    {
        base.ExecuteLessOperate(lessOperate);

        this.Op(this.Kind.Less, null, null);
        return true;
    }

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        base.ExecuteAndOperate(andOperate);

        this.Op(this.Kind.And, null, null);
        return true;
    }

    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        base.ExecuteOrnOperate(ornOperate);

        this.Op(this.Kind.Orn, null, null);
        return true;
    }

    public override bool ExecuteNotOperate(NotOperate notOperate)
    {
        base.ExecuteNotOperate(notOperate);

        this.Op(this.Kind.Not, null, null);
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        base.ExecuteAddOperate(addOperate);

        this.Op(this.Kind.Add, null, null);
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        base.ExecuteSubOperate(subOperate);

        this.Op(this.Kind.Sub, null, null);
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        base.ExecuteMulOperate(mulOperate);

        this.Op(this.Kind.Mul, null, null);
        return true;
    }

    public override bool ExecuteDivOperate(DivOperate divOperate)
    {
        base.ExecuteDivOperate(divOperate);

        this.Op(this.Kind.Div, null, null);
        return true;
    }

    public override bool ExecuteSignLessOperate(SignLessOperate signLessOperate)
    {
        base.ExecuteSignLessOperate(signLessOperate);

        this.Op(this.Kind.SignLess, null, null);
        return true;
    }

    public override bool ExecuteSignMulOperate(SignMulOperate signMulOperate)
    {
        base.ExecuteSignMulOperate(signMulOperate);

        this.Op(this.Kind.SignMul, null, null);
        return true;
    }

    public override bool ExecuteSignDivOperate(SignDivOperate signDivOperate)
    {
        base.ExecuteSignDivOperate(signDivOperate);

        this.Op(this.Kind.SignDiv, null, null);
        return true;
    }

    public override bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        base.ExecuteBitAndOperate(bitAndOperate);

        this.Op(this.Kind.BitAnd, null, null);
        return true;
    }

    public override bool ExecuteBoolValue(BoolValue boolValue)
    {
        this.Op(this.Kind.BoolValue, this.BoolArg(this.ArgA, boolValue.Value), null);
        return true;
    }

    public override bool ExecuteIntValue(IntValue intValue)
    {
        this.IntValueOp(intValue.Value);
        return true;
    }

    public override bool ExecuteIntSignValue(IntSignValue intSignValue)
    {
        this.IntValueOp(intSignValue.Value);
        return true;
    }

    public override bool ExecuteIntHexValue(IntHexValue intHexValue)
    {
        this.IntValueOp(intHexValue.Value);
        return true;
    }

    public override bool ExecuteIntHexSignValue(IntHexSignValue intHexSignValue)
    {
        this.IntValueOp(intHexSignValue.Value);
        return true;
    }

    public override bool ExecuteStringValue(StringValue stringValue)
    {
        this.Op(this.Kind.StringValue, this.StringArg(this.ArgA, stringValue.Value), null);
        return true;
    }

    protected virtual bool IntValueOp(long value)
    {
        this.Op(this.Kind.IntValue, this.IntArg(this.ArgA, value), null);
        return true;
    }

    protected virtual BinaryOperateArg BoolArg(BinaryOperateArg arg, bool value)
    {
        arg.Kind = 1;
        arg.Bool = value;
        arg.Int = -1;
        arg.String = null;
        return arg;
    }

    protected virtual BinaryOperateArg IntArg(BinaryOperateArg arg, long value)
    {
        arg.Kind = 2;
        arg.Bool = false;
        arg.Int = value;
        arg.String = null;
        return arg;
    }

    protected virtual BinaryOperateArg StringArg(BinaryOperateArg arg, String value)
    {
        arg.Kind = 3;
        arg.Bool = false;
        arg.Int = -1;
        arg.String = value;
        return arg;
    }

    protected virtual bool Op(BinaryOperateKind kind, BinaryOperateArg argA, BinaryOperateArg argB)
    {
        if (argA == null)
        {
            argA = this.NullArg;
        }

        if (argB == null)
        {
            argB = this.NullArg;
        }

        this.Operate.Kind = kind.Index;
        this.Operate.ArgA = argA;
        this.Operate.ArgB = argB;

        this.State.ExecuteOperate(this.Operate);
        return true;
    }

    protected virtual ModuleInfo Info(NodeNode node)
    {
        return node.NodeAny as ModuleInfo;
    }
}