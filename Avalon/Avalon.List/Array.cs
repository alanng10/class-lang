namespace Avalon.List;

public class Array : List
{
    public override bool Init()
    {
        this.InfraInfra = InfraInfra.This;
        this.Comparer = new Comparer();
        this.Comparer.Init();

        long k;
        k = this.Count;

        if (!this.ValidCount(k))
        {
            return false;
        }

        this.Value = new object[k];
        return true;
    }

    public override object FirstIndex { get { return null; } set { } }
    public override object LastIndex { get { return null; } set { } }

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

    public virtual bool ValidCount(long value)
    {
        return !(value < 0);
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

    public virtual bool Sort(Compare compare, Range range, Array array)
    {
        return true;
    }


    private bool Merge(Compare compare, object[] B, object[] A, long start, long mid, long end)
    {
        long i;
        long j;
        i = start;
        j = mid;

        long k;
        k = start;
        
        while (i < mid & j < end)
        {
            object left;
            object right;
            left = A[i];
            right = A[j];

            int ka;
            ka = compare.Execute(left, right);

            bool b;
            b = (0 < ka);
            
            if (!b)
            {
                B[k] = A[i];

                i = i + 1;
            }

            if (b)
            {
                B[k] = A[j];

                j = j + 1;
            }

            k = k + 1;
        }

        while (i < mid)
        {
            B[k] = A[i];

            i = i + 1;

            k = k + 1;
        }

        while (j < end)
        {
            B[k] = A[j];

            j = j + 1;

            k = k + 1;
        }

        return true;
    }


    private bool CopyArray(object[] dest, object[] source, long start, long end)
    {
        long count;
        count = end - start;
        
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = start + i;

            dest[index] = source[index];

            i = i + 1;
        }
        return true;
    }
}