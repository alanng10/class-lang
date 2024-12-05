namespace View.Draw;

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

        ulong ka;
        ka = Extern.Stat_PointDataCount(stat);

        ulong dataCount;
        dataCount = countU * ka;

        ulong dataValue;
        dataValue = Extern.New(dataCount);

        this.InternDataValue = dataValue;

        this.Intern = Extern.Data_New();
        Extern.Data_Init(this.Intern);
        Extern.Data_ValueSet(this.Intern, dataValue);
        Extern.Data_CountSet(this.Intern, dataCount);
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
        k = this.Memory(index);

        Extern.PointData_PointGet(k, this.InternPos);

        ulong colU;
        ulong rowU;
        colU = Extern.Pos_ColGet(this.InternPos);
        rowU = Extern.Pos_RowGet(this.InternPos);

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

        this.InternInfra.PosSet(this.InternPos, value.Col, value.Row);

        ulong k;
        k = this.Memory(index);

        Extern.PointData_PointSet(k, this.InternPos);

        return true;
    }

    private ulong Memory(long index)
    {
        ulong ka;
        ka = (ulong)index;

        ulong share;
        share = Extern.Infra_Share();

        ulong stat;
        stat = Extern.Share_Stat(share);

        ulong kk;
        kk = Extern.Stat_PointDataCount(stat);

        ulong k;
        k = ka * kk;
        k = this.InternDataValue + k;

        return k;
    }
}