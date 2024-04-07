namespace Avalon.Infra;

public class ModuleInfo : Any
{
    public virtual string RefString([CallerFilePath] string filePath = null)
    {
        return "";
    }
}