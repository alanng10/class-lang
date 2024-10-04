namespace Class.Node;

public class CreateOperate : Any
{
    public virtual Create Create { get; set; }

    public virtual Node Execute()
    {
        return null;
    }

    public virtual long ExecuteListNew()
    {
        return 0;
    }

    public virtual Array ExecuteListGet(long index)
    {
        return null;
    }

    public virtual bool ExecuteListSetItem(long index, long itemIndex, object item)
    {
        return false;
    }

    public virtual bool ExecuteListCount(long index, long count)
    {
        return false;
    }
    
    public virtual bool ExecuteError(ErrorKind kind, long start, long end)
    {
        return false;
    }

    public virtual String ExecuteNameValue(Text text)
    {
        return null;
    }

    public virtual String ExecuteStringValue(Text text)
    {
        return null;
    }
}