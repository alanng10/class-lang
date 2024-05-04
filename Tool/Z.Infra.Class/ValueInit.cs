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

    public virtual uint InitBool(uint value)
    {
        return BoolValue.True;
    }

    public virtual uint InitInt(ulong value)
    {
        return BoolValue.True;
    }

    public virtual uint InitString(string value)
    {
        return BoolValue.True;
    }
}