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


    public virtual AddressKind IPv6 { get; set; }
    public virtual AddressKind IPv4 { get; set; }
    public virtual AddressKind Broadcast { get; set; }
    public virtual AddressKind LocalHost { get; set; }
    public virtual AddressKind LocalHostIPv6 { get; set; }
    public virtual AddressKind Any { get; set; }
    public virtual AddressKind AnyIPv6 { get; set; }
    public virtual AddressKind AnyIPv4 { get; set; }


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

    protected virtual Array Array { get; set; }

    protected virtual int ArrayCount
    { 
        get
        {
            return 8;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual AddressKind Get(int index)
    {
        return (AddressKind)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }

}