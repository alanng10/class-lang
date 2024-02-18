namespace Class.Library;





public class StateKindList : Any
{
    public static StateKindList This { get; } = CreateShare();




    private static StateKindList CreateShare()
    {
        StateKindList share;


        share = new StateKindList();



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




        this.ItemGet = this.AddItem("G");
        this.Set = this.AddItem("S");
        this.Call = this.AddItem("C");






        return true;
    }




    public virtual StateKind ItemGet { get; set; }
    public virtual StateKind Set { get; set; }
    public virtual StateKind Call { get; set; }




    protected virtual StateKind AddItem(string text)
    {
        StateKind item;

        item = new StateKind();

        item.Init();

        item.Index = this.Index;

        item.Text = text;



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
            return 3;
        } 
        set
        {
        }
    }




    public virtual int Count { get; set; }




    public virtual StateKind Get(int index)
    {
        return (StateKind)this.Array.Get(index);
    }



    
    protected virtual int Index { get; set; }

}