namespace Avalon.List;

public class ArrayIter : Iter
{
    internal virtual Array Array { get; set; }
    internal virtual long IntIndex { get; set; }
    internal virtual long CurrentIndex { get; set; }

    public override bool Next()
    {
        long k;
        k = this.IntIndex;

        bool b;
        b = this.Array.ValidAt(k);

        if (b)
        {
            this.CurrentIndex = k;
            this.IntIndex = k + 1;
        }
        return b;
    }

    public override object Index
    {
        get
        {
            long k;
            k = this.CurrentIndex;
            if (k < 0)
            {
                return null;
            }

            object a;
            a = k;
            return a;
        }
        set
        {
        }
    }

    public override object Value
    {
        get
        {
            long k;
            k = this.CurrentIndex;

            if (k < 0)
            {
                return null;
            }

            return this.Array.GetAt(k);
        }
        set
        {
        }
    }

    public virtual long ArrayIndex
    {
        get
        {
            return this.CurrentIndex;
        }
        set
        {
        }
    }
}