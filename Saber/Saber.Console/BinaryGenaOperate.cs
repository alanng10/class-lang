namespace Saber.Console;

public class BinaryGenaOperate : Any
{
    public virtual BinaryGena Gena { get; set; }

    public virtual bool ExecuteByte(long value)
    {
        return false;
    }
}