namespace Class.Node;

public class PrivateCountNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecutePrivateCount(this.Arg);
        return true;
    }
}