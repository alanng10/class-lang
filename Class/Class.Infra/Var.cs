namespace Class.Infra;

public class Var : Any
{
    public virtual string Name { get; set; }

    public virtual Class Class { get; set; }

    public virtual SystemInfo SystemClass { get; set; }

    public virtual object Any { get; set; }
}