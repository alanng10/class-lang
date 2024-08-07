namespace Avalon.Console;

public class StringOut : Out
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.Sj = new StringJoin();
        this.Sj.Init();
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    private StringJoin Sj { get; set; }

    public override bool Write(string o)
    {
        this.InfraInfra.StringJoinString(this.Sj, o);
        return true;
    }

    public virtual bool Clear()
    {
        this.Sj.Clear();
        return true;
    }

    public virtual string Result()
    {
        return this.Sj.Result();
    }
}