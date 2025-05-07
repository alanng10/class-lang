namespace Saber.Infra;

public class Error : Any
{
    public virtual Stage Stage { get; set; }
    public virtual ErrorKind Kind { get; set; }
    public virtual Range Range { get; set; }
    public virtual String Name { get; set; }
    public virtual long Source { get; set; }
}