namespace Avalon.List;

public class Array : List
{
    public override bool Init()
    {
        this.InfraInfra = InfraInfra.This;

        long k;
        k = this.Count;

        this.Value = new object[k];
        return true;
    }

    public override object FirstIndex { get { return null; } set { } }
    public override object LastIndex { get { return null; } set { } }

    protected virtual InfraInfra InfraInfra { get; set; }
    private object[] Value { get; set; }

    public override object Add(object item)
    {
        return null;
    }

    public override object Ins(object index, object item)
    {
        return null;
    }

    public override bool Rem(object index)
    {
        return false;
    }

    public override bool Clear()
    {
        return false;
    }

    public override bool Valid(object index)
    {
        return false;
    }

    public override object Get(object index)
    {
        return null;
    }

    public override bool Set(object index, object value)
    {
        return false;
    }

    public virtual bool ValidAt(long index)
    {
        return this.InfraInfra.ValidIndex(this.Count, index);
    }

    public virtual object GetAt(long index)
    {
        if (!this.ValidAt(index))
        {
            return null;
        }
        return this.Value[index];
    }

    public virtual bool SetAt(long index, object value)
    {
        if (!this.ValidAt(index))
        {
            return false;
        }
        this.Value[index] = value;
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