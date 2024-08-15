namespace Avalon.Infra;

public class StringComp : Any
{
    public static StringComp This { get; } = ShareCreate();

    private static StringComp ShareCreate()
    {
        StringComp share;
        share = new StringComp();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InternInfra = InternInfra.This;
        return true;
    }

    private InternInfra InternInfra { get; set; }

    public virtual String CreateChar(uint c, long count)
    {
        InternInfra internInfra;
        internInfra = this.InternInfra;

        if (count < 0)
        {
            return null;
        }

        long ko;
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

            internInfra.DataCharSet(data.Value, index, c);

            i = i + 1;
        }

        String a;
        a = new String();
        a.Data = data;
        a.Count = count;
        a.Init();
        return a;
    }

    public virtual String CreateString(String s, Range range)
    {
        return this.CreateData(s.Data, range);
    }

    public virtual String CreateData(Data data, Range range)
    {
        InternInfra internInfra;
        internInfra = this.InternInfra;

        long kka;
        kka = sizeof(uint);

        long dataCount;
        dataCount = data.Count;
        long totalCount;
        totalCount = dataCount / kka;

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
            if (!internInfra.ValidRange(totalCount, index, count))
            {
                return null;
            }
        }

        Data dest;
        dest = new Data();
        dest.Count = count * kka;
        dest.Init();

        long i;
        i = 0;
        while (i < count)
        {
            long kea;
            long keb;
            kea = (i + index) * kka;
            keb = i * kka;

            uint aa;
            aa = internInfra.DataCharGet(data.Value, kea);

            internInfra.DataCharSet(dest.Value, keb, aa);

            i = i + 1;
        }

        String a;
        a = new String();
        a.Data = dest;
        a.Count = count;
        a.Init();
        return a;
    }

    public virtual long Count(String o)
    {
        return o.Count;
    }

    public virtual long Char(String o, long index)
    {
        InternInfra internInfra;
        internInfra = this.InternInfra;

        long count;
        count = this.Count(o);

        if (!internInfra.ValidIndex(count, index))
        {
            return -1;
        }

        uint a;
        a = internInfra.DataCharGet(o.Data.Value, index * sizeof(uint));
        return a;
    }
}