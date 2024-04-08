namespace Avalon.List;

public class Array : List
{
    public override bool Init()
    {
        this.InfraInfra = InfraInfra.This;
        this.Comparer = new Comparer();
        this.Comparer.Init();

        this.Value = new object[this.Count];
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }

    private object[] Value { get; set; }
    private Comparer Comparer { get; set; }

    public override object Add(object item)
    {
        return null;
    }

    public override object Insert(object index, object item)
    {
        return null;
    }

    public override bool Remove(object index)
    {
        return false;
    }

    public override bool Clear()
    {
        return false;
    }

    public virtual bool Contain(int index)
    {
        return !(index < 0) & (index < this.Count);
    }

    public virtual object Get(int index)
    {
        if (!this.Contain(index))
        {
            return null;
        }
        return this.Value[index];
    }

    public virtual bool Set(int index, object value)
    {
        if (!this.Contain(index))
        {
            return false;
        }
        this.Value[index] = value;
        return true;
    }

    public virtual bool Sort(Range range, Compare compare)
    {
        int index;
        index = range.Index;
        int count;
        count = range.Count;

        this.Comparer.CompareAny = compare;

        SystemArray.Sort<object>(this.Value, index, count, this.Comparer);
        
        this.Comparer.CompareAny = null;
        return true;
    }

    public override Iter IterCreate()
    {
        Iter a;
        a = new ArrayIter();
        a.Init();
        return a;
    }

    public override bool IterSet(Iter iter)
    {
        ArrayIter a;
        a = (ArrayIter)iter;
        a.Array = this;
        a.IntIndex = 0;
        a.CurrentIndex = -1;
        return true;
    }
}