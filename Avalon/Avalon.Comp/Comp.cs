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

    protected virtual Mod CreateChangeArg()
    {
        Mod a;
        a = new Mod();
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

    public virtual bool Change(Field varField, Mod change)
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

    public virtual Mod ChangeArg { get; set; }
    public virtual EventEvent ChangeEvent { get; set; }
}