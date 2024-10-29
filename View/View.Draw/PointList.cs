namespace Mirai.Draw;

public class PointList : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternInfra = InternInfra.This;
        this.InfraInfra = InfraInfra.This;

        this.InternPos = this.InternInfra.PosCreate();

        long count;
        count = this.Count;
        ulong countU;
        countU = (ulong)count;

        ulong share;
        share = Extern.Infra_Share();

        ulong stat;
        stat = Extern.Share_Stat(share);

        ulong ua;
        ua = Extern.Stat_PointDataCount(stat);

        ulong dataCount;
        dataCount = countU * ua;

        ulong dataValue;
        dataValue = Extern.New(dataCount);

        this.InternDataValue = dataValue;

        ulong intern;
        intern = Extern.Data_New();
        Extern.Data_Init(intern);
        Extern.Data_CountSet(intern, dataCount);
        Extern.Data_ValueSet(intern, dataValue);
        this.Intern = intern;
        return true;
    }

    public virtual bool Final()
    {
        Extern.Data_Final(this.Intern);
        Extern.Data_Delete(this.Intern);

        Extern.Delete(this.InternDataValue);

        this.InternInfra.PosDelete(this.InternPos);

        return true;
    }

    public virtual long Count { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private ulong InternDataValue { get; set; }
    private ulong InternPos { get; set; }

    public virtual bool Get(long index, Pos result)
    {
        if (!this.InfraInfra.ValidIndex(this.Count, index))
        {
            return false;
        }

        ulong k;
        k = this.Address(index);

        ulong pos;
        pos = this.InternPos;

        Extern.PointData_PointGet(k, pos);

        ulong colU;
        ulong rowU;
        colU = Extern.Pos_ColGet(pos);
        rowU = Extern.Pos_RowGet(pos);

        long col;
        long row;
        col = (long)colU;
        row = (long)rowU;

        result.Col = col;
        result.Row = row;
        return true;
    }

    public virtual bool Set(long index, Pos value)
    {
        if (!this.InfraInfra.ValidIndex(this.Count, index))
        {
            return false;
        }

        ulong pos;
        pos = this.InternPos;

        this.InternInfra.PosSet(pos, value.Col, value.Row);

        ulong k;
        k = this.Address(index);

        Extern.PointData_PointSet(k, pos);

        return true;
    }

    private ulong Address(long index)
    {
        ulong ka;
        ka = (ulong)index;

        ulong share;
        share = Extern.Infra_Share();

        ulong stat;
        stat = Extern.Share_Stat(share);

        ulong ua;
        ua = Extern.Stat_PointDataCount(stat);

        ulong k;
        k = ka * ua;
        k = this.InternDataValue + k;

        return k;
    }
}