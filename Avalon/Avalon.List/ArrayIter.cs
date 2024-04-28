namespace Avalon.List;

public class ArrayIter : Iter
{
    internal virtual Array Array { get; set; }
    internal virtual int IntIndex { get; set; }
    internal virtual int CurrentIndex { get; set; }

    public override bool Next()
    {
        bool b;
        b = this.Array.Contain(this.IntIndex);

        if (b)
        {
            this.CurrentIndex = this.IntIndex;
            this.IntIndex = this.IntIndex + 1;
        }
        return b;
    }

    public override object Index
    {
        get
        {
            if (this.CurrentIndex < 0)
            {
                return null;
            }
            object a;
            a = this.CurrentIndex;
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
            if (this.CurrentIndex < 0)
            {
                return null;
            }
            return this.Array.Get(this.CurrentIndex);
        }
        set
        {
        }
    }

    public virtual int ArrayIndex
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