namespace Avalon.Math;

public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.MathMath = Math.This;
        return true;
    }

    protected virtual Math MathMath { get; set; }

    public virtual long Int(Comp comp, long value)
    {
        comp.Cand = value;
        comp.Expo = 0;

        long a;
        a = this.MathMath.Value(comp);
        return a;
    }
}