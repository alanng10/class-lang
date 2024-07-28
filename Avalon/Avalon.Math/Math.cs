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
        aa = comp.Significand;
        long ab;
        ab = comp.Exponent;

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

    public virtual long ValueTen(long significand, long exponentTen)
    {
        ulong ua;
        ulong ub;
        ua = (ulong)significand;
        ub = (ulong)exponentTen;

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
        s = (long)(u.Significand);
        e = (long)(u.Exponent);

        result.Significand = s;
        result.Exponent = e;
        return true;
    }

    public virtual int Less(long valueA, long valueB)
    {
        ulong ua;
        ulong ub;
        ua = (ulong)valueA;
        ub = (ulong)valueB;

        ulong u;
        u = Extern.Math_Less(this.Intern, ua, ub);

        int k;
        k = (int)u;

        int a;
        a = k;
        return a;
    }
}