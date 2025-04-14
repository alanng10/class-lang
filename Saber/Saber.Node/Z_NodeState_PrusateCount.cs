namespace Saber.Node;

public class PrusateCountNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecutePrusateCount(range);
        return true;
    }
}