namespace Avalon.Infra;

public class StringComp : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = Infra.This;
        return true;
    }

    private InternIntern InternIntern { get; set; }
    protected virtual Infra InfraInfra { get; set; }

    public virtual String CreateChar(uint c, long count)
    {
        Infra infraInfra;
        infraInfra = this.InfraInfra;

        if (count < 0)
        {
            return null;
        }

        int ko;
        ko = sizeof(uint);

        long ka;
        ka = count * ko;
        
        Data data;
        data = new Data();
        data.Count = ka;
        data.Init();

        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i * ko;

            infraInfra.DataMidSet(data, index, c);

            i = i + 1;
        }

        String a;
        a = new String();
        a.Data = data;
        a.Count = count;
        a.Init();
        
        return a;
    }

    public virtual String CreateData(Data data, Range range)
    {
        Infra infraInfra;
        infraInfra = this.InfraInfra;

        long dataCount;
        dataCount = data.Count;
        long totalCount;
        totalCount = dataCount / sizeof(uint);

        long index;
        long count;
        index = 0;
        count = 0;
        bool b;
        b = (range == null);
        if (b)
        {
            index = 0;
            count = totalCount;
        }
        if (!b)
        {
            index = range.Index;
            count = range.Count;
            if (!infraInfra.ValidRange(totalCount, index, count))
            {
                return null;
            }
        }

        String a;
        a = null;
        
        bool ba;
        ba = (data is StringData);

        if (!ba)
        {
            Data kk;
            kk = new Data();
            kk.Count = count * sizeof(uint);
            kk.Init();

            long i;
            i = 0;
            while (i < count)
            {
                long ke;
                ke = i * sizeof(uint);

                uint aa;
                aa = infraInfra.DataCharGet(data, ke + index);

                infraInfra.DataCharSet(kk, ke, aa);

                i = i + 1;
            }

            a = new String();
            a.DataData = kk;
            a.CountData = count;
            a.Init();
        }

        if (ba)
        {
            StringData stringData;
            stringData = (StringData)data;

            string dataString;
            dataString = stringData.ValueString;

            a = dataString.Substring(index, count);
        }
        
        return a;
    }
}