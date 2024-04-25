namespace Avalon.View;






public class Text : View
{
    public override bool Init()
    {
        base.Init();




        this.TextInfra = TextInfra.This;




        this.ValueField = this.CreateValueField();




        this.ForeField = this.CreateForeField();




        this.FontField = this.CreateFontField();




        this.DestField = this.CreateDestField();




        this.AlignField = this.CreateAlignField();






        this.Value = this.CreateValue();




        this.Fore = this.CreateFore();




        this.Font = this.CreateFont();




        this.Dest = this.CreateDest();




        this.Align = this.CreateAlign();





        return true;
    }





    protected virtual TextInfra TextInfra { get; set; }





    protected virtual Field CreateValueField()
    {
        return this.ViewInfra.FieldCreate(this);
    }




    protected virtual Field CreateForeField()
    {
        return this.ViewInfra.FieldCreate(this);
    }




    protected virtual Field CreateFontField()
    {
        return this.ViewInfra.FieldCreate(this);
    }




    protected virtual Field CreateDestField()
    {
        return this.ViewInfra.FieldCreate(this);
    }




    protected virtual Field CreateAlignField()
    {
        return this.ViewInfra.FieldCreate(this);
    }






    protected virtual TextText CreateValue()
    {
        return this.TextInfra.TextCreateString("");
    }





    protected virtual DrawPen CreateFore()
    {
        return this.DrawInfra.BlackPen;
    }




    protected virtual DrawFont CreateFont()
    {
        return this.DrawInfra.Font;
    }




    protected virtual Rect CreateDest()
    {
        Rect a;

        a = new Rect();

        a.Init();


        return a;
    }





    protected virtual DrawTextAlign CreateAlign()
    {
        DrawTextAlignList a;

        a = DrawTextAlignList.This;


        return a.LeftUp;
    }






    public virtual Field ValueField { get; set; }




    public virtual TextText Value
    {
        get
        {
            return (TextText)this.ValueField.GetAny();
        }

        set
        {
            this.ValueField.SetAny(value);
        }
    }





    protected virtual bool ChangeValue(Change change)
    {
        this.Trigger(this.ValueField);



        return true;
    }







    public virtual Field ForeField { get; set; }




    public virtual DrawPen Fore
    {
        get
        {
            return (DrawPen)this.ForeField.GetAny();
        }

        set
        {
            this.ForeField.SetAny(value);
        }
    }





    protected virtual bool ChangeFore(Change change)
    {
        this.Trigger(this.ForeField);



        return true;
    }








    public virtual Field FontField { get; set; }




    public virtual DrawFont Font
    {
        get
        {
            return (DrawFont)this.FontField.GetAny();
        }

        set
        {
            this.FontField.SetAny(value);
        }
    }





    protected virtual bool ChangeFont(Change change)
    {
        this.Trigger(this.FontField);



        return true;
    }







    public virtual Field DestField { get; set; }




    public virtual Rect Dest
    {
        get
        {
            return (Rect)this.DestField.Get();
        }

        set
        {
            this.DestField.Set(value);
        }
    }





    protected virtual bool ChangeDest(Change change)
    {
        this.Trigger(this.DestField);



        return true;
    }






    public virtual Field AlignField { get; set; }




    public virtual DrawTextAlign Align
    {
        get
        {
            return (DrawTextAlign)this.AlignField.GetAny();
        }

        set
        {
            this.AlignField.SetAny(value);
        }
    }





    protected virtual bool ChangeAlign(Change change)
    {
        this.Trigger(this.AlignField);



        return true;
    }






    public override bool Change(Field field, Change change)
    {
        base.Change(field, change);




        if (this.ValueField == field)
        {
            this.ChangeValue(change);
        }


        if (this.ForeField == field)
        {
            this.ChangeFore(change);
        }


        if (this.FontField == field)
        {
            this.ChangeFont(change);
        }


        if (this.DestField == field)
        {
            this.ChangeDest(change);
        }


        if (this.AlignField == field)
        {
            this.ChangeAlign(change);
        }



        return true;
    }









    protected override bool CheckDrawChild()
    {
        return !(this.Value == null);
    }








    protected override bool ExecuteChildDraw(DrawDraw draw)
    {
        TextText span;

        span = this.Value;



        DrawRect dest;

        dest = this.DrawRectA;



        dest.Pos.Left = this.Dest.Pos.Left;


        dest.Pos.Up = this.Dest.Pos.Up;


        dest.Size.Width = this.Dest.Size.Width;


        dest.Size.Height = this.Dest.Size.Height;



        DrawTextAlign align;

        align = this.Align;




        DrawPen fore;

        fore = this.Fore;


        DrawFont font;

        font = this.Font;




        DrawPen oa;

        oa = draw.Pen;



        DrawFont ob;

        ob = draw.Font;



        draw.Pen = fore;


        draw.Font = font;



        draw.ExecuteText(span, dest, align, false);



        draw.Font = ob;


        draw.Pen = oa;





        return true;
    }







    public override View Child
    {
        get
        {
            return null;
        }
        set
        {
        }
    }
}