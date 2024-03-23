namespace Class.Refer;

public class Write : Any
{
    public override bool Init()
    {
        base.Init();
        this.CountOperate = new CountWriteOperate();
        this.CountOperate.Write = this;
        this.CountOperate.Init();
        this.SetOperate = new SetWriteOperate();
        this.SetOperate.Write = this;
        this.SetOperate.Init();
        return true;
    }

    public virtual Refer Refer { get; set; }
    public virtual Data Data { get; set; }
    public virtual int Index { get; set; }

    protected virtual CountWriteOperate CountOperate { get; set; }
    protected virtual SetWriteOperate SetOperate { get; set; }
    protected virtual WriteOperate Operate { get; set; }

    public virtual bool Execute()
    {
        this.Operate = this.CountOperate;
        this.Index = 0;

        this.ExecuteStage();

        int count;
        count = this.Index;
        this.Data = new Data();
        this.Data.Count = count;
        this.Data.Init();

        this.Operate = this.SetOperate;
        this.Index = 0;

        this.ExecuteStage();

        this.Operate = null;
        this.Index = 0;

        return true;
    }

    protected virtual bool ExecuteStage()
    {
        return true;
    }


    protected virtual bool ExecuteInt(long value)
    {
        

        return true;
    }

    protected virtual bool ExecuteByte(int value)
    {
        this.Operate.Execute(value);
        return true;
    }
}