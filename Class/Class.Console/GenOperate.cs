namespace Class.Console;

public class GenOperate : Any
{
    public virtual Gen Gen { get; set; }

    public virtual bool ExecuteString(string o)
    {
        return true;
    }
}