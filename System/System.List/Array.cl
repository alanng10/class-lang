class Array : List
{
    maide prusate Bool Init()
    {
        this.InternIntern : share Intern;
        this.InfraInfra : share InfraInfra;

        var Int k;
        k : this.Count;

        this.Value : this.InternIntern.ArrayNew(k);
        return true;
    }

    field prusate Any Start { get { } set { } }
    field prusate Any End { get { } set { } }
    field private Intern InternIntern { get { return data; } set { data : value; } }
    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field private Any Value { get { return data; } set { data : value; } }

    maide prusate Any Add(var Any item)
    {
        return null;
    }

    maide prusate Any Ins(var Any index, var Any item)
    {
        return null;
    }

    maide prusate Bool Rem(var Any index)
    {
        return false;
    }

    maide prusate Bool Clear()
    {
        return false;
    }

    maide prusate Bool Valid(var Any index)
    {
        var Int k;
        k : cast Int(index);

        return this.InfraInfra.ValidIndex(this.Count, k);
    }

    maide prusate Any Get(var Any index)
    {
        inf (~this.Valid(index))
        {
            return null;
        }

        var Int k;
        k : cast Int(index);

        return this.InternIntern.ArrayGet(this.Value, k);
    }

    maide prusate Bool Set(var Any index, var Any value)
    {
        inf (~this.Valid(index))
        {
            return false;
        }

        var Int k;
        k : cast Int(index);

        this.InternIntern.ArraySet(this.Value, k, value);
        return true;
    }

    maide prusate Iter IterCreate()
    {
        var Iter a;
        a : new ArrayIter;
        a.Init();
        return a;
    }

    maide prusate Bool IterSet(var Iter iter)
    {
        var ArrayIter a;
        a : cast ArrayIter(iter);
        a.Array : this;
        a.IntIndex : 0;
        a.CurrentIndex : null;
        return true;
    }
}