namespace Avalon.Infra;

public class ModuleInfo : Any
{
    public virtual string RefString()
    {
        return null;
    }

    public virtual string _RefString([CallerFilePath] string filePath = null)
    {
        return "";
    }
}