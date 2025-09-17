namespace Saber.Console;

public class BinaryStateOperate : Any
{
    public virtual BinaryState State { get; set; }

    public virtual bool ExecuteByte(long value)
    {
        return false;
    }
}