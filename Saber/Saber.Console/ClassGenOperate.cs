namespace Saber.Console;

public class ClassGenOperate : Any
{
    public virtual ClassGen Gen { get; set; }

    public virtual bool ExecuteChar(long o)
    {
        return false;
    }

    public virtual bool ExecuteTextInt(long o)
    {
        return false;
    }

    public virtual bool ExecuteTextIntHex(long o)
    {
        return false;
    }
}