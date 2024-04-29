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

    public virtual PenKind Solid { get { return __D_Solid; } set { __D_Solid = value; } }
    protected PenKind __D_Solid;
    public virtual PenKind Dash { get { return __D_Dash; } set { __D_Dash = value; } }
    protected PenKind __D_Dash;
    public virtual PenKind Dot { get { return __D_Dot; } set { __D_Dot = value; } }
    protected PenKind __D_Dot;
    public virtual PenKind DashDot { get { return __D_DashDot; } set { __D_DashDot = value; } }
    protected PenKind __D_DashDot;
    public virtual PenKind DashDotDot { get { return __D_DashDotDot; } set { __D_DashDotDot = value; } }
    protected PenKind __D_DashDotDot;
    public virtual PenKind CustomDash { get { return __D_CustomDash; } set { __D_CustomDash = value; } }
    protected PenKind __D_CustomDash;

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

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 6; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual PenKind Get(int index)
    {
        return (PenKind)this.Array.Get(index);
    }
}