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
}