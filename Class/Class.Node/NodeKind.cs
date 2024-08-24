namespace Class.Node;

public class NodeKind : Any
{
    public virtual long Index { get; set; }
    public virtual String Name { get; set; }
    public virtual Node Node { get; set; }
    public virtual InfraState NewState { get; set; }
    public virtual NodeState NodeState { get; set; }
    public virtual CreateSetState CreateSetState { get; set; }
}