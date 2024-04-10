namespace Class.Binary;

public class WriteOperate : Any
{
    public virtual bool ExecuteByte(int value)
    {
        return true;
    }

    public virtual bool ExecuteInt(long value)
    {
        return true;
    }
}