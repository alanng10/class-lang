namespace Avalon.Draw;

public class PenJoinList : Any
{
    public static PenJoinList This { get; } = ShareCreate();

    private static PenJoinList ShareCreate()
    {
        PenJoinList share;
        share = new PenJoinList();
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

        this.Miter = this.AddItem(Extern.Stat_PenJoinMiter(stat));
        this.Bevel = this.AddItem(Extern.Stat_PenJoinBevel(stat));
        this.Round = this.AddItem(Extern.Stat_PenJoinRound(stat));
        this.SvgMiter = this.AddItem(Extern.Stat_PenJoinSvgMiter(stat));

        return true;
    }

    public virtual PenJoin Miter { get; set; }
    public virtual PenJoin Bevel { get; set; }
    public virtual PenJoin Round { get; set; }
    public virtual PenJoin SvgMiter { get; set; }

    protected virtual PenJoin AddItem(ulong o)
    {
        PenJoin item;
        item = new PenJoin();
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
            return 4;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual PenJoin Get(int index)
    {
        return (PenJoin)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }
}