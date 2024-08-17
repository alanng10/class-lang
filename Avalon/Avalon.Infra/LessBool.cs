namespace Avalon.Infra;

public class LessBool : Any
{
    public virtual long Execute(bool left, bool right)
    {
        long leftA;
        long rightA;
        leftA = this.BoolInt(left);
        rightA = this.BoolInt(right);
        
        return leftA - rightA;
    }

    protected virtual long BoolInt(bool o)
    {
        long a;
        a = 0;
        if (o)
        {
            a = 1;
        }
        return a;
    }
}