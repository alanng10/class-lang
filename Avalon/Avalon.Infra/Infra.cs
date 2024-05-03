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
        this.NewLine = "\n";
        this.PathCombine = "/";
        return true;
    }

    public virtual long IntCapValue { get; set; }
    public virtual string NewLine { get { return __D_NewLine; } set { __D_NewLine = value; } }
    protected string __D_NewLine;
    public virtual string PathCombine { get { return __D_PathCombine; } set { __D_PathCombine = value; } }
    protected string __D_PathCombine;

    public virtual string StringCreateChar(char c)
    {
        return c.ToString();
    }

    public virtual bool CheckIndex(int count, int index)
    {
        return this.CheckRange(count, index, 1);
    }

    public virtual bool CheckLongIndex(long count, long index)
    {
        return this.CheckLongRange(count, index, 1);
    }

    public virtual bool IndexRange(Range range, int index)
    {
        range.Index = index;        
        range.Count = 1;
        return true;
    }

    public virtual bool CheckRange(int totalCount, int index, int count)
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

    public virtual bool CheckLongRange(long totalCount, long index, long count)
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

    public virtual char DataCharGet(Data data, long index)
    {
        return (char)this.DataShortGet(data, index);
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

    public virtual bool DataCharSet(Data data, long index, char value)
    {
        return this.DataShortSet(data, index, (ushort)value);
    }

    public virtual ulong DataByteListGet(Data data, long index, int count)
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
        long d;
        d = (this.IntCapValue - 1);
        ulong da;
        da = (ulong)d;
        ulong a;
        a = oo;
        a = a & da;
        return a;
    }

    public virtual bool DataByteListSet(Data data, long index, int count, ulong value)
    {
        long d;
        d = this.IntCapValue - 1;
        ulong da;
        da = (ulong)d;
        ulong oo;
        oo = value;
        oo = oo & da;

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

    public virtual Data DataCreateString(string a, Range range)
    {
        int index;
        int count;
        index = 0;
        count = 0;
        
        bool b;
        b = (range == null);
        if (b)
        {
            index = 0;
            count = a.Length;
        }
        if (!b)
        {
            index = range.Index;
            count = range.Count;
            if (!this.CheckRange(a.Length, index, count))
            {
                return null;
            }
        }

        int oa;
        oa = sizeof(char);

        Data data;
        data = new Data();
        data.Count = count * oa;
        data.Init();

        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = a[index + i];

            long dataIndex;
            dataIndex = i * oa;

            this.DataCharSet(data, dataIndex, oc);
            i = i + 1;
        }

        return data;
    }
}