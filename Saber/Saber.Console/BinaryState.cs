namespace Saber.Console;

public class BinaryState : Any
{
    public override bool Init()
    {
        base.Init();
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

    public virtual bool ExecuteByte(long value)
    {
        return true;
    }
}