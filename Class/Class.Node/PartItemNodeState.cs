namespace Class.Node;

public class PartItemNodeState : NodeState
{
    public override bool Execute()
    {
        Node a;
        a = this.Create.ExecuteComp(this.Arg);
        this.Result = a;
        return true;
    }
}