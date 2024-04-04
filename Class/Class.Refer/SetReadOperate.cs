namespace Class.Refer;

public class SetReadOperate : Any
{
    public virtual string ExecuteString()
    {
        return null;
    }

    public virtual Array ExecuteArray()
    {
        return null;
    }

    public virtual bool ExecuteArrayItemSet(Array array, int index, object value)
    {
        return true;
    }

    public virtual Field ExecuteField()
    {
        return null;
    }
}