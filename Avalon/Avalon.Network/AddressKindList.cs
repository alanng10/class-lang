namespace Avalon.Network;

public class AddressKindList : Any
{
    public static AddressKindList This { get; } = ShareCreate();

    private static AddressKindList ShareCreate()
    {
        AddressKindList share;
        share = new AddressKindList();
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

        this.IPv6 = this.AddItem(Extern.Stat_NetworkAddressKindIPv6(stat));
        this.IPv4 = this.AddItem(Extern.Stat_NetworkAddressKindIPv4(stat));
        this.Broadcast = this.AddItem(Extern.Stat_NetworkAddressKindBroadcast(stat));
        this.LocalHost = this.AddItem(Extern.Stat_NetworkAddressKindLocalHost(stat));
        this.LocalHostIPv6 = this.AddItem(Extern.Stat_NetworkAddressKindLocalHostIPv6(stat));
        this.Any = this.AddItem(Extern.Stat_NetworkAddressKindAny(stat));
        this.AnyIPv6 = this.AddItem(Extern.Stat_NetworkAddressKindAnyIPv6(stat));
        this.AnyIPv4 = this.AddItem(Extern.Stat_NetworkAddressKindAnyIPv4(stat));
        return true;
    }

    public virtual AddressKind IPv6 { get { return __D_IPv6; } set { __D_IPv6 = value; } }
    protected AddressKind __D_IPv6;
    public virtual AddressKind IPv4 { get { return __D_IPv4; } set { __D_IPv4 = value; } }
    protected AddressKind __D_IPv4;
    public virtual AddressKind Broadcast { get { return __D_Broadcast; } set { __D_Broadcast = value; } }
    protected AddressKind __D_Broadcast;
    public virtual AddressKind LocalHost { get { return __D_LocalHost; } set { __D_LocalHost = value; } }
    protected AddressKind __D_LocalHost;
    public virtual AddressKind LocalHostIPv6 { get { return __D_LocalHostIPv6; } set { __D_LocalHostIPv6 = value; } }
    protected AddressKind __D_LocalHostIPv6;
    public virtual AddressKind Any { get { return __D_Any; } set { __D_Any = value; } }
    protected AddressKind __D_Any;
    public virtual AddressKind AnyIPv6 { get { return __D_AnyIPv6; } set { __D_AnyIPv6 = value; } }
    protected AddressKind __D_AnyIPv6;
    public virtual AddressKind AnyIPv4 { get { return __D_AnyIPv4; } set { __D_AnyIPv4 = value; } }
    protected AddressKind __D_AnyIPv4;

    protected virtual AddressKind AddItem(ulong o)
    {
        AddressKind item;
        item = new AddressKind();
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

    protected virtual int ArrayCount { get { return 8; } set { } }
    protected int _D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual AddressKind Get(int index)
    {
        return (AddressKind)this.Array.Get(index);
    }
}