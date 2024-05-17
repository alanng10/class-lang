namespace Avalon.Infra;

public class BoolCompare : Any
{
    public virtual int Execute(bool left, bool right)
    {
        int leftA;
        int rightA;
        leftA = this.BoolInt(left);
        rightA = this.BoolInt(right);
        
        return leftA - rightA;
    }

    protected virtual int BoolInt(bool o)
    {
        int a;
        a = 0;
        if (o)
        {
            a = 1;
        }
        return a;
    }
}