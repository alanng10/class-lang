namespace Demo;

class ViewC : View
{
    public override bool Init()
    {
        base.Init();
        this.RectLong = this.DrawInfra.RectIntCreate(0, 0, 0, 0);
        return true;
    }

    public DrawRectInt EllipseRect { get; set; }
    public DrawBrush EllipseBrush { get; set; }
    public DrawFace Face { get; set; }
    public DrawTextAlign TextAlign { get; set; }
    public Text Text { get; set; }
    public DrawBrush TextPen { get; set; }
    private DrawRectInt RectLong { get; set; }

    protected override bool ExecuteDrawThis(DrawDraw draw)
    {
        base.ExecuteDrawThis(draw);
        this.EllipseRect.Pos.Left = this.MathInt(this.Pos.Left + 400);
        this.EllipseRect.Pos.Up = this.MathInt(this.Pos.Up + 20);
        
        draw.Fill = this.EllipseBrush;

        draw.ExecuteEllipse(this.EllipseRect);

        draw.Fill = null;

        DrawRectInt rect;
        rect = this.RectLong;
        rect.Pos.Left = this.MathInt(this.Pos.Left + 150);
        rect.Pos.Up = this.MathInt(this.Pos.Up + 50);
        rect.Size.Width = this.MathInt(300);
        rect.Size.Height = this.MathInt(100);

        draw.Face = this.Face;
        draw.Pen = this.TextPen;

        draw.ExecuteText(this.Text, rect, this.TextAlign, false);

        draw.Pen = null;
        draw.Face = null;
        return true;
    }
}