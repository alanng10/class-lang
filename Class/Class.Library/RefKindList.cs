namespace Class.Library;





public class RefKindList : Any
{
    public static RefKindList This { get; } = CreateShare();




    private static RefKindList CreateShare()
    {
        RefKindList share;


        share = new RefKindList();



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




        this.Null = this.AddItem();
        this.Any = this.AddItem();
        this.Bool = this.AddItem();
        this.Int = this.AddItem();
        this.StringValue = this.AddItem();
        this.ItemArray = this.AddItem();
        this.Data = this.AddItem();






        return true;
    }




    public virtual RefKind Null { get; set; }
    public virtual RefKind Any { get; set; }
    public virtual RefKind Bool { get; set; }
    public virtual RefKind Int { get; set; }
    public virtual RefKind StringValue { get; set; }
    public virtual RefKind ItemArray { get; set; }
    public virtual RefKind Data { get; set; }




    protected virtual RefKind AddItem()
    {
        RefKind item;

        item = new RefKind();

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
            return 7;
        } 
        set
        {
        }
    }




    public virtual int Count { get; set; }




    public virtual RefKind Get(int index)
    {
        return (RefKind)this.Array.Get(index);
    }



    
    protected virtual int Index { get; set; }

}