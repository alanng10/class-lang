namespace Avalon.Comp;

public class Comp : Any
{
    public override bool Init()
    {
        base.Init();
        this.ModEvent = this.CreateModEvent();
        this.ModArg = this.CreateModArg();
        return true;
    }

    protected virtual EventEvent CreateModEvent()
    {
        EventEvent a;
        a = new EventEvent();
        a.Init();
        return a;
    }

    protected virtual Mod CreateModArg()
    {
        Mod a;
        a = new Mod();
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