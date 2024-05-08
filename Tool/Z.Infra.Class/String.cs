namespace Z.Infra.Class;

public class String : Any
{
    public static readonly String This = ShareCreate();

    private static String ShareCreate()
    {
        String share;
        share = new String();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }

    public virtual int G_Count(string o)
    {
        return o.Length;
    }

    public virtual bool S_Count(string o, int value)
    {
        if (o == null)
        {
            throw new Exception("Null Reference Exception");
        }
        return true;
    }

    public virtual int C_Char(string o, int index)
    {
        if (!this.InfraInfra.CheckIndex(o.Length, index))
        {
            return -1;
        }

        char oc;
        oc = o[index];
        int a;
        a = oc;
        return a;
    }

    public virtual string C_Substring(string o, Range range)
    {
        int index;
        int count;
        index = range.Index;
        count = range.Count;
        if (!this.InfraInfra.CheckRange(o.Length, index, count))
        {
            return null;
        }
        return o.Substring(index, count);
    }
}