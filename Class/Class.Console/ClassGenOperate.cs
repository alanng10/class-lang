namespace Class.Console;

public class ClassGenOperate : Any
{
    public virtual ClassGen Gen { get; set; }

    public virtual bool ExecuteChar(long o)
    {
        return false;
    }

    public virtual bool ExecuteIntFormat(long o)
    {
        return false;
    }
}