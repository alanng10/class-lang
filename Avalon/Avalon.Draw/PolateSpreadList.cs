namespace Avalon.Draw;

public class PolateSpreadList : Any
{
    public static PolateSpreadList This { get; } = ShareCreate();

    private static PolateSpreadList ShareCreate()
    {
        PolateSpreadList share;
        share = new PolateSpreadList();
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

        this.Pad = this.AddItem(Extern.Stat_PolateSpreadPad(stat));
        this.Reflect = this.AddItem(Extern.Stat_PolateSpreadReflect(stat));
        this.Repeat = this.AddItem(Extern.Stat_PolateSpreadRepeat(stat));
        return true;
    }

    public virtual PolateSpread Pad { get; set; }
    public virtual PolateSpread Reflect { get; set; }
    public virtual PolateSpread Repeat { get; set; }

    protected virtual PolateSpread AddItem(ulong o)
    {
        PolateSpread item;
        item = new PolateSpread();
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

    protected virtual long ArrayCount { get { return 3; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual PolateSpread Get(long index)
    {
        return (PolateSpread)this.Array.GetAt(index);
    }
}