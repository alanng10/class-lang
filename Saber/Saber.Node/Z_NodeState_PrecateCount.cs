namespace Class.Node;

public class PrecateCountNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecutePrecateCount(range);
        return true;
    }
}