namespace Avalon.Infra;

public class InternInfra : Any
{
    public static InternInfra This { get; } = ShareCreate();

    private static InternInfra ShareCreate()
    {
        InternInfra share;
        share = new InternInfra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InternIntern = Intern.This;

        long o;
        o = 1;
        o = o << 60;
        this.IntCapValue = o;
        return true;
    }

    public virtual String ModuleFoldPath { get; set; }
    protected virtual long IntCapValue { get; set; }
    protected virtual Intern InternIntern { get; set; }

    public virtual long DataByteListGet(object data, long index, long count)
    {
        Intern internIntern;
        internIntern = this.InternIntern;

        ulong oo;
        oo = 0;

        long i;
        i = 0;
        while (i < count)
        {
            long ob;
            ob = internIntern.DataGet(data, index + i);

            int shiftCount;
            shiftCount = (int)(i * 8);

            ulong o;
            o = (ulong)ob;
            o = o << shiftCount;

            oo = oo | o;

            i = i + 1;
        }
        long d;
        d = (this.IntCapValue - 1);
        ulong da;
        da = (ulong)d;
        ulong ka;
        ka = oo;
        ka = ka & da;

        long a;
        a = (long)ka;
        return a;
    }

    public virtual bool DataByteListSet(object data, long index, long count, long value)
    {
        Intern internIntern;
        internIntern = this.InternIntern;

        long d;
        d = this.IntCapValue - 1;
        ulong da;
        da = (ulong)d;
        ulong db;
        db = (ulong)value;
        ulong oo;
        oo = db;
        oo = oo & da;

        long i;
        i = 0;
        while (i < count)
        {
            int shiftCount;
            shiftCount = (int)(i * 8);

            ulong o;
            o = oo >> shiftCount;

            long oa;
            oa = (long)o;

            internIntern.DataSet(data, index + i, oa);

            i = i + 1;
        }
        return true;
    }

    public virtual long DataMidGet(object data, long index)
    {
        return this.DataByteListGet(data, index, sizeof(uint));
    }

    public virtual bool DataMidSet(object data, long index, long value)
    {
        return this.DataByteListSet(data, index, sizeof(uint), value);
    }

    public virtual long DataCharGet(object data, long index)
    {
        return this.DataMidGet(data, index);
    }

    public virtual bool DataCharSet(object data, long index, long value)
    {
        return this.DataMidSet(data, index, value);
    }
}