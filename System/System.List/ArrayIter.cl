class ArrayIter : Iter
{
    field pronate Array Array { get { return data; } set { data : value; } }
    field pronate Int IntIndex { get { return data; } set { data : value; } }
    field pronate Int CurrentIndex { get { return data; } set { data : value; } }

    maide prusate Bool Next()
    {
        var Int k;
        k : this.IntIndex;

        var Bool b;
        b : this.Array.Valid(k);

        inf (b)
        {
            this.CurrentIndex : k;
            this.IntIndex : k + 1;
        }
        return b;
    }

    field prusate Any Index
    {
        get
        {
            var Int k;
            k : this.CurrentIndex;
            inf (k = null)
            {
                return null;
            }

            var Any a;
            a : k;
            return a;
        }
        set
        {
        }
    }

    field prusate Any Value
    {
        get
        {
            var Int k;
            k : this.CurrentIndex;

            inf (k = null)
            {
                return null;
            }

            return this.Array.Get(k);
        }
        set
        {
        }
    }

    maide prusate Bool Clear()
    {
        this.Array : null;
        this.IntIndex : null;
        this.CurrentIndex : null;
        return true;
    }
}