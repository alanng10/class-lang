namespace Avalon.Infra;

public class LessInt : Any
{
    public virtual long Execute(long lite, long rite)
    {
        long a;
        a = lite - rite;
        return a;
    }
}