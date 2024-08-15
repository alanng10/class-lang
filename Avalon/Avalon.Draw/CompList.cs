namespace Avalon.Draw;

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
        this.DestinationOver = this.AddItem(Extern.Stat_CompDestinationOver(stat));
        this.Clear = this.AddItem(Extern.Stat_CompClear(stat));
        this.Source = this.AddItem(Extern.Stat_CompSource(stat));
        this.Destination = this.AddItem(Extern.Stat_CompDestination(stat));
        this.SourceIn = this.AddItem(Extern.Stat_CompSourceIn(stat));
        this.DestinationIn = this.AddItem(Extern.Stat_CompDestinationIn(stat));
        this.SourceOut = this.AddItem(Extern.Stat_CompSourceOut(stat));
        this.DestinationOut = this.AddItem(Extern.Stat_CompDestinationOut(stat));
        this.SourceAtop = this.AddItem(Extern.Stat_CompSourceAtop(stat));
        this.DestinationAtop = this.AddItem(Extern.Stat_CompDestinationAtop(stat));
        return true;
    }

    public virtual Comp SourceOver { get; set; }
    public virtual Comp DestinationOver { get; set; }
    public virtual Comp Clear { get; set; }
    public virtual Comp Source { get; set; }
    public virtual Comp Destination { get; set; }
    public virtual Comp SourceIn { get; set; }
    public virtual Comp DestinationIn { get; set; }
    public virtual Comp SourceOut { get; set; }
    public virtual Comp DestinationOut { get; set; }
    public virtual Comp SourceAtop { get; set; }
    public virtual Comp DestinationAtop { get; set; }

    protected virtual Comp AddItem(ulong o)
    {
        long index;
        index = this.Index;

        Comp item;
        item = new Comp();
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

    protected virtual long ArrayCount { get { return 11; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual Comp Get(long index)
    {
        return (Comp)this.Array.GetAt(index);
    }
}