namespace Avalon.Comp;

public class Comp : Any
{
    public override bool Init()
    {
        base.Init();
        this.ChangeArg = this.CreateChangeArg();
        this.ChangeEvent = new EventEvent();
        this.ChangeEvent.Init();
        return true;
    }

    protected virtual Change CreateChangeArg()
    {
        Change a;
        a = new Change();
        a.Init();
        return a;
    }

    public virtual bool Change(Field field, Change change)
    {
        return true;
    }

    protected virtual bool Event(Field field)
    {
        this.ChangeArg.Comp = this;
        this.ChangeArg.Field = field;
        this.ChangeEvent.Execute(this.ChangeArg);
        return true;
    }

    public virtual Change ChangeArg { get; set; }
    public virtual EventEvent ChangeEvent { get; set; }
}