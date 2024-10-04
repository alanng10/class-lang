namespace Class.Infra;

public class Field : Any
{
    public virtual String Name { get; set; }
    public virtual Class Class { get; set; }
    public virtual Count Count { get; set; }
    public virtual Field Virtual { get; set; }
    public virtual Table Get { get; set; }
    public virtual Table Set { get; set; }
    public virtual Class Parent { get; set; }
    public virtual long Index { get; set; }
    public virtual long BinaryIndex { get; set; }
    public virtual object Any { get; set; }
}