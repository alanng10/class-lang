namespace Mirai.Draw;

public class SlashJoinList : Any
{
    public static SlashJoinList This { get; } = ShareCreate();

    private static SlashJoinList ShareCreate()
    {
        SlashJoinList share;
        share = new SlashJoinList();
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

        this.Miter = this.AddItem(Extern.Stat_SlashJoinMiter(stat));
        this.Bevel = this.AddItem(Extern.Stat_SlashJoinBevel(stat));
        this.Round = this.AddItem(Extern.Stat_SlashJoinRound(stat));
        return true;
    }

    public virtual SlashJoin Miter { get; set; }
    public virtual SlashJoin Bevel { get; set; }
    public virtual SlashJoin Round { get; set; }

    protected virtual SlashJoin AddItem(ulong o)
    {
        SlashJoin item;
        item = new SlashJoin();
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

    public virtual SlashJoin Get(long index)
    {
        return (SlashJoin)this.Array.GetAt(index);
    }
}