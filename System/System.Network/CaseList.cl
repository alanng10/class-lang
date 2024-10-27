class CaseList : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count : this.Array.Count;
        this.Index : 0;

        this.Unconnected : this.AddItem();
        this.HostLookup : this.AddItem();
        this.Connecting : this.AddItem();
        this.Connected : this.AddItem();
        this.Bound : this.AddItem();
        this.Listening : this.AddItem();
        this.Closing : this.AddItem();
        return true;
    }

    field prusate Case Unconnected { get { return data; } set { data : value; } }
    field prusate Case HostLookup { get { return data; } set { data : value; } }
    field prusate Case Connecting { get { return data; } set { data : value; } }
    field prusate Case Connected { get { return data; } set { data : value; } }
    field prusate Case Bound { get { return data; } set { data : value; } }
    field prusate Case Listening { get { return data; } set { data : value; } }
    field prusate Case Closing { get { return data; } set { data : value; } }

    maide precate Case AddItem()
    {
        var Case item;
        item : new Case;
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

    field precate Int ArrayCount { get { return 7; } set { } }

    field prusate Int Count { get { return data; } set { data : value; } }
    
    field precate Int Index { get { return data; } set { data : value; } }

    maide prusate Case Get(var Int index)
    {
        return cast Case(this.Array.Get(index));
    }
}