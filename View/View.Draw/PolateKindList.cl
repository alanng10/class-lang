class PolateKindList : Any
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

        this.Linear : this.AddItem(extern.Stat_PolateKindLinear(stat));
        this.Radial : this.AddItem(extern.Stat_PolateKindRadial(stat));
        return true;
    }

    field prusate PolateKind Linear { get { return data; } set { data : value; } }
    field prusate PolateKind Radial { get { return data; } set { data : value; } }

    maide precate PolateKind AddItem(var Int o)
    {
        var PolateKind item;
        item : new PolateKind;
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

    field precate Int ArrayCount { get { return 2; } set { } }

    field prusate Int Count { get { return data; } set { data : value; } }

    field precate Int Index { get { return data; } set { data : value; } }

    maide prusate PolateKind Get(var Int index)
    {
        return cast PolateKind(this.Array.Get(index));
    }
}