namespace Avalon.Console;

public class StringOut : Out
{
    public override bool Init()
    {
        base.Init();
        this.Sb = new StringBuilder();
        return true;
    }

    private StringBuilder Sb { get; set; }

    public override bool Write(string o)
    {
        this.Sb.Append(o);
        return true;
    }

    public virtual bool Clear()
    {
        this.Sb.Clear();
        return true;
    }

    public virtual string Result()
    {
        return this.Sb.ToString();
    }
}