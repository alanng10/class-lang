namespace Avalon.View;

public class GridPos : Comp
{
    public override bool Init()
    {
        base.Init();
        this.ColField = this.CreateColField();
        this.RowField = this.CreateRowField();
        return true;
    }

    protected virtual Field CreateRowField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateColField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    public virtual Field RowField { get; set; }

    public virtual int Row
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

    public virtual Field ColField { get; set; }

    public virtual int Col
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

    public override bool Change(Field field, Change change)
    {
        if (this.RowField == field)
        {
            this.ChangeRow(change);
        }
        if (this.ColField == field)
        {
            this.ChangeCol(change);
        }
        return true;
    }
}