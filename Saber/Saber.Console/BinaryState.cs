namespace Saber.Console;

public class BinaryState : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;

        this.CountOperate = this.CreateCountOperate();
        this.SetOperate = this.CreateSetOperate();
        return true;
    }

    protected virtual BinaryStateCountOperate CreateCountOperate()
    {
        BinaryStateCountOperate a;
        a = new BinaryStateCountOperate();
        a.State = this;
        a.Init();
        return a;
    }

    protected virtual BinaryStateSetOperate CreateSetOperate()
    {
        BinaryStateSetOperate a;
        a = new BinaryStateSetOperate();
        a.State = this;
        a.Init();
        return a;
    }

    public virtual ClassModule Module { get; set; }
    public virtual Data Result { get; set; }
    public virtual BinaryStateArg Arg { get; set; }
    public virtual BinaryStateOperate Operate { get; set; }
    public virtual BinaryStateCountOperate CountOperate { get; set; }
    public virtual BinaryStateSetOperate SetOperate { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }

    public virtual bool Execute()
    {
        this.Arg = new BinaryStateArg();
        this.Arg.Init();

        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        long count;
        count = this.Arg.Index;
        this.Arg.Data = new Data();
        this.Arg.Data.Count = count;
        this.Arg.Data.Init();

        this.Operate = this.SetOperate;

        this.ResetStage();
        this.ExecuteStage();

        this.Result = this.Arg.Data;

        this.Operate = null;
        this.Arg = null;
        return true;
    }

    public virtual bool ResetStage()
    {
        this.Arg.Index = 0;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        return true;
    }

    public virtual bool ExecuteOperate(BinaryOperate operate)
    {
        this.ExecuteByte(operate.Kind);

        this.ExecuteOperateArg(operate.ArgA);
        this.ExecuteOperateArg(operate.ArgB);
        return true;
    }

    public virtual bool ExecuteOperateArg(BinaryOperateArg arg)
    {
        if (arg.Kind == 0)
        {
            return true;
        }

        return true;
    }

    protected virtual bool ExecuteInt(long value)
    {
        return this.ExecuteIntCount(value, sizeof(long));
    }

    protected virtual bool ExecuteIntCount(long value, long count)
    {
        long k;
        k = value;
        k = k & (this.InfraInfra.IntCapValue - 1);

        long i;
        i = 0;
        while (i < count)
        {
            int shift;
            shift = (int)(i * 8);

            long ka;
            ka = (k >> shift) & 0xff;

            this.ExecuteByte(ka);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteByte(long value)
    {
        this.Operate.ExecuteByte(value);
        return true;
    }
}