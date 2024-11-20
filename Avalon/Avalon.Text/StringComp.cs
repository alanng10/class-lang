namespace Avalon.Text;

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
        this.InternIntern = Intern.This;
        this.InternInfra = InternInfra.This;
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    private Intern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }

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

        long dataCount;
        dataCount = count * ko;

        object value;
        value = this.InternIntern.DataNew(dataCount);

        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i * ko;

            internInfra.DataCharSet(value, index, c);

            i = i + 1;
        }

        String a;
        a = this.InternIntern.StringNew();
        this.InternIntern.StringValueSet(a, value);
        this.InternIntern.StringCountSet(a, count);
        return a;
    }

    public virtual String CreateData(Data data, Range range)
    {
        if (data == null)
        {
            return null;
        }
        return this.CreateDataValue(data.Value, data.Count, range);
    }

    public virtual String CreateString(String s, Range range)
    {
        if (s == null)
        {
            return null;
        }

        object k;
        k = this.InternIntern.StringValueGet(s);

        long count;
        count = this.Count(s);
        count = count * sizeof(uint);

        return this.CreateDataValue(k, count, range);
    }

    private String CreateDataValue(object data, long dataCount, Range range)
    {
        InternInfra internInfra;
        internInfra = this.InternInfra;

        long kka;
        kka = sizeof(uint);

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

            if (!this.InfraInfra.ValidRange(totalCount, index, count))
            {
                return null;
            }
        }

        long valueCount;
        valueCount = count * kka;

        object value;
        value = this.InternIntern.DataNew(valueCount);

        long i;
        i = 0;
        while (i < count)
        {
            long ka;
            long kb;
            ka = (index + i) * kka;
            kb = i * kka;

            uint n;
            n = internInfra.DataCharGet(data, ka);

            internInfra.DataCharSet(value, kb, n);

            i = i + 1;
        }

        String a;
        a = this.InternIntern.StringNew();
        this.InternIntern.StringValueSet(a, value);
        this.InternIntern.StringCountSet(a, count);
        return a;
    }

    public virtual long Count(String s)
    {
        if (s == null)
        {
            return -1;
        }

        return this.InternIntern.StringCountGet(s);
    }

    public virtual long Char(String s, long index)
    {
        long count;
        count = this.Count(s);

        if (!this.InfraInfra.ValidIndex(count, index))
        {
            return -1;
        }

        object k;
        k = this.InternIntern.StringValueGet(s);

        long ka;
        ka = index * sizeof(uint);

        uint a;
        a = this.InternInfra.DataCharGet(k, ka);
        return a;
    }
}