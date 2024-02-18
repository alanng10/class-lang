namespace Avalon.View;







public class GridCol : Comp
{
    public override bool Init()
    {
        base.Init();





        this.WidthField = this.CreateWidthField();




        this.Width = 0;

        



        return true;
    }







    protected virtual Field CreateWidthField()
    {
        return this.ViewInfra.FieldCreate(this);
    }






    public virtual Field WidthField { get; set; }




    public virtual int Width
    {
        get
        {
            return this.WidthField.GetInt();
        }

        set
        {
            this.WidthField.SetInt(value);
        }
    }




    protected virtual bool ChangeWidth(Change change)
    {
        this.Trigger(this.WidthField);



        return true;
    }





    public override bool Change(Field field, Change change)
    {
        if (this.WidthField == field)
        {
            this.ChangeWidth(change);
        }



        return true;
    }
}