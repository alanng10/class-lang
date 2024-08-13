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
            object o;
            o = source.GetAt(sourceIndex + i);
            dest.SetAt(destIndex + i, o);

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
}