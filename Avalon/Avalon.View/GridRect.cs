namespace Avalon.View;

public class GridRect : Comp
{
    public override bool Init()
    {
        base.Init();
        this.PosField = this.CreatePosField();
        this.SizeField = this.CreateSizeField();
        this.Pos = this.CreatePos();
        this.Size = this.CreateSize();
        return true;
    }

    protected virtual Field CreatePosField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateSizeField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual GridPos CreatePos()
    {
        GridPos a;
        a = new GridPos();
        a.Init();
        return a;
    }

    protected virtual GridSize CreateSize()
    {
        GridSize a;
        a = new GridSize();
        a.Init();
        return a;
    }

    public virtual Field PosField { get; set; }

    public virtual GridPos Pos
    {
        get
        {
            return (GridPos)this.PosField.Get();
        }

        set
        {
            this.PosField.Set(value);
        }
    }

    protected virtual bool ChangePos(Change change)
    {
        this.Event(this.PosField);
        return true;
    }

    public virtual Field SizeField { get; set; }

    public virtual GridSize Size
    {
        get
        {
            return (GridSize)this.SizeField.Get();
        }

        set
        {
            this.SizeField.Set(value);
        }
    }

    protected virtual bool ChangeSize(Change change)
    {
        this.Event(this.SizeField);
        return true;
    }

    public override bool Change(Field field, Change change)
    {
        if (this.PosField == field)
        {
            this.ChangePos(change);
        }
        if (this.SizeField == field)
        {
            this.ChangeSize(change);
        }
        return true;
    }
}