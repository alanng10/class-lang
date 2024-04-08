namespace Class.Refer;

public class ReadOperate : Any
{
    public virtual Field ExecuteField()
    {
        return null;
    }

    public virtual Maide ExecuteMaide()
    {
        return null;
    }

    public virtual Var ExecuteVar()
    {
        return null;
    }

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
}