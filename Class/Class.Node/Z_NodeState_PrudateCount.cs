namespace Class.Node;

public class PrudateCountNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecutePrudateCount(range);
        return true;
    }
}