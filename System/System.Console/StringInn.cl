class StringInn : Inn
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InfraInfra : share InfraInfra;
        this.TextInfra : share TextInfra;
        this.StringComp : share StringComp;
        this.Range : new Range;
        this.Range.Init();
        this.NewLineChar : this.TextInfra.Char(this.TextInfra.NewLine);
        return true;
    }

    field prusate String String { get { return data; } set { data : value; } }
    field prusate Int Index { get { return data; } set { data : value; } }
    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field precate TextInfra TextInfra { get { return data; } set { data : value; } }    
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate Range Range { get { return data; } set { data : value; } }
    field precate Int NewLineChar { get { return data; } set { data : value; } }

    maide prusate String Read()
    {
        var StringComp stringComp;
        stringComp : this.StringComp;

        var String k;
        k : this.String;
        var Int index;
        index : this.Index;

        var Int count;
        count : stringComp.Count(k);

        inf (~this.InfraInfra.ValidIndex(count, index))
        {
            return null;
        }

        var Range range;
        range : this.Range;

        var String a;

        var Int ka;
        ka : this.StringIndex(k, index, this.NewLineChar);

        var Bool b;
        b : (ka = null);

        inf (b)
        {
            var Int countA;
            countA : count - index;

            range.Index : index;
            range.Count : countA;

            a : stringComp.CreateString(k, range);

            index : count;
        }
        inf (~b)
        {
            var Int countB;
            countB : ka - index;

            range.Index : index;
            range.Count : countB;

            a : stringComp.CreateString(k, range);

            index : index + countB + 1;
        }
        
        this.Index : index;

        return a;
    }

    maide prusate Bool Reset()
    {
        this.Index : 0;
        return true;
    }

    maide private Int StringIndex(var String string, var Int index, var Int value)
    {
        var StringComp stringComp;
        stringComp : this.StringComp;

        var Int count;
        count : stringComp.Count(string);

        var Int i;
        i : index;
        while (i < count)
        {
            var Int ka;
            ka : stringComp.Char(string, i);
            
            inf (ka = value)
            {
                return i;
            }

            i : i + 1;
        }

        return null;
    }
}