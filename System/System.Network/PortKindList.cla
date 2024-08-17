class PortKindList : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count : this.Array.Count;
        this.Index : 0;

        var Extern extern;
        extern : share Extern;

        var Int varShare;
        varShare : extern.Infra_Share();
        var Int stat;
        stat : extern.Share_Stat(varShare);

        this.IPv6 : this.AddItem(extern.Stat_NetworkPortKindIPv6(stat));
        this.IPv4 : this.AddItem(extern.Stat_NetworkPortKindIPv4(stat));
        this.Broadcast : this.AddItem(extern.Stat_NetworkPortKindBroadcast(stat));
        this.LocalHost : this.AddItem(extern.Stat_NetworkPortKindLocalHost(stat));
        this.LocalHostIPv6 : this.AddItem(extern.Stat_NetworkPortKindLocalHostIPv6(stat));
        this.Any : this.AddItem(extern.Stat_NetworkPortKindAny(stat));
        this.AnyIPv6 : this.AddItem(extern.Stat_NetworkPortKindAnyIPv6(stat));
        this.AnyIPv4 : this.AddItem(extern.Stat_NetworkPortKindAnyIPv4(stat));
        return true;
    }

    field prusate PortKind IPv6 { get { return data; } set { data : value; } }
    field prusate PortKind IPv4 { get { return data; } set { data : value; } }
    field prusate PortKind Broadcast { get { return data; } set { data : value; } }
    field prusate PortKind LocalHost { get { return data; } set { data : value; } }
    field prusate PortKind LocalHostIPv6 { get { return data; } set { data : value; } }
    field prusate PortKind Any { get { return data; } set { data : value; } }
    field prusate PortKind AnyIPv6 { get { return data; } set { data : value; } }
    field prusate PortKind AnyIPv4 { get { return data; } set { data : value; } }

    maide precate PortKind AddItem(var Int o)
    {
        var PortKind item;
        item : new PortKind;
        item.Init();
        item.Index : this.Index;
        item.Intern : o;
        this.Array.Set(item.Index, item);
        this.Index : this.Index + 1;
        return item;
    }

    maide precate Bool InitArray()
    {
        this.Array : new Array;
        this.Array.Count : this.ArrayCount;
        this.Array.Init();
        return true;
    }

    field precate Array Array { get { return data; } set { data : value; } }

    field precate Int ArrayCount { get { return 8; } set { } }

    field prusate Int Count { get { return data; } set { data : value; } }
    
    field precate Int Index { get { return data; } set { data : value; } }

    maide prusate PortKind Get(var Int index)
    {
        return cast PortKind(this.Array.Get(index));
    }
}