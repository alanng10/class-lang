namespace Avalon.Comp;

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
    public virtual Change SetChangeArg { get; set; }
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
            this.Value.ChangeEvent.State.RemoveState(this.State);
        }

        this.Value = value;

        if (!(this.Value == null))
        {
            this.Value.ChangeEvent.State.AddState(this.State);
        }

        this.SetChange();
        return true;
    }

    public virtual bool GetBool()
    {
        return this.ValueAny.Bool;
    }

    public virtual bool SetBool(bool value)
    {
        this.ValueAny.Bool = value;
        this.SetChange();
        return true;
    }

    public virtual int GetMid()
    {
        return this.ValueAny.Mid;
    }

    public virtual bool SetMid(int value)
    {
        this.ValueAny.Mid = value;
        this.SetChange();
        return true;
    }

    public virtual long GetLong()
    {
        return this.ValueAny.Int;
    }

    public virtual bool SetLong(long value)
    {
        this.ValueAny.Int = value;
        this.SetChange();
        return true;
    }

    public virtual object GetAny()
    {
        return this.ValueAny.Any;
    }

    public virtual bool SetAny(object value)
    {
        this.ValueAny.Any = value;
        this.SetChange();
        return true;
    }

    protected virtual bool SetChange()
    {
        this.Comp.Change(this, this.SetChangeArg);
        return true;
    }
}