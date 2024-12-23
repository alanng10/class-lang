namespace Avalon.Infra;

public class LessInt : Any
{
    public virtual long Execute(long lite, long rite)
    {
        if (lite < rite)
        {
            return -1;
        }

        if (rite < lite)
        {
            return 1;
        }
        return 0;
    }
}