namespace Avalon.View;

public class GridRow : Comp
{
    public override bool Init()
    {
        base.Init();
        this.HeightField = this.CreateHeightField();
        this.Height = 0;
        return true;
    }

    protected virtual Field CreateHeightField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    public virtual Field HeightField { get; set; }

    public virtual int Height
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

    public override bool Change(Field field, Change change)
    {
        if (this.HeightField == field)
        {
            this.ChangeHeight(change);
        }
        return true;
    }
}