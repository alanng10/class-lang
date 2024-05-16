namespace Class.Port;

public class ReadOperate : Any
{
    public virtual string ExecuteString(int row, Range range)
    {
        return null;
    }

    public virtual Array ExecuteArray(int count)
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