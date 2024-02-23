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

    protected virtual GridRect CreateRect()
    {
        GridRect a;
        a = new GridRect();
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
        this.Trigger(this.ViewField);
        return true;
    }

    public virtual Field RectField { get; set; }

    public virtual GridRect Rect
    {
        get
        {
            return (GridRect)this.RectField.Get();
        }
        set
        {
            this.RectField.Set(value);
        }
    }

    protected virtual bool ChangeRect(Change change)
    {
        this.Trigger(this.RectField);
        return true;
    }

    public override bool Change(Field field, Change change)
    {
        if (this.ViewField == field)
        {
            this.ChangeView(change);
        }
        if (this.RectField == field)
        {
            this.ChangeRect(change);
        }
        return true;
    }
}