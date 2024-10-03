namespace Mirai.Draw;

public class BrushJoinList : Any
{
    public static BrushJoinList This { get; } = ShareCreate();

    private static BrushJoinList ShareCreate()
    {
        BrushJoinList share;
        share = new BrushJoinList();
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

        this.Miter = this.AddItem(Extern.Stat_BrushJoinMiter(stat));
        this.Bevel = this.AddItem(Extern.Stat_BrushJoinBevel(stat));
        this.Round = this.AddItem(Extern.Stat_BrushJoinRound(stat));
        return true;
    }

    public virtual BrushJoin Miter { get; set; }
    public virtual BrushJoin Bevel { get; set; }
    public virtual BrushJoin Round { get; set; }

    protected virtual BrushJoin AddItem(ulong o)
    {
        BrushJoin item;
        item = new BrushJoin();
        item.Init();
        item.Index = this.Index;
        item.Intern = o;
        this.Array.SetAt(item.Index, item);
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

    protected virtual long ArrayCount { get { return 3; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual BrushJoin Get(long index)
    {
        return (BrushJoin)this.Array.GetAt(index);
    }
}