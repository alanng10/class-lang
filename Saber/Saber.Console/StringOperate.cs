namespace Saber.Console;

public class StringOperate : Any
{
    public virtual StringTravel Travel { get; set; }

    public virtual bool ExecuteString(String value)
    {
        return false;
    }

    public virtual bool ExecuteClassStart(long index)
    {
        return false;
    }

    public virtual bool ExecuteClassEnd(long index)
    {
        return false;
    }
}