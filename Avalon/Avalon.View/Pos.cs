namespace Avalon.View;

public class Pos : Comp
{
    public override bool Init()
    {
        base.Init();
        this.LeftField = this.CreateLeftField();
        this.UpField = this.CreateUpField();
        return true;
    }

    protected virtual Field CreateLeftField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateUpField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    public override bool Change(Field varField, Change change)
    {
        if (this.LeftField == varField)
        {
            this.ChangeLeft(change);
        }
        if (this.UpField == varField)
        {
            this.ChangeUp(change);
        }
        return true;
    }

    public virtual Field LeftField { get; set; }

    public virtual int Left
    {
        get
        {
            return this.LeftField.GetMid();
        }

        set
        {
            this.LeftField.SetMid(value);
        }
    }

    protected virtual bool ChangeLeft(Change change)
    {
        this.Event(this.LeftField);
        return true;
    }

    public virtual Field UpField { get; set; }

    public virtual int Up
    {
        get
        {
            return this.UpField.GetMid();
        }

        set
        {
            this.UpField.SetMid(value);
        }
    }

    protected virtual bool ChangeUp(Change change)
    {
        this.Event(this.UpField);
        return true;
    }
}