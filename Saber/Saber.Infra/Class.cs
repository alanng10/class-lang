namespace Saber.Infra;

public class Class : Any
{
    public virtual String Name { get; set; }

    public virtual Class Base { get; set; }

    public virtual Table Field { get; set; }

    public virtual Table Maide { get; set; }

    public virtual Module Module { get; set; }

    public virtual long BaseIndex { get; set; }

    public virtual InfraRange FieldRange { get; set; }

    public virtual InfraRange MaideRange { get; set; }

    public virtual long Index { get; set; }

    public virtual object Any { get; set; }
}