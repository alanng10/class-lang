namespace Class.Infra;



public class Maide : Any
{
    public virtual string Name { get; set; }

    public virtual Class Class { get; set; }

    public virtual SystemClass SystemClass { get; set; }

    public virtual Count Count { get; set; }

    public virtual Table Param { get; set; }

    public virtual Table Call { get; set; }

    public virtual Class Parent { get; set; }

    public virtual object Any { get; set; }

    public virtual int Index { get; set; }
}