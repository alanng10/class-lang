namespace Class.Node;

public class PrudateCountNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecutePrudateCount(this.Arg);
        return true;
    }
}