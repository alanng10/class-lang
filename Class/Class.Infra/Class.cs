namespace Class.Infra;

public class Class : Any
{
    public virtual string Name { get; set; }

    public virtual Class Base { get; set; }

    public virtual Table Field { get; set; }

    public virtual Table Maide { get; set; }

    public virtual Module Module { get; set; }

    public virtual int Index { get; set; }

    public virtual object Any { get; set; }
}