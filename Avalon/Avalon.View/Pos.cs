namespace Avalon.View;

public class Pos : Comp
{
    public override bool Init()
    {
        base.Init();
        this.ColField = this.CreateColField();
        this.RowField = this.CreateRowField();
        return true;
    }

    protected virtual Field CreateColField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateRowField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    public override bool Change(Field varField, Change change)
    {
        if (this.ColField == varField)
        {
            this.ChangeCol(change);
        }
        if (this.RowField == varField)
        {
            this.ChangeRow(change);
        }
        return true;
    }

    public virtual Field ColField { get; set; }

    public virtual long Col
    {
        get
        {
            return this.ColField.GetInt();
        }

        set
        {
            this.ColField.SetInt(value);
        }
    }

    protected virtual bool ChangeCol(Change change)
    {
        this.Event(this.ColField);
        return true;
    }

    public virtual Field RowField { get; set; }

    public virtual long Row
    {
        get
        {
            return this.RowField.GetInt();
        }

        set
        {
            this.RowField.SetInt(value);
        }
    }

    protected virtual bool ChangeRow(Change change)
    {
        this.Event(this.RowField);
        return true;
    }
}