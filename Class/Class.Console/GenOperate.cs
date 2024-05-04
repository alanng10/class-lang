namespace Class.Console;

public class GenOperate : Any
{
    public virtual GenTraverse Traverse { get; set; }

    public virtual bool ExecuteString(string o)
    {
        return true;
    }
}