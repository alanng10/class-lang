namespace Class.Node;

public class TargetNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteTarget(range);
        return true;
    }
}