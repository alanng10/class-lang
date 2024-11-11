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
            
        }
    }
}