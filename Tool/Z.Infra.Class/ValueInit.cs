namespace Z.Infra.Class;

public class ValueInit : Any
{
    public static readonly ValueInit This = ShareCreate();

    private static ValueInit ShareCreate()
    {
        ValueInit share;
        share = new ValueInit();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public virtual bool InitBool(bool value)
    {
        return true;
    }

    public virtual bool InitInt(ulong value)
    {
        return true;
    }

    public virtual bool InitString(string value)
    {
        return true;
    }
}