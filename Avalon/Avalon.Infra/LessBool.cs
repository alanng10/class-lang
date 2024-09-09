namespace Avalon.Infra;

public class LessBool : Any
{
    public virtual long Execute(bool lite, bool rite)
    {
        long liteA;
        long riteA;
        liteA = this.IntBool(lite);
        riteA = this.IntBool(rite);

        return liteA - riteA;
    }

    protected virtual long IntBool(bool o)
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