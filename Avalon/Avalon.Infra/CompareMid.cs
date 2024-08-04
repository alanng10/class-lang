namespace Avalon.Infra;

public class CompareMid : Any
{
    public virtual int Execute(int left, int right)
    {
        return left - right;
    }
}