namespace Class.Node;

public class NodeState : InfraState
{
    public virtual Create Create { get; set; }
    public new virtual Node Result { get; set; }
    public new virtual Range Arg { get; set; }
}