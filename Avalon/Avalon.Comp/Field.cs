namespace Avalon.Comp;

public class Field : Any
{
    public virtual Comp Comp { get; set; }
    public virtual FieldState State { get; set; }
    public virtual Change SetChangeArg { get; set; }
    protected virtual Comp Value { get; set; }

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

    protected virtual bool BoolValue { get; set; }

    public virtual bool GetBool()
    {
        return this.BoolValue;
    }

    public virtual bool SetBool(bool value)
    {
        this.BoolValue = value;
        this.SetChange();
        return true;
    }

    protected virtual int IntValue { get; set; }

    public virtual int GetInt()
    {
        return this.IntValue;
    }

    public virtual bool SetInt(int value)
    {
        this.IntValue = value;
        this.SetChange();
        return true;
    }

    protected virtual object AnyValue { get; set; }

    public virtual object GetAny()
    {
        return this.AnyValue;
    }

    public virtual bool SetAny(object value)
    {
        this.AnyValue = value;
        this.SetChange();
        return true;
    }

    protected virtual bool SetChange()
    {
        this.Comp.Change(this, this.SetChangeArg);
        return true;
    }
}