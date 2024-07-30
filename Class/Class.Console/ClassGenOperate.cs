namespace Class.Console;

public class ClassGenOperate : Any
{
    public virtual ClassGen Gen { get; set; }

    public virtual bool ExecuteText(string o)
    {
        return false;
    }

    public virtual bool ExecuteChar(char o)
    {
        return false;
    }

    public virtual bool ExecuteIntFormat(long o)
    {
        return false;
    }
}