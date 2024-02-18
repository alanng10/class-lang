namespace Demo;



class ViewA : View
{
    public virtual DrawPen DrawPen { get; set; }


    public virtual Demo Demo { get; set; }


    public virtual DrawTransform Transform { get; set; }


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




        DrawRect rect;

        rect = this.DrawRectA;


        rect.Pos.Left = left;

        rect.Pos.Up = up;

        rect.Size.Width = width;

        rect.Size.Height = height;

        


        DrawBrush brush;

        brush = this.Back;



        draw.Brush = brush;



        DrawPen pen;

        pen = this.DrawPen;


        draw.Pen = pen;




        draw.FillPos.Left = left;

        draw.FillPos.Up = up;


        draw.SetFillPos();
        



        long scaleFactor;

        scaleFactor = this.DrawInfra.ScaleFactor;


        draw.ExecuteRoundRect(rect, 40 * scaleFactor, 30 * scaleFactor);




        DrawImage playImage;

        playImage = this.Demo.PlayImage;




        rect.Pos.Left = 0;

        rect.Pos.Up = 0;



        DrawRect rectB;

        rectB = this.DrawRectB;


        rectB.Pos.Left = 0;

        rectB.Pos.Up = 0;

        rectB.Size.Width = playImage.Size.Width;

        rectB.Size.Height = playImage.Size.Height;




        long ooa;

        ooa = left;
        
        ooa = ooa * scaleFactor;



        long oob;

        oob = up;
        
        oob = oob * scaleFactor;




        int oa;

        oa = this.RotateValue * 10;



        int ob;
        
        ob = oa / 360;

        ob = ob * 360;



        oa = oa - ob;




        long angle;

        angle = oa * scaleFactor;




        this.Transform.Reset();



        this.Transform.Offset(ooa, oob);



        this.Transform.Rotate(angle);



        draw.Transform = this.Transform;


        draw.SetTransform();



        draw.ExecuteImage(playImage, rect, rectB);



        draw.Transform = null;


        draw.SetTransform();
        



        draw.Brush = null;



        draw.Pen = null;




        return true;
    }
}