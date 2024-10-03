namespace Mirai.Draw;

public class BrushLineList : Any
{
    public static BrushLineList This { get; } = ShareCreate();

    private static BrushLineList ShareCreate()
    {
        BrushLineList share;
        share = new BrushLineList();
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

        this.Solid = this.AddItem(Extern.Stat_BrushLineSolid(stat));
        this.Dash = this.AddItem(Extern.Stat_BrushLineDash(stat));
        this.Dot = this.AddItem(Extern.Stat_BrushLineDot(stat));
        this.DashDot = this.AddItem(Extern.Stat_BrushLineDashDot(stat));
        this.DashDotDot = this.AddItem(Extern.Stat_BrushLineDashDotDot(stat));
        return true;
    }

    public virtual BrushLine Solid { get; set; }
    public virtual BrushLine Dash { get; set; }
    public virtual BrushLine Dot { get; set; }
    public virtual BrushLine DashDot { get; set; }
    public virtual BrushLine DashDotDot { get; set; }

    protected virtual BrushLine AddItem(ulong o)
    {
        BrushLine item;
        item = new BrushLine();
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

    protected virtual long ArrayCount { get { return 5; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual BrushLine Get(long index)
    {
        return (BrushLine)this.Array.GetAt(index);
    }
}