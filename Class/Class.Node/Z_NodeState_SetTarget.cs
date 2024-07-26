namespace Class.Node;

public class SetTargetNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteSetTarget(range);
        return true;
    }
}