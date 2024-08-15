namespace Avalon.Draw;

public class BrushCapList : Any
{
    public static BrushCapList This { get; } = ShareCreate();

    private static BrushCapList ShareCreate()
    {
        BrushCapList share;
        share = new BrushCapList();
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

        this.Flat = this.AddItem(Extern.Stat_BrushCapFlat(stat));
        this.Square = this.AddItem(Extern.Stat_BrushCapSquare(stat));
        this.Round = this.AddItem(Extern.Stat_BrushCapRound(stat));
        return true;
    }

    public virtual BrushCap Flat { get; set; }
    public virtual BrushCap Square { get; set; }
    public virtual BrushCap Round { get; set; }

    protected virtual BrushCap AddItem(ulong o)
    {
        long index;
        index = this.Index;

        BrushCap item;
        item = new BrushCap();
        item.Init();
        item.Index = index;
        item.Intern = o;
        this.Array.SetAt(index, item);
        this.Index = index + 1;
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

    public virtual BrushCap Get(long index)
    {
        return (BrushCap)this.Array.GetAt(index);
    }
}