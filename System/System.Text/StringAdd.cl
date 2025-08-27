class StringAdd : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InfraInfra : share InfraInfra;
        this.StringComp : share StringComp;

        this.Range : new Range;
        this.Range.Init();

        var Int capacity;
        capacity : 16;

        var Data data;
        data : new Data;
        data.Count : capacity * 4;
        data.Init();

        this.Data : data;
        this.Capacity : capacity;
        return true;
    }

    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate Range Range { get { return data; } set { data : value; } }
    field private Data Data { get { return data; } set { data : value; } }
    field private Int Count { get { return data; } set { data : value; } }
    field private Int Capacity { get { return data; } set { data : value; } }

    maide prusate String Result()
    {
        this.Range.Index : 0;
        this.Range.Count : this.Count;

        var String a;
        a : this.StringComp.CreateData(this.Data, this.Range);
        return a;
    }

    maide prusate Bool Clear()
    {
        this.Count : 0;
        return true;
    }

    maide prusate Bool Execute(var Int value)
    {
        var InfraInfra infraInfra;
        infraInfra : this.InfraInfra;

        var Int count;
        var Int capacity;
        count : this.Count;
        capacity : this.Capacity;

        var Data data;
        data : this.Data;

        var Int kka;
        kka : 4;

        inf (~(count < capacity))
        {
            var Int ka;
            ka : capacity * 2;

            var Int kd;
            kd : ka * kka;

            var Data k;
            k : new Data;
            k.Count : kd;
            k.Init();

            var Int kk;
            kk : count * kka;
            infraInfra.DataCopy(k, 0, data, 0, kk);

            data : k;

            capacity : ka;

            this.Data : data;

            this.Capacity : capacity;
        }

        var Int ke;
        ke : count * kka;

        infraInfra.DataCharSet(data, ke, value);

        count : count + 1;

        this.Count : count;

        return true;
    }
}