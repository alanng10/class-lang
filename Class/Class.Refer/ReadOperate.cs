namespace Class.Refer;

public class ReadOperate : Any
{
    public virtual string ExecuteString(int count)
    {
        return null;
    }

    public virtual Array ExecuteArray(int count)
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