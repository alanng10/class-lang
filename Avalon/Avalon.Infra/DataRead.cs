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

    public virtual int ExecuteInt(long index)
    {
        this.SetRange(index, this.InfraInfra.IntByteCount);

        Data data;
        data = this.Data;

        if (!this.InfraInfra.CheckLongRange(data.Count, this.Range))
        {
            return 0;
        }

        int o;
        o = this.InternIntern.DataReadInt(data.Value, index);
        return o;
    }

    public virtual ulong ExecuteULong(long index)
    {
        this.SetRange(index, this.InfraInfra.ULongByteCount);

        Data data;
        data = this.Data;

        if (!this.InfraInfra.CheckLongRange(data.Count, this.Range))
        {
            return 0;
        }

        ulong o;
        o = this.InternIntern.DataReadULong(data.Value, index);
        return o;
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