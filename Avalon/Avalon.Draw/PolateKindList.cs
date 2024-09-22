namespace Avalon.Draw;

public class PolateKindList : Any
{
    public static PolateKindList This { get; } = ShareCreate();

    private static PolateKindList ShareCreate()
    {
        PolateKindList share;
        share = new PolateKindList();
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

        this.Linear = this.AddItem(Extern.Stat_PolateKindLinear(stat));
        this.Radial = this.AddItem(Extern.Stat_PolateKindRadial(stat));
        return true;
    }

    public virtual PolateKind Linear { get; set; }
    public virtual PolateKind Radial { get; set; }

    protected virtual PolateKind AddItem(ulong o)
    {
        PolateKind item;
        item = new PolateKind();
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

    protected virtual long ArrayCount { get { return 2; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual PolateKind Get(long index)
    {
        return (PolateKind)this.Array.GetAt(index);
    }
}