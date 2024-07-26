namespace Class.Node;

public class ProbateCountNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteProbateCount(range);
        return true;
    }
}