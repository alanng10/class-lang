class TableIter : Iter
{
    maide prusate Bool Init()
    {
        base.Init();
        this.ListIter : new Iter;
        this.ListIter.Init();
        return true;
    }

    field pronate Iter ListIter { get { return data; } set { data : value; } }

    field prusate Any Index
    {
        get
        {
            return this.Entry().Index;
        }
        set
        {
        }
    }

    field prusate Any Value
    {
        get
        {
            return this.Entry().Value;
        }
        set
        {
        }
    }

    maide prusate Bool Next()
    {
        return this.ListIter.Next();
    }

    maide private Entry Entry()
    {
        var Entry a;
        a : cast Entry(this.ListIter.Value);
        return a;
    }

    maide prusate Bool Clear()
    {
        this.ListIter.Clear();
        return true;
    }
}