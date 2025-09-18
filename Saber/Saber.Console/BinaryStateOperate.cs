namespace Saber.Console;

public class BinaryStateOperate : Any
{
    public virtual BinaryState State { get; set; }

    public virtual bool ExecuteTravelStart()
    {
        return false;
    }

    public virtual bool ExecuteTravelEnd()
    {
        return false;
    }

    public virtual bool ExecuteOperate()
    {
        return false;
    }

    public virtual bool ExecuteByte(long value)
    {
        return false;
    }
}