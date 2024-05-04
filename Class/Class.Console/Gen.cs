namespace Class.Console;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.CountOperate = new CountGenOperate();
        this.CountOperate.Gen = this;
        this.CountOperate.Init();
        return true;
    }

    public virtual Data Data { get; set; }
    public virtual GenArg Arg { get; set; }
    protected GenOperate Operate { get; set; }
    protected CountGenOperate CountOperate { get; set; }
    protected SetGenOperate SetOperate { get; set; }

    public virtual bool Execute()
    {
        this.Arg = new GenArg();
        this.Arg.Init();

        this.ExecuteStage();

        this.ExecuteStage();

        this.Data = this.Arg.Data;
        this.Arg = null;
        return true;
    }

    protected virtual bool ExecuteStage()
    {
        return true;
    }
}