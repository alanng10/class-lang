namespace Class.Refer;

public class WriteOperate : Any
{
    public virtual Write Write { get; set; }

    public virtual bool Execute(int value)
    {
        return true;
    }
}