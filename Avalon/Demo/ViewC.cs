namespace Demo;

class ViewC : View
{
    public override bool Init()
    {
        base.Init();
        DrawPosLong pos;
        pos = new DrawPosLong();
        pos.Init();
        DrawSizeLong size;
        size = new DrawSizeLong();
        size.Init();
        DrawRectLong rect;
        rect = new DrawRectLong();
        rect.Init();
        rect.Pos = pos;
        rect.Size = size;
        this.RectLong = rect;
        return true;
    }

    public DrawRect EllipseRect { get; set; }
    public DrawBrush EllipseBrush { get; set; }
    public DrawFont Font { get; set; }
    public DrawTextAlign TextAlign { get; set; }
    public Text Text { get; set; }
    public DrawPen TextPen { get; set; }
    private DrawRectLong RectLong { get; set; }

    protected override bool ExecuteDrawThis(DrawDraw draw)
    {
        base.ExecuteDrawThis(draw);
        this.EllipseRect.Pos.Left = this.Pos.Left + 400;
        this.EllipseRect.Pos.Up = this.Pos.Up + 20;
        
        draw.Brush = this.EllipseBrush;

        draw.ExecuteEllipse(this.EllipseRect);

        draw.Brush = null;

        long k;
        k = 1 << 20;

        DrawRectLong rect;
        rect = this.RectLong;
        rect.Pos.Left = (this.Pos.Left + 150) * k;
        rect.Pos.Up = (this.Pos.Up + 50) * k;
        rect.Size.Width = 300 * k;
        rect.Size.Height = 100 * k;

        draw.Font = this.Font;
        draw.Pen = this.TextPen;

        draw.ExecuteText(this.Text, rect, this.TextAlign, false);

        draw.Pen = null;
        draw.Font = null;
        return true;
    }
}