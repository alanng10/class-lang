namespace Avalon.View;







public class Rect : Comp
{
    public override bool Init()
    {
        base.Init();






        this.PosField = this.CreatePosField();






        this.SizeField = this.CreateSizeField();






        this.Pos = this.CreatePos();





        this.Size = this.CreateSize();
        





        return true;
    }







    protected virtual Field CreatePosField()
    {
        return this.ViewInfra.FieldCreate(this);
    }






    protected virtual Field CreateSizeField()
    {
        return this.ViewInfra.FieldCreate(this);
    }







    protected virtual Pos CreatePos()
    {
        Pos a;


        a = new Pos();


        a.Init();



        a.Left = 0;


        a.Up = 0;




        return a;
    }







    protected virtual Size CreateSize()
    {
        Size a;


        a = new Size();


        a.Init();


        a.Width = 0;


        a.Height = 0;




        return a;
    }







    public override bool Change(Field field, Change change)
    {
        if (this.PosField == field)
        {
            this.ChangePos(change);
        }





        if (this.SizeField == field)
        {
            this.ChangeSize(change);
        }




        return true;
    }






    public virtual Field PosField { get; set; }




    public virtual Pos Pos
    {
        get
        {
            return (Pos)this.PosField.Get();
        }

        set
        {
            this.PosField.Set(value);
        }
    }




    protected virtual bool ChangePos(Change change)
    {
        this.Trigger(this.PosField);



        return true;
    }







    public virtual Field SizeField { get; set; }




    public virtual Size Size
    {
        get
        {
            return (Size)this.SizeField.Get();
        }

        set
        {
            this.SizeField.Set(value);
        }
    }




    protected virtual bool ChangeSize(Change change)
    {
        this.Trigger(this.SizeField);



        return true;
    }
}