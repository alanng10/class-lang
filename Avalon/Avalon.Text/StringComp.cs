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
        this.InternInfra = InternInfra.This;
        this.InfraInfra = InfraInfra.This;
        return true;
    }

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

        byte[] value;
        value = new byte[dataCount];

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
        a = new String();
        a.Value = value;
        a.Count = count;
        a.Init();
        return a;
    }

    public virtual String CreateData(Data data, Range range)
    {
        if (data == null)
        {
            return null;
        }
        return this.CreateDataValue(data.Value, range);
    }

    public virtual String CreateString(String s, Range range)
    {
        if (s == null)
        {
            return null;
        }
        return this.CreateDataValue(s.Value, range);
    }

    private String CreateDataValue(byte[] data, Range range)
    {
        InternInfra internInfra;
        internInfra = this.InternInfra;

        long kka;
        kka = sizeof(uint);

        long dataCount;
        dataCount = data.LongLength;
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

        byte[] value;
        value = new byte[valueCount];

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
        a = new String();
        a.Value = value;
        a.Count = count;
        a.Init();
        return a;
    }

    public virtual long Count(String o)
    {
        if (o == null)
        {
            return -1;
        }

        return o.Count;
    }

    public virtual long Char(String o, long index)
    {
        long count;
        count = this.Count(o);

        if (!this.InfraInfra.ValidIndex(count, index))
        {
            return -1;
        }

        uint a;
        a = this.InternInfra.DataCharGet(o.Value, index * sizeof(uint));
        return a;
    }
}