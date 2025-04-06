namespace Saber.Infra;

public class StringWriteOperate : Any
{
    public virtual StringWrite Write { get; set; }

    public virtual bool ExecuteChar(long n)
    {
        return false;
    }
}