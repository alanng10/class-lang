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

        long o;
        o = 1;
        o = o << 60;
        this.IntCapValue = o;
        this.NewLine = '\n';
        this.PathCombine = '/';
        return true;
    }

    public virtual long IntCapValue { get; set; }
    public virtual char NewLine { get; set; }
    public virtual char PathCombine { get; set; }

    public virtual bool IndexRange(Range range, int index)
    {
        range.Index = index;        
        range.Count = 1;
        return true;
    }

    public virtual bool CheckRange(int count, Range range)
    {
        int index;
        int countA;
        index = range.Index;
        countA = range.Count;
        if (index < 0)
        {
            return false;
        }
        if (countA < 0)
        {
            return false;
        }
        if (count < index + countA)
        {
            return false;
        }
        return true;
    }

    public virtual bool CheckLongRange(long count, DataRange range)
    {
        long index;
        long countA;
        index = range.Index;
        countA = range.Count;
        if (index < 0)
        {
            return false;
        }
        if (countA < 0)
        {
            return false;
        }
        if (count < index + countA)
        {
            return false;
        }
        return true;
    }

    public virtual long DataIntGet(Data data, long index)
    {
        return this.DataByteListGet(data, index, sizeof(long));
    }

    public virtual int DataMidGet(Data data, long index)
    {
        return (int)this.DataByteListGet(data, index, sizeof(int));
    }

    public virtual short DataShortGet(Data data, long index)
    {
        return (short)this.DataByteListGet(data, index, sizeof(short));
    }

    public virtual char DataCharGet(Data data, long index)
    {
        return (char)this.DataShortGet(data, index);
    }

    public virtual bool DataIntSet(Data data, long index, long value)
    {
        return this.DataByteListSet(data, index, sizeof(long), value);
    }

    public virtual bool DataMidSet(Data data, long index, int value)
    {
        return this.DataByteListSet(data, index, sizeof(int), value);
    }

    public virtual bool DataShortSet(Data data, long index, short value)
    {
        return this.DataByteListSet(data, index, sizeof(short), value);
    }

    public virtual bool DataCharSet(Data data, long index, char value)
    {
        return this.DataShortSet(data, index, (short)value);
    }

    public virtual long DataByteListGet(Data data, long index, int count)
    {
        ulong oo;
        oo = 0;

        ulong o;
        o = 0;
        int shiftCount;
        shiftCount = 0;
        byte ob;
        ob = 0;

        int i;
        i = 0;
        while (i < count)
        {
            ob = (byte)data.Get(index + i);

            shiftCount = i * 8;

            o = ob;
            o = o << shiftCount;

            oo = oo | o;

            i = i + 1;
        }
        long a;
        a = (long)oo;
        return a;
    }

    public virtual bool DataByteListSet(Data data, long index, int count, long value)
    {
        ulong oo;
        oo = (ulong)value;
        ulong o;
        o = 0;
        int shiftCount;
        shiftCount = 0;
        byte ob;
        ob = 0;

        int i;
        i = 0;
        while (i < count)
        {
            shiftCount = i * 8;

            o = oo >> shiftCount;

            ob = (byte)o;

            data.Set(index + i, ob);

            i = i + 1;
        }
        return true;
    }

    public virtual Data DataCreateString(string a)
    {
        int count;
        count = a.Length;

        int oa;
        oa = sizeof(short);

        Data data;
        data = new Data();
        data.Count = count * oa;
        data.Init();

        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = a[i];
            long index;
            index = i * oa;

            this.DataCharSet(data, index, oc);
            i = i + 1;
        }

        return data;
    }
}