namespace Avalon.Draw;

public class CompositeList : Any
{
    public static CompositeList This { get; } = ShareCreate();

    private static CompositeList ShareCreate()
    {
        CompositeList share;
        share = new CompositeList();
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

        this.SourceOver = this.AddItem(Extern.Stat_CompositeSourceOver(stat));
        this.DestinationOver = this.AddItem(Extern.Stat_CompositeDestinationOver(stat));
        this.Clear = this.AddItem(Extern.Stat_CompositeClear(stat));
        this.Source = this.AddItem(Extern.Stat_CompositeSource(stat));
        this.Destination = this.AddItem(Extern.Stat_CompositeDestination(stat));
        this.SourceIn = this.AddItem(Extern.Stat_CompositeSourceIn(stat));
        this.DestinationIn = this.AddItem(Extern.Stat_CompositeDestinationIn(stat));
        this.SourceOut = this.AddItem(Extern.Stat_CompositeSourceOut(stat));
        this.DestinationOut = this.AddItem(Extern.Stat_CompositeDestinationOut(stat));
        this.SourceAtop = this.AddItem(Extern.Stat_CompositeSourceAtop(stat));
        this.DestinationAtop = this.AddItem(Extern.Stat_CompositeDestinationAtop(stat));
        this.Xor = this.AddItem(Extern.Stat_CompositeXor(stat));
        this.Plus = this.AddItem(Extern.Stat_CompositePlus(stat));
        this.Multiply = this.AddItem(Extern.Stat_CompositeMultiply(stat));
        this.Screen = this.AddItem(Extern.Stat_CompositeScreen(stat));
        this.Overlay = this.AddItem(Extern.Stat_CompositeOverlay(stat));
        this.Darken = this.AddItem(Extern.Stat_CompositeDarken(stat));
        this.Lighten = this.AddItem(Extern.Stat_CompositeLighten(stat));
        this.ColorDodge = this.AddItem(Extern.Stat_CompositeColorDodge(stat));
        this.ColorBurn = this.AddItem(Extern.Stat_CompositeColorBurn(stat));
        this.HardLight = this.AddItem(Extern.Stat_CompositeHardLight(stat));
        this.SoftLight = this.AddItem(Extern.Stat_CompositeSoftLight(stat));
        this.Difference = this.AddItem(Extern.Stat_CompositeDifference(stat));
        this.Exclusion = this.AddItem(Extern.Stat_CompositeExclusion(stat));

        return true;
    }

    public virtual Composite SourceOver { get; set; }
    public virtual Composite DestinationOver { get; set; }
    public virtual Composite Clear { get; set; }
    public virtual Composite Source { get; set; }
    public virtual Composite Destination { get; set; }
    public virtual Composite SourceIn { get; set; }
    public virtual Composite DestinationIn { get; set; }
    public virtual Composite SourceOut { get; set; }
    public virtual Composite DestinationOut { get; set; }
    public virtual Composite SourceAtop { get; set; }
    public virtual Composite DestinationAtop { get; set; }
    public virtual Composite Xor { get; set; }
    public virtual Composite Plus { get; set; }
    public virtual Composite Multiply { get; set; }
    public virtual Composite Screen { get; set; }
    public virtual Composite Overlay { get; set; }
    public virtual Composite Darken { get; set; }
    public virtual Composite Lighten { get; set; }
    public virtual Composite ColorDodge { get; set; }
    public virtual Composite ColorBurn { get; set; }
    public virtual Composite HardLight { get; set; }
    public virtual Composite SoftLight { get; set; }
    public virtual Composite Difference { get; set; }
    public virtual Composite Exclusion { get; set; }

    protected virtual Composite AddItem(ulong o)
    {
        Composite item;
        item = new Composite();
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
            return 24;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual Composite Get(int index)
    {
        return (Composite)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }
}