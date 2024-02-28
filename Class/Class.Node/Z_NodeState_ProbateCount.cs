namespace Class.Node;

public class ProbateCountNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteProbateCount(this.Arg);
        return true;
    }
}