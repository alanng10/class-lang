class StatusList : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count : this.Array.Count;
        this.Index : 0;

        this.NoError : this.AddItem();
        this.ReadError : this.AddItem();
        this.WriteError : this.AddItem();
        this.FatalError : this.AddItem();
        this.ResourceError : this.AddItem();
        this.OpenError : this.AddItem();
        this.AbortError : this.AddItem();
        this.TimeOutError : this.AddItem();
        this.UnspecifiedError : this.AddItem();
        this.RemoveError : this.AddItem();
        this.RenameError : this.AddItem();
        this.PositionError : this.AddItem();
        this.ResizeError : this.AddItem();
        this.PermissionsError : this.AddItem();
        this.CopyError : this.AddItem();
        return true;
    }

    field prusate Status NoError { get { return data; } set { data : value; } }
    field prusate Status ReadError { get { return data; } set { data : value; } }
    field prusate Status WriteError { get { return data; } set { data : value; } }
    field prusate Status FatalError { get { return data; } set { data : value; } }
    field prusate Status ResourceError { get { return data; } set { data : value; } }
    field prusate Status OpenError { get { return data; } set { data : value; } }
    field prusate Status AbortError { get { return data; } set { data : value; } }
    field prusate Status TimeOutError { get { return data; } set { data : value; } }
    field prusate Status UnspecifiedError { get { return data; } set { data : value; } }
    field prusate Status RemoveError { get { return data; } set { data : value; } }
    field prusate Status RenameError { get { return data; } set { data : value; } }
    field prusate Status PositionError { get { return data; } set { data : value; } }
    field prusate Status ResizeError { get { return data; } set { data : value; } }
    field prusate Status PermissionsError { get { return data; } set { data : value; } }
    field prusate Status CopyError { get { return data; } set { data : value; } }

    maide precate Status AddItem()
    {
        var Status item;
        item : new Status;
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

    field precate Int ArrayCount { get { return 15; } set { } }

    field prusate Int Count { get { return data; } set { data : value; } }
    
    field precate Int Index { get { return data; } set { data : value; } }

    maide prusate Status Get(var Int index)
    {
        return cast Status(this.Array.Get(index));
    }
}