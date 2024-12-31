class SlashJoinList : Any
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

        this.Miter : this.AddItem(extern.Stat_SlashJoinMiter(stat));
        this.Bevel : this.AddItem(extern.Stat_SlashJoinBevel(stat));
        this.Round : this.AddItem(extern.Stat_SlashJoinRound(stat));
        return true;
    }

    field prusate SlashJoin Miter { get { return data; } set { data : value; } }
    field prusate SlashJoin Bevel { get { return data; } set { data : value; } }
    field prusate SlashJoin Round { get { return data; } set { data : value; } }

    maide precate SlashJoin AddItem(var Int o)
    {
        var SlashJoin item;
        item : new SlashJoin;
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

    field precate Int ArrayCount { get { return 3; } set { } }

    field prusate Int Count { get { return data; } set { data : value; } }

    field precate Int Index { get { return data; } set { data : value; } }

    maide prusate SlashJoin Get(var Int index)
    {
        return cast SlashJoin(this.Array.Get(index));
    }
}