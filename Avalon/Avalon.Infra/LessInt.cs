namespace Avalon.Infra;

public class LessInt : Any
{
    public virtual long Execute(long left, long right)
    {
        long a;
        a = left - right;
        return a;
    }
}