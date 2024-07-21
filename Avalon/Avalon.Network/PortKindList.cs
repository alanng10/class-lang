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

    public virtual PortKind IPv6 { get { return __D_IPv6; } set { __D_IPv6 = value; } }
    protected PortKind __D_IPv6;
    public virtual PortKind IPv4 { get { return __D_IPv4; } set { __D_IPv4 = value; } }
    protected PortKind __D_IPv4;
    public virtual PortKind Broadcast { get { return __D_Broadcast; } set { __D_Broadcast = value; } }
    protected PortKind __D_Broadcast;
    public virtual PortKind LocalHost { get { return __D_LocalHost; } set { __D_LocalHost = value; } }
    protected PortKind __D_LocalHost;
    public virtual PortKind LocalHostIPv6 { get { return __D_LocalHostIPv6; } set { __D_LocalHostIPv6 = value; } }
    protected PortKind __D_LocalHostIPv6;
    public virtual PortKind Any { get { return __D_Any; } set { __D_Any = value; } }
    protected PortKind __D_Any;
    public virtual PortKind AnyIPv6 { get { return __D_AnyIPv6; } set { __D_AnyIPv6 = value; } }
    protected PortKind __D_AnyIPv6;
    public virtual PortKind AnyIPv4 { get { return __D_AnyIPv4; } set { __D_AnyIPv4 = value; } }
    protected PortKind __D_AnyIPv4;

    protected virtual PortKind AddItem(ulong o)
    {
        PortKind item;
        item = new PortKind();
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

    protected virtual int ArrayCount { get { return 8; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual PortKind Get(int index)
    {
        return (PortKind)this.Array.GetAt(index);
    }
}