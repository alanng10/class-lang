namespace Avalon.Infra;

public class Value : Any
{
    public virtual bool Bool { get; set; }

    public virtual int Mid { get; set; }

    public virtual long Int { get; set; }

    public virtual object Any { get; set; }
}