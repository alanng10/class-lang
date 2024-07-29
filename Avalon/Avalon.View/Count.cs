namespace Avalon.View;

public class Count : Comp
{
    public override bool Init()
    {
        base.Init();
        this.ValueField = this.CreateValueField();
        this.Value = 0;
        return true;
    }

    protected virtual Field CreateValueField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    public virtual Field ValueField { get; set; }

    public virtual int Value
    {
        get
        {
            return this.ValueField.GetMid();
        }

        set
        {
            this.ValueField.SetMid(value);
        }
    }

    protected virtual bool ChangeValue(Change change)
    {
        this.Event(this.ValueField);
        return true;
    }

    public override bool Change(Field varField, Change change)
    {
        if (this.ValueField == varField)
        {
            this.ChangeValue(change);
        }
        return true;
    }
}