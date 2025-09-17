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

    public override bool ExecuteVarOperate(VarOperate varOperate)
    {
        Var varVar;
        varVar = this.Info(varOperate).Var;

        this.Op(this.Kind.Var, this.IntArg(this.ArgA, varVar.Index), null);
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

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        base.ExecuteAndOperate(andOperate);

        this.Op(this.Kind.And, null, null);
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

    protected BinaryOperateArg IntArg(BinaryOperateArg arg, long value)
    {
        arg.Kind = 2;
        arg.Bool = false;
        arg.Int = value;
        arg.String = null;
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