namespace Z.Infra.Class;

public class ValueInt : Any
{
    public static readonly ValueInt This = ShareCreate();

    private static ValueInt ShareCreate()
    {
        ValueInt share;
        share = new ValueInt();
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