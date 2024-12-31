class SlashLineList : Any
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

        this.Solid : this.AddItem(extern.Stat_SlashLineSolid(stat));
        this.Dash : this.AddItem(extern.Stat_SlashLineDash(stat));
        this.Dot : this.AddItem(extern.Stat_SlashLineDot(stat));
        this.DashDot : this.AddItem(extern.Stat_SlashLineDashDot(stat));
        this.DashDotDot : this.AddItem(extern.Stat_SlashLineDashDotDot(stat));
        return true;
    }

    field prusate SlashLine Solid { get { return data; } set { data : value; } }
    field prusate SlashLine Dash { get { return data; } set { data : value; } }
    field prusate SlashLine Dot { get { return data; } set { data : value; } }
    field prusate SlashLine DashDot { get { return data; } set { data : value; } }
    field prusate SlashLine DashDotDot { get { return data; } set { data : value; } }

    maide precate SlashLine AddItem(var Int o)
    {
        var SlashLine item;
        item : new SlashLine;
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

    field precate Int ArrayCount { get { return 5; } set { } }

    field prusate Int Count { get { return data; } set { data : value; } }

    field precate Int Index { get { return data; } set { data : value; } }

    maide prusate SlashLine Get(var Int index)
    {
        return cast SlashLine(this.Array.Get(index));
    }
}