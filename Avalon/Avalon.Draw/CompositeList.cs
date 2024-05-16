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
        return true;
    }

    public virtual Composite SourceOver { get { return __D_SourceOver; } set { __D_SourceOver = value; } }
    protected Composite __D_SourceOver;
    public virtual Composite DestinationOver { get { return __D_DestinationOver; } set { __D_DestinationOver = value; } }
    protected Composite __D_DestinationOver;
    public virtual Composite Clear { get { return __D_Clear; } set { __D_Clear = value; } }
    protected Composite __D_Clear;
    public virtual Composite Source { get { return __D_Source; } set { __D_Source = value; } }
    protected Composite __D_Source;
    public virtual Composite Destination { get { return __D_Destination; } set { __D_Destination = value; } }
    protected Composite __D_Destination;
    public virtual Composite SourceIn { get { return __D_SourceIn; } set { __D_SourceIn = value; } }
    protected Composite __D_SourceIn;
    public virtual Composite DestinationIn { get { return __D_DestinationIn; } set { __D_DestinationIn = value; } }
    protected Composite __D_DestinationIn;
    public virtual Composite SourceOut { get { return __D_SourceOut; } set { __D_SourceOut = value; } }
    protected Composite __D_SourceOut;
    public virtual Composite DestinationOut { get { return __D_DestinationOut; } set { __D_DestinationOut = value; } }
    protected Composite __D_DestinationOut;
    public virtual Composite SourceAtop { get { return __D_SourceAtop; } set { __D_SourceAtop = value; } }
    protected Composite __D_SourceAtop;
    public virtual Composite DestinationAtop { get { return __D_DestinationAtop; } set { __D_DestinationAtop = value; } }
    protected Composite __D_DestinationAtop;

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

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 11; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual Composite Get(int index)
    {
        return (Composite)this.Array.Get(index);
    }
}