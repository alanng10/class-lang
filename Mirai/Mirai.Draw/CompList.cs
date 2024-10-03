namespace Mirai.Draw;

public class CompList : Any
{
    public static CompList This { get; } = ShareCreate();

    private static CompList ShareCreate()
    {
        CompList share;
        share = new CompList();
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

        this.SourceOver = this.AddItem(Extern.Stat_CompSourceOver(stat));
        this.DestOver = this.AddItem(Extern.Stat_CompDestOver(stat));
        this.Source = this.AddItem(Extern.Stat_CompSource(stat));
        this.Dest = this.AddItem(Extern.Stat_CompDest(stat));
        this.SourceIn = this.AddItem(Extern.Stat_CompSourceIn(stat));
        this.DestIn = this.AddItem(Extern.Stat_CompDestIn(stat));
        this.SourceOut = this.AddItem(Extern.Stat_CompSourceOut(stat));
        this.DestOut = this.AddItem(Extern.Stat_CompDestOut(stat));
        return true;
    }

    public virtual Comp SourceOver { get; set; }
    public virtual Comp DestOver { get; set; }
    public virtual Comp Source { get; set; }
    public virtual Comp Dest { get; set; }
    public virtual Comp SourceIn { get; set; }
    public virtual Comp DestIn { get; set; }
    public virtual Comp SourceOut { get; set; }
    public virtual Comp DestOut { get; set; }

    protected virtual Comp AddItem(ulong o)
    {
        Comp item;
        item = new Comp();
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

    protected virtual long ArrayCount { get { return 8; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual Comp Get(long index)
    {
        return (Comp)this.Array.GetAt(index);
    }
}