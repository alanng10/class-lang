namespace Saber.Console;

public class BinaryStateTravel : Travel
{
    public override bool Init()
    {
        base.Init();
        this.Kind = BinaryOperateKindList.This;

        this.NullArg = this.CreateNullArg();
        return true;
    }

    protected BinaryOperateArg CreateNullArg()
    {
        BinaryOperateArg a;
        a = new BinaryOperateArg();
        a.Init();
        a.Kind = 0;
        return a;
    }

    public virtual BinaryState State { get; set; }
    protected virtual BinaryOperateKindList Kind { get; set; }
    protected virtual BinaryOperateArg NullArg { get; set; }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        this.Op(this.Kind.ItemThis, null, null);
        return true;
    }

    protected virtual bool Op(BinaryOperateKind kind, BinaryOperateArg argA, BinaryOperateArg argB)
    {
        this.State.ExecuteOperate(null);
        return true;
    }
}