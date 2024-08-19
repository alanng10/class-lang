namespace Avalon.View;

public class Size : Comp
{
    public override bool Init()
    {
        base.Init();
        this.WedField = this.CreateWidthField();
        this.HeightField = this.CreateHeightField();
        return true;
    }

    protected virtual Field CreateWidthField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateHeightField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    public override bool Change(Field varField, Change change)
    {
        if (this.WedField == varField)
        {
            this.ChangeWidth(change);
        }
        if (this.HeightField == varField)
        {
            this.ChangeHeight(change);
        }
        return true;
    }

    public virtual Field WedField { get; set; }

    public virtual long Wed
    {
        get
        {
            return this.WedField.GetInt();
        }

        set
        {
            this.WedField.SetInt(value);
        }
    }

    protected virtual bool ChangeWidth(Change change)
    {
        this.Event(this.WedField);
        return true;
    }

    public virtual Field HeightField { get; set; }

    public virtual long Het
    {
        get
        {
            return this.HeightField.GetInt();
        }

        set
        {
            this.HeightField.SetInt(value);
        }
    }

    protected virtual bool ChangeHeight(Change change)
    {
        this.Event(this.HeightField);
        return true;
    }
}