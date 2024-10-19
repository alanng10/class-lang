namespace Mirai.Draw;

public class SlashLineList : Any
{
    public static SlashLineList This { get; } = ShareCreate();

    private static SlashLineList ShareCreate()
    {
        SlashLineList share;
        share = new SlashLineList();
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

        this.Solid = this.AddItem(Extern.Stat_SlashLineSolid(stat));
        this.Dash = this.AddItem(Extern.Stat_SlashLineDash(stat));
        this.Dot = this.AddItem(Extern.Stat_SlashLineDot(stat));
        this.DashDot = this.AddItem(Extern.Stat_SlashLineDashDot(stat));
        this.DashDotDot = this.AddItem(Extern.Stat_SlashLineDashDotDot(stat));
        return true;
    }

    public virtual SlashLine Solid { get; set; }
    public virtual SlashLine Dash { get; set; }
    public virtual SlashLine Dot { get; set; }
    public virtual SlashLine DashDot { get; set; }
    public virtual SlashLine DashDotDot { get; set; }

    protected virtual SlashLine AddItem(ulong o)
    {
        SlashLine item;
        item = new SlashLine();
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

    public virtual SlashLine Get(long index)
    {
        return (SlashLine)this.Array.GetAt(index);
    }
}