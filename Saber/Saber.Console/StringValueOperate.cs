namespace Saber.Console;

public class StringValueOperate : Any
{
    public virtual StringValueTraverse Traverse { get; set; }

    public virtual bool Execute(String k)
    {
        return false;
    }
}