namespace Avalon.Text;

public class Code : Any
{
    public static Code This { get; } = ShareCreate();

    private static Code ShareCreate()
    {
        Code share;
        share = new Code();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    private InternIntern InternIntern { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }

    public virtual long ExecuteCount(CodeKind innKind, CodeKind outKind, Data data, Range dataRange)
    {
        if (!this.ValidCodeKind(innKind, outKind))
        {
            return -1;
        }

        long dataIndex;
        long dataCount;
        dataIndex = dataRange.Index;
        dataCount = dataRange.Count;

        if (!this.InfraInfra.ValidRange(data.Count, dataIndex, dataCount))
        {
            return -1;
        }

        ulong dataIndexU;
        ulong dataCountU;
        dataIndexU = (ulong)dataIndex;
        dataCountU = (ulong)dataCount;

        ulong u;
        u = this.InternIntern.TextEncodeCountArray(innKind.Intern, outKind.Intern, data.Value, dataIndexU, dataCountU);

        long a;
        a = (long)u;
        return a;
    }

    internal virtual long ExecuteCountString(CodeKind innKind, CodeKind outKind, string data, Range dataRange)
    {
        if (!this.ValidCodeKind(innKind, outKind))
        {
            return -1;
        }

        long dataIndex;
        long dataCount;
        dataIndex = dataRange.Index;
        dataCount = dataRange.Count;

        long ka;
        ka = data.Length * sizeof(char);

        if (!this.InfraInfra.ValidRange(ka, dataIndex, dataCount))
        {
            return -1;
        }

        ulong dataIndexU;
        ulong dataCountU;
        dataIndexU = (ulong)dataIndex;
        dataCountU = (ulong)dataCount;

        ulong u;
        u = this.InternIntern.TextEncodeCountString(innKind.Intern, outKind.Intern, data, dataIndexU, dataCountU);

        long a;
        a = (long)u;
        return a;
    }

    public virtual bool ExecuteResult(Data result, long resultIndex, CodeKind innKind, CodeKind outKind, Data data, Range dataRange)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

        if (!this.ValidCodeKind(innKind, outKind))
        {
            return false;
        }

        if (!infraInfra.ValidRange(result.Count, resultIndex, 0))
        {
            return false;
        }

        long dataIndex;
        long dataCount;
        dataIndex = dataRange.Index;
        dataCount = dataRange.Count;

        if (!infraInfra.ValidRange(data.Count, dataIndex, dataCount))
        {
            return false;
        }

        ulong dataIndexU;
        ulong dataCountU;
        dataIndexU = (ulong)dataIndex;
        dataCountU = (ulong)dataCount;

        ulong resultIndexU;
        resultIndexU = (ulong)resultIndex;

        this.InternIntern.TextEncodeResultArrayArray(result.Value, resultIndexU, innKind.Intern, outKind.Intern, data.Value, dataIndexU, dataCountU);

        return true;
    }

    internal virtual bool ExecuteResultString(Data result, long resultIndex, CodeKind innKind, CodeKind outKind, string data, Range dataRange)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

        if (!this.ValidCodeKind(innKind, outKind))
        {
            return false;
        }

        if (!infraInfra.ValidRange(result.Count, resultIndex, 0))
        {
            return false;
        }

        long dataIndex;
        long dataCount;
        dataIndex = dataRange.Index;
        dataCount = dataRange.Count;

        long ka;
        ka = data.Length * sizeof(char);

        if (!infraInfra.ValidRange(ka, dataIndex, dataCount))
        {
            return false;
        }

        ulong dataIndexU;
        ulong dataCountU;
        dataIndexU = (ulong)dataIndex;
        dataCountU = (ulong)dataCount;

        ulong resultIndexU;
        resultIndexU = (ulong)resultIndex;

        this.InternIntern.TextEncodeResultStringArray(result.Value, resultIndexU, innKind.Intern, outKind.Intern, data, dataIndexU, dataCountU);

        return true;
    }

    public virtual bool ValidCodeKind(CodeKind innKind, CodeKind outKind)
    {
        if (innKind == outKind)
        {
            return false;
        }
        return true;
    }
}