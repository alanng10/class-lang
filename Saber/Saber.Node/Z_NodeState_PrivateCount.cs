namespace Saber.Node;

public class PrivateCountNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecutePrivateCount(range);
        return true;
    }
}