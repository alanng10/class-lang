class AlignList : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count : this.Array.Count;
        this.Index : 0;

        this.Start : this.AddItem();
        this.Mid : this.AddItem();
        this.End : this.AddItem();
        return true;
    }

    field prusate Align Start { get { return data; } set { data : value; } }
    field prusate Align Mid { get { return data; } set { data : value; } }
    field prusate Align End { get { return data; } set { data : value; } }

    maide precate Align AddItem()
    {
        var Align item;
        item : new Align;
        item.Init();
        item.Index : this.Index;
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

    maide prusate Align Get(var Int index)
    {
        return cast Align(this.Array.Get(index));
    }
}