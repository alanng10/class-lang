namespace Class.Node;

public class PrudateAccessNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecutePrudateAccess(this.Arg);
        return true;
    }
}