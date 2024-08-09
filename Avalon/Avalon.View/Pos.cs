namespace Avalon.View;

public class Pos : Comp
{
    public override bool Init()
    {
        base.Init();
        this.ColField = this.CreateLeftField();
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
        if (this.ColField == varField)
        {
            this.ChangeLeft(change);
        }
        if (this.UpField == varField)
        {
            this.ChangeUp(change);
        }
        return true;
    }

    public virtual Field ColField { get; set; }

    public virtual int Col
    {
        get
        {
            return this.ColField.GetMid();
        }

        set
        {
            this.ColField.SetMid(value);
        }
    }

    protected virtual bool ChangeLeft(Change change)
    {
        this.Event(this.ColField);
        return true;
    }

    public virtual Field UpField { get; set; }

    public virtual int Row
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