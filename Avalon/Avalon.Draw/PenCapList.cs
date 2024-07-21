namespace Avalon.Draw;

public class PenCapList : Any
{
    public static PenCapList This { get; } = ShareCreate();

    private static PenCapList ShareCreate()
    {
        PenCapList share;
        share = new PenCapList();
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

        this.Flat = this.AddItem(Extern.Stat_PenCapFlat(stat));
        this.Square = this.AddItem(Extern.Stat_PenCapSquare(stat));
        this.Round = this.AddItem(Extern.Stat_PenCapRound(stat));
        return true;
    }

    public virtual PenCap Flat { get { return __D_Flat; } set { __D_Flat = value; } }
    protected PenCap __D_Flat;
    public virtual PenCap Square { get { return __D_Square; } set { __D_Square = value; } }
    protected PenCap __D_Square;
    public virtual PenCap Round { get { return __D_Round; } set { __D_Round = value; } }
    protected PenCap __D_Round;

    protected virtual PenCap AddItem(ulong o)
    {
        PenCap item;
        item = new PenCap();
        item.Init();
        item.Index = this.Index;
        item.Intern = o;
        this.Array.Set((object)item.Index, item);
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

    public virtual PenCap Get(int index)
    {
        return (PenCap)this.Array.Get((object)index);
    }
}