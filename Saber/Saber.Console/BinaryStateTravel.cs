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

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        this.Op(this.Kind.ItemThis, null, null);
        return true;
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
}