namespace Saber.Infra;

public class Var : Any
{
    public virtual String Name { get; set; }
    public virtual Class Class { get; set; }
    public virtual long Index { get ;set; }
    public virtual object Any { get; set; }
}