namespace Demo;

class ViewA : View
{
    public virtual DrawBrush DrawPen { get; set; }
    public virtual Demo Demo { get; set; }
    public virtual DrawForm Form { get; set; }
    public virtual int RotateValue { get; set; }

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

        DrawRectInt rect;
        rect = this.DrawRectIntA;
        rect.Pos.Left = this.MathInt(left);
        rect.Pos.Up = this.MathInt(up);
        rect.Size.Width = this.MathInt(width);
        rect.Size.Height = this.MathInt(height);

        DrawBrush brush;
        brush = this.Back;
        draw.Fill = brush;
        DrawBrush pen;
        pen = this.DrawPen;
        draw.Stroke = pen;

        draw.FillPos.Left = this.MathInt(left);
        draw.FillPos.Up = this.MathInt(up);
        draw.FillPosSet();
        
        draw.ExecuteRoundRect(rect, this.MathInt(40), this.MathInt(30));

        DrawImage playImage;
        playImage = this.Demo.PlayImage;

        rect.Pos.Left = 0;
        rect.Pos.Up = 0;

        DrawRectInt rectB;
        rectB = this.DrawRectIntB;
        rectB.Pos.Left = 0;
        rectB.Pos.Up = 0;
        rectB.Size.Width = this.MathInt(playImage.Size.Width);
        rectB.Size.Height = this.MathInt(playImage.Size.Height);

        long ooa;
        ooa = this.MathInt(left);

        long oob;
        oob = this.MathInt(up);

        int oa;
        oa = this.RotateValue * 10;
        int ob;        
        ob = oa / 360;
        ob = ob * 360;
        oa = oa - ob;

        long angle;
        angle = this.MathInt(oa);

        this.Form.Reset();

        this.Form.Offset(ooa, oob);

        this.Form.Rotate(angle);

        draw.Form = this.Form;
        draw.FormSet();

        draw.ExecuteImage(playImage, rect, rectB);

        draw.Form = null;
        draw.FormSet();
        
        draw.Fill = null;

        draw.Stroke = null;
        return true;
    }
}