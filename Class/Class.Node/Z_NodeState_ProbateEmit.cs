namespace Class.Node;

public class ProbateEmitNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteProbateEmit(this.Arg);
        return true;
    }
}