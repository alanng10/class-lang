namespace Z.Infra.Class;

public class ModuleInfo : Any
{
    public virtual string Name(string o)
    {
        return o;
    }

    public virtual ulong Version(ulong o)
    {
        return o;
    }
}