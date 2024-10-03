namespace Mirai.Draw;

public class PolateStop : Any
{
    public override bool Init()
    {
        base.Init();

        this.InternIntern = InternIntern.This;
        this.DrawInfra = Infra.This;
        this.InternPolateStopPoint = new InternPolateStopPoint();
        this.InternPolateStopPoint.Init();

        long count;
        count = this.Count;
        ulong countU;
        countU = (ulong)count;
        this.Intern = Extern.PolateStop_New();
        Extern.PolateStop_CountSet(this.Intern, countU);
        Extern.PolateStop_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.PolateStop_Final(this.Intern);
        Extern.PolateStop_Delete(this.Intern);
        return true;
    }

    public virtual long Count { get; set; }

    private InternIntern InternIntern { get; set; }
    protected virtual Infra DrawInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private InternPolateStopPoint InternPolateStopPoint { get; set; }

    public virtual bool PointSet(long index, PolateStopPoint point)
    {
        ulong indexU;
        ulong posU;
        ulong colorU;
        indexU = (ulong)index;
        posU = (ulong)(point.Pos);
        colorU = this.DrawInfra.InternColor(point.Color);
        Extern.PolateStop_PointSet(this.Intern, indexU, posU, colorU);
        return true;
    }

    public virtual bool PointGet(long index, PolateStopPoint result)
    {
        InternPolateStopPoint u;
        u = this.InternPolateStopPoint;

        ulong indexU;
        indexU = (ulong)index;
        this.InternIntern.DrawPolateStopPointGet(this.Intern, indexU, u);

        ulong ua;
        ua = u.Pos;
        ulong ub;
        ub = u.Color;
        long pos;
        pos = (long)(ua);
        result.Pos = pos;
        this.DrawInfra.ColorSet(result.Color, ub);
        return true;
    }
}