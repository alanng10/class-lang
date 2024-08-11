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

    public virtual BrushKind Color { get; set; }
    public virtual BrushKind Gradient { get; set; }
    public virtual BrushKind Image { get; set; }

    protected virtual BrushKind AddItem(ulong o)
    {
        int index;
        index = this.Index;

        BrushKind item;
        item = new BrushKind();
        item.Init();
        item.Index = index;
        item.Intern = o;
        this.Array.SetAt(index, item);
        this.Index = index + 1;
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

    protected virtual int ArrayCount { get { return 3; } set { } }

    public virtual int Count { get; set; }
    
    protected virtual int Index { get; set; }

    public virtual BrushKind Get(int index)
    {
        return (BrushKind)this.Array.GetAt(index);
    }
}