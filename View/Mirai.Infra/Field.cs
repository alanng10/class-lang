namespace Mirai.Infra;

public class Field : Any
{
    public override bool Init()
    {
        base.Init();
        this.ValueAny = new InfraValue();
        this.ValueAny.Init();
        return true;
    }

    public virtual Comp Comp { get; set; }
    public virtual FieldState State { get; set; }
    public virtual Mod SetModArg { get; set; }
    protected virtual Comp Value { get; set; }
    protected virtual InfraValue ValueAny { get; set; }

    public virtual Comp Get()
    {
        return this.Value;
    }

    public virtual bool Set(Comp value)
    {
        if (!(this.Value == null))
        {
            this.Value.ModEvent.State.RemState(this.State);
        }

        this.Value = value;

        if (!(this.Value == null))
        {
            this.Value.ModEvent.State.AddState(this.State);
        }

        this.SetMod();
        return true;
    }

    public virtual bool GetBool()
    {
        return this.ValueAny.Bool;
    }

    public virtual bool SetBool(bool value)
    {
        this.ValueAny.Bool = value;
        this.SetMod();
        return true;
    }

    public virtual long GetInt()
    {
        return this.ValueAny.Int;
    }

    public virtual bool SetInt(long value)
    {
        this.ValueAny.Int = value;
        this.SetMod();
        return true;
    }

    public virtual object GetAny()
    {
        return this.ValueAny.Any;
    }

    public virtual bool SetAny(object value)
    {
        this.ValueAny.Any = value;
        this.SetMod();
        return true;
    }

    protected virtual bool SetMod()
    {
        this.Comp.Mod(this, this.SetModArg);
        return true;
    }
}