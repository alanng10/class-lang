namespace Avalon.Console;

public class StringOut : Out
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.StringAdd = new StringAdd();
        this.StringAdd.Init();
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    private StringAdd StringAdd { get; set; }

    public override bool Write(String o)
    {
        this.InfraInfra.AddString(this.StringAdd, o);
        return true;
    }

    public virtual bool Clear()
    {
        this.StringAdd.Clear();
        return true;
    }

    public virtual String Rest()
    {
        return this.StringAdd.Result();
    }
}