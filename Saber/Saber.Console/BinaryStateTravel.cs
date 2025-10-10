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
        return this.CreateArg();
    }

    protected virtual BinaryOperateArg CreateArgB()
    {
        return this.CreateArg();
    }

    protected virtual BinaryOperateArg CreateArg()
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
    protected virtual long InfIndex { get; set; }
    protected virtual long WhileIndex { get; set; }

    public virtual bool ResetBlockIndex()
    {
        this.InfIndex = 0;
        this.WhileIndex = 0;
        return true;
    }

    public override bool ExecuteOperateExecute(OperateExecute operateExecute)
    {
        base.ExecuteOperateExecute(operateExecute);

        this.Ope(this.Kind.End, null, null);
        return true;
    }

    public override bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        base.ExecuteReturnExecute(returnExecute);

        this.Ope(this.Kind.Ret, null, null);
        return true;
    }

    public override bool ExecuteReferExecute(ReferExecute referExecute)
    {
        NodeVar nodeVar;
        nodeVar = referExecute.Var;

        Var varVar;
        varVar = this.Info(nodeVar).Var;

        this.Ope(this.Kind.Refer, this.IntArg(this.ArgA, varVar.Index), null);
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

        this.Ope(this.Kind.Are, this.IntArg(this.ArgA, k), null);
        return true;
    }

    public override bool ExecuteInfExecute(InfExecute infExecute)
    {
        Operate cond;
        cond = infExecute.Cond;
        State then;
        then = infExecute.Then;

        this.ExecuteOperate(cond);

        long index;
        index = this.InfIndex;

        this.InfIndex = index + 1;

        this.Ope(this.Kind.InfStart, this.IntArg(this.ArgA, index), null);

        this.ExecuteState(then);

        this.Ope(this.Kind.InfEnd, this.IntArg(this.ArgA, index), null);
        return true;
    }

    public override bool ExecuteWhileExecute(WhileExecute whileExecute)
    {
        Operate cond;
        cond = whileExecute.Cond;
        State loop;
        loop = whileExecute.Loop;

        long index;
        index = this.WhileIndex;

        this.WhileIndex = index + 1;

        this.Ope(this.Kind.WhileStart, this.IntArg(this.ArgA, index), null);

        this.ExecuteOperate(cond);

        this.Ope(this.Kind.While, this.IntArg(this.ArgA, index), null);

        this.ExecuteState(loop);

        this.Ope(this.Kind.WhileEnd, this.IntArg(this.ArgA, index), null);
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

        this.Ope(this.Kind.ItemGet, this.IntArg(this.ArgA, kk), null);
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

        this.Ope(this.Kind.Set, this.IntArg(this.ArgA, kk), null);
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

        this.Ope(this.Kind.Call, this.IntArg(this.ArgA, kk), this.IntArg(this.ArgB, k));
        return true;
    }

    public override bool ExecuteVarOperate(VarOperate varOperate)
    {
        Var varVar;
        varVar = this.Info(varOperate).Var;

        this.Ope(this.Kind.Var, this.IntArg(this.ArgA, varVar.Index), null);
        return true;
    }

    public override bool ExecuteVarMark(VarMark varMark)
    {
        Var varVar;
        varVar = this.Info(varMark).Var;

        this.Ope(this.Kind.VarMark, this.IntArg(this.ArgA, varVar.Index), null);
        return true;
    }

    public override bool ExecuteNewOperate(NewOperate newOperate)
    {
        ClassClass ka;
        ka = this.Info(newOperate).OperateClass;

        long k;
        k = this.State.ClassIndex(ka);

        this.Ope(this.Kind.New, this.IntArg(this.ArgA, k), null);
        return true;
    }

    public override bool ExecuteShareOperate(ShareOperate shareOperate)
    {
        ClassClass ka;
        ka = this.Info(shareOperate).OperateClass;

        long k;
        k = this.State.ClassIndex(ka);

        this.Ope(this.Kind.Share, this.IntArg(this.ArgA, k), null);
        return true;
    }

    public override bool ExecuteCastOperate(CastOperate castOperate)
    {
        ClassClass ka;
        ka = this.Info(castOperate).OperateClass;

        long k;
        k = this.State.ClassIndex(ka);

        this.Ope(this.Kind.Cast, this.IntArg(this.ArgA, k), null);
        return true;
    }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        this.Ope(this.Kind.ItemThis, null, null);
        return true;
    }

    public override bool ExecuteBaseOperate(BaseOperate baseOperate)
    {
        this.Ope(this.Kind.Base, null, null);
        return true;
    }

    public override bool ExecuteNullOperate(NullOperate nullOperate)
    {
        this.Ope(this.Kind.Null, null, null);
        return true;
    }

    public override bool ExecuteSameOperate(SameOperate sameOperate)
    {
        base.ExecuteSameOperate(sameOperate);

        this.Ope(this.Kind.Same, null, null);
        return true;
    }

    public override bool ExecuteLessOperate(LessOperate lessOperate)
    {
        base.ExecuteLessOperate(lessOperate);

        this.Ope(this.Kind.Less, null, null);
        return true;
    }

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        base.ExecuteAndOperate(andOperate);

        this.Ope(this.Kind.And, null, null);
        return true;
    }

    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        base.ExecuteOrnOperate(ornOperate);

        this.Ope(this.Kind.Orn, null, null);
        return true;
    }

    public override bool ExecuteNotOperate(NotOperate notOperate)
    {
        base.ExecuteNotOperate(notOperate);

        this.Ope(this.Kind.Not, null, null);
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        base.ExecuteAddOperate(addOperate);

        this.Ope(this.Kind.Add, null, null);
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        base.ExecuteSubOperate(subOperate);

        this.Ope(this.Kind.Sub, null, null);
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        base.ExecuteMulOperate(mulOperate);

        this.Ope(this.Kind.Mul, null, null);
        return true;
    }

    public override bool ExecuteDivOperate(DivOperate divOperate)
    {
        base.ExecuteDivOperate(divOperate);

        this.Ope(this.Kind.Div, null, null);
        return true;
    }

    public override bool ExecuteSignLessOperate(SignLessOperate signLessOperate)
    {
        base.ExecuteSignLessOperate(signLessOperate);

        this.Ope(this.Kind.SignLess, null, null);
        return true;
    }

    public override bool ExecuteSignMulOperate(SignMulOperate signMulOperate)
    {
        base.ExecuteSignMulOperate(signMulOperate);

        this.Ope(this.Kind.SignMul, null, null);
        return true;
    }

    public override bool ExecuteSignDivOperate(SignDivOperate signDivOperate)
    {
        base.ExecuteSignDivOperate(signDivOperate);

        this.Ope(this.Kind.SignDiv, null, null);
        return true;
    }

    public override bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        base.ExecuteBitAndOperate(bitAndOperate);

        this.Ope(this.Kind.BitAnd, null, null);
        return true;
    }

    public override bool ExecuteBitOrnOperate(BitOrnOperate bitOrnOperate)
    {
        base.ExecuteBitOrnOperate(bitOrnOperate);

        this.Ope(this.Kind.BitOrn, null, null);
        return true;
    }

    public override bool ExecuteBitNotOperate(BitNotOperate bitNotOperate)
    {
        base.ExecuteBitNotOperate(bitNotOperate);

        this.Ope(this.Kind.BitNot, null, null);
        return true;
    }

    public override bool ExecuteBitLiteOperate(BitLiteOperate bitLiteOperate)
    {
        base.ExecuteBitLiteOperate(bitLiteOperate);

        this.Ope(this.Kind.BitLite, null, null);
        return true;
    }

    public override bool ExecuteBitRiteOperate(BitRiteOperate bitRiteOperate)
    {
        base.ExecuteBitRiteOperate(bitRiteOperate);

        this.Ope(this.Kind.BitRite, null, null);
        return true;
    }

    public override bool ExecuteBitSignRiteOperate(BitSignRiteOperate bitSignRiteOperate)
    {
        base.ExecuteBitSignRiteOperate(bitSignRiteOperate);

        this.Ope(this.Kind.BitSignRite, null, null);
        return true;
    }

    public override bool ExecuteBoolValue(BoolValue boolValue)
    {
        this.Ope(this.Kind.BoolValue, this.BoolArg(this.ArgA, boolValue.Value), null);
        return true;
    }

    public override bool ExecuteIntValue(IntValue intValue)
    {
        this.IntValueOpe(intValue.Value);
        return true;
    }

    public override bool ExecuteIntSignValue(IntSignValue intSignValue)
    {
        this.IntValueOpe(intSignValue.Value);
        return true;
    }

    public override bool ExecuteIntHexValue(IntHexValue intHexValue)
    {
        this.IntValueOpe(intHexValue.Value);
        return true;
    }

    public override bool ExecuteIntHexSignValue(IntHexSignValue intHexSignValue)
    {
        this.IntValueOpe(intHexSignValue.Value);
        return true;
    }

    public override bool ExecuteStringValue(StringValue stringValue)
    {
        this.Ope(this.Kind.StringValue, this.StringArg(this.ArgA, stringValue.Value), null);
        return true;
    }

    protected virtual bool IntValueOpe(long value)
    {
        this.Ope(this.Kind.IntValue, this.IntArg(this.ArgA, value), null);
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

    protected virtual bool Ope(BinaryOperateKind kind, BinaryOperateArg argA, BinaryOperateArg argB)
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