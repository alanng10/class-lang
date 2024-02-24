namespace Demo;

class ViewC : View
{
    public DrawRect EllipseRect { get; set; }
    public DrawBrush EllipseBrush { get; set; }
    public DrawFont Font { get; set; }
    public DrawTextAlign TextAlign { get; set; }
    public TextSpan Text { get; set; }
    public DrawPen TextPen { get; set; }

    protected override bool ExecuteDrawThis(DrawDraw draw)
    {
        base.ExecuteDrawThis(draw);
        this.EllipseRect.Pos.Left = this.Pos.Left + 400;
        this.EllipseRect.Pos.Up = this.Pos.Up + 20;
        
        draw.Brush = this.EllipseBrush;

        draw.ExecuteEllipse(this.EllipseRect);

        draw.Brush = null;

        this.DrawRectA.Pos.Left = this.Pos.Left + 150;
        this.DrawRectA.Pos.Up = this.Pos.Up + 50;
        this.DrawRectA.Size.Width = 300;
        this.DrawRectA.Size.Height = 100;

        draw.Font = this.Font;
        draw.Pen = this.TextPen;

        draw.ExecuteText(this.Text, this.DrawRectA, this.TextAlign, false);

        draw.Pen = null;
        draw.Font = null;
        return true;
    }
}