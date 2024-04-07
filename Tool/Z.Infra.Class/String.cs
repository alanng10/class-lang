namespace Z.Infra.Class;

public class String
{
    public int G_Count(string o)
    {
        return o.Length;
    }

    public int C_Char(string o, int index)
    {
        return o[index];
    }

    public string C_SubString(string o, Range range)
    {
        return o.Substring(range.Index, range.Count);
    }
}