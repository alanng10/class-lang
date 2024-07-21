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

    public virtual Comp SourceOver { get { return __D_SourceOver; } set { __D_SourceOver = value; } }
    protected Comp __D_SourceOver;
    public virtual Comp DestinationOver { get { return __D_DestinationOver; } set { __D_DestinationOver = value; } }
    protected Comp __D_DestinationOver;
    public virtual Comp Clear { get { return __D_Clear; } set { __D_Clear = value; } }
    protected Comp __D_Clear;
    public virtual Comp Source { get { return __D_Source; } set { __D_Source = value; } }
    protected Comp __D_Source;
    public virtual Comp Destination { get { return __D_Destination; } set { __D_Destination = value; } }
    protected Comp __D_Destination;
    public virtual Comp SourceIn { get { return __D_SourceIn; } set { __D_SourceIn = value; } }
    protected Comp __D_SourceIn;
    public virtual Comp DestinationIn { get { return __D_DestinationIn; } set { __D_DestinationIn = value; } }
    protected Comp __D_DestinationIn;
    public virtual Comp SourceOut { get { return __D_SourceOut; } set { __D_SourceOut = value; } }
    protected Comp __D_SourceOut;
    public virtual Comp DestinationOut { get { return __D_DestinationOut; } set { __D_DestinationOut = value; } }
    protected Comp __D_DestinationOut;
    public virtual Comp SourceAtop { get { return __D_SourceAtop; } set { __D_SourceAtop = value; } }
    protected Comp __D_SourceAtop;
    public virtual Comp DestinationAtop { get { return __D_DestinationAtop; } set { __D_DestinationAtop = value; } }
    protected Comp __D_DestinationAtop;

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

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 11; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual Comp Get(int index)
    {
        return (Comp)this.Array.Get((object)index);
    }
}