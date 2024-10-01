namespace Avalon.Comp;

public class Comp : Any
{
    public override bool Init()
    {
        base.Init();
        this.ModEvent = this.CreateChangeEvent();
        this.ModArg = this.CreateChangeArg();
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
        this.ModArg.Comp = this;
        this.ModArg.Field = varField;
        this.ModEvent.Execute(this.ModArg);
        return true;
    }

    public virtual Mod ModArg { get; set; }
    public virtual EventEvent ModEvent { get; set; }
}