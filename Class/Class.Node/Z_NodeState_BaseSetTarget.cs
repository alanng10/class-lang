namespace Class.Node;

public class BaseSetTargetNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBaseSetTarget(range);
        return true;
    }
}