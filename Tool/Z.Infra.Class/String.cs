namespace Z.Infra.Class;

public class String
{
    public virtual int G_Count(string o)
    {
        return o.Length;
    }

    public virtual int C_Char(string o, int index)
    {
        return o[index];
    }

    public virtual string C_SubString(string o, Range range)
    {
        return o.Substring(range.Index, range.Count);
    }
}