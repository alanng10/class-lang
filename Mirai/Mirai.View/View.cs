namespace Mirai.View;

public class View : Comp
{
    public override bool Init()
    {
        base.Init();
        this.DrawInfra = DrawInfra.This;

        this.PosField = this.CreatePosField();
        this.SizeField = this.CreateSizeField();
        this.BackField = this.CreateBackField();
        this.VisibleField = this.CreateVisibleField();
        this.ChildField = this.CreateChildField();

        this.Pos = this.CreatePos();
        this.Size = this.CreateSize();
        this.Back = this.CreateBack();
        this.Visible = true;

        this.Area = this.CreateArea();

        this.DrawRectA = this.CreateDrawRect();
        this.DrawRectB = this.CreateDrawRect();
        this.DrawRectC = this.CreateDrawRect();
        this.DrawRectD = this.CreateDrawRect();

        this.DrawPosA = this.CreateDrawPos();

        this.StackRect = this.CreateStackRect();
        this.StackPos = this.CreateStackPos();
        return true;
    }

    public virtual DrawRect Area { get; set; }

    protected virtual DrawInfra DrawInfra { get; set; }
    protected virtual DrawRect DrawRectA { get; set; }
    protected virtual DrawRect DrawRectB { get; set; }
    protected virtual DrawRect DrawRectC { get; set; }
    protected virtual DrawRect DrawRectD { get; set; }
    protected virtual DrawPos DrawPosA { get; set; }
    protected virtual DrawRect StackRect { get; set; }
    protected virtual DrawPos StackPos { get; set; }

    protected virtual Field CreatePosField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateSizeField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateBackField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateVisibleField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateChildField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Pos CreatePos()
    {
        Pos a;
        a = new Pos();
        a.Init();
        a.Left = 0;
        a.Up = 0;
        return a;
    }

    protected virtual Size CreateSize()
    {
        Size a;
        a = new Size();
        a.Init();
        a.Width = 0;
        a.Height = 0;
        return a;
    }

    protected virtual DrawBrush CreateBack()
    {
        DrawBrush a;
        a = this.DrawInfra.WhiteBrush;
        return a;
    }

    protected virtual DrawRect CreateArea()
    {
        DrawRect rect;
        rect = this.DrawInfra.RectCreate(0, 0, 0, 0);
        return rect;
    }

    protected virtual DrawRect CreateDrawRect()
    {
        DrawRect rect;
        rect = this.DrawInfra.RectCreate(0, 0, 0, 0);
        return rect;
    }

    protected virtual DrawPos CreateDrawPos()
    {
        DrawPos pos;
        pos = this.DrawInfra.PosCreate(0, 0);
        return pos;
    }

    protected virtual DrawRect CreateStackRect()
    {
        DrawRect rect;
        rect = this.DrawInfra.RectCreate(0, 0, 0, 0);
        return rect;
    }

    protected virtual DrawPos CreateStackPos()
    {
        DrawPos pos;
        pos = this.DrawInfra.PosCreate(0, 0);
        return pos;
    }

    public virtual Field PosField { get; set; }

    public virtual Pos Pos
    {
        get
        {
            return (Pos)this.PosField.Get();
        }
        set
        {
            this.PosField.Set(value);
        }
    }

    protected virtual bool ModPos(Mod mod)
    {
        this.Event(this.PosField);
        return true;
    }

    public virtual Field SizeField { get; set; }

    public virtual Size Size
    {
        get
        {
            return (Size)this.SizeField.Get();
        }
        set
        {
            this.SizeField.Set(value);
        }
    }

    protected virtual bool ModSize(Mod mod)
    {
        this.Event(this.SizeField);
        return true;
    }

    public virtual Field BackField { get; set; }

    public virtual DrawBrush Back
    {
        get
        {
            return (DrawBrush)this.BackField.GetAny();
        }
        set
        {
            this.BackField.SetAny(value);
        }
    }

    protected virtual bool ModBack(Mod mod)
    {
        this.Event(this.BackField);
        return true;
    }

    public virtual Field VisibleField { get; set; }

    public virtual bool Visible
    {
        get
        {
            return this.VisibleField.GetBool();
        }
        set
        {
            this.VisibleField.SetBool(value);
        }
    }

    protected virtual bool ModVisible(Mod mod)
    {
        this.Event(this.VisibleField);
        return true;
    }

    public virtual Field ChildField { get; set; }

    public virtual View Child
    {
        get
        {
            return (View)this.ChildField.Get();
        }
        set
        {
            this.ChildField.Set(value);
        }
    }

    protected virtual bool ModChild(Mod mod)
    {
        this.Event(this.ChildField);
        return true;
    }

    public override bool Mod(Field field, Mod mod)
    {
        if (this.SizeField == field)
        {
            this.ModSize(mod);
        }
        if (this.PosField == field)
        {
            this.ModPos(mod);
        }
        if (this.BackField == field)
        {
            this.ModBack(mod);
        }
        if (this.VisibleField == field)
        {
            this.ModVisible(mod);
        }
        if (this.ChildField == field)
        {
            this.ModChild(mod);
        }
        return true;
    }

    protected virtual bool CheckDraw()
    {
        return this.Visible;
    }

    public virtual bool ExecuteDraw(DrawDraw draw)
    {
        this.ViewInfra.AssignDrawRectValue(this.Area, draw.Area);

        if (!this.CheckDraw())
        {
            return true;
        }

        this.ExecuteDrawThis(draw);

        if (!this.ValidDrawChild())
        {
            return true;
        }

        this.ExecuteDrawChild(draw);
        return true;
    }

    protected virtual bool ExecuteDrawThis(DrawDraw draw)
    {
        long left;
        long up;
        left = this.Pos.Col;
        up = this.Pos.Row;
        long width;
        long height;
        width = this.Size.Wed;
        height = this.Size.Het;

        this.DrawRectA.Pos.Col = left;
        this.DrawRectA.Pos.Row = up;
        this.DrawRectA.Size.Wed = width;
        this.DrawRectA.Size.Het = height;

        DrawRect rect;
        rect = this.DrawRectA;
        DrawBrush brush;
        brush = this.Back;
        draw.Fill = brush;

        draw.FillPos.Col = left;
        draw.FillPos.Row = up;
        draw.FillPosSet();

        draw.ExecuteRect(rect);

        draw.FillPos.Col = 0;
        draw.FillPos.Row = 0;
        draw.FillPosSet();

        draw.Fill = null;
        return true;
    }

    protected virtual bool ValidDrawChild()
    {
        return !(this.Child == null);
    }

    protected virtual bool ExecuteDrawChild(DrawDraw draw)
    {
        long left;
        long up;
        left = this.Pos.Col;
        left = left + draw.Pos.Col;
        up = this.Pos.Row;
        up = up + draw.Pos.Row;

        long width;
        long height;
        width = this.Size.Wed;
        height = this.Size.Het;

        this.DrawRectA.Pos.Col = left;
        this.DrawRectA.Pos.Row = up;
        this.DrawRectA.Size.Wed = width;
        this.DrawRectA.Size.Het = height;

        this.SetChildArea(this.DrawRectA);

        this.ViewInfra.StackPushChild(draw, this.StackRect, this.StackPos, this.DrawRectA, this.DrawPosA);

        this.ExecuteChildDraw(draw);

        this.ViewInfra.StackPopChild(draw, this.StackRect, this.StackPos);
        return true;
    }

    protected virtual bool SetChildArea(DrawRect thisRect)
    {
        return true;
    }

    protected virtual bool ExecuteChildDraw(DrawDraw draw)
    {
        this.Child.ExecuteDraw(draw);
        return true;
    }
}