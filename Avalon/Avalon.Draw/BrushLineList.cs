namespace Avalon.Draw;

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

    public virtual BrushLine Solid { get { return __D_Solid; } set { __D_Solid = value; } }
    protected BrushLine __D_Solid;
    public virtual BrushLine Dash { get { return __D_Dash; } set { __D_Dash = value; } }
    protected BrushLine __D_Dash;
    public virtual BrushLine Dot { get { return __D_Dot; } set { __D_Dot = value; } }
    protected BrushLine __D_Dot;
    public virtual BrushLine DashDot { get { return __D_DashDot; } set { __D_DashDot = value; } }
    protected BrushLine __D_DashDot;
    public virtual BrushLine DashDotDot { get { return __D_DashDotDot; } set { __D_DashDotDot = value; } }
    protected BrushLine __D_DashDotDot;

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

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 5; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual BrushLine Get(int index)
    {
        return (BrushLine)this.Array.GetAt(index);
    }
}