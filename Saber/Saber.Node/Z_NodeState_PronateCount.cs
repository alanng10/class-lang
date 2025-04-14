namespace Saber.Node;

public class PronateCountNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecutePronateCount(range);
        return true;
    }
}