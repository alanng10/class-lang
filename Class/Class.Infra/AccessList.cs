namespace Class.Infra;





public class AccessList : Any
{
    public static AccessList This { get; } = CreateShare();




    private static AccessList CreateShare()
    {
        AccessList share;


        share = new AccessList();



        Any a;


        a = share;


        a.Init();



        return share;
    }






    public override bool Init()
    {
        base.Init();



        this.InitArray();



        this.Count = this.Array.Count;



        this.Index = 0;




        this.Prudate = this.AddItem();
        this.Probate = this.AddItem();
        this.Precate = this.AddItem();
        this.Private = this.AddItem();






        return true;
    }




    public virtual Access Prudate { get; set; }
    public virtual Access Probate { get; set; }
    public virtual Access Precate { get; set; }
    public virtual Access Private { get; set; }




    protected virtual Access AddItem()
    {
        Access item;

        item = new Access();

        item.Init();

        item.Index = this.Index;



        this.Array.Set(this.Index, item);


        this.Index = this.Index + 1;



        return item;
    }




    protected virtual bool InitArray()
    {
        this.Array = new Array();


        this.Array.Count = this.ArrayCount;


        this.Array.Init();



        return true;
    }





    protected virtual Array Array { get; set; }



    protected virtual int ArrayCount
    { 
        get
        {
            return 4;
        } 
        set
        {
        }
    }




    public virtual int Count { get; set; }




    public virtual Access Get(int index)
    {
        return (Access)this.Array.Get(index);
    }



    
    protected virtual int Index { get; set; }

}