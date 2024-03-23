namespace Avalon.Intern;



public class String
{
    public static int Count(string o)
    {
        return o.Length;
    }

    public static int Char(string o, int index)
    {
        if (index < 0 | !(index < o.Length))
        {
            return -1;
        }

        return o[index];
    }
}