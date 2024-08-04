namespace Avalon.Infra;

public class CompareInt : Any
{
    public virtual int Execute(long left, long right)
    {
        long o;
        o = left - right;
        if (o < 0)
        {
            return -1;
        }
        if (0 < o)
        {
            return 1;
        }
        return 0;
    }
}