namespace Avalon.Text;

public class Encode : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = Infra.This;
        return true;
    }

    private InternIntern InternIntern { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Infra TextInfra { get; set; }
    private ulong Intern { get; set; }

    public virtual long ExecuteCount(EncodeKind innKind, EncodeKind outKind, Data data, RangeInt dataRange)
    {
        long dataIndex;
        long dataCount;
        dataIndex = dataRange.Index;
        dataCount = dataRange.Count;

        if (!this.InfraInfra.ValidRangeInt(data.Count, dataIndex, dataCount))
        {
            return -1;
        }

        ulong dataIndexU;
        ulong dataCountU;
        dataIndexU = (ulong)dataIndex;
        dataCountU = (ulong)dataCount;

        ulong u;
        u = this.InternIntern.TextEncodeCount(innKind.Intern, outKind.Intern, data.Value, dataIndexU, dataCountU);

        long a;
        a = (long)u;
        return a;
    }

    public virtual bool ExecuteResult(Text result, EncodeKind innKind, EncodeKind outKind, Data data, RangeInt dataRange)
    {
        if (!this.TextInfra.ValidRange(result))
        {
            return false;
        }

        long dataIndex;
        long dataCount;
        dataIndex = dataRange.Index;
        dataCount = dataRange.Count;

        if (!this.InfraInfra.ValidRangeInt(data.Count, dataIndex, dataCount))
        {
            return false;
        }

        ulong dataIndexU;
        ulong dataCountU;
        dataIndexU = (ulong)dataIndex;
        dataCountU = (ulong)dataCount;

        ulong resultIndex;
        resultIndex = (ulong)result.Range.Index;

        this.InternIntern.TextEncodeResult(result.Data.Value, resultIndex, innKind.Intern, outKind.Intern, data.Value, dataIndexU, dataCountU);

        return true;
    }
}