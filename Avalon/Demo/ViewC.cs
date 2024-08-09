namespace Demo;

class ViewC : View
{
    public override bool Init()
    {
        base.Init();
        this.Rect = this.DrawInfra.RectIntCreate(0, 0, 0, 0);
        return true;
    }

    public DrawRectInt EllipseRect { get; set; }
    public DrawBrush EllipseBrush { get; set; }
    public DrawFace Face { get; set; }
    public DrawTextAlign TextAlign { get; set; }
    public Text Text { get; set; }
    public DrawBrush TextPen { get; set; }
    private DrawRectInt Rect { get; set; }

    protected override bool ExecuteDrawThis(DrawDraw draw)
    {
        base.ExecuteDrawThis(draw);
        this.EllipseRect.Pos.Col = this.MathInt(this.Pos.Left + 400);
        this.EllipseRect.Pos.Row = this.MathInt(this.Pos.Up + 20);
        
        draw.Fill = this.EllipseBrush;

        draw.ExecuteRound(this.EllipseRect);

        draw.Fill = null;

        DrawRectInt rect;
        rect = this.Rect;
        rect.Pos.Col = this.MathInt(this.Pos.Left + 150);
        rect.Pos.Row = this.MathInt(this.Pos.Up + 50);
        rect.Size.Width = this.MathInt(300);
        rect.Size.Height = this.MathInt(100);

        draw.Face = this.Face;
        draw.Stroke = this.TextPen;

        draw.ExecuteText(this.Text, rect, this.TextAlign, false);

        draw.Stroke = null;
        draw.Face = null;
        return true;
    }
}