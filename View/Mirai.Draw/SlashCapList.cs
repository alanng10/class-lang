namespace Mirai.Draw;

public class SlashCapList : Any
{
    public static SlashCapList This { get; } = ShareCreate();

    private static SlashCapList ShareCreate()
    {
        SlashCapList share;
        share = new SlashCapList();
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

        this.Flat = this.AddItem(Extern.Stat_SlashCapFlat(stat));
        this.Square = this.AddItem(Extern.Stat_SlashCapSquare(stat));
        this.Round = this.AddItem(Extern.Stat_SlashCapRound(stat));
        return true;
    }

    public virtual SlashCap Flat { get; set; }
    public virtual SlashCap Square { get; set; }
    public virtual SlashCap Round { get; set; }

    protected virtual SlashCap AddItem(ulong o)
    {
        SlashCap item;
        item = new SlashCap();
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

    public virtual SlashCap Get(long index)
    {
        return (SlashCap)this.Array.GetAt(index);
    }
}