class PolateSpreadList : Any
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

        this.Pad : this.AddItem(extern.Stat_PolateSpreadPad(stat));
        this.Reflect : this.AddItem(extern.Stat_PolateSpreadReflect(stat));
        this.Repeat : this.AddItem(extern.Stat_PolateSpreadRepeat(stat));
        return true;
    }

    field prusate PolateSpread Pad { get { return data; } set { data : value; } }
    field prusate PolateSpread Reflect { get { return data; } set { data : value; } }
    field prusate PolateSpread Repeat { get { return data; } set { data : value; } }

    maide precate PolateSpread AddItem(var Int o)
    {
        var PolateSpread item;
        item : new PolateSpread;
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

    maide prusate PolateSpread Get(var Int index)
    {
        return cast PolateSpread(this.Array.Get(index));
    }
}