namespace Avalon.Draw;

public class BrushKindList : Any
{
    public static BrushKindList This { get; } = ShareCreate();

    private static BrushKindList ShareCreate()
    {
        BrushKindList share;
        share = new BrushKindList();
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

        this.Color = this.AddItem(Extern.Stat_BrushKindColor(stat));
        this.Gradient = this.AddItem(Extern.Stat_BrushKindGradient(stat));
        this.Image = this.AddItem(Extern.Stat_BrushKindImage(stat));
        return true;
    }

    public virtual BrushKind Color { get { return __D_Color; } set { __D_Color = value; } }
    protected BrushKind __D_Color;
    public virtual BrushKind Gradient { get { return __D_Gradient; } set { __D_Gradient = value; } }
    protected BrushKind __D_Gradient;
    public virtual BrushKind Image { get { return __D_Image; } set { __D_Image = value; } }
    protected BrushKind __D_Image;

    protected virtual BrushKind AddItem(ulong o)
    {
        BrushKind item;
        item = new BrushKind();
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

    public virtual BrushKind Get(int index)
    {
        return (BrushKind)this.Array.GetAt(index);
    }
}