namespace Class.Node;







public class NodeKind : Any
{
    public virtual int Index { get; set; }




    public virtual string Name { get; set; }




    public virtual Node Node { get; set; }




    public virtual InfraState NewState { get; set; }




    public virtual NodeState NodeState { get; set; }




    public virtual CreateOperateState CreateOperateState { get; set; }
}