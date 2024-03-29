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

    public virtual Array ArrayCreate(int count)
    {
        Array a;
        a = new Array();
        a.Count = count;
        a.Init();
        return a;
    }

    public virtual Array ArrayCreateList(List list)
    {
        Array a;
        a = new Array();
        a.Count = list.Count;
        a.Init();
        
        Iter iter;
        iter = list.IterCreate();
        list.IterSet(iter);

        int count;
        count = a.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            object aa;
            aa = iter.Value;
            a.Set(i, aa);
            i = i + 1;
        }
        return a;
    }

    public virtual bool ArrayCopy(Array dest, int destIndex, Array source, int sourceIndex, int count)
    {
        int i;
        i = 0;
        while (i < count)
        {
            object o;
            o = source.Get(sourceIndex + i);
            dest.Set(destIndex + i, o);

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