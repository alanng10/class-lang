namespace Mirai.Infra;

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
    public virtual Field FieldCreate(CompComp comp)
    {
        Field a;
        a = new Field();
        a.Init();
        a.Comp = comp;
        a.State = new FieldState();
        a.State.Init();
        a.State.Field = a;
        a.SetModArg = new Mod();
        a.SetModArg.Init();
        return a;
    }
}