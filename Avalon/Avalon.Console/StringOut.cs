namespace Avalon.Console;

public class StringOut : Out
{
    public override bool Init()
    {
        base.Init();
        this.Sj = new StringJoin();
        this.Sj.Init();
        return true;
    }

    private StringJoin Sj { get; set; }

    public override bool Write(string o)
    {
        this.Sj.Append(o);
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