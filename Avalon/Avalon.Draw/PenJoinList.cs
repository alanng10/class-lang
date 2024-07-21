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

    public virtual PenJoin Miter { get { return __D_Miter; } set { __D_Miter = value; } }
    protected PenJoin __D_Miter;
    public virtual PenJoin Bevel { get { return __D_Bevel; } set { __D_Bevel = value; } }
    protected PenJoin __D_Bevel;
    public virtual PenJoin Round { get { return __D_Round; } set { __D_Round = value; } }
    protected PenJoin __D_Round;
    public virtual PenJoin SvgMiter { get { return __D_SvgMiter; } set { __D_SvgMiter = value; } }
    protected PenJoin __D_SvgMiter;

    protected virtual PenJoin AddItem(ulong o)
    {
        PenJoin item;
        item = new PenJoin();
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

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 4; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual PenJoin Get(int index)
    {
        return (PenJoin)this.Array.GetAt(index);
    }
}