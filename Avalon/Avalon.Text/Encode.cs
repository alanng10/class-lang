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
        u = 0;

        bool b;
        b = (data is StringData);

        if (!b)
        {
            u = this.InternIntern.TextEncodeCountArray(innKind.Intern, outKind.Intern, data.Value, dataIndexU, dataCountU);
        }

        if (b)
        {
            StringData stringData;
            stringData = (StringData)data;

            string dataString;
            dataString = stringData.ValueString;

            u = this.InternIntern.TextEncodeCountString(innKind.Intern, outKind.Intern, dataString, dataIndexU, dataCountU);
        }

        long a;
        a = (long)u;
        return a;
    }

    public virtual bool ExecuteResult(Data result, long resultIndex, EncodeKind innKind, EncodeKind outKind, Data data, RangeInt dataRange)
    {
        if (!this.InfraInfra.ValidRangeInt(result.Count, resultIndex, 0))
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

        ulong resultIndexU;
        resultIndexU = (ulong)resultIndex;

        bool b;
        b = (data is StringData);

        if (!b)
        {
            this.InternIntern.TextEncodeResultArrayArray(result.Value, resultIndexU, innKind.Intern, outKind.Intern, data.Value, dataIndexU, dataCountU);
        }

        if (b)
        {
            StringData stringData;
            stringData = (StringData)data;

            string dataString;
            dataString = stringData.ValueString;

            this.InternIntern.TextEncodeResultStringArray(result.Value, resultIndexU, innKind.Intern, outKind.Intern, dataString, dataIndexU, dataCountU);
        }

        return true;
    }
}