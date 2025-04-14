namespace Saber.Node;

public class PrecateCountNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecutePrecateCount(range);
        return true;
    }
}