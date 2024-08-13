namespace Avalon.Infra;

public class CompareInt : Any
{
    public virtual int Execute(long left, long right)
    {
        long o;
        o = left - right;
        
        int a;
        a = 0;

        if (o < 0)
        {
            a = -1;
        }
        if (0 < o)
        {
            a = 1;
        }
        return a;
    }
}