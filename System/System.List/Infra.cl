class Infra : Any
{
    maide prusate Array ArrayCreate(var Int count)
    {
        var Array a;
        a : new Array;
        a.Count : count;
        a.Init();
        return a;
    }

    maide prusate Array ArrayCreateList(var List list)
    {
        var Array array;
        array : new Array;
        array.Count : list.Count;
        array.Init();
        
        var Iter iter;
        iter : list.IterCreate();
        list.IterSet(iter);

        var Int count;
        count : array.Count;
        var Int i;
        i : 0;
        while (i < count)
        {
            iter.Next();
            var Any a;
            a : iter.Value;
            array.Set(i, a);
            i : i + 1;
        }
        return array;
    }

    maide prusate Bool ArrayCopy(var Array dest, var Int destIndex, var Array source, var Int sourceIndex, var Int count)
    {
        var Int i;
        i : 0;
        while (i < count)
        {
            var Any k;
            k : source.Get(sourceIndex + i);
            dest.Set(destIndex + i, k);

            i : i + 1;
        }
        return true;
    }

    maide prusate Bool TableAdd(var Table table, var Any index, var Any value)
    {
        var Entry entry;
        entry : new Entry;
        entry.Init();
        entry.Index : index;
        entry.Value : value;
        table.Add(entry);
        return true;
    }

    maide prusate Bool Sort(var Array array, var Less less, var Range range, var Array copy)
    {
        var Int start;
        var Int end;
        start : range.Index;
        end : start + range.Count;

        this.CopyArray(copy, array, start, end);

        this.SplitMerge(array, copy, less, start, end);

        return true;
    }

    maide private Bool SplitMerge(var Array dest, var Array source, var Less less, var Int start, var Int end)
    {
        inf (end - start < 2)
        {
            return true;
        }

        var Int mid;
        mid : (start + end) / 2;

        this.SplitMerge(source, dest, less, start, mid);

        this.SplitMerge(source, dest, less, mid, end);

        this.Merge(dest, source, less, start, mid, end);

        return true;
    }

    maide private Bool Merge(var Array dest, var Array source, var Less less, var Int start, var Int mid, var Int end)
    {
        var Int i;
        var Int j;
        i : start;
        j : mid;

        var Int k;
        k : start;

        while (i < mid & j < end)
        {
            var Any lite;
            var Any rite;
            lite : source.Get(i);
            rite : source.Get(j);

            var Int ke;
            ke : less.Execute(lite, rite);

            var Bool b;
            b : (sign<(0, ke));

            inf (~b)
            {
                dest.Set(k, lite);

                i : i + 1;
            }

            inf (b)
            {
                dest.Set(k, rite);

                j : j + 1;
            }

            k : k + 1;
        }

        while (i < mid)
        {
            var Any ka;
            ka : source.Get(i);

            dest.Set(k, ka);

            i : i + 1;

            k : k + 1;
        }

        while (j < end)
        {
            var Any kb;
            kb : source.Get(j);

            dest.Set(k, kb);

            j : j + 1;

            k : k + 1;
        }

        return true;
    }

    maide private Bool CopyArray(var Array dest, var Array source, var Int start, var Int end)
    {
        var Int count;
        count : end - start;

        this.ArrayCopy(dest, start, source, start, count);
        return true;
    }

    maide prusate Int Find(var Array array, var Any any, var Less less, var Range range)
    {
        var Int start;
        var Int end;
        start : range.Index;
        end : start + range.Count;

        return this.BinaryFind(array, any, less, start, end);
    }

    maide private Int BinaryFind(var Array array, var Any any, var Less less, var Int start, var Int end)
    {
        var Int count;
        count : end - start;
        inf (count < 1)
        {
            return null;
        }

        inf (count = 1)
        {
            var Any ka;
            ka : array.Get(start);

            var Int kea;
            kea : less.Execute(any, ka);

            var Bool baa;
            baa : (kea = 0);

            inf (baa)
            {
                return start;
            }
            inf (~baa)
            {
                return null;
            }
        }

        var Int mid;
        mid : (start + end) / 2;

        var Any k;
        k : array.Get(mid);

        var Int ke;
        ke : less.Execute(any, k);

        var Bool b;
        b : (sign<(ke, 0));
        inf (b)
        {
            return this.BinaryFind(array, any, less, start, mid);
        }
        inf (~b)
        {
            return this.BinaryFind(array, any, less, mid, end);
        }
    }
}