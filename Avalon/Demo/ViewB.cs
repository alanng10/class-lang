namespace Demo;

class ViewB : View
{
    public override bool Init()
    {
        base.Init();
        this.DrawComp = DrawCompList.This;
        return true;
    }

    public virtual DrawImage DrawImage { get; set; }
    public virtual DrawRect SourceRect { get; set; }
    public virtual DrawForm Form { get; set; }
    public virtual DrawImage ThreadDrawImage { get; set; }
    public virtual DrawRect DestRectA { get; set; }
    public virtual DrawRect SourceRectA { get; set; }

    protected virtual DrawCompList DrawComp { get; set; }

    protected override bool ExecuteDrawThis(DrawDraw draw)
    {
        long left;
        left = this.Pos.Col;
        long up;
        up = this.Pos.Row;
        long wed;
        wed = this.Size.Wed;
        long height;
        height = this.Size.Het;

        DrawRect rect;
        rect = this.DrawRectA;
        rect.Pos.Col = this.MathInt(left);
        rect.Pos.Row = this.MathInt(up);
        rect.Size.Wed = this.MathInt(wed);
        rect.Size.Het = this.MathInt(height);

        DrawRect sourceRect;
        sourceRect = this.SourceRect;

        long angle;
        angle = this.MathInt(20);
    
        long horizScale;
        horizScale = this.MathValue(3, -1);

        long vertScale;
        vertScale = this.MathInt(1);

        this.Form.Reset();

        this.Form.Rotate(angle);

        this.Form.Scale(horizScale, vertScale);

        draw.Form = this.Form;
        draw.FormSet();

        draw.ExecuteImage(this.DrawImage, rect, sourceRect);

        draw.Form = null;
        draw.FormSet();

        this.DestRectA.Pos.Col = this.MathInt(left);
        this.DestRectA.Pos.Row = this.MathInt(up + 150);

        draw.Comp = this.DrawComp.SourceOver;

        draw.ExecuteImage(this.ThreadDrawImage, this.DestRectA, this.SourceRectA);

        draw.Comp = null;
        return true;
    }
}