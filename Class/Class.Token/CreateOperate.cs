namespace Class.Token;

public class CreateOperate : Any
{
    public virtual bool ExecuteToken()
    {
        return false;
    }

    public virtual bool ExecuteComment()
    {
        return false;
    }

    public virtual bool ExecuteCodeStart(int index)
    {
        return false;
    }

    public virtual bool ExecuteCodeEnd(int index)
    {
        return false;
    }
}