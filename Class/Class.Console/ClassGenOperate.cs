namespace Class.Console;

public class ClassGenOperate : Any
{
    public virtual ClassGen Gen { get; set; }

    public virtual bool ExecuteText(string o)
    {
        return true;
    }

    public virtual bool ExecuteChar(char o)
    {
        return true;
    }
}