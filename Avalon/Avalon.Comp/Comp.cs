namespace Avalon.Comp;

public class Comp : Any
{
    public override bool Init()
    {
        base.Init();
        this.ChangeEvent = this.CreateChangeEvent();
        this.ChangeArg = this.CreateChangeArg();
        return true;
    }

    protected virtual Change CreateChangeArg()
    {
        Change a;
        a = new Change();
        a.Init();
        return a;
    }

    protected virtual EventEvent CreateChangeEvent()
    {
        EventEvent a;
        a = new EventEvent();
        a.Init();
        return a;
    }

    public virtual bool Change(Field varField, Change change)
    {
        return true;
    }

    protected virtual bool Event(Field varField)
    {
        this.ChangeArg.Comp = this;
        this.ChangeArg.Field = varField;
        this.ChangeEvent.Execute(this.ChangeArg);
        return true;
    }

    public virtual Change ChangeArg { get; set; }
    public virtual EventEvent ChangeEvent { get; set; }
}