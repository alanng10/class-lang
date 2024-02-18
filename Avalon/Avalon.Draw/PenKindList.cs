namespace Avalon.Draw;





public class PenKindList : Any
{
    public static PenKindList This { get; } = ShareCreate();




    private static PenKindList ShareCreate()
    {
        PenKindList share;


        share = new PenKindList();



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




        this.Solid = this.AddItem(Extern.Stat_PenKindSolid(stat));
        this.Dash = this.AddItem(Extern.Stat_PenKindDash(stat));
        this.Dot = this.AddItem(Extern.Stat_PenKindDot(stat));
        this.DashDot = this.AddItem(Extern.Stat_PenKindDashDot(stat));
        this.DashDotDot = this.AddItem(Extern.Stat_PenKindDashDotDot(stat));
        this.CustomDash = this.AddItem(Extern.Stat_PenKindCustomDash(stat));






        return true;
    }




    public virtual PenKind Solid { get; set; }
    public virtual PenKind Dash { get; set; }
    public virtual PenKind Dot { get; set; }
    public virtual PenKind DashDot { get; set; }
    public virtual PenKind DashDotDot { get; set; }
    public virtual PenKind CustomDash { get; set; }




    protected virtual PenKind AddItem(ulong o)
    {
        PenKind item;

        item = new PenKind();

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
            return 6;
        } 
        set
        {
        }
    }




    public virtual int Count { get; set; }




    public virtual PenKind Get(int index)
    {
        return (PenKind)this.Array.Get(index);
    }



    
    protected virtual int Index { get; set; }

}