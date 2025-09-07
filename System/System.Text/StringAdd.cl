class StringAdd : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InfraInfra : share InfraInfra;
        this.StringComp : share StringComp;

        this.Range : new Range;
        this.Range.Init();

        var Int capaci;
        capaci : 16;

        var Data data;
        data : new Data;
        data.Count : capaci * 4;
        data.Init();

        this.Data : data;
        this.Capaci : capaci;
        return true;
    }

    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate Range Range { get { return data; } set { data : value; } }
    field private Data Data { get { return data; } set { data : value; } }
    field private Int Count { get { return data; } set { data : value; } }
    field private Int Capaci { get { return data; } set { data : value; } }

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
        var Int count;
        var Int capaci;
        count : this.Count;
        capaci : this.Capaci;

        var Data data;
        data : this.Data;

        var Int kka;
        kka : 4;

        inf (~(count < capaci))
        {
            var Int ka;
            ka : capaci * 2;

            var Int kd;
            kd : ka * kka;

            var Data k;
            k : new Data;
            k.Count : kd;
            k.Init();

            var Int kk;
            kk : count * kka;
            this.InfraInfra.DataCopy(k, 0, data, 0, kk);

            data : k;

            capaci : ka;

            this.Data : data;

            this.Capaci : capaci;
        }

        var Int ke;
        ke : count * kka;

        this.InfraInfra.DataCharSet(data, ke, value);

        count : count + 1;

        this.Count : count;

        return true;
    }
}