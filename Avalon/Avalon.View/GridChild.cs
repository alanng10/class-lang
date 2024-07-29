namespace Avalon.View;

public class GridChild : Comp
{
    public override bool Init()
    {
        base.Init();
        this.ViewField = this.CreateViewField();
        this.RectField = this.CreateRectField();
        this.Rect = this.CreateRect();
        return true;
    }

    protected virtual Field CreateViewField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateRectField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Rect CreateRect()
    {
        Rect a;
        a = new Rect();
        a.Init();
        return a;
    }

    public virtual Field ViewField { get; set; }

    public virtual View View
    {
        get
        {
            return (View)this.ViewField.Get();
        }
        set
        {
            this.ViewField.Set(value);
        }
    }

    protected virtual bool ChangeView(Change change)
    {
        this.Event(this.ViewField);
        return true;
    }

    public virtual Field RectField { get; set; }

    public virtual Rect Rect
    {
        get
        {
            return (Rect)this.RectField.Get();
        }
        set
        {
            this.RectField.Set(value);
        }
    }

    protected virtual bool ChangeRect(Change change)
    {
        this.Event(this.RectField);
        return true;
    }

    public override bool Change(Field varField, Change change)
    {
        if (this.ViewField == varField)
        {
            this.ChangeView(change);
        }
        if (this.RectField == varField)
        {
            this.ChangeRect(change);
        }
        return true;
    }
}