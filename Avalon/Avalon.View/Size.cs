namespace Avalon.View;

public class Size : Comp
{
    public override bool Init()
    {
        base.Init();
        this.WidthField = this.CreateWidthField();
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
        if (this.WidthField == varField)
        {
            this.ChangeWidth(change);
        }
        if (this.HeightField == varField)
        {
            this.ChangeHeight(change);
        }
        return true;
    }

    public virtual Field WidthField { get; set; }

    public virtual int Width
    {
        get
        {
            return this.WidthField.GetMid();
        }

        set
        {
            this.WidthField.SetMid(value);
        }
    }

    protected virtual bool ChangeWidth(Change change)
    {
        this.Event(this.WidthField);
        return true;
    }

    public virtual Field HeightField { get; set; }

    public virtual int Height
    {
        get
        {
            return this.HeightField.GetMid();
        }

        set
        {
            this.HeightField.SetMid(value);
        }
    }

    protected virtual bool ChangeHeight(Change change)
    {
        this.Event(this.HeightField);
        return true;
    }
}