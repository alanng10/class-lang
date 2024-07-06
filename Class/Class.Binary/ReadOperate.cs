namespace Class.Binary;

public class ReadOperate : Any
{
    public virtual Binary ExecuteBinary()
    {
        return null;
    }

    public virtual Class ExecuteClass()
    {
        return null;
    }

    public virtual Import ExecuteImport()
    {
        return null;
    }

    public virtual Part ExecutePart()
    {
        return null;
    }

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

    public virtual Value ExecuteClassIndex()
    {
        return null;
    }

    public virtual ModuleRef ExecuteModuleRef()
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