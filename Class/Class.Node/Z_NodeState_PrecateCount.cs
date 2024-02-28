namespace Class.Node;

public class PrecateCountNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecutePrecateCount(this.Arg);
        return true;
    }
}