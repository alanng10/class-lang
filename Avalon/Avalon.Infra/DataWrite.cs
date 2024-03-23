namespace Avalon.Infra;

public class DataWrite : Any
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

    public virtual bool ExecuteMid(long index, int value)
    {
        ulong o;
        o = (ulong)value;
        this.ExecuteByteList(index, this.InfraInfra.IntByteCount, o);
        return true;
    }

    public virtual bool ExecuteInt(long index, long value)
    {
        ulong o;
        o = (ulong)value;
        this.ExecuteByteList(index, this.InfraInfra.ULongByteCount, o);
        return true;
    }

    public virtual bool ExecuteShort(long index, short value)
    {
        ulong o;
        o = (ulong)value;
        this.ExecuteByteList(index, this.InfraInfra.UShortByteCount, o);
        return true;
    }

    protected virtual bool SetRange(long index, int count)
    {
        DataRange range;
        range = this.Range;
        range.Index = index;
        range.Count = count;
        return true;
    }

    protected virtual bool ExecuteByteList(long index, int count, ulong value)
    {
        this.SetRange(index, count);
        Data data;
        data = this.Data;
        if (!this.InfraInfra.CheckLongRange(data.Count, this.Range))
        {
            return true;
        }

        this.ByteListWrite(index, count, value);
        return true;
    }

    protected virtual bool ByteListWrite(long index, int count, ulong value)
    {
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
            shiftCount = i * 8;

            o = value >> shiftCount;

            ob = (byte)o;

            data.Set(index + i, ob);

            i = i + 1;
        }
        return true;
    }
}