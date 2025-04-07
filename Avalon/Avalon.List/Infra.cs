namespace Avalon.List;

public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public virtual Array ArrayCreate(long count)
    {
        Array a;
        a = new Array();
        a.Count = count;
        a.Init();
        return a;
    }

    public virtual Array ArrayCreateList(List list)
    {
        Array array;
        array = new Array();
        array.Count = list.Count;
        array.Init();

        Iter iter;
        iter = list.IterCreate();
        list.IterSet(iter);

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            object a;
            a = iter.Value;
            array.SetAt(i, a);
            i = i + 1;
        }
        return array;
    }

    public virtual bool ArrayCopy(Array dest, long destIndex, Array source, long sourceIndex, long count)
    {
        long i;
        i = 0;
        while (i < count)
        {
            object k;
            k = source.GetAt(sourceIndex + i);
            dest.SetAt(destIndex + i, k);

            i = i + 1;
        }
        return true;
    }

    public virtual bool TableAdd(Table table, object index, object value)
    {
        Entry entry;
        entry = new Entry();
        entry.Init();
        entry.Index = index;
        entry.Value = value;
        table.Add(entry);
        return true;
    }

    public virtual bool Sort(Array array, Less less, Range range, Array copy)
    {
        long start;
        long end;
        start = range.Index;
        end = start + range.Count;

        this.CopyArray(copy, array, start, end);

        this.SplitMerge(array, copy, less, start, end);

        return true;
    }

    private bool SplitMerge(Array dest, Array source, Less less, long start, long end)
    {
        if (end - start < 2)
        {
            return true;
        }

        long mid;
        mid = (start + end) / 2;

        this.SplitMerge(source, dest, less, start, mid);

        this.SplitMerge(source, dest, less, mid, end);

        this.Merge(dest, source, less, start, mid, end);

        return true;
    }

    private bool Merge(Array dest, Array source, Less less, long start, long mid, long end)
    {
        long i;
        long j;
        i = start;
        j = mid;

        long k;
        k = start;

        while (i < mid & j < end)
        {
            object lite;
            object rite;
            lite = source.GetAt(i);
            rite = source.GetAt(j);

            long ke;
            ke = less.Execute(lite, rite);

            bool b;
            b = (0 < ke);

            if (!b)
            {
                dest.SetAt(k, lite);

                i = i + 1;
            }

            if (b)
            {
                dest.SetAt(k, rite);

                j = j + 1;
            }

            k = k + 1;
        }

        while (i < mid)
        {
            object ka;
            ka = source.GetAt(i);

            dest.SetAt(k, ka);

            i = i + 1;

            k = k + 1;
        }

        while (j < end)
        {
            object kb;
            kb = source.GetAt(j);

            dest.SetAt(k, kb);

            j = j + 1;

            k = k + 1;
        }

        return true;
    }


    private bool CopyArray(Array dest, Array source, long start, long end)
    {
        long count;
        count = end - start;

        this.ArrayCopy(dest, start, source, start, count);
        return true;
    }

    public virtual long Find(Array array, object any, Less less, Range range)
    {
        long start;
        long end;
        start = range.Index;
        end = start + range.Count;

        return this.BinaryFind(array, any, less, start, end);
    }

    private long BinaryFind(Array array, object any, Less less, long start, long end)
    {
        long count;
        count = end - start;
        if (count < 1)
        {
            return -1;
        }

        if (count == 1)
        {
            object ka;
            ka = array.GetAt(start);

            long kea;
            kea = less.Execute(any, ka);

            bool baa;
            baa = (kea == 0);

            if (baa)
            {
                return start;
            }
            if (!baa)
            {
                return -1;
            }
        }

        long mid;
        mid = (start + end) / 2;

        object k;
        k = array.GetAt(mid);

        long ke;
        ke = less.Execute(any, k);

        bool b;
        b = (ke < 0);
        if (b)
        {
            return this.BinaryFind(array, any, less, start, mid);
        }
        if (!b)
        {
            return this.BinaryFind(array, any, less, mid, end);
        }
        return -1;
    }
}