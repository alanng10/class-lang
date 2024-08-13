namespace Avalon.Infra;

public class CompareMid : Any
{
    public virtual int Execute(int left, int right)
    {
        long k;
        k = left;
        k = k - right;

        int a;
        a = 0;
        if (k < 0)
        {
            a = -1;
        }
        if (0 < k)
        {
            a = 1;
        }
        
        return a;
    }
}