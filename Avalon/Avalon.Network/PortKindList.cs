namespace Avalon.Network;

public class PortKindList : Any
{
    public static PortKindList This { get; } = ShareCreate();

    private static PortKindList ShareCreate()
    {
        PortKindList share;
        share = new PortKindList();
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

        this.IPv6 = this.AddItem(Extern.Stat_NetworkPortKindIPv6(stat));
        this.IPv4 = this.AddItem(Extern.Stat_NetworkPortKindIPv4(stat));
        this.Broadcast = this.AddItem(Extern.Stat_NetworkPortKindBroadcast(stat));
        this.LocalHost = this.AddItem(Extern.Stat_NetworkPortKindLocalHost(stat));
        this.LocalHostIPv6 = this.AddItem(Extern.Stat_NetworkPortKindLocalHostIPv6(stat));
        this.Any = this.AddItem(Extern.Stat_NetworkPortKindAny(stat));
        this.AnyIPv6 = this.AddItem(Extern.Stat_NetworkPortKindAnyIPv6(stat));
        this.AnyIPv4 = this.AddItem(Extern.Stat_NetworkPortKindAnyIPv4(stat));
        return true;
    }

    public virtual PortKind IPv6 { get; set; }
    public virtual PortKind IPv4 { get; set; }
    public virtual PortKind Broadcast { get; set; }
    public virtual PortKind LocalHost { get; set; }
    public virtual PortKind LocalHostIPv6 { get; set; }
    public virtual PortKind Any { get; set; }
    public virtual PortKind AnyIPv6 { get; set; }
    public virtual PortKind AnyIPv4 { get; set; }

    protected virtual PortKind AddItem(ulong o)
    {
        int index;
        index = this.Index;

        PortKind item;
        item = new PortKind();
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

    protected virtual int ArrayCount { get { return 8; } set { } }

    public virtual int Count { get; set; }
    
    protected virtual int Index { get; set; }

    public virtual PortKind Get(int index)
    {
        return (PortKind)this.Array.GetAt(index);
    }
}