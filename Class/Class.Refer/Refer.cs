namespace Class.Refer;

public class Refer : Any
{
    public virtual ModuleRef Ref { get; set; }

    public virtual Array Class { get; set; }

    public virtual Array Import { get; set; }

    public virtual Array Base { get; set; }

    public virtual Array Part { get; set; }
}