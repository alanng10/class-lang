namespace Avalon.Infra;

public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.StringComp = StringComp.This;

        long o;
        o = 1;
        o = o << 60;
        this.IntCapValue = o;
        return true;
    }

    public virtual long IntCapValue { get; set; }
    protected virtual StringComp StringComp { get; set; }

    public virtual bool ValidIndex(long count, long index)
    {
        return this.ValidRange(count, index, 1);
    }

    public virtual bool ValidRange(long totalCount, long index, long count)
    {
        if (totalCount < 0)
        {
            return false;
        }
        if (index < 0)
        {
            return false;
        }
        if (count < 0)
        {
            return false;
        }
        if (totalCount < index + count)
        {
            return false;
        }
        return true;
    }

    public virtual bool IndexRange(Range range, long index)
    {
        range.Index = index;
        range.Count = 1;
        return true;
    }

    public virtual ulong DataIntGet(Data data, long index)
    {
        return this.DataByteListGet(data, index, sizeof(ulong));
    }

    public virtual uint DataMidGet(Data data, long index)
    {
        return (uint)this.DataByteListGet(data, index, sizeof(uint));
    }

    public virtual ushort DataShortGet(Data data, long index)
    {
        return (ushort)this.DataByteListGet(data, index, sizeof(ushort));
    }

    public virtual uint DataCharGet(Data data, long index)
    {
        return this.DataMidGet(data, index);
    }

    public virtual bool DataIntSet(Data data, long index, ulong value)
    {
        return this.DataByteListSet(data, index, sizeof(ulong), value);
    }

    public virtual bool DataMidSet(Data data, long index, uint value)
    {
        return this.DataByteListSet(data, index, sizeof(uint), value);
    }

    public virtual bool DataShortSet(Data data, long index, ushort value)
    {
        return this.DataByteListSet(data, index, sizeof(ushort), value);
    }

    public virtual bool DataCharSet(Data data, long index, uint value)
    {
        return this.DataMidSet(data, index, value);
    }

    public virtual ulong DataByteListGet(Data data, long index, long count)
    {
        ulong oo;
        oo = 0;

        long i;
        i = 0;
        while (i < count)
        {
            byte ob;
            ob = (byte)data.Get(index + i);

            int shiftCount;
            shiftCount = (int)(i * 8);
            
            ulong o;
            o = ob;
            o = o << shiftCount;

            oo = oo | o;

            i = i + 1;
        }
        long d;
        d = (this.IntCapValue - 1);
        ulong da;
        da = (ulong)d;
        ulong a;
        a = oo;
        a = a & da;
        return a;
    }

    public virtual bool DataByteListSet(Data data, long index, long count, ulong value)
    {
        long d;
        d = this.IntCapValue - 1;
        ulong da;
        da = (ulong)d;
        ulong oo;
        oo = value;
        oo = oo & da;

        long i;
        i = 0;
        while (i < count)
        {
            int shiftCount;
            shiftCount = (int)(i * 8);

            ulong o;
            o = oo >> shiftCount;
            
            byte ob;
            ob = (byte)o;

            data.Set(index + i, ob);

            i = i + 1;
        }
        return true;
    }

    public virtual bool DataCopy(Data dest, long destIndex, Data source, long sourceIndex, long count)
    {
        long i;
        i = 0;
        while (i < count)
        {
            long n;
            n = source.Get(sourceIndex + i);

            dest.Set(destIndex + i, n);

            i = i + 1;
        }
        return true;
    }

    public virtual bool StringJoinString(StringAdd h, String a)
    {
        StringComp stringComp;
        stringComp = this.StringComp;

        long count;
        count = stringComp.Count(a);
        long i;
        i = 0;
        while (i < count)
        {
            uint oc;
            oc = (uint)stringComp.Char(a, i);

            h.Add(oc);

            i = i + 1;
        }
        return true;
    }

    public virtual StringLess StringLessCreate()
    {
        LessInt charLess;
        charLess = new LessInt();
        charLess.Init();

        CharForm charForm;
        charForm = new CharForm();
        charForm.Init();

        StringLess a;
        a = new StringLess();
        a.CharLess = charLess;
        a.LiteCharForm = charForm;
        a.RiteCharForm = charForm;
        a.Init();
        return a;
    }
}