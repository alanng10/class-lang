namespace Avalon.Draw;

public class GradientStop : Any
{
    public override bool Init()
    {
        base.Init();

        this.InternIntern = InternIntern.This;
        this.DrawInfra = Infra.This;
        this.InternDrawGradientStopPoint = new InternDrawGradientStopPoint();
        this.InternDrawGradientStopPoint.Init();

        int count;
        count = this.Count;
        ulong countU;
        countU = (ulong)count;
        this.Intern = Extern.GradientStop_New();
        Extern.GradientStop_CountSet(this.Intern, countU);
        Extern.GradientStop_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.GradientStop_Final(this.Intern);
        Extern.GradientStop_Delete(this.Intern);
        return true;
    }

    public virtual int Count { get; set; }

    private InternIntern InternIntern { get; set; }
    protected virtual Infra DrawInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private InternDrawGradientStopPoint InternDrawGradientStopPoint { get; set; }

    public virtual bool SetPoint(int index, GradientStopPoint point)
    {
        ulong indexU;
        ulong posU;
        ulong colorU;
        indexU = (ulong)index;
        posU = (ulong)(point.Pos);
        colorU = this.DrawInfra.InternColor(point.Color);
        Extern.GradientStop_PointSet(this.Intern, indexU, posU, colorU);
        return true;
    }

    public virtual bool GetPoint(int index, GradientStopPoint result)
    {
        InternDrawGradientStopPoint u;
        u = this.InternDrawGradientStopPoint;

        ulong indexU;
        indexU = (ulong)index;
        this.InternIntern.DrawGradientStopPointGet(this.Intern, indexU, u);

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