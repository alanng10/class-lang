namespace Class.Node;

public class SetTargetNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteSetTarget(this.Arg);
        return true;
    }
}