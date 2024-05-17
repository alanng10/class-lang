namespace Avalon.Infra;

public class IntCompare : Any
{
    public virtual int Execute(int left, int right)
    {
        return left - right;
    }
}