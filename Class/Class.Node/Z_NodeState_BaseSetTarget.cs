namespace Class.Node;

public class BaseSetTargetNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBaseSetTarget(this.Arg);
        return true;
    }
}