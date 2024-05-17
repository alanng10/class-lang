namespace Avalon.Text;

public class CharCompare : Any
{
    public virtual int Execute(char left, char right)
    {
        int leftA;
        int rightA;
        leftA = left;
        rightA = right;
        return leftA - rightA;
    }
}