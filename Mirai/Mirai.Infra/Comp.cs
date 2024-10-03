namespace Mirai.Infra;

public class Comp : CompComp
{
    public override bool Init()
    {
        base.Init();
        this.MathInfra = MathInfra.This;
        this.ViewInfra = Infra.This;

        this.Math = this.CreateMath();
        this.MathComp = this.CreateMathComp();
        return true;
    }

    protected virtual MathInfra MathInfra { get; set; }
    protected virtual Infra ViewInfra { get; set; }
    protected virtual MathMath Math { get; set; }
    protected virtual MathComp MathComp { get; set; }

    protected virtual MathMath CreateMath()
    {
        MathMath a;
        a = new MathMath();
        a.Init();
        return a;
    }

    protected virtual MathComp CreateMathComp()
    {
        MathComp a;
        a = new MathComp();
        a.Init();
        return a;
    }

    protected virtual long MathInt(long n)
    {
        MathInfra mathInfra;
        mathInfra = this.MathInfra;

        MathMath math;
        math = this.Math;

        MathComp mathComp;
        mathComp = this.MathComp;

        long a;
        a = mathInfra.Int(math, mathComp, n);
        return a;
    }

    protected virtual long MathValue(long significand, long exponent)
    {
        MathComp mathComp;
        mathComp = this.MathComp;

        mathComp.Cand = significand;
        mathComp.Expo = exponent;

        long a;
        a = this.Math.Value(mathComp);
        return a;
    }
}