namespace Class.Token;

public class CreateOperate : Any
{
    public virtual bool ExecuteToken()
    {
        return true;
    }

    public virtual bool ExecuteComment()
    {
        return true;
    }

    public virtual bool ExecuteCodeStart(int index)
    {
        return true;
    }

    public virtual bool ExecuteCodeEnd(int index)
    {
        return true;
    }
}