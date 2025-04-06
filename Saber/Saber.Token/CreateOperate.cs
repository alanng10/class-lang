namespace Saber.Token;

public class CreateOperate : Any
{
    public virtual Create Create { get; set; }

    public virtual bool ExecuteToken(long row, Range range)
    {
        return false;
    }

    public virtual bool ExecuteComment(long row, Range range)
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