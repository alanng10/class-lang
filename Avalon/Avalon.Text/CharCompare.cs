namespace Avalon.Text;

public class CharCompare : Any
{
    public virtual int Execute(char left, char right)
    {
        return left.CompareTo(right);
    }
}