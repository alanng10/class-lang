namespace Avalon.Math;

public partial class Math : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternComp = new InternMathComp();
        this.InternComp.Init();
        return true;
    }

    private InternIntern InternIntern { get; set; }
    private ulong Intern { get; set; }
    private InternMathComp InternComp { get; set; }

    public virtual long Value(Comp comp)
    {
        long aa;
        aa = comp.Cand;
        long ab;
        ab = comp.Expo;

        ulong ua;
        ulong ub;
        ua = (ulong)aa;
        ub = (ulong)ab;

        ulong u;
        u = Extern.Math_Value(this.Intern, ua, ub);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ValueTen(long cand, long expoTen)
    {
        ulong ua;
        ulong ub;
        ua = (ulong)cand;
        ub = (ulong)expoTen;

        ulong u;
        u = Extern.Math_ValueTen(this.Intern, ua, ub);
        long a;
        a = (long)u;
        return a;
    }

    public virtual bool Comp(Comp result, long value)
    {
        InternMathComp u;
        u = this.InternComp;
        this.InternIntern.MathComp(this.Intern, u, value);

        long s;
        long e;
        s = (long)(u.Cand);
        e = (long)(u.Exponent);

        result.Cand = s;
        result.Expo = e;
        return true;
    }

    public virtual long Less(long valueA, long valueB)
    {
        ulong ua;
        ulong ub;
        ua = (ulong)valueA;
        ub = (ulong)valueB;

        ulong u;
        u = Extern.Math_Less(this.Intern, ua, ub);

        long k;
        k = (long)u;

        long a;
        a = k;
        return a;
    }
}