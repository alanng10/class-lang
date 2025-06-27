namespace Saber.Binary;

public class WriteOperate : Any
{
    public virtual Write Write { get; set; }

    public virtual bool ExecuteByte(long value)
    {
        return false;
    }
}