namespace Saber.Binary;

public class Binary : Any
{
    public virtual ModuleRef Ref { get; set; }
    public virtual Array Class { get; set; }
    public virtual Array Import { get; set; }
    public virtual Array Export { get; set; }
    public virtual Array Base { get; set; }
    public virtual Array Part { get; set; }
    public virtual long Entry { get; set; }
}