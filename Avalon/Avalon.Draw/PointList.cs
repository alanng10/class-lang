namespace Avalon.Draw;

public class PointList : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternInfra = InternInfra.This;

        this.InternPos = this.InternInfra.PosCreate();

        int count;
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

    public virtual int Count { get; set; }
    private InternInfra InternInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private ulong InternDataValue { get; set; }
    private ulong InternPos { get; set; }

    public virtual bool Get(int index, PosInt result)
    {
        ulong k;
        k = this.Address(index);

        ulong pos;
        pos = this.InternPos;

        Extern.PointData_PointGet(k, pos);

        ulong leftU;
        ulong upU;
        leftU = Extern.Pos_LeftGet(pos);
        upU = Extern.Pos_UpGet(pos);

        long left;
        long up;
        left = (long)leftU;
        up = (long)upU;

        result.Left = left;
        result.Up = up;

        return true;
    }

    public virtual bool Set(int index, PosInt value)
    {
        ulong pos;
        pos = this.InternPos;

        this.InternInfra.PosSet(pos, value.Left, value.Up);

        ulong k;
        k = this.Address(index);

        Extern.PointData_PointSet(k, pos);

        return true;
    }

    private ulong Address(int index)
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