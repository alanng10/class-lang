namespace Avalon.Console;

public class StringOut : Out
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.StringAdd = new StringAdd();
        this.StringAdd.Init();
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    private StringAdd StringAdd { get; set; }

    public override bool Write(String value)
    {
        this.TextInfra.AddString(this.StringAdd, value);
        return true;
    }

    public virtual bool Clear()
    {
        this.StringAdd.Clear();
        return true;
    }

    public virtual String Result()
    {
        return this.StringAdd.Result();
    }
}