namespace Avalon.Console;

public class Out : Any
{
    public virtual bool Write(string o)
    {
        return false;
    }
}