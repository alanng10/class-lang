namespace Avalon.View;







public class Image : View
{
    public override bool Init()
    {
        base.Init();






        this.ValueField = this.CreateValueField();





        this.SourceField = this.CreateSourceField();





        



        this.Value = null;





        this.Source = this.CreateSource();







        this.DestRect = this.CreateDestRect();





        this.SourceRect = this.CreateSourceRect();






        return true;
    }







    protected virtual DrawRect DestRect { get; set; }





    protected virtual DrawRect SourceRect { get; set; }






    protected virtual Field CreateValueField()
    {
        return this.ViewInfra.FieldCreate(this);
    }





    protected virtual Field CreateSourceField()
    {
        return this.ViewInfra.FieldCreate(this);
    }





    protected virtual Rect CreateSource()
    {
        Rect a;

        a = new Rect();

        a.Init();


        return a;
    }






    protected virtual DrawRect CreateDestRect()
    {
        DrawRect rect;

        rect = new DrawRect();

        rect.Init();


        rect.Pos = new DrawPos();

        rect.Pos.Init();

        rect.Size = new DrawSize();

        rect.Size.Init();



        return rect;
    }





    protected virtual DrawRect CreateSourceRect()
    {
        DrawRect rect;

        rect = new DrawRect();

        rect.Init();


        rect.Pos = new DrawPos();

        rect.Pos.Init();

        rect.Size = new DrawSize();

        rect.Size.Init();



        return rect;
    }






    public virtual Field ValueField { get; set; }




    public virtual DrawImage Value
    {
        get
        {
            return (DrawImage)this.ValueField.GetAny();
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







    public virtual Field SourceField { get; set; }




    public virtual Rect Source
    {
        get
        {
            return (Rect)this.SourceField.Get();
        }

        set
        {
            this.SourceField.Set(value);
        }
    }





    protected virtual bool ChangeSource(Change change)
    {
        this.Trigger(this.SourceField);



        return true;
    }







    protected override bool CheckDrawChild()
    {
        return !(this.Value == null);
    }






    protected override bool ExecuteChildDraw(DrawDraw draw)
    {
        DrawImage image;

        image = this.Value;




        DrawRect destRect;

        destRect = this.DestRect;



        DrawRect sourceRect;

        sourceRect = this.SourceRect;





        destRect.Pos.Left = this.Pos.Left;

        destRect.Pos.Up = this.Pos.Up;



        destRect.Size.Width = this.Size.Width;

        destRect.Size.Height = this.Size.Height;




        sourceRect.Pos.Left = this.Source.Pos.Left;

        sourceRect.Pos.Up = this.Source.Pos.Up;


        sourceRect.Size.Width = this.Source.Size.Width;

        sourceRect.Size.Height = this.Source.Size.Height;





        //draw.ExecuteImage(image, destRect, sourceRect);
        




        return true;
    }








    public override bool Change(Field field, Change change)
    {
        base.Change(field, change);




        if (this.ValueField == field)
        {
            this.ChangeValue(change);
        }



        if (this.SourceField == field)
        {
            this.ChangeSource(change);
        }




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