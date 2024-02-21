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

    public virtual bool ExecuteInt(long index, int value)
    {
        this.SetRange(index, this.InfraInfra.IntByteCount);
        Data data;
        data = this.Data;
        if (!this.InfraInfra.CheckLongRange(data.Count, this.Range))
        {
            return true;
        }

        this.InternIntern.DataWriteInt(data.Value, index, value);
        return true;
    }

    public virtual bool ExecuteULong(long index, ulong value)
    {
        this.SetRange(index, this.InfraInfra.ULongByteCount);
        Data data;
        data = this.Data;
        if (!this.InfraInfra.CheckLongRange(data.Count, this.Range))
        {
            return true;
        }

        this.InternIntern.DataWriteULong(data.Value, index, value);
        return true;
    }

    protected virtual bool SetRange(long index, int count)
    {
        DataRange range;
        range = this.Range;
        range.Start = index;
        range.End = index + count;
        return true;
    }
}