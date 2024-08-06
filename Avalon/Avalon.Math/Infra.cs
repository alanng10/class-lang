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

    public virtual long Int(Math math, Comp comp, long value)
    {
        comp.Cand = value;
        comp.Expo = 0;

        long a;
        a = math.Value(comp);
        return a;
    }
}