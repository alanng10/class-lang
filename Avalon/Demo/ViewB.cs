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
        int left;
        left = this.Pos.Left;
        int up;
        up = this.Pos.Up;
        int width;
        width = this.Size.Width;
        int height;
        height = this.Size.Height;

        DrawRect rect;
        rect = this.DrawRectA;
        rect.Pos.Left = left;
        rect.Pos.Up = up;
        rect.Size.Width = width;
        rect.Size.Height = height;

        DrawRect sourceRect;
        sourceRect = this.SourceRect;

        long scaleFactor;
        scaleFactor = this.DrawInfra.ScaleFactor;

        long angle;
        angle = 20 * scaleFactor;
    
        long horizScale;
        horizScale = scaleFactor + scaleFactor / 2;

        long vertScale;
        vertScale = scaleFactor;

        this.Form.Reset();

        this.Form.Rotate(angle);

        this.Form.Scale(horizScale, vertScale);

        draw.Form = this.Form;
        draw.FormSet();

        draw.ExecuteImage(this.DrawImage, rect, sourceRect);

        draw.Form = null;
        draw.FormSet();

        this.DestRectA.Pos.Left = left;
        this.DestRectA.Pos.Up = up + 150;

        draw.Comp = this.DrawComp.SourceOver;

        draw.ExecuteImage(this.ThreadDrawImage, this.DestRectA, this.SourceRectA);

        draw.Comp = null;
        return true;
    }
}