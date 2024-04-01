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

    public virtual char CharGet(Data data, int index)
    {
        int oaa;
        int oab;
        oaa = data.Get(index);
        oab = data.Get(index + 1);
        int o;
        o = oaa;
        o = o | (oab << 8);
        short ob;
        ob = (short)o;
        char oc;
        oc = (char)ob;
        return oc;
    }

    public virtual bool IntSet(Data data, long index, long value)
    {
        return this.ByteListSet(data, index, sizeof(long), value);
    }

    public virtual bool MidSet(Data data, long index, int value)
    {
        return this.ByteListSet(data, index, sizeof(int), value);
    }

    public virtual bool ShortSet(Data data, long index, short value)
    {
        return this.ByteListSet(data, index, sizeof(short), value);
    }

    public virtual bool CharSet(Data data, int index, char value)
    {
        return this.ShortSet(data, index, (short)value);
    }

    public virtual long ByteListGet(Data data, long index, int count)
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

    public virtual bool ByteListSet(Data data, long index, int count, long value)
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
            short oo;
            oo = (short)oc;
            long index;
            index = i * oa;

            this.ShortSet(data, index, oo);
            i = i + 1;
        }

        return data;
    }
}