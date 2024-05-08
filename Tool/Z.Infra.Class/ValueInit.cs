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

    public virtual bool Bool(bool value)
    {
        return true;
    }

    public virtual bool Int(ulong value)
    {
        return true;
    }

    public virtual bool String(string value)
    {
        if (value == null)
        {
            throw new Exception("Null Reference Exception");
        }
        return true;
    }
}