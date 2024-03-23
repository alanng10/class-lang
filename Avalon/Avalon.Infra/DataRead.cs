namespace Avalon.Infra;

public class DataRead : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = Infra.This;
        this.Range = new DataRange();
        this.Range.Init();
        return true;
    }

    public virtual Data Data { get; set; }
    private InternIntern InternIntern { get; set; }
    protected virtual Infra InfraInfra { get; set; }
    protected virtual DataRange Range { get; set; }

    public virtual int ExecuteMid(long index)
    {
        ulong o;
        o = this.ExecuteByteList(index, this.InfraInfra.IntByteCount);
        int a;
        a = (int)o;
        return a;
    }

    public virtual long ExecuteInt(long index)
    {
        ulong o;
        o = this.ExecuteByteList(index, this.InfraInfra.ULongByteCount);
        long a;
        a = (long)o;
        return a;
    }

    public virtual ushort ExecuteUShort(long index)
    {
        ulong o;
        o = this.ExecuteByteList(index, this.InfraInfra.UShortByteCount);
        ushort a;
        a = (ushort)o;
        return a;
    }

    protected virtual bool SetRange(long index, int count)
    {
        DataRange range;
        range = this.Range;
        range.Index = index;
        range.Count = count;
        return true;
    }

    protected virtual ulong ExecuteByteList(long index, int count)
    {
        this.SetRange(index, count);
        Data data;
        data = this.Data;
        if (!this.InfraInfra.CheckLongRange(data.Count, this.Range))
        {
            return 0;
        }

        ulong a;
        a = this.ByteListRead(index, count);
        return a;
    }

    protected virtual ulong ByteListRead(long index, int count)
    {
        ulong a;
        a = 0;

        ulong o;
        o = 0;
        int shiftCount;
        shiftCount = 0;
        Data data;
        data = this.Data;
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

            a = a | o;

            i = i + 1;
        }
        return a;
    }
}