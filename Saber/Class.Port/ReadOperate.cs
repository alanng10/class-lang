namespace Class.Port;

public class ReadOperate : Any
{
    public virtual String ExecuteString(long row, Range range)
    {
        return null;
    }

    public virtual Array ExecuteArray(long count)
    {
        return null;
    }

    public virtual bool ExecuteArrayItemSet(Array array, long index, object value)
    {
        return false;
    }

    public virtual Port ExecutePort()
    {
        return null;
    }

    public virtual ModuleRef ExecuteModuleRef()
    {
        return null;
    }

    public virtual Import ExecuteImport()
    {
        return null;
    }

    public virtual ImportClass ExecuteImportClass()
    {
        return null;
    }

    public virtual Export ExecuteExport()
    {
        return null;
    }

    public virtual Storage ExecuteStorage()
    {
        return null;
    }
}