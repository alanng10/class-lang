namespace Saber.Node;

public class MarkNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteMark(range);
        return true;
    }
}