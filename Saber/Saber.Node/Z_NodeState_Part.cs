namespace Saber.Node;

public class PartNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecutePart(range);
        return true;
    }
}