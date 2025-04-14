namespace Saber.Node;

public class StringValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteStringValue(range);
        return true;
    }
}