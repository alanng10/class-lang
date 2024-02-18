namespace Avalon.Draw;





public class PenCapList : Any
{
    public static PenCapList This { get; } = ShareCreate();




    private static PenCapList ShareCreate()
    {
        PenCapList share;


        share = new PenCapList();



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




        ulong share;

        share = Extern.Infra_Share();



        ulong stat;

        stat = Extern.Share_Stat(share);




        this.Flat = this.AddItem(Extern.Stat_PenCapFlat(stat));
        this.Square = this.AddItem(Extern.Stat_PenCapSquare(stat));
        this.Round = this.AddItem(Extern.Stat_PenCapRound(stat));






        return true;
    }




    public virtual PenCap Flat { get; set; }
    public virtual PenCap Square { get; set; }
    public virtual PenCap Round { get; set; }




    protected virtual PenCap AddItem(ulong o)
    {
        PenCap item;

        item = new PenCap();

        item.Init();

        item.Index = this.Index;

        item.Intern = o;



        this.Array.Set(item.Index, item);



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




    public virtual PenCap Get(int index)
    {
        return (PenCap)this.Array.Get(index);
    }



    
    protected virtual int Index { get; set; }

}