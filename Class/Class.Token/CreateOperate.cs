namespace Class.Token;

public class CreateOperate : Any
{
    public virtual bool ExecuteToken()
    {
        return false;
    }

    public virtual bool ExecuteInfo()
    {
        return false;
    }

    public virtual bool ExecuteCodeStart(long index)
    {
        return false;
    }

    public virtual bool ExecuteCodeEnd(long index)
    {
        return false;
    }
}