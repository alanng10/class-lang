namespace Z.Infra.Class;

public class String
{
    public static int G_Count(string o)
    {
        return o.Length;
    }

    public static int C_Char(string o, int index)
    {
        if (index < 0 | !(index < o.Length))
        {
            return -1;
        }

        return o[index];
    }

    public static string C_SubString(string o, Range range)
    {
        return o.Substring(range.Index, range.Count);
    }
}