namespace Class.Node;

public class VarTargetNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteVarTarget(range);
        return true;
    }
}