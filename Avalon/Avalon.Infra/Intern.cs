namespace Avalon.Infra;

public class Intern : Any
{
    public static Intern This { get; } = ShareCreate();

    private static Intern ShareCreate()
    {
        Intern share;
        share = new Intern();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    [SystemThreadStatic]
    public static object ThisThread = null;

    public virtual String StringNew()
    {
        String a;
        a = new String();
        a.Init();
        return a;
    }

    public virtual object StringValueGet(String k)
    {
        return k.Value;
    }

    public virtual bool StringValueSet(String k, object value)
    {
        k.Value = value;
        return true;
    }

    public virtual long StringCountGet(String k)
    {
        return k.Count;
    }

    public virtual bool StringCountSet(String k, long value)
    {
        k.Count = value;
        return true;
    }

    public virtual object DataNew(long count)
    {
        return new byte[count];
    }

    public virtual long DataGet(object data, long index)
    {
        byte[] k;
        k = data as byte[];

        return k[index];
    }

    public virtual bool DataSet(object data, long index, long value)
    {
        byte[] k;
        k = data as byte[];

        byte ob;
        ob = (byte)value;

        k[index] = ob;

        return true;
    }

    public virtual object ArrayNew(long count)
    {
        return new object[count];
    }

    public virtual object ArrayGet(object array, long index)
    {
        object[] k;
        k = array as object[];

        return k[index];
    }

    public virtual bool ArraySet(object array, long index, object value)
    {
        object[] k;
        k = array as object[];

        k[index] = value;

        return true;
    }
}