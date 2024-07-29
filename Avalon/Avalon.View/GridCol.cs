namespace Avalon.View;

public class GridCol : Comp
{
    public override bool Init()
    {
        base.Init();
        this.WidthField = this.CreateWidthField();
        this.Width = 0;
        return true;
    }

    protected virtual Field CreateWidthField()
    {
        return this.ViewInfra.FieldCreate(this);
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

    public override bool Change(Field varField, Change change)
    {
        if (this.WidthField == varField)
        {
            this.ChangeWidth(change);
        }
        return true;
    }
}