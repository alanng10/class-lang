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

    public virtual BrushCap Flat { get { return __D_Flat; } set { __D_Flat = value; } }
    protected BrushCap __D_Flat;
    public virtual BrushCap Square { get { return __D_Square; } set { __D_Square = value; } }
    protected BrushCap __D_Square;
    public virtual BrushCap Round { get { return __D_Round; } set { __D_Round = value; } }
    protected BrushCap __D_Round;

    protected virtual BrushCap AddItem(ulong o)
    {
        BrushCap item;
        item = new BrushCap();
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

    protected virtual int ArrayCount { get { return 3; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual BrushCap Get(int index)
    {
        return (BrushCap)this.Array.GetAt(index);
    }
}