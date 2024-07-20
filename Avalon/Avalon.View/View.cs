namespace Avalon.View;

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

    protected virtual bool ChangePos(Change change)
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

    protected virtual bool ChangeSize(Change change)
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

    protected virtual bool ChangeBack(Change change)
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

    protected virtual bool ChangeVisible(Change change)
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

    protected virtual bool ChangeChild(Change change)
    {
        this.Event(this.ChildField);
        return true;
    }

    public override bool Change(Field field, Change change)
    {
        if (this.SizeField == field)
        {
            this.ChangeSize(change);
        }
        if (this.PosField == field)
        {
            this.ChangePos(change);
        }
        if (this.BackField == field)
        {
            this.ChangeBack(change);
        }
        if (this.VisibleField == field)
        {
            this.ChangeVisible(change);
        }
        if (this.ChildField == field)
        {
            this.ChangeChild(change);
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

        if (!this.CheckDrawChild())
        {
            return true;
        }

        this.ExecuteDrawChild(draw);
        return true;
    }

    protected virtual bool ExecuteDrawThis(DrawDraw draw)
    {
        int left;
        left = this.Pos.Left;
        int up;
        up = this.Pos.Up;
        int width;
        width = this.Size.Width;
        int height;
        height = this.Size.Height;

        this.DrawRectA.Pos.Left = left;
        this.DrawRectA.Pos.Up = up;
        this.DrawRectA.Size.Width = width;
        this.DrawRectA.Size.Height = height;

        DrawRect rect;
        rect = this.DrawRectA;
        DrawBrush brush;
        brush = this.Back;
        draw.Brush = brush;
        
        draw.FillPos.Left = left;
        draw.FillPos.Up = up;
        draw.FillPosSet();

        draw.ExecuteRect(rect);
        
        draw.FillPos.Left = 0;
        draw.FillPos.Up = 0;
        draw.FillPosSet();

        draw.Brush = null;
        return true;
    }

    protected virtual bool CheckDrawChild()
    {
        return !(this.Child == null);
    }

    protected virtual bool ExecuteDrawChild(DrawDraw draw)
    {
        int left;        
        left = this.Pos.Left;
        left = left + draw.Pos.Left;
        int up;
        up = this.Pos.Up;
        up = up + draw.Pos.Up;

        int width;
        width = this.Size.Width;
        int height;
        height = this.Size.Height;

        this.DrawRectA.Pos.Left = left;
        this.DrawRectA.Pos.Up = up;
        this.DrawRectA.Size.Width = width;
        this.DrawRectA.Size.Height = height;

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