namespace Class.Node;

public class ProbateAccessNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteProbateAccess(this.Arg);
        return true;
    }
}